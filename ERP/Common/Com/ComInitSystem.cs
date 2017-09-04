using System.Globalization;
using System.Threading;

namespace ERP.Common
{
    public class ComInitSystem
    {
        public static void Init()
        {
            var culture = ComLanguageResourceManage.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ///////////////////////////////////////////////////////////// 
            FormatDatePattern();
        }

        public static void FormatDatePattern()
        {
            //日期格式化  
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentUICulture = (CultureInfo)Thread.CurrentThread.CurrentUICulture.Clone();
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
        }
    }
}
