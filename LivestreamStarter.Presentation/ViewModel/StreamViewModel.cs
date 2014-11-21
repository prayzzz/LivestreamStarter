using System.Windows.Media;

using GalaSoft.MvvmLight;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class StreamViewModel : ViewModelBase
    {
        private string name;

        private int viewers;

        private int channel;

        private int game;

        private ImageSource gameImage;

        private ImageSource channelImage;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged();
            }
        }

        public int Viewers
        {
            get
            {
                return this.viewers;
            }

            set
            {
                this.viewers = value;
                this.RaisePropertyChanged();
            }
        }

        public int Channel
        {
            get
            {
                return this.channel;
            }

            set
            {
                this.channel = value;
                this.RaisePropertyChanged();
            }
        }

        public ImageSource ChannelImage
        {
            get
            {
                return this.channelImage;
            }

            set
            {
                this.channelImage = value;
                this.RaisePropertyChanged();
            }
        }

        public int Game
        {
            get
            {
                return this.game;
            }

            set
            {
                this.game = value;
                this.RaisePropertyChanged();
            }
        }

        public ImageSource GameImage
        {
            get
            {
                return this.gameImage;
            }

            set
            {
                this.gameImage = value;
                this.RaisePropertyChanged();
            }
        }
    }
}