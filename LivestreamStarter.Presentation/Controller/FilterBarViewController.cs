using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class FilterBarViewController : ViewControllerBase<FilterBarViewModel, IFilterBarViewService>
    {
        public FilterBarViewController()
        {
            this.FilterChangedCommand = new RelayCommand<FilterBarDto>(this.HandleFilterChanged);

            if (IsInDesignModeStatic)
            {
                this.Model.GameFilter.Add(new FilterBarDto { Name = "Test1" });
                this.Model.GameFilter.Add(new FilterBarDto { Name = "Test2" });
                this.Model.GameFilter.Add(new FilterBarDto { Name = "Test3" });
            }
        }

        public RelayCommand<FilterBarDto> FilterChangedCommand { get; set; }

        public override void InitializeModel()
        {
            foreach (var dto in this.Service.Get())
            {
                this.Model.GameFilter.Add(dto);
            }
        }

        private void HandleFilterChanged(FilterBarDto dto)
        {
            this.Service.DtoToModel(dto);
            Messenger.Default.Send(new FilterChangedMessage(dto.Id, dto.IsAllowed));
        }
    }
}