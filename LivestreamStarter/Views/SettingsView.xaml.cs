using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class SettingsView
    {
        public SettingsView()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private SettingsViewController Controller
        {
            get
            {
                return (SettingsViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Controller.Initialize();
            this.Controller.InitializeModel();
        }
    }
}
