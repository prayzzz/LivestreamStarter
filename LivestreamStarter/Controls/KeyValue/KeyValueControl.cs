﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LivestreamStarter.Controls.KeyValue
{
    public class KeyValueControl : Control
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            "Key",
            typeof(string),
            typeof(KeyValueControl),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(object),
            typeof(KeyValueControl),
            new FrameworkPropertyMetadata
            {
                DefaultValue = null,
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            });

        static KeyValueControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KeyValueControl), new FrameworkPropertyMetadata(typeof(KeyValueControl)));
        }

        public string Key
        {
            get
            {
                return (string)GetValue(KeyProperty);
            }

            set
            {
                this.SetValue(KeyProperty, value);
            }
        }

        public object Value
        {
            get
            {
                return this.GetValue(ValueProperty);
            }

            set
            {
                this.SetValue(ValueProperty, value);
            }
        }
    }
}