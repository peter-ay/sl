using System;
using System.Windows.Data;

namespace ERP.Converters
{
    public class FormatDateTimeString : IValueConverter
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
                    var r1 = System.Convert.ToDateTime(value).ToShortDateString();
                    var r2 = System.Convert.ToDateTime(value).ToLongTimeString().ToString();
                    return r1 + " " + r2;
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
