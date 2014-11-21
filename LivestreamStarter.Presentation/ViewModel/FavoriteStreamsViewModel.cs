using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using GalaSoft.MvvmLight;

using Logic.Dto;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class FavoriteStreamsViewModel : ViewModelBase
    {
        public FavoriteStreamsViewModel()
        {
            this.Streams = new ObservableCollection<StreamDto>();
        }

        public IList<StreamDto> Streams { get; private set; }
    }
}