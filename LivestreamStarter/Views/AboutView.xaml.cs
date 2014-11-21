using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class AboutView
    {
        public AboutView()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private AboutViewController ViewModel
        {
            get
            {
                return (AboutViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.Initialize();
            this.ViewModel.InitializeModel();
        }
    }
}
