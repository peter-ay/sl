using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ERP.Common;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using ERP.Utility;

namespace ERP.ViewModel
{
    public class VMSale_PriceContract_CusCode : VMList
    {
        //private string _billcode = "";
        private V_B_Customer _SelectedItem;
        private List<string> cusCodeList = new List<string>();
        private Lazy<DSSale_PriceContract> DS_Bill = new Lazy<DSSale_PriceContract>();

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

        #region ListShowDetail

        //private string _BCode = "";
        //public string BCode
        //{
        //    get { return _BCode; }
        //    set { _BCode = value; RaisePropertyChanged("BCode"); }
        //}

        private string _GpCode = "";
        public string GpCode
        {
            get { return _GpCode; }
            set { _GpCode = value; RaisePropertyChanged("CusType"); }
        }

        private string _CusTypeName = "";
        public string GpName
        {
            get { return _CusTypeName; }
            set { _CusTypeName = value; RaisePropertyChanged("CusTypeName"); }
        }

        #endregion


        public VMSale_PriceContract_CusCode()
            : base("CusCode", "B_Customer", "cusCode", "cusName")
        {
            IsChildWindow = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "GpCode" + USptstr.Str2 + this.GpCode.MyStr();
            _SWhere += USptstr.Str1 + "PCIncludeState" + USptstr.Str2 + this._ConInclude;
        }

        protected override void OnLoadMainEnd()
        {
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_PriceContract_CusGroup_CusCodeListQuery", ReSetCusCode, true);
            var _W = USptstr.Str1 + "GpCode" + USptstr.Str2 + this.GpCode.MyStr();
            ds.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = _W });
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

            foreach (V_Sale_PriceContract_CusGroup_CusCode y in items2)
            {
                foreach (V_B_Customer item in DContextList)
                {
                    if (item.CusCode.ToUpper() == y.CusCode.ToUpper())
                    {
                        item.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }

        protected override void OnIDChange(string msg)
        {
            var _Str = msg.Split(new string[] { "||" }, StringSplitOptions.None);
            //this.BID = _Str[0].ToString();
            this.BCode = _Str[0].ToString();
            this.GpCode = _Str[1].ToString();
            this.GpName = _Str[2].ToString();
            this.Title = ErpUIText.Get(this.VMNameAuthority + "_Title") + " || " + msg;
            this.InitSearchCondition();
            this.Load();
            //if (this._billcode != msg)
            //{
            //    this._billcode = msg;
            //    this.Title = ErpUIText.Get(this.VMNameAuthority + "_Title") + " || " + msg;
            //    this.InitSearchCondition();
            //    this.Search();
            //}
        }

        protected override void InitSearchCondition()
        {
            this.IsIncludeAll = true;
            this.SKeyCode = "";
            this.SKeyName = "";
            this._ConInclude = -1;
        }

        #region methods


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////
        /// </summary>

        //private RelayCommand<string> _CmdRBCdiInclude;

        ///// <summary>
        ///// Gets the CmdRBCdiInclude.
        ///// </summary>
        //public RelayCommand<string> CmdRBCdiInclude
        //{
        //    get
        //    {
        //        return _CmdRBCdiInclude
        //            ?? (_CmdRBCdiInclude = new RelayCommand<string>(ExecuteCmdRBCdiInclude));
        //    }
        //}

        //private void ExecuteCmdRBCdiInclude(string parameter)
        //{
        //    _PCConInclude = System.Convert.ToInt32(parameter);
        //}

        ///////////////////////////////////////////////////////////////////////////
        private string _tbName = "Sale_PriceContract_CusGroup_CusCode";

        protected override void Export()
        {
            ComExport.Export(_tbName, " GpCode='" + this.GpCode + "'", " CusCode");
        }

        protected override void Import()
        {
            ComImport.Import(_tbName, this.GpCode);
        }

        /////////////////////////////////////////////////

        private RelayCommand<V_B_Customer> _CmdCusCodeCheckClick;

        /// <summary>
        /// Gets the CmdCusCodeCheckClick.
        /// </summary>
        public RelayCommand<V_B_Customer> CmdCusCodeCheckClick
        {
            get
            {
                return _CmdCusCodeCheckClick
                    ?? (_CmdCusCodeCheckClick = new RelayCommand<V_B_Customer>(ExecuteCmdCusCodeCheckClick));
            }
        }

        private void ExecuteCmdCusCodeCheckClick(V_B_Customer parameter)
        {
            this.PrepareUpdate(parameter);
        }

        private void PrepareUpdate(V_B_Customer parameter)
        {
            this._SelectedItem = parameter;
            cusCodeList.Clear();
            cusCodeList.Add(_SelectedItem.CusCode);
            this.UpdateCusCodes(_SelectedItem.IsSelected);
        }

        private void UpdateCusCodes(bool flag, bool isShowBusy = false)
        {
            if (isShowBusy)
                this.IsBusy = true;
            else
                _SelectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.UpdateCusCodes(USysInfo.DBCode, USysInfo.LgIndex, this.GpCode, cusCodeList, flag,
                geted =>
                {
                    if (isShowBusy)
                        this.IsBusy = false;
                    else
                        _SelectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        protected override void ExecuteCmdAllAssign()
        {
            base.ExecuteCmdAllAssign();
            this.ToIncludeALL();
        }

        private void ToIncludeALL()
        {
            this.cusCodeList.Clear();
            foreach (V_B_Customer t in this.DContextList)
            {
                t.IsSelected = true;
                cusCodeList.Add(t.CusCode);
            }
            this.UpdateCusCodes(true, true);
        }

        /////////////////////////////////////////////////

        protected override void ExecuteCmdAllUnAssign()
        {
            base.ExecuteCmdAllUnAssign();
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this.cusCodeList.Clear();
            foreach (V_B_Customer t in this.DContextList)
            {
                t.IsSelected = false;
                cusCodeList.Add(t.CusCode);
            }
            this.UpdateCusCodes(false, true);
        }

        #endregion

    }
}
