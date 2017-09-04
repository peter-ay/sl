using System.Collections.ObjectModel;
using ERP.Web.Entity;
using ERP.Common;
using System.Collections.Generic;
using System.Linq;
using ERP.Utility;
using ERP.View;
using System.Windows.Controls;
using ERP.Web.DomainService.Bill;
using System;

namespace ERP.ViewModel
{
    public class VMB_Customer_Main_List : VMList
    {
        private V_B_Customer_Acc _selectedItem;
        private List<string> uCodeList = new List<string>();
        private Lazy<DSB_Customer_Main_AssignAccCusCode> DS_Bill = new Lazy<DSB_Customer_Main_AssignAccCusCode>();

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

        private string _MainCusCode = "";
        public string MainCusCode
        {
            get
            {
                return _MainCusCode;
            }
            set
            {
                _MainCusCode = value;
                RaisePropertyChanged("MainCusCode");
            }
        }

        private string _MainCusName = "";
        public string MainCusName
        {
            get
            {
                return _MainCusName;
            }
            set
            {
                _MainCusName = value;
                RaisePropertyChanged("MainCusName");
            }
        }


        public VMB_Customer_Main_List()
            : base("MainCusCode", "B_Customer_Main", "mainCusCode", "mainCusName", isAutoRefresh: true)
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
                var item = new V_B_Customer_Main() { MainCusCode = this.AccCusCode, MainCusName = this.AccCusName };
                this.GridSelectedItemChanged(item);
            }
        }

        protected override void GridSelectedItemChanged(System.ServiceModel.DomainServices.Client.Entity item)
        {
            if (item == null) return;
            var it = item as V_B_Customer_Main;
            this.MainCusCode = it.MainCusCode;
            this.MainCusName = it.MainCusName;
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_Customer_Main_CusIncludeListByMainCusCode, ReSetSelectCodes);
            ds.QueryParameters.Add(new Parameter() { ParameterName = "mainCusCode", Value = this.MainCusCode });
            this.IsBusyList2 = true;
            ds.Load();
        }

        protected override string PrepareDDsInfoList2QueryName()
        {
            return "GetV_B_Customer_AccList";
        }

        protected override string PrepareDDsInfoList2DefaultKeyCode()
        {
            return "AccCusCode";
        }

        protected override void PrepareDDsInfoList2Parameters()
        {
            this._SWhere2 = "";
            if (!string.IsNullOrEmpty(this.AccCusCode))
                _SWhere2 += "AccCusCode" + USptstr.Str2 + this.AccCusCode;
            if (!string.IsNullOrEmpty(this.AccCusName))
                _SWhere2 += USptstr.Str1 + "AccCusName" + USptstr.Str2 + this.AccCusName;
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

            foreach (V_B_Customer_Acc itenm in DContextList2)
            {
                itenm.IsSelected = false;
            }

            foreach (V_B_Customer_Acc y in items2)
            {
                foreach (V_B_Customer_Acc itenm in DContextList2)
                {
                    if (itenm.AccCusCode.ToUpper() == y.AccCusCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_B_Customer_Acc);
        }

        private void PrepareUpdate(V_B_Customer_Acc parameter)
        {
            if (string.IsNullOrEmpty(this.MainCusCode)) return;
            this._selectedItem = parameter;
            uCodeList.Clear();
            uCodeList.Add(_selectedItem.AccCusCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {

            _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.Update(USysInfo.DBCode, USysInfo.LgIndex, this.MainCusCode, uCodeList, flag,
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
