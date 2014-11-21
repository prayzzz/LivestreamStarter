using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class ActionBarView
    {
        public ActionBarView()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private ActionBarViewController ViewModel
        {
            get
            {
                return (ActionBarViewController)this.DataContext;
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
