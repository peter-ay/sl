
using ERP.Common;
namespace System
{
    public static class ExMStringMethods
    {
        public static string MyStr(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            return str.Trim().ToUpper();
        }

        public static string UIStr(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            string rstr = "";
            string[] stringSeparators = new string[] { "//" };
            var rs = str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                switch (ComLanguageResourceManage.CurrentCulture.Name)
                {
                    case "en-US":
                        rstr = rs[2];
                        break;
                    case "zh-Hans":
                        rstr = rs[0];
                        break;
                    case "zh-Hant":
                        rstr = rs[1];
                        break;
                }
            }
            catch { rstr = rs[0]; }
            return rstr.Trim();
        }
    }
}
