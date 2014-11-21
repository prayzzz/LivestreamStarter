using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using BaseEntities;
using BaseEntities.Enum;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using Services;
using Services.Common;
using Services.Extensions;
using Services.Interfaces;
using Services.Listener;

using TwitchConnector.Entities;
using TwitchConnector.ServiceInterfaces;

using IRepository = Services.Interfaces.IRepository;

namespace TwitchConnector.Plugins
{
    public class StreamUpdatePlugin : IStreamUpdateListener
    {
        private static ITwitchService TwitchService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ITwitchService>();
            }
        }

        private static IRepository Repository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IRepository>();
            }
        }

        private static ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }

        public void Update(StreamModel model)
        {
            if (model == null || model.Channel != PluginInformations.Channel)
            {
                return;
            }

            TwitchStream stream;

            try
            {
                stream = TwitchService.GetStreamInformations(model.Name);
            }
            catch (WebException ex)
            {
                Logger.Log(ex);
                return;
            }

            if (stream == null)
            {
                model.Status = StatusEnum.Offline;
                return;
            }

            EntityToModel(model, stream);
        }

        public void UpdateAll()
        {
            var modelsToUpdate = ServiceLocator.Current.GetInstance<IRepository>().GetQueryable<StreamModel>().Where(x => x.Channel == PluginInformations.Channel);
            var twitchStreams = GetPartialList(modelsToUpdate, 100).Select(GetStreamInformations).ToList();

            foreach (var modelToUpdate in modelsToUpdate)
            {
                modelToUpdate.Status = StatusEnum.Offline;
                modelToUpdate.Viewers = 0;
            }

            foreach (var twitchStream in twitchStreams.Where(x => x != null && x.streams != null).SelectMany(x => x.streams))
            {
                var model = modelsToUpdate.FirstOrDefault(x => x.Name == twitchStream.channel.name);
                if (model != null && twitchStream.channel != null)
                {
                    EntityToModel(model, twitchStream);
                }
            }
        }

        private static IEnumerable<IEnumerable<T>> GetPartialList<T>(IEnumerable<T> list, int count)
        {
            for (var i = 0; i < list.Count(); i = i + count)
            {
                yield return list.Skip(i).Take(count);
            }
        }

        private static void EntityToModel(StreamModel model, TwitchStream entity)
        {
            var channel = PluginInformations.Channel;
            var game = Repository.GetGameOrDefault(entity.game);

            model.Name = entity.channel.name.Trim();

            model.Channel = channel;
            model.ChannelStatus = string.IsNullOrEmpty(entity.channel.status) ? string.Empty : entity.channel.status;

            model.Game = game;

            model.Viewers = entity.viewers;
            model.Status = StatusEnum.Online;
            model.StreamLink = string.Format(channel.WeblinkPattern, model.Name);
            model.PreviewImagePath = entity.preview.medium;
        }

        private static TwitchStreams GetStreamInformations(IEnumerable<StreamModel> streamModels)
        {
            try
            {
                return TwitchService.GetStreamInformations(streamModels.Select(x => x.Name));
            }
            catch (Exception e)
            {
                Logger.Log(e);
                return null;
            }
        }
    }
}