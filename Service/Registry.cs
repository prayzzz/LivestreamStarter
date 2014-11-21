using GalaSoft.MvvmLight.Ioc;

using Services.Interfaces;

namespace Services
{
    public static class Registry
    {
        public static void Register()
        {
            SimpleIoc.Default.Register<ILogger>(() => new Common.Logger());

            SimpleIoc.Default.Register<IXmlFileService>(() => new Services.XmlFileService());
            SimpleIoc.Default.Register<IStreamStarter>(() => new Services.StreamStarter());
            SimpleIoc.Default.Register<IStreamUpdateTimer>(() => new Common.StreamUpdateTimer());
            SimpleIoc.Default.Register<ILivestreamProcessManager>(() => new Common.LivestreamProcessManager());
            SimpleIoc.Default.Register<IRepository>(() => new Common.Repository());
        }

        public static void RegisterDesignTime()
        {
            SimpleIoc.Default.Register<ILogger>(() => new Common.Logger());

            SimpleIoc.Default.Register<IXmlFileService>(() => new DesignTime.XmlFileService());
            SimpleIoc.Default.Register<IStreamStarter>(() => new DesignTime.StreamStarter());
            SimpleIoc.Default.Register<ILivestreamProcessManager>(() => new DesignTime.LivestreamProcessManager());
            SimpleIoc.Default.Register<IRepository>(() => new Common.Repository());
        }
    }
}