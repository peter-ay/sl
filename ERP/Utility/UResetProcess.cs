using ERP.Common;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Utility
{
    public class UResetProcess
    {
        public static void Set(bool is_CF)
        {
            if (is_CF)
            {
                Messenger.Default.Send<bool>((true), USysMessages.ACBoxProcess_CF_IsShow);
                Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_KF_IsShow);
            }
            else
            {
                Messenger.Default.Send<bool>((false), USysMessages.ACBoxProcess_CF_IsShow);
                Messenger.Default.Send<bool>((true), USysMessages.ACBoxProcess_KF_IsShow);
            }
        }
    }
}
