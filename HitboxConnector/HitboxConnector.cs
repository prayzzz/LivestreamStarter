using Common;

using GalaSoft.MvvmLight.Ioc;

using HitboxConnector.Plugins;

using Services.Listener;

namespace HitboxConnector
{
    public class HitboxConnector : IConnector
    {
        public void Register()
        {
            SimpleIoc.Default.Register<ISettingsLoadListener>(() => new SettingsPlugin(), "Hitbox");
            SimpleIoc.Default.Register<IStreamUpdateListener>(() => new StreamUpdatePlugin(), "Hitbox");
            SimpleIoc.Default.Register<IStreamLoadListener>(() => new StreamLoadPlugin(), "Hitbox");

            ////SimpleIoc.Default.Register<IPathService, PathService>();
            ////SimpleIoc.Default.Register<ITwitchService, TwitchService>();
        }
    }
}
