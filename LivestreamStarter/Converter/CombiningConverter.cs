﻿using System;
using System.Windows.Data;

namespace LivestreamStarter.Converter
{
    public class CombiningConverter : IValueConverter
    {
        public IValueConverter Converter1 { get; set; }

        public IValueConverter Converter2 { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var convertedValue = Converter1.Convert(value, targetType, parameter, culture);
            return Converter2.Convert(convertedValue, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}