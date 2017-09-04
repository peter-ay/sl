
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
using System;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using ERP.Web.DomainService.Bill;
using ERP.View;
using ERP.Web.DomainService.Erp;
using System.Windows;

namespace ERP.ViewModel
{
    public class VMWare_Report_Stocks_Lens_XY_List : VMList
    {
        #region SearchCondition

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private string _WhCodeSelected = "";
        public string WhCodeSelected
        {
            get { return _WhCodeSelected; }
            set { _WhCodeSelected = value; RaisePropertyChanged("WhCodeSelected"); }
        }

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _LensCodeSelected = "";
        public string LensCodeSelected
        {
            get { return _LensCodeSelected; }
            set { _LensCodeSelected = value; RaisePropertyChanged("LensCodeSelected"); }
        }

        private string _CYL = "CYL";
        public string CYL
        {
            get { return _CYL; }
            set { _CYL = value; RaisePropertyChanged("CYL"); }
        }

        private string _F_LR = "";
        public string F_LR
        {
            get { return _F_LR; }
            set { _F_LR = value; RaisePropertyChanged("F_LR"); }
        }

        //SIndexWhCode
        private int _SIndexWhCode = -1;
        public int SIndexWhCode
        {
            get { return _SIndexWhCode; }
            set { _SIndexWhCode = value; RaisePropertyChanged("SIndexWhCode"); }
        }

        #endregion

        private ObservableCollection<V_Ware_Report_Stocks_Lens_XY> _SourceTree = new ObservableCollection<V_Ware_Report_Stocks_Lens_XY>();
        public ObservableCollection<V_Ware_Report_Stocks_Lens_XY> SourceTree
        {
            get
            {
                return _SourceTree;
            }
            set
            {
                _SourceTree = value;
                RaisePropertyChanged("SourceTree");
            }
        }

