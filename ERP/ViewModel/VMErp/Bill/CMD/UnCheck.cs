using System;
using System.Reflection;
using System.ServiceModel.DomainServices.Client;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdUnCheck;

        public RelayCommand CmdUnCheck
        {
            get
            {
                return _CmdUnCheck ?? (_CmdUnCheck = new RelayCommand(ExecuteCmdUnCheck));
            }
        }

        private void ExecuteCmdUnCheck()
        {
            if (!CanExecuteCmdUnCheck())
            {
                return;
            }
            this.UnCheck();
        }

        protected virtual void UnCheck()
        {
            try
            {
                this.IsBusy = true;
                var obj = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.DomainService.Bill.DS" + this.PrepareDSBill());
                Action<InvokeOperation> action = new Action<InvokeOperation>(OnUnCheckCompleted);
                var method = obj.GetType().GetMethod("UnCheck", new Type[] { typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), action.GetType(), typeof(object) });
                method.Invoke(obj, new object[] { USysInfo.DBCode, USysInfo.LgIndex, this.CurrentIDCode, USysInfo.UserCode, USysInfo.UserName, action, null });
            }
            catch { this.IsBusy = false; MessageErp.ErrorMessage(ErpUIText.ErrMsg); }
        }

        private void OnUnCheckCompleted(InvokeOperation geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            this.LoadBill(this.CurrentIDCode);
        }

        private bool CanExecuteCmdUnCheck()
        {
            return URight.Check(this.VMNameAuthority + "_UnCheck");
        }
    }
}
