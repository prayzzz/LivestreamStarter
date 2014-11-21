using GalaSoft.MvvmLight.Ioc;

using Logic.NewServiceInterfaces;
using Logic.ViewServiceInterfaces;

namespace Logic
{
    public static class Registry
    {
        public static void Register()
        {
            SimpleIoc.Default.Register<ILogViewService>(() => new ViewServices.LogViewService());
            SimpleIoc.Default.Register<IMainViewService>(() => new ViewServices.MainViewService());
            SimpleIoc.Default.Register<IAboutViewService>(() => new ViewServices.AboutViewService());
            SimpleIoc.Default.Register<ISettingsViewService>(() => new ViewServices.SettingsViewService());
            SimpleIoc.Default.Register<IAddStreamViewService>(() => new ViewServices.AddStreamViewService());
            SimpleIoc.Default.Register<IFavoriteStreamsViewService>(() => new ViewServices.FavoriteStreamsViewService());
            SimpleIoc.Default.Register<IStreamsOverviewViewService>(() => new ViewServices.StreamsOverviewViewService());
            SimpleIoc.Default.Register<IActionBarService>(() => new ViewServices.ActionBarService());
            SimpleIoc.Default.Register<IFilterBarViewService>(() => new ViewServices.FilterBarViewService());
            SimpleIoc.Default.Register<IErrorViewService>(() => new ViewServices.ErrorViewService());

            SimpleIoc.Default.Register<IStreamService>(() => new NewServices.StreamService());
        }

        public static void RegisterDesignTime()
        {
            SimpleIoc.Default.Register<ILogViewService>(() => new DesignTime.LogViewService());
            SimpleIoc.Default.Register<IMainViewService>(() => new DesignTime.MainViewService());
            SimpleIoc.Default.Register<IAboutViewService>(() => new DesignTime.AboutViewService());
            SimpleIoc.Default.Register<ISettingsViewService>(() => new DesignTime.SettingsViewService());
            SimpleIoc.Default.Register<IAddStreamViewService>(() => new DesignTime.AddStreamViewService());
            SimpleIoc.Default.Register<IFavoriteStreamsViewService>(() => new DesignTime.FavoriteStreamsViewService());
            SimpleIoc.Default.Register<IStreamsOverviewViewService>(() => new DesignTime.StreamsOverviewViewService());
            SimpleIoc.Default.Register<IActionBarService>(() => new DesignTime.ActionBarService());
            SimpleIoc.Default.Register<IFilterBarViewService>(() => new DesignTime.FilterBarViewService());
            SimpleIoc.Default.Register<IErrorViewService>(() => new DesignTime.ErrorViewService());

            SimpleIoc.Default.Register<IStreamService>(() => new DesignTime.StreamService());
        }
    }
}