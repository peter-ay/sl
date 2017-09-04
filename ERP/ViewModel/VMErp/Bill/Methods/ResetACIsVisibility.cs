
using System.Windows;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected void ResetACIsVisibility(bool isVisibility)
        {
            var _isVisibility = isVisibility == true ? Visibility.Visible : Visibility.Collapsed;

            this.IsShowAC = _isVisibility;
            //this.IsShowACProcessCF = _isVisibility;
            //this.IsShowACProcessKF = _isVisibility;

            //if (isVisibility)
            //    Messenger.Default.Send<int>((0), USysMessages.ACBoxMinPrefixLengthChange);
            //else
            //    Messenger.Default.Send<int>((-1), USysMessages.ACBoxMinPrefixLengthChange);
            if (isVisibility)
                this.ACMinimumPrefixLength = 0;
            else
                this.ACMinimumPrefixLength = -1;
        }
    }
}
