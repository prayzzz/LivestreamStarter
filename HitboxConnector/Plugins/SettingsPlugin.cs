﻿using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;
using Services.Listener;

namespace HitboxConnector.Plugins
{
    public class SettingsPlugin : ISettingsLoadListener
    {
        public void ChannelsLoaded()
        {
            ServiceLocator.Current.GetInstance<IRepository>().Add(PluginInformations.Channel);
        }

        public void GamesLoaded()
        {
        }
    }
}