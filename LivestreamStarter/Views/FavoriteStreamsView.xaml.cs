using System.Windows;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    public partial class FavoriteStreamsView
    {
        public FavoriteStreamsView()
        {
            InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private FavoriteStreamsViewController ViewModel
        {
            get
            {
                return (FavoriteStreamsViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.Initialize();
            this.ViewModel.InitializeModel();
        }
    }
}
