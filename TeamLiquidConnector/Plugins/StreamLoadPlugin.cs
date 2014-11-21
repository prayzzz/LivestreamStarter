using System.Linq;
using System.Net;

using BaseEntities;
using BaseEntities.Enum;

using Microsoft.Practices.ServiceLocation;

using Services;
using Services.Common;
using Services.Extensions;
using Services.Interfaces;
using Services.Listener;

using TeamLiquidConnector.Entities;
using TeamLiquidConnector.ServiceInterfaces;

namespace TeamLiquidConnector.Plugins
{
    public class StreamLoadPlugin : IStreamLoadListener
    {
        private static ITeamLiquidService TeamLiquidService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ITeamLiquidService>();
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

        public void Load()
        {
            TeamLiquidStreamList teamLiquidStreamList;

            try
            {
                teamLiquidStreamList = TeamLiquidService.GetStreamList();
            }
            catch (WebException ex)
            {
                Logger.Log(ex);
                return;
            }

            XmlToEntity(teamLiquidStreamList);
        }

        public bool CheckStreamName(ChannelModel channel, string name)
        {
            return true;
        }

        private static void XmlToEntity(StreamModel model, XmlStream entity)
        {
            var channel = Repository.GetChannelOrDefault(entity.Channel.Channel);
            var game = Repository.GetGameOrDefault(entity.Game);

            model.Name = entity.Channel.Name;
            model.DisplayName = entity.Channel.Title;

            model.Channel = channel;

            model.Game = game;

            model.Status = entity.Status;
            model.Viewers = entity.Viewers;
            model.StreamLink = string.IsNullOrEmpty(channel.WeblinkPattern) ? string.Empty : string.Format(channel.WeblinkPattern, model.Name);
            model.Status = StatusEnum.Online;
        }

        private static void XmlToEntity(TeamLiquidStreamList streamList)
        {
            var streams = Repository.GetList<StreamModel>();

            foreach (var xml in streamList.Streams)
            {
                var entity = streams.FirstOrDefault(x => x.Name == xml.Channel.Name) ?? new StreamModel();

                XmlToEntity(entity, xml);

                Repository.Add(entity);
            }
        }
    }
}