
namespace System
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using ERP.Web.Common;

    public static class ExString
    {
        public static string GetMyStr(this string str)
        {
            return str == null ? "" : str.Trim().ToUpper();
        }

        public static string[] GetSptstr(this string str)
        {
            string[] stringSeparators = new string[] { ComSptstr.Str1 };
            return str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetSptstrValue(this string[] str, string kCode)
        {
            string[] stringSeparators = new string[] { ComSptstr.Str2 };
            var rs = str.Where(it => it.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)[0].GetMyStr() == kCode.GetMyStr()).FirstOrDefault();
            try
            {
                return rs.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            catch
            {
                return "";
            }
        }

        public static string GetCorrectXlsName(this string str)
        {
            str = str.Replace("/", "-");
            str = str.Replace(@"\", "-");
            str = str.Replace(@"?", "-");
            str = str.Replace(@"*", "-");
            str = str.Replace(@"[", "-");
            str = str.Replace(@"]", "-");
            return str == null ? "" : str.Trim().ToUpper();
        }

        public static string GetRightStr(this string str, int length)
        {
            string _Rs = str;
            try
            {
                _Rs = str.Substring(str.Length - length, length);
            }
            catch { }
            return _Rs;
        }

        public static string GetMyShortDateStr(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        public static bool GetBoolStr(this string str)
        {
            return Convert.ToBoolean((str.ToString().Trim() == "1" || str.ToString().Trim().ToLower() == "true") ? true : false);
        }

        public static int GetIntStr(this string str)
        {
            return Convert.ToInt32(str.ToString().Trim() == "" ? "0" : str);
        }
    }
}
