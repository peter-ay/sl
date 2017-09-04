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
    public class VMB_Customer_Right_Browse : VMList
    {
        private V_B_Customer _selectedItem;
        private List<string> _CodeList = new List<string>();
        private Lazy<DSB_Customer> _DSBill = new Lazy<DSB_Customer>();

        #region Property
        private bool _IsIncludeAll = true;
        public bool IsIncludeAll
        {
            get { return _IsIncludeAll; }
            set
            {
                _IsIncludeAll = value;
                RaisePropertyChanged<bool>(() => this.IsIncludeAll);
            }
        }

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

        private string _DpCode = "";
        public string DpCode
        {
            get
            {
                return _DpCode;
            }
            set
            {
                _DpCode = value;
                RaisePropertyChanged("DpCode");
            }
        }

        #endregion

        public VMB_Customer_Right_Browse()
            : base("CusCode", "B_Customer", "cusCode", "cusName")
        {
            this.IsChildWindow = true;
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.DpCode = "";
            this.IsIncludeAll = true;
            this._ConInclude = -1;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "DpCode" + USptstr.Str2 + this.DpCode;
            _SWhere += USptstr.Str1 + "GpCode" + USptstr.Str2 + this._GpCode;
            _SWhere += USptstr.Str1 + "BrowseIncludeState" + USptstr.Str2 + this._ConInclude;
        }

        protected override void OnLoadMainEnd()
        {
            if (this._GpCode == "")
                return;

            this.GetCusCodeByGpCode();
        }

        private void GetCusCodeByGpCode()
        {
            var _DDs = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_CustomerRightBrowseGpCode", ReSetSelectCodes, true);
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

            foreach (V_B_Customer itenm in DContextList)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Customer_Browse it2 in items2)
            {
                if (string.IsNullOrEmpty(it2.GpCode)) continue;

                foreach (V_B_Customer itenm in DContextList)
                {
                    if (itenm.CusCode.ToUpper() == it2.CusCode.ToUpper())
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
            this.GetCusCodeByGpCode();
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Customer);
        }

        private void PrepareUpdate(V_B_Customer parameter)
        {
            this._selectedItem = parameter;
            _CodeList.Clear();
            _CodeList.Add(_selectedItem.CusCode);
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

        protected override void ExecuteCmdAllAssign()
        {
            if (string.IsNullOrEmpty(this._GpCode))
                return;
            this.ToIncludeALL();
        }

        private void ToIncludeALL()
        {
            this._CodeList.Clear();
            foreach (V_B_Customer t in this.DContextList)
            {
                t.IsSelected = true;
                _CodeList.Add(t.CusCode);
            }
            this.UpdateCodes(true, true);
        }

        protected override void ExecuteCmdAllUnAssign()
        {
            if (string.IsNullOrEmpty(this._GpCode))
                return;
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this._CodeList.Clear();
            foreach (V_B_Customer t in this.DContextList)
            {
                t.IsSelected = false;
                _CodeList.Add(t.CusCode);
            }
            this.UpdateCodes(false, true);
        }

        #endregion
    }
}
