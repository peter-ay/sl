
using System;
namespace ERP.Utility
{
    public class UID
    {
        static Random ran = new Random();

        public static string ID
        {
            get
            {
                return UDataTime.ShortDateTime +
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


        private static string RandomNum
        {
            get
            {
                return ran.Next(0, 9).ToString();
            }
        }
    }
}
