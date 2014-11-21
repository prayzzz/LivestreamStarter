using GalaSoft.MvvmLight;

using Logic.Dto;

namespace LivestreamStarter.Presentation.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private SettingsDto settings;

        public SettingsDto Settings
        {
            get
            {
                return this.settings;
            }

            set
            {
                this.settings = value;
                this.RaisePropertyChanged();
            }
        }
    }
}