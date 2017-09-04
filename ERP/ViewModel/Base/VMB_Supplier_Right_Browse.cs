using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;

namespace ERP.ViewModel
{
    public class VMB_Supplier_Right_Browse : VMList
    {
        private V_B_Supplier _selectedItem;
        private List<string> _CodeList = new List<string>();
        private Lazy<DSB_Supplier> _DSBill = new Lazy<DSB_Supplier>();

        #region Property

        private string _GpCode = "";
        public string GpCode
        {
            get
            {
                return _GpCode;
            }
            set
            {
                _GpCode = value;
                RaisePropertyChanged("GpCode");
            }
        }

        #endregion

        public VMB_Supplier_Right_Browse()
            : base("SpCode", "B_Supplier", "spCode", "spName")
        {
            this.IsChildWindow = true;
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }


        protected override void OnLoadMainEnd()
        {
            if (this._GpCode == "")
                return;

            this.GetSpCodeByGpCode();
        }

        private void GetSpCodeByGpCode()
        {
            var _DDs = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_SupplierRightBrowseGpCode", ReSetSelectCodes, true);
            _DDs.QueryParameters.Add(new Parameter() { ParameterName = "gpCode", Value = this._GpCode });
            this.IsBusy = true;
            _DDs.Load();
        }

        private void ReSetSelectCodes(object s, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_B_Supplier itenm in DContextList)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Supplier_Browse it2 in items2)
            {
                if (string.IsNullOrEmpty(it2.GpCode)) continue;

                foreach (V_B_Supplier itenm in DContextList)
                {
                    if (itenm.SpCode.ToUpper() == it2.SpCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        #region methods

        protected override void ExecuteCmdComBGpCodeChange(System.ServiceModel.DomainServices.Client.Entity paramater)
        {
            if (paramater == null) return;
            var item = paramater as V_S_UserGroup;
            this._GpCode = item.GpCode;
            this.GetSpCodeByGpCode();
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Supplier);
        }

        private void PrepareUpdate(V_B_Supplier parameter)
        {
            this._selectedItem = parameter;
            _CodeList.Clear();
            _CodeList.Add(_selectedItem.SpCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {
            if (string.IsNullOrEmpty(this._GpCode))
                return;

            if (isShowBusy)
                this.IsBusy = true;
            else
                _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            _DSBill.Value.AssignRightBrowse(USysInfo.DBCode, USysInfo.LgIndex, this._GpCode, _CodeList, flag,
                geted =>
                {
                    if (isShowBusy)
                        this.IsBusy = false;
                    else
                        _selectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }

        #endregion
    }
}
