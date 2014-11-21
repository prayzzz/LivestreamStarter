using System.Collections.Generic;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class ErrorViewModel : ViewModelBase
    {
        public ErrorViewModel()
        {
            this.Messages = new ObservableCollection<string>();
        }

        public IList<string> Messages { get; set; }
    }
}