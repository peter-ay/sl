
namespace ERP.Utility
{
    public class USysInfo
    {
        static int _LoginMode = 1;
        public static int LoginMode
        {
            get { return USysInfo._LoginMode; }
            set { USysInfo._LoginMode = value; }
        }

        static string _UserCode = "";
        public static string UserCode
        {
            get { return USysInfo._UserCode; }
            set { USysInfo._UserCode = value; }
        }

        static string _UserName = "";
        public static string UserName
        {
            get { return USysInfo._UserName; }
            set { USysInfo._UserName = value; }
        }

        static string _DBCode = "";
        public static string DBCode
        {
            get { return USysInfo._DBCode; }
            set { USysInfo._DBCode = value; }
        }

        static string _DBName = "";
        public static string DBName
        {
            get { return USysInfo._DBName; }
            set { USysInfo._DBName = value; }
        }

        static string _ServerIP = "";
        public static string ServerIP
        {
            get { return USysInfo._ServerIP; }
            set { USysInfo._ServerIP = value; }
        }

        static bool _F_Manager = false;
        public static bool F_Manager
        {
            get { return USysInfo._F_Manager; }
            set { USysInfo._F_Manager = value; }
        }

        static string _IP = "";
        public static string IP
        {
            get { return USysInfo._IP; }
            set { USysInfo._IP = value; }
        }

        static string _ClientID = "";
        public static string ClientID
        {
            get { return USysInfo._ClientID; }
            set { USysInfo._ClientID = value; }
        }

        static string _ErrMsg = "";
        public static string ErrMsg
        {
            get { return USysInfo._ErrMsg; }
            set { USysInfo._ErrMsg = value; }
        }

        static string _DBPrefix = "";
        public static string DBPrefix
        {
            get { return USysInfo._DBPrefix; }
            set { USysInfo._DBPrefix = value; }
        }

        static int _LgIndex = 0;
        public static int LgIndex
        {
            get { return USysInfo._LgIndex; }
            set { USysInfo._LgIndex = value; }
        }

        private static string _GroupCode = "";
        public static string GroupCode
        {
            get { return USysInfo._GroupCode; }
            set { USysInfo._GroupCode = value; }
        }

        private static string _GroupName = "";
        public static string GroupName
        {
            get { return USysInfo._GroupName; }
            set { USysInfo._GroupName = value; }
        }

        private static int _GpID = -1;
        public static int GpID
        {
            get { return USysInfo._GpID; }
            set { USysInfo._GpID = value; }
        }

        private static bool _F_WhCodeUse = false;
        public static bool F_WhCodeUse
        {
            get { return USysInfo._F_WhCodeUse; }
            set { USysInfo._F_WhCodeUse = value; }
        }

        private static bool _F_WhCodeBrowse = false;
        public static bool F_WhCodeBrowse
        {
            get { return USysInfo._F_WhCodeBrowse; }
            set { USysInfo._F_WhCodeBrowse = value; }
        }

        private static bool _F_DpCodeBrowse = false;
        public static bool F_DpCodeBrowse
        {
            get { return USysInfo._F_DpCodeBrowse; }
            set { USysInfo._F_DpCodeBrowse = value; }
        }

        private static bool _F_SpCodeBrowse = false;
        public static bool F_SpCodeBrowse
        {
            get { return USysInfo._F_SpCodeBrowse; }
            set { USysInfo._F_SpCodeBrowse = value; }
        }

        private static bool _F_CusCodeBrowse = false;
        public static bool F_CusCodeBrowse
        {
            get { return USysInfo._F_CusCodeBrowse; }
            set { USysInfo._F_CusCodeBrowse = value; }
        }

        public static string DBERP
        {
            get
            {
                return "HKOERP";
            }
        }
    }
}
