using GalaSoft.MvvmLight;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class LogViewModel : ViewModelBase
    {
        private string message;

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.RaisePropertyChanged();
            }
        }
    }
}