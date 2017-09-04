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
    public class VMB_Supplier_Default_Lens : VMList
    {
        //private string _billcode = "";
        private V_B_Material_Lens _SelectedItem;
        private List<string> cusCodeList = new List<string>();
        private Lazy<DSB_Supplier> DS_Bill = new Lazy<DSB_Supplier>();

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

        private string _SpCode = "";
        public string SpCode
        {
            get { return _SpCode; }
            set { _SpCode = value; RaisePropertyChanged("SpCode"); }
        }

        private string _SpName = "";
        public string SpName
        {
            get { return _SpName; }
            set { _SpName = value; RaisePropertyChanged("SpName"); }
        }

        #endregion


        public VMB_Supplier_Default_Lens()
            : base("LensCode", "B_Material_Lens", "lensCode", "lensName")
        {
            IsChildWindow = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "SpCode" + USptstr.Str2 + this.SpCode.MyStr();
            _SWhere += USptstr.Str1 + "SDIncludeState" + USptstr.Str2 + this._ConInclude;
        }

        protected override void OnLoadMainEnd()
        {
            var ds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Supplier_Default_LensListQuery", ReSetLensCode, true);
            var _W = USptstr.Str1 + "SpCode" + USptstr.Str2 + this.SpCode.MyStr();
            ds.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = _W });
            this.IsBusy = true;
            ds.Load();
        }

        private void ReSetLensCode(object s, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_B_Supplier_Default_Lens y in items2)
            {
                foreach (V_B_Material_Lens item in DContextList)
                {
                    if (item.LensCode.ToUpper() == y.LensCode.ToUpper())
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
            this.SpCode = _Str[1].ToString();
            this.SpName = _Str[2].ToString();
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
        private string _tbName = "B_Supplier_Default_CusGroup_LensCode";

        protected override void Export()
        {
            ComExport.Export(_tbName, " SpCode='" + this.SpCode + "'", " LensCode");
        }

        protected override void Import()
        {
            ComImport.Import(_tbName, this.SpCode);
        }

        /////////////////////////////////////////////////

        private RelayCommand<V_B_Material_Lens> _CmdLensCodeCheckClick;

        /// <summary>
        /// Gets the CmdLensCodeCheckClick.
        /// </summary>
        public RelayCommand<V_B_Material_Lens> CmdLensCodeCheckClick
        {
            get
            {
                return _CmdLensCodeCheckClick
                    ?? (_CmdLensCodeCheckClick = new RelayCommand<V_B_Material_Lens>(ExecuteCmdLensCodeCheckClick));
            }
        }

        private void ExecuteCmdLensCodeCheckClick(V_B_Material_Lens parameter)
        {
            this.PrepareUpdate(parameter);
        }

        private void PrepareUpdate(V_B_Material_Lens parameter)
        {
            this._SelectedItem = parameter;
            cusCodeList.Clear();
            cusCodeList.Add(_SelectedItem.LensCode);
            this.UpdateLensCodes(_SelectedItem.IsSelected);
        }

        private void UpdateLensCodes(bool flag, bool isShowBusy = false)
        {
            if (isShowBusy)
                this.IsBusy = true;
            else
                _SelectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.UpdateLensCodes(USysInfo.DBCode, USysInfo.LgIndex, this.SpCode, cusCodeList, flag,
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
            foreach (V_B_Material_Lens t in this.DContextList)
            {
                t.IsSelected = true;
                cusCodeList.Add(t.LensCode);
            }
            this.UpdateLensCodes(true, true);
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
            foreach (V_B_Material_Lens t in this.DContextList)
            {
                t.IsSelected = false;
                cusCodeList.Add(t.LensCode);
            }
            this.UpdateLensCodes(false, true);
        }

        #endregion

    }
}
