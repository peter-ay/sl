using System;
using System.Reflection;
using System.ServiceModel.DomainServices.Client;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using ERP.Common;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdSave;

        public RelayCommand CmdSave
        {
            get
            {
                return _CmdSave ?? (_CmdSave = new RelayCommand(ExecuteCmdSave));
            }
        }

        private void ExecuteCmdSave()
        {
            if (!CanExecuteCmdSave())
            {
                return;
            }
            this.Save();
        }

        protected virtual bool VerifySave()
        {
            this.FixEditACBug();
            return true;
        }

        protected virtual void Save(bool f_Verify = true)
        {
            if (f_Verify && !this.VerifySave())
                return;

            try
            {
                this.IsBusy = true;
                this.PrepareModel();
                this.PrepareModelToSave();
                var model = this.CurrentModel;
                try
                {
                    model.GetType().GetProperty("MName").SetValue(model, USysInfo.UserName, null);
                }
                catch { }
                var obj = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.DomainService.Bill.DS" + this.PrepareDSBill());

                MethodInfo method;
                if (this.EditMode)
                {
                    var _Checker = "";
                    try { _Checker = model.GetType().GetProperty("Checker").GetValue(model, null).ToString(); }
                    catch { }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    var _UpdateMethod = "Update";
                    if (!string.IsNullOrEmpty(_Checker))
                    {
                        _UpdateMethod = "UpdateEdit";
                    }
                    Action<InvokeOperation> action = new Action<InvokeOperation>(OnEditCompleted);
                    method = obj.GetType().GetMethod(_UpdateMethod, new Type[] { typeof(string), typeof(int), model.GetType(), action.GetType(), typeof(object) });
                    method.Invoke(obj, new object[] { USysInfo.DBCode, USysInfo.LgIndex, model, action, null });
                }
                else
                {
                    Action<InvokeOperation<string>> action = new Action<InvokeOperation<string>>(OnSaveCompleted);
                    method = obj.GetType().GetMethod("Add", new Type[] { typeof(string), typeof(int), model.GetType(), action.GetType(), typeof(object) });
                    method.Invoke(obj, new object[] { USysInfo.DBCode, USysInfo.LgIndex, model, action, null });
                }
            }
            catch { this.IsBusy = false; MessageErp.ErrorMessage(ErpUIText.ErrMsg); }
        }

        protected virtual string PrepareDSBill()
        {
            return this.VMNameAuthority;
        }

        protected virtual void PrepareModel()
        {
            try
            {
                this.CurrentModel = Assembly.GetExecutingAssembly().CreateInstance("ERP.Web.Model.M" + this.ModelName);
            }
            catch { }
        }

        protected virtual void PrepareModelToSave()
        {
            var _Model = this.CurrentModel;
            ComCopyProperties.Copy(_Model, this.DContextMain);
        }

        protected virtual void OnSaveCompleted(InvokeOperation<string> geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            //if (string.IsNullOrEmpty(this.CurrentIDCode))
            //    MessageErp.InfoMessage(ErpUIText.Get("ERP_SaveSucceed") + Environment.NewLine + geted.Value.ToString().Trim());
            this.OnSaveCompleted2(geted.Value);
        }

        protected virtual void OnSaveCompleted2(string id)
        {
            this.LoadBill(id);
        }

        protected virtual void OnEditCompleted(InvokeOperation geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }
            if (!string.IsNullOrEmpty(this.CurrentIDCode))
                this.LoadBill(this.CurrentIDCode);
        }

        protected virtual bool CanExecuteCmdSave()
        {
            return URight.Check(this.VMNameAuthority + "_Save", false);
        }
    }
}
