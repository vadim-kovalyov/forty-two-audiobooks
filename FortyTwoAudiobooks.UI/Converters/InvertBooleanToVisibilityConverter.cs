using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FortyTwoAudiobooks.UI.Converters
{
    public sealed class InvertBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool && (bool)value) ? Visibility.Collapsed : Visibility.Visible;

        }

        public object ConvertBack(Object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility && (Visibility)value == Visibility.Collapsed;
        }
    }
}