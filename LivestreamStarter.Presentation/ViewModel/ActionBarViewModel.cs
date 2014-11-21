using GalaSoft.MvvmLight;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class ActionBarViewModel : ViewModelBase
    {
        private bool isPlaying;

        private string streamName;

        public bool IsPlaying
        {
            get
            {
                return this.isPlaying;
            }

            set
            {
                this.isPlaying = value;
                this.RaisePropertyChanged();
            }
        }

        public string StreamName
        {
            get
            {
                return this.streamName;
            }

            set
            {
                this.streamName = value;
                this.RaisePropertyChanged();
            }
        }
    }
}