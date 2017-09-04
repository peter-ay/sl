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
    public class VMB_Warehouse_Right_Use : VMList
    {
        private V_B_Warehouse _selectedItem;
        private List<string> _CodeList = new List<string>();
        private Lazy<DSB_Warehouse> _DSBill = new Lazy<DSB_Warehouse>();

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

        public VMB_Warehouse_Right_Use()
            : base("WhCode", "B_Warehouse", "whCode", "whName")
        {
            this.IsChildWindow = true;
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }


        protected override void OnLoadMainEnd()
        {
            if (this._GpCode == "")
                return;

            this.GetWhCodeByGpCode();
        }

        private void GetWhCodeByGpCode()
        {
            var _DDs = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_WarehouseRightUseGpCode", ReSetSelectCodes, true);
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

            foreach (V_B_Warehouse itenm in DContextList)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Warehouse_Use it2 in items2)
            {
                if (string.IsNullOrEmpty(it2.GpCode)) continue;

                foreach (V_B_Warehouse itenm in DContextList)
                {
                    if (itenm.WhCode.ToUpper() == it2.WhCode.ToUpper())
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
            this.GetWhCodeByGpCode();
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Warehouse);
        }

        private void PrepareUpdate(V_B_Warehouse parameter)
        {
            this._selectedItem = parameter;
            _CodeList.Clear();
            _CodeList.Add(_selectedItem.WhCode);
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

            _DSBill.Value.AssignRightUse(USysInfo.DBCode, USysInfo.LgIndex, this._GpCode, _CodeList, flag,
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
