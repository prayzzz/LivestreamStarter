using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

using LivestreamStarter.Presentation.Controller;

using Microsoft.Practices.ServiceLocation;

using Settings.Manager;

namespace LivestreamStarter.Presentation
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                Logic.Registry.RegisterDesignTime();
                Services.Registry.RegisterDesignTime();

                SettingsManager.LoadDesignTime();
                Registry.Register();

                return;
            }

            Logic.Registry.Register();
            Services.Registry.Register();


            SettingsManager.Load();
            Registry.Register();

            StartUp();
        }

        public static MainViewController Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewController>();
            }
        }

        public static LogViewController Log
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogViewController>();
            }
        }

        public static SettingsViewController Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewController>();
            }
        }

        public static AboutViewController About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewController>();
            }
        }

        public static FavoriteStreamsViewController FavoriteStreams
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FavoriteStreamsViewController>();
            }
        }

        public static StreamsOverviewViewController StreamsOverview
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StreamsOverviewViewController>();
            }
        }

        public static AddStreamViewController AddStream
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddStreamViewController>();
            }
        }

        public static ActionBarViewController ActionBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActionBarViewController>();
            }
        }

        public static FilterBarViewController FilterBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FilterBarViewController>();
            }
        }

        public static ErrorViewController Error
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ErrorViewController>();
            }
        }

        public static void Cleanup()
        {
            SimpleIoc.Default.GetInstance<Services.Interfaces.IStreamUpdateTimer>().Stop();
        }

        private static void StartUp()
        {
            SimpleIoc.Default.GetInstance<Services.Interfaces.IStreamUpdateTimer>().Start(true);
        }
    }
}