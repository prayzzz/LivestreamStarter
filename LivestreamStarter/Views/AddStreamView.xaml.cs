using System.Windows;
using System.Windows.Controls;

using LivestreamStarter.Presentation.Controller;

namespace LivestreamStarter.Views
{
    /// <summary>
    /// Interaktionslogik für AddStreamView.xaml
    /// </summary>
    public partial class AddStreamView : UserControl
    {
        public AddStreamView()
        {
            InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private AddStreamViewController ViewModel
        {
            get
            {
                return (AddStreamViewController)this.DataContext;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.ViewModel.Initialize();
            this.ViewModel.InitializeModel();
        }
    }
}
