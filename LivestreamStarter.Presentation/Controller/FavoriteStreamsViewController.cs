using System;
using System.Threading.Tasks;
using System.Windows;

using Common.Args;
using Common.Common;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class FavoriteStreamsViewController : ViewControllerBase<FavoriteStreamsViewModel, IFavoriteStreamsViewService>
    {
        public FavoriteStreamsViewController()
        {
            this.OpenInBrowserCommand = new RelayCommand<StreamDto>(this.OpenInBrowser);
            this.AddToFavoritesCommand = new RelayCommand<StreamDto>(AddToFavorites);
            this.RemoveFromFavoritesCommand = new RelayCommand<StreamDto>(RemoveFromFavorites);
            this.PlayStreamCommand = new RelayCommand<StreamDto>(this.PlayStream);

            if (IsInDesignModeStatic)
            {
                this.Model.Streams.Add(new StreamDto { DisplayName = "LognStreamName asdasdffg#1", Viewers = 200000, Status = "offline" });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#5", Viewers = 200000, Status = "offline" });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#6", Viewers = 200000, Status = "online" });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#7", Viewers = 200000, Status = "online" });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#8", Viewers = 200000, Status = "offline" });
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        //// ReSharper disable UnusedAutoPropertyAccessor.Global
        public RelayCommand<StreamDto> OpenInBrowserCommand { get; set; }

        public RelayCommand<StreamDto> AddToFavoritesCommand { get; set; }

        public RelayCommand<StreamDto> RemoveFromFavoritesCommand { get; set; }

        public RelayCommand<StreamDto> PlayStreamCommand { get; set; }

        //// ReSharper restore MemberCanBePrivate.Global
        //// ReSharper restore UnusedAutoPropertyAccessor.Global

        public override void Initialize()
        {
            Messenger.Default.Register<StreamActionMessage>(this, this.HandleStreamActionMessage);

            ServiceLocator.Current.GetInstance<IStreamUpdateTimer>().StreamListLoaded += this.OnStreamListLoaded;
            ServiceLocator.Current.GetInstance<IStreamUpdateTimer>().StreamListUpdated += this.OnStreamListUpdated;
        }

        public override void InitializeModel()
        {
            foreach (var stream in Service.GetFavoriteStreams())
            {
                this.Model.Streams.Add(stream);
            }
        }

        private static void AddToFavorites(StreamDto dto)
        {
            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.AddToFavorites, dto.Id));
        }

        private static void RemoveFromFavorites(StreamDto dto)
        {
            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.RemoveFromFavorites, dto.Id));
        }

        private void HandleStreamActionMessage(StreamActionMessage message)
        {
            switch (message.Action)
            {
                case StreamActionEnum.AddToFavorites:
                    if (message.Id != null)
                    {
                        this.AddStreamToFavorites(message.Id.Value);
                    }

                    break;
                case StreamActionEnum.RemoveFromFavorites:
                    if (message.Id != null)
                    {
                        this.RemoveStreamFromFavorites(message.Id.Value);
                    }

                    break;
                case StreamActionEnum.Added:
                    if (message.Id != null)
                    {
                        this.StreamAdded(message.Id.Value);
                    }

                    break;
            }
        }

        private void StreamAdded(int id)
        {
            this.Model.Streams.Add(Service.GetStream(id));
        }

        private void RemoveStreamFromFavorites(int id)
        {
            this.Service.UnfavStream(id);
            this.Model.Streams.RemoveAll(x => x.Id == id);
        }

        private void AddStreamToFavorites(int id)
        {
            this.Service.FavStream(id);
            this.Model.Streams.Add(Service.GetStream(id));
        }

        private void OnStreamListLoaded(object sender, StreamListLoadedArgs args)
        {
            Application.Current.Dispatcher.Invoke(() => this.Service.GetStreamDtos(this.Model.Streams));
        }

        private void OnStreamListUpdated(object sender, StreamListUpdatedArgs args)
        {
            Application.Current.Dispatcher.Invoke(() => this.Service.GetStreamDtos(this.Model.Streams));
        }

        private void OpenInBrowser(StreamDto dto)
        {
            Service.OpenInBrowser(dto.Id);
        }

        private async void PlayStream(StreamDto dto)
        {
            var result = await Task.Run(() => Service.PlayStream(dto.Id, Messages));

            this.ProcessErrorMessages();

            if (result)
            {
                Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.Start, dto.Id));
            }
        }
    }
}