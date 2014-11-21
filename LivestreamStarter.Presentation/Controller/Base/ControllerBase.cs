using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using Logic.Properties;

namespace LivestreamStarter.Presentation.Controller.Base
{
    public class ControllerBase : INotifyPropertyChanged
    {
        private static bool? isInDesignMode;

        public event PropertyChangedEventHandler PropertyChanged;

        protected static bool IsInDesignModeStatic
        {
            get
            {
                if (!isInDesignMode.HasValue)
                {
                    isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue;
                }

                return isInDesignMode.Value;
            }
        }

        protected void OnModelPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            this.OnPropertyChanged(propertyChangedEventArgs.PropertyName);
        }

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}