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
        private RelayCommand _CmdDelete;

        /// <summary>
        /// Gets the CmdDelete.
        /// </summary>
        public RelayCommand CmdDelete
        {
            get
            {
                return _CmdDelete ?? (_CmdDelete = new RelayCommand(ExecuteCmdDelete));
            }
        }

        private void ExecuteCmdDelete()
        {
            if (!CanExecuteCmdDelete())
            {
                return;
            }

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_DeleteConfirmBill"), MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.Delete();
            };
            u.Show();
        }

        protected virtual void Delete()
        {
            try
            {
                this.IsBusy = true;
                var obj = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.DomainService.Bill.DS" + this.PrepareDSBill());
                Action<InvokeOperation> action = new Action<InvokeOperation>(OnDeleteCompleted);
                var method = obj.GetType().GetMethod("Delete", new Type[] { typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), action.GetType(), typeof(object) });
                method.Invoke(obj, new object[] { USysInfo.DBCode, USysInfo.LgIndex, this.CurrentIDCode,USysInfo.UserCode,USysInfo.UserName, action, null });
            }
            catch { this.IsBusy = false; MessageErp.ErrorMessage(ErpUIText.ErrMsg); }
        }

        protected virtual void OnDeleteCompleted(InvokeOperation geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {

                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            //MessageErp.InfoMessage(ErpUIText.Get("ERP_DeleteSucceed"));
            this.Drop();
        }


        private bool CanExecuteCmdDelete()
        {
            return URight.Check(this.VMNameAuthority + "_Delete");
        }
    }
}
