using System;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
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
            this.AskDelete();
        }

        private void AskDelete()
        {
            if (this.GridListSelectedCodes.Count == 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_DeleteNone"));
                return;
            }

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_DeleteConfirmList") + "[" + this.GridListSelectedCodes.Count.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.Delete();
            };
            u.Show();
        }

        protected virtual void Delete()
        {
            Lazy<DSDelete> DS_Bill_Deletes = new Lazy<DSDelete>();
            try
            {
                this.IsBusy = true;

                DS_Bill_Deletes.Value.Delete(USysInfo.DBCode, USysInfo.LgIndex, this.PrepareDeleteTableName(), this.GridListSelectedCodes, this.CurrentIDCode ?? "", USysInfo.UserCode, USysInfo.UserName, geted =>
                {
                    this.IsBusy = false;
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    //MessageErp.InfoMessage(ErpUIText.Get("ERP_DeleteSucceed"));
                    this.RefreshList();
                }, null);
            }
            catch
            { MessageErp.ErrorMessage(ErpUIText.Get("ERP_Err")); }
        }

        protected virtual string PrepareDeleteTableName()
        {
            return this.VMNameAuthority.Replace("_List", "");
        }

        private bool CanExecuteCmdDelete()
        {
            return URight.Check(this.VMNameAuthority + "_Delete");
        }

    }
}
