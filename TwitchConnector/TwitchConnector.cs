using Common;

using GalaSoft.MvvmLight.Ioc;

using Services.Listener;

using TwitchConnector.Plugins;
using TwitchConnector.ServiceInterfaces;
using TwitchConnector.Services;

namespace TwitchConnector
{
    public class TwitchConnector : IConnector
    {
        public void Register()
        {
            SimpleIoc.Default.Register<ISettingsLoadListener>(() => new SettingsPlugin(), "Twitch");
            SimpleIoc.Default.Register<IStreamUpdateListener>(() => new StreamUpdatePlugin(), "Twitch");
            SimpleIoc.Default.Register<IStreamLoadListener>(() => new StreamLoadPlugin(), "Twitch");

            SimpleIoc.Default.Register<IPathService, PathService>();
            SimpleIoc.Default.Register<ITwitchService, TwitchService>();
        }
    }
}