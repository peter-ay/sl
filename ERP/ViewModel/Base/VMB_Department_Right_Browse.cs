using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ERP.ViewModel
{
    public class VMB_Department_Right_Browse : VMList
    {
        //private V_B_Department _selectedItem;
        public new V_B_Department SelectedItem
        {
            get;
            set;
        }

        private List<string> _CodeList = new List<string>();
        private Lazy<DSB_Department> _DSBill = new Lazy<DSB_Department>();

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

        public VMB_Department_Right_Browse()
            : base("DpCode", "B_Department", "dpCode", "dpName")
        {
            this.IsChildWindow = true;
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }


        protected override void OnLoadMainEnd()
        {
            if (this._GpCode == "")
                return;

            this.GetDpCodeByGpCode();
        }

        private void GetDpCodeByGpCode()
        {
            var _DDs = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_DepartmentRightBrowseGpCode", ReSetSelectCodes, true);
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

            foreach (V_B_Department itenm in DContextList)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Department_Browse it2 in items2)
            {
                if (string.IsNullOrEmpty(it2.GpCode)) continue;

                foreach (V_B_Department itenm in DContextList)
                {
                    if (itenm.DpCode.ToUpper() == it2.DpCode.ToUpper())
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
            this.GetDpCodeByGpCode();
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Department);
        }

        private void PrepareUpdate(V_B_Department parameter)
        {
            this.SelectedItem = parameter;
            _CodeList.Clear();
            _CodeList.Add(SelectedItem.DpCode);
            this.UpdateCodes(SelectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {
            if (string.IsNullOrEmpty(this._GpCode))
                return;

            if (isShowBusy)
                this.IsBusy = true;
            else
                SelectedItem.Msg = ErpUIText.Get("ERP_Updating");

            _DSBill.Value.AssignRightBrowse(USysInfo.DBCode, USysInfo.LgIndex, this._GpCode, _CodeList, flag,
                geted =>
                {
                    if (isShowBusy)
                        this.IsBusy = false;
                    else
                        SelectedItem.Msg = "";

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
