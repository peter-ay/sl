
using ERP.Common;
using ERP.Utility;
using System.Collections.ObjectModel;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
namespace ERP.ViewModel
{
    public class VMCH_PDChoose : VMListCH
    {
        #region Property

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

        private string _SelectedItem2 = "";
        public string SelectedItem2
        {
            get { return _SelectedItem2; }
            set { _SelectedItem2 = value; RaisePropertyChanged("SelectedItem2"); }
        }

        #endregion

        public VMCH_PDChoose()
            : base("WhCode")
        {
            if (ComHelpWhCode.UHV_B_Warehouse_Browse.Count > 0)
            {
                this.SIndexWhCode = 0;
                this.WhCode = ComHelpWhCode.UHV_B_Warehouse_Browse[0].WhCode;
                this.WhCodeSelected = this.WhCode;
            }
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_Ware_Report_Stocks_Lens_XYList";
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

        #region TreeClick

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
                        this.F_LR = this.SelectedItem.F_LR;
                        this.SelectedItem2 = this.WhCodeSelected + "-" + this.LensCodeSelected + "-" + this.F_LR;
                    }));
            }
        }

        #endregion

    }
}