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
        private RelayCommand _CmdCheck;

        public RelayCommand CmdCheck
        {
            get
            {
                return _CmdCheck ?? (_CmdCheck = new RelayCommand(ExecuteCmdCheck));
            }
        }

        private void ExecuteCmdCheck()
        {
            if (!CanExecuteCmdCheck())
            {
                return;
            }
            this.Check();
        }

        protected virtual void Check()
        {
            try
            {
                this.IsBusy = true;
                var obj = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.DomainService.Bill.DS" + this.PrepareDSBill());
                Action<InvokeOperation> action = new Action<InvokeOperation>(OnCheckCompleted);
                var method = obj.GetType().GetMethod("Check", new Type[] { typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), action.GetType(), typeof(object) });
                method.Invoke(obj, new object[] { USysInfo.DBCode, USysInfo.LgIndex, this.CurrentIDCode, USysInfo.UserCode, USysInfo.UserName, action, null });
            }
            catch { this.IsBusy = false; MessageErp.ErrorMessage(ErpUIText.ErrMsg); }
        }

        private void OnCheckCompleted(InvokeOperation geted)
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

        private bool CanExecuteCmdCheck()
        {
            return URight.Check(this.VMNameAuthority + "_Check");
        }
    }
}
