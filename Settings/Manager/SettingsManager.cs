using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using BaseEntities;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;
using Services.Listener;

using Settings.Entities;
using Settings.XmlEntities;

namespace Settings.Manager
{
    public static class SettingsManager
    {
        private const string StreamsXml = "./config/streams.xml";

        private const string SettingsXml = "./config/settings.xml";

        private static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        private static IXmlFileService XmlFileService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IXmlFileService>();
            }
        }

        public static void Load()
        {
            var settings = LoadSettings() ?? new SettingsModel();

            Repository.Add(settings);

            LoadGames(settings);
            LoadChannels(settings);
            LoadFilter(settings);

            LoadFavoriteStreams();
        }

        public static void LoadDesignTime()
        {
            Repository.Add(new SettingsModel());
        }

        public static void Save()
        {
            SaveFavoriteStreams();
            SaveSettings();
        }

        private static SettingsModel LoadSettings()
        {
            return XmlFileService.Load<SettingsModel>(SettingsXml);
        }

        private static void LoadGames(SettingsModel settingsModel)
        {
            DefaultValues defaultValues;

            using (var sw = new StringReader(Resources.Resources.DefaultValues))
            {
                var xmls = new XmlSerializer(typeof(DefaultValues));
                defaultValues = xmls.Deserialize(sw) as DefaultValues;
            }

            if (defaultValues != null)
            {
                foreach (var game in defaultValues.Games)
                {
                    Repository.Add(game);
                }
            }

            foreach (var game in settingsModel.Games)
            {
                Repository.Add(game);
            }

            foreach (var instance in ServiceLocator.Current.GetAllInstances<ISettingsLoadListener>())
            {
                instance.GamesLoaded();
            }
        }

        private static void LoadChannels(SettingsModel settingsModel)
        {
            DefaultValues defaultValues;

            using (var sw = new StringReader(Resources.Resources.DefaultValues))
            {
                var xmls = new XmlSerializer(typeof(DefaultValues));
                defaultValues = xmls.Deserialize(sw) as DefaultValues;
            }

            if (defaultValues != null)
            {
                foreach (var channel in defaultValues.Channels)
                {
                    Repository.Add(channel);
                }
            }

            foreach (var channel in settingsModel.Channels)
            {
                Repository.Add(channel);
            }

            foreach (var instance in ServiceLocator.Current.GetAllInstances<ISettingsLoadListener>())
            {
                instance.ChannelsLoaded();
            }
        }

        private static void LoadFilter(SettingsModel settings)
        {
            foreach (var filter in settings.GameFilter)
            {
                filter.Game = Repository.GetById<GameModel>(filter.Game.Id);
            }

            foreach (var game in Repository.GetQueryable<GameModel>().Where(game => settings.GameFilter.All(x => x.Game != game)))
            {
                settings.GameFilter.Add(new GameFilterModel(game, true));
            }

            settings.GameFilter.RemoveAll(x => settings.Games.Any(y => y != x.Game));
        }

        private static void LoadFavoriteStreams()
        {
            var xmlStreams = XmlFileService.Load<List<XmlStream>>(StreamsXml);

            if (xmlStreams == null)
            {
                return;
            }

            foreach (var xmlStream in xmlStreams)
            {
                Repository.Add(XmlToModel(xmlStream));
            }
        }

        private static void SaveFavoriteStreams()
        {
            var xmlStreams = Repository.GetQueryable<StreamModel>().Select(ModelToXml).ToList();

            XmlFileService.Save(StreamsXml, xmlStreams);
        }

        private static void SaveSettings()
        {
            var settings = Repository.GetList<SettingsModel>().FirstOrDefault();

            if (settings == null)
            {
                return;
            }

            settings.Channels = Repository.GetQueryable<ChannelModel>().Where(x => x.IsCustomChannel).ToList();
            settings.Games = Repository.GetQueryable<GameModel>().Where(x => x.IsCustomGame).ToList();

            XmlFileService.Save(SettingsXml, settings);
        }

        private static StreamModel XmlToModel(XmlStream xmlStream)
        {
            var model = new StreamModel();
            model.Channel = Repository.GetQueryable<ChannelModel>().FirstOrDefault(x => x.Name == xmlStream.Channel) ?? Repository.GetQueryable<ChannelModel>().FirstOrDefault(x => x.IsDefault);
            model.Game = Repository.GetQueryable<GameModel>().FirstOrDefault(x => x.Name == xmlStream.Game) ?? Repository.GetQueryable<GameModel>().FirstOrDefault(x => x.IsDefault);
            model.DisplayName = xmlStream.DisplayName;
            model.Name = xmlStream.Name;
            model.StreamLink = xmlStream.StreamLink;
            model.IsFavorite = xmlStream.IsFavorite;

            return model;
        }

        private static XmlStream ModelToXml(StreamModel model)
        {
            var xmlStream = new XmlStream();
            xmlStream.Channel = model.Channel.Name;
            xmlStream.Game = model.Game != null ? model.Game.Name : string.Empty;
            xmlStream.DisplayName = model.DisplayName;
            xmlStream.Name = model.Name;
            xmlStream.StreamLink = model.StreamLink;
            xmlStream.IsFavorite = model.IsFavorite;

            return xmlStream;
        }
    }
}