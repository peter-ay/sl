using System.Collections.ObjectModel;
using ERP.Web.Entity;
using ERP.Common;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ERP.Utility;
using ERP.View;
using System;
using ERP.Web.DomainService.Bill;

namespace ERP.ViewModel
{
    public class VMB_Customer_Acc_List : VMList
    {
        private V_B_Customer _selectedItem;
        private List<string> uCodeList = new List<string>();
        private Lazy<DSB_Customer_Acc_AssignCusCode> DS_Bill = new Lazy<DSB_Customer_Acc_AssignCusCode>();

        private string _CusCode = "";
        public string CusCode
        {
            get
            {
                return _CusCode;
            }
            set
            {
                _CusCode = value;
                RaisePropertyChanged("CusCode");
            }
        }

        private string _CusName = "";
        public string CusName
        {
            get
            {
                return _CusName;
            }
            set
            {
                _CusName = value;
                RaisePropertyChanged("CusName");
            }
        }

        private string _AccCusCode = "";
        public string AccCusCode
        {
            get
            {
                return _AccCusCode;
            }
            set
            {
                _AccCusCode = value;
                RaisePropertyChanged("AccCusCode");
            }
        }

        private string _AccCusName = "";
        public string AccCusName
        {
            get
            {
                return _AccCusName;
            }
            set
            {
                _AccCusName = value;
                RaisePropertyChanged("AccCusName");
            }
        }

        public VMB_Customer_Acc_List()
            : base("AccCusCode", "B_Customer_Acc", "accCusCode", "accCusName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.LoadList2();
        }

        protected override void Refresh2()
        {
            this.LoadList2();
        }

        protected override void OnLoadMainEnd2()
        {
            if (!string.IsNullOrEmpty(this.AccCusCode))
            {
                var item = new V_B_Customer_Acc() { AccCusCode = this.AccCusCode, AccCusName = this.AccCusName };
                this.GridSelectedItemChanged(item);
            }
        }

        protected override void GridSelectedItemChanged(System.ServiceModel.DomainServices.Client.Entity item)
        {
            if (item == null) return;
            var it = item as V_B_Customer_Acc;
            this.AccCusCode = it.AccCusCode;
            this.AccCusName = it.AccCusName;
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_Customer_Acc_CusIncludeListByAccCusCode, ReSetSelectCodes);
            ds.QueryParameters.Add(new Parameter() { ParameterName = "accCusCode", Value = this.AccCusCode });
            this.IsBusyList2 = true;
            ds.Load();
        }

        protected override string PrepareDDsInfoList2QueryName()
        {
            return "GetV_B_CustomerList";
        }

        protected override string PrepareDDsInfoList2DefaultKeyCode()
        {
            return "CusCode";
        }

        protected override void PrepareDDsInfoList2Parameters()
        {
            this._SWhere2 = "";
            if (!string.IsNullOrEmpty(this.CusCode))
                _SWhere2 += "CusCode" + USptstr.Str2 + this.CusCode;
            if (!string.IsNullOrEmpty(this.CusName))
                _SWhere2 += USptstr.Str1 + "CusName" + USptstr.Str2 + this.CusName;
            this.DDsInfoList2.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = this._SWhere2 });
        }

        private void ReSetSelectCodes(object s, LoadedDataEventArgs geted)
        {
            this.IsBusyList2 = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            if (DContextList2 == null) return;

            foreach (V_B_Customer itenm in DContextList2)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Customer y in items2)
            {
                foreach (V_B_Customer itenm in DContextList2)
                {
                    if (itenm.CusCode.ToUpper() == y.CusCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Customer);
        }

        private void PrepareUpdate(V_B_Customer parameter)
        {
            if (string.IsNullOrEmpty(this.AccCusCode)) return;
            this._selectedItem = parameter;
            uCodeList.Clear();
            uCodeList.Add(_selectedItem.CusCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {

            _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.Update(USysInfo.DBCode,USysInfo.LgIndex,this.AccCusCode, uCodeList, flag,
                geted =>
                {
                    _selectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }


    }
}
