using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ERP.Common;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public class VMSale_ContractBill_Sub_CusCode : VMList
    {
        private string _billcode = "";
        private int _conInclude = -1;
        private V_Base_CustomerSmart _selectedItem;
        private List<string> cusCodeList = new List<string>();
        private Lazy<DSSale_ContractBill> DS_Bill = new Lazy<DSSale_ContractBill>();

        private double wrapPanelHeigh = 0;
        public double WrapPanelHeigh
        {
            get { return wrapPanelHeigh; }
            set { wrapPanelHeigh = value; RaisePropertyChanged("WrapPanelHeigh"); }
        }

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


        public VMSale_ContractBill_Sub_CusCode()
            : base("CusCode", "Sale_ContractBill_Sub_CusCode", "cusCode", "cusName")
        {
            IsChildWindow = true;
        }

        protected override void PrepareDDsInfoMainParameters()
        {
            base.PrepareDDsInfoMainParameters();
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "contractCode", Value = this._billcode.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "includeState", Value = this._conInclude });
        }

        protected override void OnLoadMainEnd()
        {
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_ContractBill_Sub_CusCodeQuery", ReSetCusCode);
            ds.FilterDescriptors.Add(new FilterDescriptor() { PropertyPath = "ContractCode", Value = this._billcode });
            this.IsBusy = true;
            ds.Load();
        }

        private void ReSetCusCode(object s, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_Sale_ContractBill_Sub_CusCode y in items2)
            {
                foreach (V_Base_CustomerSmart itenm in DContextMain)
                {
                    if (itenm.CusCode.ToUpper() == y.CusCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }

        protected override void OnBillCodeChange(string msg)
        {
            if (this._billcode != msg)
            {
                this._billcode = msg;
                this.Title = ErpUIText.Get(this.VMNameAuthority + "_Title") + " || " + msg;
                this.InitSearchCondition();
                this.ExecuteCmdSearch();
            }
        }

        protected override void InitSearchCondition()
        {
            this.IsIncludeAll = true;
            this.SKeyCode = "";
            this.SKeyName = "";
            this._conInclude = -1;
        }

        #region methods

        private RelayCommand<double> _CmdLayOutUpdate;

        /// <summary>
        /// Gets the CmdLayOutUpdate.
        /// </summary>
        public RelayCommand<double> CmdLayOutUpdate
        {
            get
            {
                return _CmdLayOutUpdate
                    ?? (_CmdLayOutUpdate = new RelayCommand<double>(ExecuteCmdLayOutUpdate));
            }
        }

        private void ExecuteCmdLayOutUpdate(double parameter)
        {
            if (WrapPanelHeigh != parameter - 125)
                this.LayOutUpdate(parameter);
        }

        private void LayOutUpdate(double parameter)
        {
            this.WrapPanelHeigh = parameter - 125;
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////
        /// </summary>

        private RelayCommand<string> _CmdRBCdiInclude;

        /// <summary>
        /// Gets the CmdRBCdiInclude.
        /// </summary>
        public RelayCommand<string> CmdRBCdiInclude
        {
            get
            {
                return _CmdRBCdiInclude
                    ?? (_CmdRBCdiInclude = new RelayCommand<string>(ExecuteCmdRBCdiInclude));
            }
        }

        private void ExecuteCmdRBCdiInclude(string parameter)
        {
            _conInclude = System.Convert.ToInt32(parameter);
        }

        ///////////////////////////////////////////////////////////////////////////
        private string _tbname = "Sale_ContractBill_Sub_CusCode";

        protected override void Export()
        {
            ComExport.Export(_tbname, " ContractCode='" + this._billcode + "'", " order by CusCode", " CusCode");
        }

        protected override void Import()
        {
            ComImport.Import(_tbname, this._billcode);
        }

        protected override void OnImportCompleted()
        {
            this.ExecuteCmdSearch();
        }

        /////////////////////////////////////////////////

        private RelayCommand<V_Base_CustomerSmart> _CmdCusCodeCheckClick;

        /// <summary>
        /// Gets the CmdCusCodeCheckClick.
        /// </summary>
        public RelayCommand<V_Base_CustomerSmart> CmdCusCodeCheckClick
        {
            get
            {
                return _CmdCusCodeCheckClick
                    ?? (_CmdCusCodeCheckClick = new RelayCommand<V_Base_CustomerSmart>(ExecuteCmdCusCodeCheckClick));
            }
        }

        private void ExecuteCmdCusCodeCheckClick(V_Base_CustomerSmart parameter)
        {
            this.PrepareUpdate(parameter);
        }

        private void PrepareUpdate(V_Base_CustomerSmart parameter)
        {
            this._selectedItem = parameter;
            cusCodeList.Clear();
            cusCodeList.Add(_selectedItem.CusCode);
            this.UpdateCusCodes(_selectedItem.IsSelected);
        }

        private void UpdateCusCodes(bool flag, bool isShowBusy = false)
        {
            if (isShowBusy)
                this.IsBusy = true;
            else
                _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.UpdateCusCodes(this._billcode, cusCodeList, flag,
                geted =>
                {
                    if (isShowBusy)
                        this.IsBusy = false;
                    else
                        _selectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        //USysInfo.ErrMsg = ErpUIText.Get("ERP_Err") + geted.Error.Message.Substring(geted.Error.Message.IndexOf('.') + 1);
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdAllAssign;

        /// <summary>
        /// Gets the CmdAllAssign.
        /// </summary>
        public RelayCommand CmdAllAssign
        {
            get
            {
                return _CmdAllAssign
                    ?? (_CmdAllAssign = new RelayCommand(ExecuteCmdAllAssign));
            }
        }

        private void ExecuteCmdAllAssign()
        {
            this.ToIncludeALL();
        }

        private void ToIncludeALL()
        {
            this.cusCodeList.Clear();
            foreach (V_Base_CustomerSmart t in this.DContextMain)
            {
                t.IsSelected = true;
                cusCodeList.Add(t.CusCode);
            }
            this.UpdateCusCodes(true, true);
        }

        /////////////////////////////////////////////////

        private RelayCommand _CmdAllUnAssign;

        /// <summary>
        /// Gets the CmdAllUnAssign.
        /// </summary>
        public RelayCommand CmdAllUnAssign
        {
            get
            {
                return _CmdAllUnAssign
                    ?? (_CmdAllUnAssign = new RelayCommand(ExecuteCmdAllUnAssign));
            }
        }

        private void ExecuteCmdAllUnAssign()
        {
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this.cusCodeList.Clear();
            foreach (V_Base_CustomerSmart t in this.DContextMain)
            {
                t.IsSelected = false;
                cusCodeList.Add(t.CusCode);
            }
            this.UpdateCusCodes(false, true);
        }

        #endregion

    }
}
