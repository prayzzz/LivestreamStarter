using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LivestreamStarter.Controls
{
    public class TabItemControl : Control
    {
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
            "IsChecked",
            typeof(bool),
            typeof(TabItemControl),
            new FrameworkPropertyMetadata
            {
                DefaultValue = false,
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register(
            "GroupName",
            typeof(string),
            typeof(TabItemControl),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            "Image",
            typeof(ImageSource),
            typeof(TabItemControl),
            new PropertyMetadata(default(ImageSource)));

        public static readonly DependencyProperty TooltipProperty = DependencyProperty.Register(
            "Tooltip",
            typeof(string),
            typeof(TabItemControl),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(TabItemControl),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            "Count",
            typeof(int),
            typeof(TabItemControl),
            new PropertyMetadata(default(int)));

        public static readonly DependencyProperty IsCountVisibleProperty = DependencyProperty.Register(
            "IsCountVisible",
            typeof(bool),
            typeof(TabItemControl),
            new PropertyMetadata(false));

        static TabItemControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemControl), new FrameworkPropertyMetadata(typeof(TabItemControl)));
        }

        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }

            set
            {
                this.SetValue(IsCheckedProperty, value);
            }
        }

        public ImageSource Image
        {
            get
            {
                return (ImageSource)GetValue(ImageProperty);
            }

            set
            {
                this.SetValue(ImageProperty, value);
            }
        }

        public string GroupName
        {
            get
            {
                return (string)GetValue(GroupNameProperty);
            }

            set
            {
                this.SetValue(ImageProperty, value);
            }
        }

        public string Tooltip
        {
            get
            {
                return (string)GetValue(TooltipProperty);
            }

            set
            {
                this.SetValue(TooltipProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        public bool Count
        {
            get
            {
                return (bool)this.GetValue(CountProperty);
            }

            set
            {
                this.SetValue(CountProperty, value);
            }
        }

        public bool IsCountVisible
        {
            get
            {
                return (bool)this.GetValue(IsCountVisibleProperty);
            }

            set
            {
                this.SetValue(IsCountVisibleProperty, value);
            }
        }
    }
}