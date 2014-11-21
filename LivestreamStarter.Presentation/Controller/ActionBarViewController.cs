using Common.Args;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class ActionBarViewController : ViewControllerBase<ActionBarViewModel, IActionBarService>
    {
        public ActionBarViewController()
        {
            this.OpenAddStreamViewCommand = new RelayCommand(() => Messenger.Default.Send(new ViewActionMessage(typeof(AddStreamViewController), ViewActionEnum.Open)));

            Messenger.Default.Register<StreamActionMessage>(this, this.HandleStreamActionMessage);
        }

        public RelayCommand OpenAddStreamViewCommand { get; set; }

        public override void Initialize()
        {
            ServiceLocator.Current.GetInstance<ILivestreamProcessManager>().ProcessExited += OnProcessExited;
        }

        public override void InitializeModel()
        {
            this.Model.IsPlaying = false;
        }

        private static void OnProcessExited(object sender, ProcessExitedArgs args)
        {
            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.Stop, null));
        }

        private void HandleStreamActionMessage(StreamActionMessage message)
        {
            switch (message.Action)
            {
                case StreamActionEnum.Start:
                    if (message.Id != null)
                    {
                        this.StreamStarted(message.Id.Value);
                    }

                    break;
                case StreamActionEnum.Stop:
                    this.StreamStopped();
                    break;
            }
        }

        private void StreamStopped()
        {
            this.Model.IsPlaying = false;
        }

        private void StreamStarted(int id)
        {
            this.Model.StreamName = Service.GetStreamName(id);
            this.Model.IsPlaying = true;
        }
    }
}