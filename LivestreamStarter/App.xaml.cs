using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

using Common;

using GalaSoft.MvvmLight.Threading;

using LivestreamStarter.Presentation;

using Settings.Manager;

namespace LivestreamStarter
{
    public partial class App
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoadConnectors();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            ViewModelLocator.Cleanup();
            SettingsManager.Save();
        }

        private static void LoadConnectors()
        {
            var connectorLibPaths = Directory.GetFiles(".").Where(x => x.EndsWith("Connector.dll"));

            foreach (var name in connectorLibPaths.Select(Path.GetFileNameWithoutExtension))
            {
                var assembly = Assembly.Load(name);
                var instance = assembly.CreateInstance(string.Format("{0}.{0}", name)) as IConnector;

                if (instance != null)
                {
                    instance.Register();
                }
            }
        }
    }
}
