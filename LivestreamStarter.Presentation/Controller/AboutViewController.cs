using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class AboutViewController : ViewControllerBase<AboutViewModel, IAboutViewService>
    {
        public AboutViewController()
        {
            this.CloseCommand = new RelayCommand(this.Close);
        }

        public RelayCommand CloseCommand { get; set; }

        public override void Initialize()
        {
        }

        public override void InitializeModel()
        {
        }

        private void Close()
        {
            Messenger.Default.Send(new ViewActionMessage(this.GetType(), ViewActionEnum.Close));
        }
    }
}