using System.Linq;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class AddStreamViewController : ViewControllerBase<AddStreamViewModel, IAddStreamViewService>
    {
        public AddStreamViewController()
        {
            this.CancelCommand = new RelayCommand(this.Cancel);
            this.SaveCommand = new AsyncRelayCommand(this.Save, this.CanSave);

            Messenger.Default.Register<ViewActionMessage>(this, this.HandleViewActionMessage);
        }

        public AsyncRelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public override void Initialize()
        {
        }

        public override void InitializeModel()
        {
            this.Model.Channels = Service.GetChannels();
            this.Model.Games = Service.GetGames();

            this.Model.Stream = new AddStreamDto();
            this.Model.Stream.Channel = this.Model.Channels.First().Key;
            this.Model.Stream.Game = this.Model.Games.First().Key;
            this.Model.Stream.IsFavorite = true;
        }

        private void Cancel()
        {
            this.Close();
        }

        private void Close()
        {
            Messenger.Default.Send(new ViewActionMessage(this.GetType(), ViewActionEnum.Close));
        }

        private void HandleViewActionMessage(ViewActionMessage message)
        {
            if (message.ViewType != this.GetType())
            {
                return;
            }

            if (message.Action == ViewActionEnum.Open)
            {
                this.InitializeModel();
            }
        }

        private void Save()
        {
            Service.Save(this.Model.Stream);
            this.Close();

            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.Added, this.Model.Stream.Id));
        }

        private bool CanSave()
        {
            if (this.Model.Stream == null)
            {
                return false;
            }

            return Service.Validate(this.Model.Stream);
        }
    }
}