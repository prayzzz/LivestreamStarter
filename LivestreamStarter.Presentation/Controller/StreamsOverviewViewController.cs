using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Common.Args;
using Common.Common;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using LivestreamStarter.Presentation.Common;
using LivestreamStarter.Presentation.Controller.Base;
using LivestreamStarter.Presentation.ViewMessages;
using LivestreamStarter.Presentation.ViewModel;

using Logic.Dto;
using Logic.ViewServiceInterfaces;

using Microsoft.Practices.ServiceLocation;

using Services.Interfaces;

namespace LivestreamStarter.Presentation.Controller
{
    public class StreamsOverviewViewController : ViewControllerBase<StreamsOverviewViewModel, IStreamsOverviewViewService>
    {
        public StreamsOverviewViewController()
        {
            this.OpenInBrowserCommand = new RelayCommand<StreamDto>(this.OpenInBrowser);
            this.AddToFavoritesCommand = new RelayCommand<StreamDto>(AddToFavorites);
            this.RemoveFromFavoritesCommand = new RelayCommand<StreamDto>(RemoveFromFavorites);
            this.PlayStreamCommand = new RelayCommand<StreamDto>(this.PlayStream);

            if (IsInDesignModeStatic)
            {
                this.Model.Streams.Add(new StreamDto { DisplayName = "LognStreamName asdasdffg#1", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#2", Viewers = 20000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#3", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#4", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#5", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#6", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#7", Viewers = 200000 });
                this.Model.Streams.Add(new StreamDto { DisplayName = "Stream#8", Viewers = 200000 });
            }
        }

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public RelayCommand<StreamDto> OpenInBrowserCommand { get; set; }

        public RelayCommand<StreamDto> AddToFavoritesCommand { get; set; }

        public RelayCommand<StreamDto> RemoveFromFavoritesCommand { get; set; }

        public RelayCommand<StreamDto> PlayStreamCommand { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper restore MemberCanBePrivate.Global

        public override void Initialize()
        {
            ServiceLocator.Current.GetInstance<IStreamUpdateTimer>().StreamListLoaded += this.OnStreamListLoaded;
            ServiceLocator.Current.GetInstance<IStreamUpdateTimer>().StreamListUpdated += this.OnStreamListUpdated;

            Messenger.Default.Register<FilterChangedMessage>(this, this.HandleFilterChanged);
        }

        public override void InitializeModel()
        {
        }

        private static void RemoveFromFavorites(StreamDto streamDto)
        {
            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.RemoveFromFavorites, streamDto.Id));
        }

        private static void AddToFavorites(StreamDto streamDto)
        {
            Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.AddToFavorites, streamDto.Id));
        }

        private void OnStreamListLoaded(object sender, StreamListLoadedArgs streamListLoadedArgs)
        {
            Application.Current.Dispatcher.Invoke(this.GetFilteredStreams);
        }

        private void OnStreamListUpdated(object sender, StreamListUpdatedArgs streamListLoadedArgs)
        {
            Application.Current.Dispatcher.Invoke(this.GetFilteredStreams);
        }

        private void GetFilteredStreams()
        {
            var viewerComparer = new ViewerComparer();
            this.Model.Streams.Clear();
            foreach (var dto in this.Service.GetStreams())
            {
                this.Model.Streams.AddSorted(dto, viewerComparer);
            }
        }

        private void HandleFilterChanged(FilterChangedMessage message)
        {
            if (!message.IsAllowed)
            {
                this.Model.Streams.RemoveAll(x => x.Game == message.GameId);
                return;
            }

            var viewerComparer = new ViewerComparer();
            foreach (var dto in this.Service.GetStreams(message.GameId))
            {
                this.Model.Streams.AddSorted(dto, viewerComparer);
            }
        }

        private void OpenInBrowser(StreamDto streamDto)
        {
            Service.OpenInBrowser(streamDto.Id);
        }

        private void PlayStream(StreamDto dto)
        {
            this.ExecuteActionWithOverlay(() => this.StartStream(dto));
        }

        private async void StartStream(StreamDto dto)
        {
            var result = await Task.Run(() => this.Service.PlayStream(dto.Id, Messages));

            this.ProcessErrorMessages();

            if (result)
            {
                Messenger.Default.Send(new StreamActionMessage(StreamActionEnum.Start, dto.Id));
            }
        }
    }
}