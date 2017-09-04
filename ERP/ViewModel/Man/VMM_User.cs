
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using ERP.View;
using System;
using ERP.Web.DomainService.Bill;
namespace ERP.ViewModel
{
    public class VMM_User : VMBill
    {
        private Lazy<DSM_User> DS_Bill = new Lazy<DSM_User>();

        private bool isEnableResetPassword = false;
        public bool IsEnableResetPassword
        {
            get { return isEnableResetPassword; }
            set { isEnableResetPassword = value; RaisePropertyChanged("IsEnableResetPassword"); }
        }

        public VMM_User()
            : base("UserCode", "S_User")
        {
            this.IsChildWindow = true;
        }

        protected override void ChangeBillSate(Utility.UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsEnableResetPassword = false;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableResetPassword = true; ;
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdResetPassword;

        /// <summary>
        /// Gets the CmdResetPassword.
        /// </summary>
        public RelayCommand CmdResetPassword
        {
            get
            {
                return _CmdResetPassword
                    ?? (_CmdResetPassword = new RelayCommand(
                    () =>
                    {
                        MessageWindowErp c = new MessageWindowErp(ErpUIText.Get("M_User_ResetPasswordAsk"), MessageWindowErp.MessageType.Confirm);
                        c.Closed += (s1, e1) =>
                        {
                            if (c.DialogResult != true)
                                return;

                            this.IsBusy = true;
                            DS_Bill.Value.ResetPassword(USysInfo.DBCode, USysInfo.LgIndex, this.CurrentIDCode, geted =>
                                {
                                    this.IsBusy = false;
                                    if (geted.HasError)
                                    {
                                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                                        geted.MarkErrorAsHandled();
                                        return;
                                    }
                                    MessageErp.InfoMessage(ErpUIText.Get("ERP_Succeed"));
                                }, null);
                        };
                        c.Show();
                    }));
            }
        }


    }
}
