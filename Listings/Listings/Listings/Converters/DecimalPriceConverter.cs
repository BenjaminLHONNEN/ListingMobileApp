using System;
using System.Globalization;
using Xamarin.Forms;

namespace Listings.Converters
{
    public class DecimalPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal reworkedValue = (decimal) value;
            if (reworkedValue != null)
            {
                return $"{reworkedValue.ToString()} €";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
