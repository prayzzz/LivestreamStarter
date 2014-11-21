using System.Windows.Media;

using BaseEntities;

namespace Logic.Dto
{
    public class StreamDto : BaseDto
    {
        private string displayName;

        private int viewers;

        private int channel;

        private int game;

        private ImageSource gameImage;

        private ImageSource channelImage;

        private string channelStatus;

        private bool isFavorite;

        private bool isAllowedAsFavorite;

        private ImageSource previewImage;

        private string status;

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                this.displayName = value;
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

        public string ChannelStatus
        {
            get
            {
                return this.channelStatus;
            }

            set
            {
                this.channelStatus = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get
            {
                return this.isFavorite;
            }

            set
            {
                this.isFavorite = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged("IsAddToFavoritesVisible");
            }
        }

        public bool IsAllowedAsFavorite
        {
            get
            {
                return this.isAllowedAsFavorite;
            }

            set
            {
                this.isAllowedAsFavorite = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged("IsAddToFavoritesVisible");
            }
        }

        public bool IsAddToFavoritesVisible
        {
            get
            {
                return this.isAllowedAsFavorite && !this.isFavorite;
            }
        }

        public ImageSource PreviewImage
        {
            get
            {
                return this.previewImage;
            }

            set
            {
                this.previewImage = value;
                this.RaisePropertyChanged();
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
                this.RaisePropertyChanged();
            }
        }
    }
}