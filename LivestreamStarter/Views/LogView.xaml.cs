using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class LogView
    {
        public LogView()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private LogViewController ViewModel
        {
            get
            {
                return (LogViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.InitializeModel();
        }
    }
}
