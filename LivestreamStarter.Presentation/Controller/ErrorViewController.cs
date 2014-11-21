using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class ErrorViewController : ViewControllerBase<ErrorViewModel, IErrorViewService>
    {
        public ErrorViewController()
        {
            Messenger.Default.Register<ErrorMessage>(this, x => this.HandleErrorMessage(x.Message));
            Messenger.Default.Register<ViewActionMessage>(this, this.HandelViewAction);

            this.CloseCommand = new RelayCommand(() => Messenger.Default.Send(new ViewActionMessage(this.GetType(), ViewActionEnum.Close)));

            if (IsInDesignModeStatic)
            {
                this.Model.Messages.Add("Fehler #1");
                this.Model.Messages.Add("Fehler #2");
                this.Model.Messages.Add("Fehler #3");
            }
        }

        public RelayCommand CloseCommand { get; set; }

        private void HandelViewAction(ViewActionMessage message)
        {
            if (message.ViewType != this.GetType())
            {
                return;
            }

            if (message.Action == ViewActionEnum.Close)
            {
                this.Model.Messages.Clear();
            }
        }

        private void HandleErrorMessage(string message)
        {
            this.Model.Messages.Add(message);
        }
    }
}