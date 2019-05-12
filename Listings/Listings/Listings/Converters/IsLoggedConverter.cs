using System;
using System.Globalization;
using Listings.Auth;
using Xamarin.Forms;

namespace Listings.Converters
{
    public class IsLoggedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? userId = value as int?;
            if (userId.HasValue)
            {
                return userId.Value == AuthService.Instance.UserId;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
