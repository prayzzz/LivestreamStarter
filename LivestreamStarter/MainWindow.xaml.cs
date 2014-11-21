using System.ComponentModel;
using System.Windows;

using LivestreamStarter.Presentation;
using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.Closing += (s, e) => ViewModelLocator.Cleanup();
            this.Loaded += this.OnLoaded;
            this.Closing += this.OnClosing;
        }

        private MainViewController Controller
        {
            get
            {
                return (MainViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Controller.Initialize();
            this.Controller.InitializeModel();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            this.Controller.Close();
        }
    }
}
