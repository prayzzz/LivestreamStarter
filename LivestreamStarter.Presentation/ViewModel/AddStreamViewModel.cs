using System.Collections.Generic;

using GalaSoft.MvvmLight;

using Logic.Dto;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class AddStreamViewModel : ViewModelBase
    {
        private IDictionary<int, string> channels;

        private IDictionary<int, string> games;

        private AddStreamDto stream;

        public AddStreamDto Stream
        {
            get
            {
                return this.stream;
            }

            set
            {
                this.stream = value;
                this.RaisePropertyChanged();
            }
        }

        public IDictionary<int, string> Channels
        {
            get
            {
                return this.channels;
            }
            set
            {
                this.channels = value;
                this.RaisePropertyChanged();
            }
        }

        public IDictionary<int, string> Games
        {
            get
            {
                return this.games;
            }
            set
            {
                this.games = value;
                this.RaisePropertyChanged();
            }
        }
    }
}