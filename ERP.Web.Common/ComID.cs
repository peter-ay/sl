
using System;
namespace ERP.Web.Common
{
    public sealed class ComID
    {
        private static readonly ComID _instance = new ComID();
        private static Random rd = new Random();

        private ComID()
        {
        }

        public static ComID GetInstance()
        {
            return _instance;
        }

        public string ID25
        {
            get
            {
                string strYear = DateTime.Now.Year.ToString();
                string strMonth = "0" + DateTime.Now.Month.ToString();
                string strDay = "0" + DateTime.Now.Day.ToString();
                string strHour = "0" + DateTime.Now.Hour.ToString();
                string strMinute = "0" + DateTime.Now.Minute.ToString();
                string strSecond = "0" + DateTime.Now.Second.ToString();
                string strMSecond = "00" + DateTime.Now.Millisecond.ToString();
                string strR1 = rd.Next(0, 9).ToString();
                string strR2 = rd.Next(0, 9).ToString();
                string strR3 = rd.Next(0, 9).ToString();
                string strR4 = rd.Next(0, 9).ToString();
                string strR5 = rd.Next(0, 9).ToString();
                string strR6 = rd.Next(0, 9).ToString();
                string strR7 = rd.Next(0, 9).ToString();
                string strR8 = rd.Next(0, 9).ToString();
                string strR9 = rd.Next(0, 9).ToString();
                string strR10 = rd.Next(0, 9).ToString();

                return strYear.GetRightStr(2) +
                strMonth.GetRightStr(2) +
                strDay.GetRightStr(2) +
                strHour.GetRightStr(2) +
                strMinute.GetRightStr(2) +
                strSecond.GetRightStr(2) +
                strMSecond.GetRightStr(3) + strR1 + strR2 + strR3 + strR4 + strR5 + strR6 + strR7 + strR8 + strR9 + strR10;
            }
        }
    }
}
