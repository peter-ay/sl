
using System;
namespace ERP.Utility
{
    public class UReportID
    {
        static Random ran = new Random();

        public static string ID
        {
            get
            {
                return USysInfo.UserCode + UDataTime.ShortDateTime +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum;
            }
        }

        public static string ExcelFileName
        {
            get
            {
                return USysInfo.UserCode + UDataTime.ShortDateTime +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum +
                    RandomNum + ".xls";
            }
        }

        private static string RandomNum
        {
            get
            {
                return ran.Next(0, 9).ToString();
            }
        }
    }
}
