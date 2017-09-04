
using ERP.Web.Entity;
namespace ERP.Utility
{
    public class USysTemp
    {
        static string _BillCodeMain;
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static string BillCodeMain
        {
            get { return USysTemp._BillCodeMain; }
            set { USysTemp._BillCodeMain = value; }
        }

        static string _CusCode;
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static string CusCode
        {
            get { return USysTemp._CusCode; }
            set { USysTemp._CusCode = value; }
        }

        static string _KeyCode;
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static string KeyCode
        {
            get { return USysTemp._KeyCode; }
            set { USysTemp._KeyCode = value; }
        }

        static string _KeyName;
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static string KeyName
        {
            get { return USysTemp._KeyName; }
            set { USysTemp._KeyName = value; }
        }

        static int _LensCodeInModule = 0;//0:All 1:Sale 2:Pur
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static int LensCodeInModule
        {
            get { return USysTemp._LensCodeInModule; }
            set { USysTemp._LensCodeInModule = value; }
        }

        //
        static V_Sale_Order_SD _V_Sale_Order_SD;
        /// <summary>
        /// ////////////////////////////////////
        /// </summary>
        public static V_Sale_Order_SD V_Sale_Order_SD
        {
            get { return USysTemp._V_Sale_Order_SD; }
            set { USysTemp._V_Sale_Order_SD = value; }
        }
    }
}
