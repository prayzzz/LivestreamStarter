using System.Collections.Generic;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using Logic.Dto;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class FilterBarViewModel : ViewModelBase
    {
        public FilterBarViewModel()
        {
            this.GameFilter = new ObservableCollection<FilterBarDto>();
        }

        public IList<FilterBarDto> GameFilter { get; private set; }
    }
}