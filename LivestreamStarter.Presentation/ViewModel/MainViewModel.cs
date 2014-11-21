using GalaSoft.MvvmLight;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool isLogTabVisible;

        private bool isLogSelected;

        private bool isFavoriteStreamListSelected;

        private bool isOverviewListSelected;

        private bool isOverlayVisible;

        private bool isOverlayCancelVisible;

        private bool isSettingsViewVisible;

        private bool isAboutViewVisible;

        private bool isAddStreamViewVisible;

        private bool isLoadingViewVisible;

        private bool isErrorViewVisible;

        private int streamOverviewCount;

        private int favoriteStreamCount;

        public bool IsLogTabVisible
        {
            get
            {
                return this.isLogTabVisible;
            }

            set
            {
                this.isLogTabVisible = value;
                this.RaisePropertyChanged();

                if (!value)
                {
                    this.IsOverviewListSelected = true;
                }
            }
        }

        public bool IsLogSelected
        {
            get
            {
                return this.isLogSelected;
            }

            set
            {
                this.isLogSelected = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsFavoriteStreamListSelected
        {
            get
            {
                return this.isFavoriteStreamListSelected;
            }

            set
            {
                this.isFavoriteStreamListSelected = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsOverviewListSelected
        {
            get
            {
                return this.isOverviewListSelected;
            }

            set
            {
                this.isOverviewListSelected = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsOverlayVisible
        {
            get
            {
                return this.isOverlayVisible;
            }

            set
            {
                this.isOverlayVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsOverlayCancelVisible
        {
            get
            {
                return this.isOverlayCancelVisible;
            }

            set
            {
                this.isOverlayCancelVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsSettingsViewVisible
        {
            get
            {
                return this.isSettingsViewVisible;
            }

            set
            {
                this.isSettingsViewVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsAboutViewVisible
        {
            get
            {
                return this.isAboutViewVisible;
            }

            set
            {
                this.isAboutViewVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsAddStreamViewVisible
        {
            get
            {
                return this.isAddStreamViewVisible;
            }

            set
            {
                this.isAddStreamViewVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsLoadingViewVisible
        {
            get
            {
                return this.isLoadingViewVisible;
            }

            set
            {
                this.isLoadingViewVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsErrorViewVisible
        {
            get
            {
                return this.isErrorViewVisible;
            }

            set
            {
                this.isErrorViewVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public int StreamOverviewCount
        {
            get
            {
                return this.streamOverviewCount;
            }

            set
            {
                this.streamOverviewCount = value;
                this.RaisePropertyChanged();
            }
        }

        public int FavoriteStreamCount
        {
            get
            {
                return this.favoriteStreamCount;
            }

            set
            {
                this.favoriteStreamCount = value;
                this.RaisePropertyChanged();
            }
        }
    }
}