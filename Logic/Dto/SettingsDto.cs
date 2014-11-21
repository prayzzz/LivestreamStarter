namespace Logic.Dto
{
    public class SettingsDto : BaseDto
    {
        private string liveStreamerPath;

        private string vlcPath;

        private bool isLogVisible;

        public string LiveStreamerPath
        {
            get
            {
                return this.liveStreamerPath;
            }

            set
            {
                this.liveStreamerPath = value;
                this.RaisePropertyChanged();
            }
        }

        public string VlcPath
        {
            get
            {
                return this.vlcPath;
            }

            set
            {
                this.vlcPath = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsLogVisible
        {
            get
            {
                return this.isLogVisible;
            }

            set
            {
                this.isLogVisible = value;
                this.RaisePropertyChanged();
            }
        }
    }
}