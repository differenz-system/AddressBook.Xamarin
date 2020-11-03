using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DifferenzXamarinDemo.Converters
{
    /// <summary>
    /// ListVisibilityConverter - returns true(items found)/false(no items) based on list item count
    /// </summary>
    public class ListVisibilityConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            return ((IList)value).Count != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
