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
    public class VMPur_PriceContract_SpCode : VMList
    {
        //private string _billcode = "";
        private V_B_Supplier _SelectedItem;
        private List<string> SpCodeList = new List<string>();
        private Lazy<DSPur_PriceContract> DS_Bill = new Lazy<DSPur_PriceContract>();

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
            set { _GpCode = value; RaisePropertyChanged("GpCode"); }
        }

        private string _GpName = "";
        public string GpName
        {
            get { return _GpName; }
            set { _GpName = value; RaisePropertyChanged("GpName"); }
        }

        #endregion


        public VMPur_PriceContract_SpCode()
            : base("SpCode", "B_Supplier", "SpCode", "spName")
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
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Pur_PriceContract_SpGroup_SpCodeListQuery", ReSetSpCode, true);
            var _W = USptstr.Str1 + "GpCode" + USptstr.Str2 + this.GpCode.MyStr();
            ds.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = _W });
            this.IsBusy = true;
            ds.Load();
        }

        private void ReSetSpCode(object s, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_Pur_PriceContract_SpGroup_SpCode y in items2)
            {
                foreach (V_B_Supplier item in DContextList)
                {
                    if (item.SpCode.ToUpper() == y.SpCode.ToUpper())
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
        private string _tbName = "Pur_PriceContract_SpGroup_SpCode";

        protected override void Export()
        {
            ComExport.Export(_tbName, " GpCode='" + this.GpCode + "'", " SpCode");
        }

        protected override void Import()
        {
            ComImport.Import(_tbName, this.GpCode);
        }

        /////////////////////////////////////////////////

        private RelayCommand<V_B_Supplier> _CmdSpCodeCheckClick;

        /// <summary>
        /// Gets the CmdSpCodeCheckClick.
        /// </summary>
        public RelayCommand<V_B_Supplier> CmdSpCodeCheckClick
        {
            get
            {
                return _CmdSpCodeCheckClick
                    ?? (_CmdSpCodeCheckClick = new RelayCommand<V_B_Supplier>(ExecuteCmdSpCodeCheckClick));
            }
        }

        private void ExecuteCmdSpCodeCheckClick(V_B_Supplier parameter)
        {
            this.PrepareUpdate(parameter);
        }

        private void PrepareUpdate(V_B_Supplier parameter)
        {
            this._SelectedItem = parameter;
            SpCodeList.Clear();
            SpCodeList.Add(_SelectedItem.SpCode);
            this.UpdateSpCodes(_SelectedItem.IsSelected);
        }

        private void UpdateSpCodes(bool flag, bool isShowBusy = false)
        {
            if (isShowBusy)
                this.IsBusy = true;
            else
                _SelectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.UpdateSpCodes(USysInfo.DBCode, USysInfo.LgIndex, this.GpCode, SpCodeList, flag,
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
            this.SpCodeList.Clear();
            foreach (V_B_Supplier t in this.DContextList)
            {
                t.IsSelected = true;
                SpCodeList.Add(t.SpCode);
            }
            this.UpdateSpCodes(true, true);
        }

        /////////////////////////////////////////////////

        protected override void ExecuteCmdAllUnAssign()
        {
            base.ExecuteCmdAllUnAssign();
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this.SpCodeList.Clear();
            foreach (V_B_Supplier t in this.DContextList)
            {
                t.IsSelected = false;
                SpCodeList.Add(t.SpCode);
            }
            this.UpdateSpCodes(false, true);
        }

        #endregion

    }
}
