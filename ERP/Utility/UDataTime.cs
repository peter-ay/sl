
using System;
namespace ERP.Utility
{
    public class UDataTime
    {
        private static readonly string Y = DateTime.Now.Year.ToString();
        private static readonly string M = ("0" + DateTime.Now.Month.ToString());
        private static readonly string D = DateTime.Now.Day.ToString();

        public static readonly DateTime NullErp = Convert.ToDateTime("1900-1-1");
        public static readonly string ShortDateTime = Y + M.Substring(M.Length - 2) + D;
    }
}
