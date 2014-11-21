using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class StreamsOverviewView
    {
        public StreamsOverviewView()
        {
            InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private StreamsOverviewViewController ViewModel
        {
            get
            {
                return (StreamsOverviewViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.Initialize();
            this.ViewModel.InitializeModel();
        }
    }
}
