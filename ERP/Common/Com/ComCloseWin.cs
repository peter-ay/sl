using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Common
{
    public class ComCloseWin
    {
        public static void Close(bool ischildwindow)
        {
            if (ischildwindow)
            {
                Messenger.Default.Send<string>((""), USysMessages.CloseChildWindow);
            }
            else
            {
                ////////////////////////////////////////////////////////////////////
                //MessageWindowErp c = new MessageWindowErp(ErpUIText.Get("ERP_ExitMsg"), MessageWindowErp.MessageType.Confirm);
                //c.Closed += (s1, e1) =>
                //{
                //    if (c.DialogResult == true)
                //        Messenger.Default.Send<string>((""), USysMessages.RemoveTab);
                //};
                //c.Show();
                ////////////////////////////////////////////////////////////////////
                Messenger.Default.Send<string>((""), USysMessages.RemoveTab);
            }
        }
    }
}
