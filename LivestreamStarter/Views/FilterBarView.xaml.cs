using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class FilterBarView
    {
        public FilterBarView()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private FilterBarViewController ViewModel
        {
            get
            {
                return (FilterBarViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.Initialize();
            this.ViewModel.InitializeModel();
            this.Loaded -= this.OnLoaded;
        }
    }
}
