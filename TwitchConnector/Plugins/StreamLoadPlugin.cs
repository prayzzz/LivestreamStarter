using System;

using BaseEntities;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;
using Services.Listener;

using TwitchConnector.ServiceInterfaces;

namespace TwitchConnector.Plugins
{
    public class StreamLoadPlugin : IStreamLoadListener
    {
        private static ITwitchService Service
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ITwitchService>();
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
        }

        public bool CheckStreamName(ChannelModel channel, string name)
        {
            if (channel != PluginInformations.Channel)
            {
                return true;
            }

            try
            {
                return Service.IsStreamNameCorrect(name);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                return false;
            }
        }
    }
}