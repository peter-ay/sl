using System;
using System.Windows.Data;

namespace ERP.Converters
{
    public class ToShortDataString : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return "";
                else
                {
                    return System.Convert.ToDateTime(value).ToShortDateString();
                }

            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
