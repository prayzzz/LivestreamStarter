using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using Logic.Dto;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class StreamsOverviewViewModel : ViewModelBase
    {
        public StreamsOverviewViewModel()
        {
            this.Streams = new ObservableCollection<StreamDto>();
        }

        public ObservableCollection<StreamDto> Streams { get; set; }
    }
}