        private V_Ware_Report_Stocks_Lens_XY _SelectedItem;
        public new V_Ware_Report_Stocks_Lens_XY SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
            }
        }

        private ObservableCollection<ComXYInputDataSource> _XYSource = new ObservableCollection<ComXYInputDataSource>();
        public ObservableCollection<ComXYInputDataSource> XYSource
        {
            get { return _XYSource; }
            set
            {
                _XYSource = value;
                RaisePropertyChanged<ObservableCollection<ComXYInputDataSource>>(() => this.XYSource);
            }
        }

        private ComXYInputMainDataSource _DContextMain = new ComXYInputMainDataSource();
        public new ComXYInputMainDataSource DContextMain
        {
            get { return _DContextMain; }
            set
            {
                _DContextMain = value;
                RaisePropertyChanged<ComXYInputMainDataSource>(() => this.DContextMain);
            }
        }

        ObservableCollection<ComXYInputListFormat> _ObservableCollectionXY = new ObservableCollection<ComXYInputListFormat>();
        public ObservableCollection<ComXYInputListFormat> ObservableCollectionXY
        {
            get { return _ObservableCollectionXY; }
        }

        private List<Ware_Stokc_Lens_Item> _SelectedItemTree = new List<Ware_Stokc_Lens_Item>();

        public VMWare_Report_Stocks_Lens_XY_List()
            : base("KeyCode", "Ware_Report_Stocks_Lens_XY", pageSize1: 0)
        {
            this.IsShowExportBool = true;

            if (ComHelpWhCode.UHV_B_Warehouse_Browse.Count > 0)
            {
                this.SIndexWhCode = 0;
                this.WhCode = ComHelpWhCode.UHV_B_Warehouse_Browse[0].WhCode;
                this.WhCodeSelected = this.WhCode;
            }

        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.LensCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();

            if (this.WhCode == "")
            {
                this.WhCode = "-99";
                this.WhCodeSelected = "-99";
            }

            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
        }

        protected override void OnLoadMainBegin()
        {
            this.SourceTree.Clear();
            this.SourceTree.Add(new V_Ware_Report_Stocks_Lens_XY() { KeyCode = ErpUIText.Get("ERP_Loading") });
            this._SelectedItemTree.Clear();
        }

        protected override void OnLoadMainEnd()
        {
            var items = this.DContextList;
            this.SourceTree.Clear();
            foreach (V_Ware_Report_Stocks_Lens_XY item in items)
            {
                if (!string.IsNullOrEmpty(item.PCode)) continue;
                item.F_Explan = true;
                item.Children = GetChild(items, item.KeyCode);
                item.Qty = item.Children.Sum(it => it.Qty);
                if (item.Qty > 0)
                    this.SourceTree.Add(item);
            }
        }

        private List<V_Ware_Report_Stocks_Lens_XY> GetChild(System.Collections.IEnumerable items, string funParentID)
        {
            List<V_Ware_Report_Stocks_Lens_XY> t = new List<V_Ware_Report_Stocks_Lens_XY>();
            foreach (V_Ware_Report_Stocks_Lens_XY item in items)
            {
                if (item.PCode == funParentID)
                {
                    item.Children = GetChild(items, item.KeyCode);
                    if (item.CodeLevel != 4)
                        item.Qty = item.Children.Sum(it => it.Qty);
                    if (item.Qty > 0)
                        t.Add(item);
                }
            }
            return t;
        }

        private void ChangeSelectedItem()
        {
            if (this._SelectedItem == null || this._SelectedItem.F_Lens != 1) return;
            this.LensCodeSelected = this.SelectedItem.KeyCode;
            this.WhCodeSelected = this.SelectedItem.WhCode;
            this.DContextMain.LensCode = this.LensCodeSelected;
            this.F_LR = this.SelectedItem.F_LR;
            this.LoadDetail();
        }

        private RelayCommand<V_Ware_Report_Stocks_Lens_XY> _CmdShowXYDetail;

        /// <summary>
        /// Gets the CmdOpenFuns.
        /// </summary>
        public RelayCommand<V_Ware_Report_Stocks_Lens_XY> CmdShowXYDetail
        {
            get
            {
                return _CmdShowXYDetail
                    ?? (_CmdShowXYDetail = new RelayCommand<V_Ware_Report_Stocks_Lens_XY>(
                    (obj) =>
                    {
                        obj.F_Explan = !obj.F_Explan;
                        if (this.SelectedItem == obj || obj.F_Lens != 1) return;
                        this.SelectedItem = obj;
                        this.LensCodeSelected = this.SelectedItem.KeyCode;
                        this.WhCodeSelected = this.SelectedItem.WhCode;
                        this.DContextMain.LensCode = this.LensCodeSelected;
                        this.F_LR = this.SelectedItem.F_LR;
                        this.LoadDetail();
                    }));
            }
        }

        private void LoadDetail()
        {
            var _DDS = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Ware_Report_Stocks_Lens_DetailList", _DDS_LoadedData, true);
            var _Str = USptstr.Str1 + "F_LoadXY" + USptstr.Str2 + this.WhCodeSelected + this.LensCodeSelected + this.F_LR;
            _DDS.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = _Str });
            this.IsBusy = true;
            _DDS.Load();
        }

        private void _DDS_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            this.IsBusy = false;

            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            var _Items = e.Entities;

            ComXYInputListFormat _item = null;
            ObservableCollectionXY.Clear();
            foreach (V_Ware_Report_Stocks_Lens_Detail item in _Items)
            {
                _item = new ComXYInputListFormat()
                        {
                            SubID = 1,
                            SPH = item.SPH.Value,
                            CYL = item.CYL.Value,
                            X_ADD = item.X_ADD.Value,
                            Qty = item.Stocks.Value,
                        };
                ObservableCollectionXY.Add(_item);
            }

            this.XYLoad();
        }

        int _CSPH1 = -1;
        int _CSPH2 = -1;
        private void XYLoad()
        {
            var _LensCodeInput = this.DContextMain.LensCode.MyStr();
            //this.IsShowWhCode = Visibility.Collapsed;
            //this.IsShowLR = Visibility.Collapsed;
            this.CYL = "CYL";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(item => item.LensCode.ToUpper().Trim() == _LensCodeInput).FirstOrDefault();
            if (_Rs == null)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_LensCodeMiss") + _LensCodeInput);
                XYSource.Clear();
                return;
            }

            this.DContextMain.LensCodeSelected = _Rs.LensCode;
            this.DContextMain.LensNameSelected = _Rs.LensName;
            this.DContextMain.F_LR = _Rs.F_LR.Value;
            this.DContextMain.F_CA = _Rs.F_CA.Value;

            if (_Rs.F_LR.Value)
            {

            }
            else
            {
                this.DContextMain.LR = "";
            }

            if (_Rs.F_CA.Value)
            {
                this.CYL = "ADD";
            }
            else
            {
                this.CYL = "CYL";
            }

            if (_Rs.F_LR.Value && string.IsNullOrEmpty(this.DContextMain.LR))
            {
                this.DContextMain.LR = "R";
            }

            var _SPH1VS = 0;
            var _SPH2VS = 0;
            var _CYL1VS = 0;
            var _CYL2VS = 0;
            var _X_ADD1VS = 0;
            var _X_ADD2VS = 0;

            try { _SPH1VS = Convert.ToInt32(this.ObservableCollectionXY.Min(it => it.SPH).ToString()); }
            catch { }
            try { _SPH2VS = Convert.ToInt32(this.ObservableCollectionXY.Max(it => it.SPH).ToString()); }
            catch { }
            try { _CYL1VS = Convert.ToInt32(this.ObservableCollectionXY.Min(it => it.CYL).ToString()); }
            catch { }
            try { _CYL2VS = Convert.ToInt32(this.ObservableCollectionXY.Max(it => it.CYL).ToString()); }
            catch { }
            try { _X_ADD1VS = Convert.ToInt32(this.ObservableCollectionXY.Min(it => it.X_ADD).ToString()); }
            catch { }
            try { _X_ADD2VS = Convert.ToInt32(this.ObservableCollectionXY.Max(it => it.X_ADD).ToString()); }
            catch { }

            var _SPH1 = _SPH1VS;
            var _SPH2 = _SPH2VS;

            var _CYL1 = _CYL1VS;
            var _CYL2 = _CYL2VS;
            if (_Rs.F_LR.Value)
            {
                _CYL1 = _X_ADD1VS;
                _CYL2 = _X_ADD2VS;
            }

            if (_SPH1 > 0)
            { _SPH1 = 0; }
            else if (_SPH2 < 0)
            { _SPH2 = 0; }
            else
            { }

            if (_CYL1 > 0)
            { _CYL1 = 0; }
            else if (_CYL2 < 0)
            { _CYL2 = 0; }
            else
            { }

            this.LoadXY(_SPH1, _SPH2, _CYL1, _CYL2);
        }

        private void LoadXY(int sPH1, int sPH2, int cYL1, int cYL2)
        {
            //每次都刷新 
            _CSPH1 = -1; _CSPH2 = -1;
            /////////////////////////////////////
            if (_CSPH1 != sPH1 || _CSPH2 != sPH2)
            {
                _CSPH1 = sPH1;
                _CSPH2 = sPH2;
                XYSource.Clear();
                #region SPH排序
                if (sPH2 <= 0)
                {
                    for (int i = sPH2; i >= sPH1; i -= 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                else if (sPH1 >= 0)
                {
                    for (int i = sPH1; i <= sPH2; i += 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                else
                {
                    for (int i = 0; i >= sPH1; i -= 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                    for (int i = 25; i <= sPH2; i += 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                XYSource.Add(new ComXYInputDataSource() { C0 = -1 });
                #endregion
            }
            DContextMain.CYL1 = cYL1;
            DContextMain.CYL2 = cYL2;
            Messenger.Default.Send<ComXYInputMainDataSource>((DContextMain), this.VMNameAuthority + "_XY");
        }


        #region WhCodeChange

        private RelayCommand<V_B_Warehouse> _CmdComBoxWhCodeChange;

        /// <summary>
        /// Gets the CmdComBoxWhCodeChange.
        /// </summary>
        public RelayCommand<V_B_Warehouse> CmdComBoxWhCodeChange
        {
            get
            {
                return _CmdComBoxWhCodeChange
                    ?? (_CmdComBoxWhCodeChange = new RelayCommand<V_B_Warehouse>(ExecuteCmdComBoxWhCodeChange));
            }
        }

        protected virtual void ExecuteCmdComBoxWhCodeChange(V_B_Warehouse paramater)
        {
            if (this.WhCodeSelected != paramater.WhCode)
            {
                this.WhCode = paramater.WhCode;
                this.WhCodeSelected = paramater.WhCode;
                this.Load();
            }
        }

        #endregion


        #region TreeChecked

        private RelayCommand<V_Ware_Report_Stocks_Lens_XY> _CmdTreeCheck;

        /// <summary>
        /// Gets the CmdTreeCheck.
        /// </summary>
        public RelayCommand<V_Ware_Report_Stocks_Lens_XY> CmdTreeCheck
        {
            get
            {
                return _CmdTreeCheck
                    ?? (_CmdTreeCheck = new RelayCommand<V_Ware_Report_Stocks_Lens_XY>(ExecuteCmdTreeCheck));
            }
        }

        private void ExecuteCmdTreeCheck(V_Ware_Report_Stocks_Lens_XY obj)
        {
            if (obj.F_Lens == 1)
            {
                var _Item = this._SelectedItemTree.Where(it => it.WhCode == obj.WhCode && it.LensCode == obj.KeyCode && it.F_LR == obj.F_LR).FirstOrDefault();
                if (obj.IsSelected && _Item == null)
                {
                    var _Item2 = new Ware_Stokc_Lens_Item()
                    {
                        WhCode = obj.WhCode,
                        LensCode = obj.KeyCode,
                        F_LR = obj.F_LR
                    };
                    this._SelectedItemTree.Add(_Item2);
                }
                else
                {
                    this._SelectedItemTree.Remove(_Item);
                }
            }
            SetChildIsSelect(obj, obj.IsSelected);
        }

        private void SetChildIsSelect(V_Ware_Report_Stocks_Lens_XY obj, bool isSelect)
        {
            obj.Children.ForEach(_It =>
            {
                _It.IsSelected = isSelect;

                if (_It.F_Lens == 1)
                {
                    var _Item = this._SelectedItemTree.Where(it => it.WhCode == _It.WhCode && it.LensCode == _It.KeyCode && it.F_LR == _It.F_LR).FirstOrDefault();
                    if (_It.IsSelected && _Item == null)
                    {
                        var _Item2 = new Ware_Stokc_Lens_Item()
                        {
                            WhCode = _It.WhCode,
                            LensCode = _It.KeyCode,
                            F_LR = _It.F_LR
                        };
                        this._SelectedItemTree.Add(_Item2);
                    }
                    else
                    {
                        this._SelectedItemTree.Remove(_Item);
                    }
                }

                SetChildIsSelect(_It, isSelect);
            });
        }
        #endregion

        protected override void Export()
        {
            if (this._ExportModel == 2 && this._SelectedItemTree.Count == 0) return;
            //if (this._ExportModel == 2 && this._SelectedItemTree.Count > 30)
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Err_MoreThan30"));
            //    return;
            //}

            List<string> _ExportItems = new List<string>();
            string _Str = "";
            if (this._ExportModel == 2)
            {
                this._SelectedItemTree.ForEach(it =>
                    {
                        _Str = it.WhCode + it.LensCode + it.F_LR;
                        _ExportItems.Add(_Str);
                    });
            }
            else
            {
                _Str = "WhCode";
                _ExportItems.Add(_Str);

                _Str = this.WhCodeSelected;
                _ExportItems.Add(_Str);
            }

            DSErp _DS = new DSErp();
            this.IsBusy = true;
            var _ID = UReportID.ExcelFileName;
            var p = _DS.GetV_Ware_Report_Stocks_Lens_XYListExportQuery(USysInfo.DBCode, USysInfo.LgIndex, _ID, _ExportItems);
            _DS.Load(p, geted =>
                {
                    this.IsBusy = false;
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    ComOpenURL.Open(_ID);
                }, null);
        }

        #region CmdRBExportModel

        private int _ExportModel = 1;
        //CmdRBExportModel
        private RelayCommand<string> _CmdRBExportModel;

        /// <summary>
        /// Gets the CmdOpenFuns.
        /// </summary>
        public RelayCommand<string> CmdRBExportModel
        {
            get
            {
                return _CmdRBExportModel
                    ?? (_CmdRBExportModel = new RelayCommand<string>(
                    (obj) =>
                    {
                        try
                        {
                            _ExportModel = Convert.ToInt32(obj);
                        }
                        catch { }
                    }));
            }
        }

        #endregion


        #region CmdMinRight


        private RelayCommand _CmdMinRight;

        /// <summary>
        /// Gets the CmdMinRight.
        /// </summary>
        public RelayCommand CmdMinRight
        {
            get
            {
                return _CmdMinRight
                    ?? (_CmdMinRight = new RelayCommand(ExecuteCmdMinRight));
            }
        }

        private GridLength _RightWidth = GridLength.Auto;
        public GridLength RightWidth
        {
            get { return _RightWidth; }
            set { _RightWidth = value; RaisePropertyChanged("RightWidth"); }
        }
        private void ExecuteCmdMinRight()
        {
            this.RightWidth = this.RightWidth == GridLength.Auto ? new GridLength(0) : GridLength.Auto;
        }

        #endregion
    }

    public class Ware_Stokc_Lens_Item
    {
        public string WhCode
        {
            get;
            set;
        }

        public string LensCode
        {
            get;
            set;
        }

        public string F_LR
        {
            get;
            set;
        }
    }
}
