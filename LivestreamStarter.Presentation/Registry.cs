using GalaSoft.MvvmLight.Ioc;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Presentation
{
    public static class Registry
    {
        public static void Register()
        {
            SimpleIoc.Default.Register<MainViewController>();
            SimpleIoc.Default.Register<SettingsViewController>();
            SimpleIoc.Default.Register<LogViewController>();
            SimpleIoc.Default.Register<AboutViewController>();
            SimpleIoc.Default.Register<AddStreamViewController>();
            SimpleIoc.Default.Register<StreamsOverviewViewController>();
            SimpleIoc.Default.Register<FavoriteStreamsViewController>();
            SimpleIoc.Default.Register<ActionBarViewController>();
            SimpleIoc.Default.Register<FilterBarViewController>();
            SimpleIoc.Default.Register<ErrorViewController>();
        }
    }
}