using Common;

using DailyMotionConnector.Plugins;
using DailyMotionConnector.ServiceInterfaces;
using DailyMotionConnector.Services;

using GalaSoft.MvvmLight.Ioc;

using Services.Listener;

namespace DailyMotionConnector
{
    public class DailyMotionConnector : IConnector
    {
        public void Register()
        {
            SimpleIoc.Default.Register<ISettingsLoadListener>(() => new SettingsPlugin(), "DailyMotion");
            SimpleIoc.Default.Register<IStreamUpdateListener>(() => new StreamUpdatePlugin(), "DailyMotion");

            SimpleIoc.Default.Register<IPathService, PathService>();
            SimpleIoc.Default.Register<IDailymotionService, DailymotionService>();
        }
    }
}