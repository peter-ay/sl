
using ERP.Common;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.Utility
{
    public class USysFlag
    {
        static bool _isReady = false;

        public static bool IsReady
        {
            get
            {
                //_isReady = (IsReadyRight && IsReadyCusCodeSmartBrowseRight);
                _isReady = (IsReadyRight);
                return _isReady;
            }
        }

        static bool _isReadyRight = false;

        public static bool IsReadyRight
        {
            get { return USysFlag._isReadyRight; }
            set
            {
                USysFlag._isReadyRight = value;
                if (value)
                    Messenger.Default.Send<bool>((false), USysMessages.MainBI);
            }
        }

        //static bool _isReadyCusCodeSmart = false;

        //public static bool IsReadyCusCodeSmartBrowseRight
        //{
        //    get { return USysFlag._isReadyCusCodeSmart; }
        //    set
        //    {
        //        USysFlag._isReadyCusCodeSmart = value;
        //        if (value)
        //            Messenger.Default.Send<bool>((false), USysMessages.MainBI);
        //    }
        //}

        //static bool _isReadyChecked = false;

        //public static bool IsReadyChecked
        //{
        //    get { return USysFlag._isReadyChecked; }
        //    set { USysFlag._isReadyChecked = value; }
        //}

        public static bool IsLogin2
        {
            set
            {
                IsReadyRight = true;
                //IsReadyCusCodeSmartBrowseRight = true;
                ComHelp.Load();
                //
                NotifiyUserLogined();
            }
        }

        private static void NotifiyUserLogined()
        {
            Messenger.Default.Send<string>((""), USysMessages.UserLogined);
            Messenger.Default.Send<string>((""), USysMessages.UserLoginedTree);
        }


        public static bool IsLogin1
        {
            set
            {
                URight.Read();
                ComHelp.Load();
                //
                NotifiyUserLogined();
            }
        }
    }
}
