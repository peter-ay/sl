using System;

namespace ERP.Common
{
    public class ComPassword
    {
        public static string Get(string pw)
        {
            string Srmm = pw;

            String MmjmStr = "";

            for (int i = 0; i <= Srmm.Length - 1; i++)
            {
                MmjmStr = MmjmStr + (Convert.ToInt16(Srmm.ToCharArray()[i]) + Convert.ToInt16(Srmm.ToCharArray()[Srmm.Length - i - 1]) + Srmm.Length + (i + 1)).ToString();
            }
            return MmjmStr;
        }
    }
}
