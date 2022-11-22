using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApp
{
    public sealed class MyBooleanToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; }
        public Visibility Action { get; set; } = Visibility.Hidden;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ^ Invert ? Visibility.Visible : Action;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}