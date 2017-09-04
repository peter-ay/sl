using System.Collections.ObjectModel;
using ERP.Web.Entity;
using ERP.Common;
using System.Collections.Generic;
using System.Linq;
using ERP.Utility;
using System.Windows;

namespace ERP.ViewModel
{
    public class VMB_Area_List : VMList
    {
        private ObservableCollection<V_B_Area> _SourceTree = new ObservableCollection<V_B_Area>();
        public ObservableCollection<V_B_Area> SourceTree
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

        private V_B_Area _SelectedItem;
        public new V_B_Area SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public VMB_Area_List()
            : base("AreaCode", "B_Area", "areaCode", "areaName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void OnLoadMainBegin()
        {
            this.SourceTree.Clear();
            this.SourceTree.Add(new V_B_Area() { AreaName = ErpUIText.Get("ERP_Loading") });
        }

        protected override void OnLoadMainEnd()
        {
            var items = this.DContextList;
            this.SourceTree.Clear();

            bool _ftemp = false;

            foreach (V_B_Area item in items)
            {
                if (!string.IsNullOrEmpty(((V_B_Area)item).PCode))
                {
                    _ftemp = false;
                    foreach (V_B_Area item2 in items)
                    {
                        if (item2.AreaCode == item.PCode)
                        {
                            _ftemp = true;
                            break;
                        }
                    }
                    if (!_ftemp)
                    {
                        this.InitChild(item, items);
                    }
                }
                else
                {
                    this.InitChild(item, items);
                    continue;
                }
            }
        }

        private void InitChild(V_B_Area item, System.Collections.IEnumerable items)
        {
            V_B_Area it;
            it = new V_B_Area();
            ComCopyProperties.Copy(it, item);
            it.F_Explan = true;
            it.Children = GetChild(items, ((V_B_Area)item).AreaCode);
            this.SourceTree.Add(it);
        }

        private System.Collections.Generic.List<V_B_Area> GetChild(System.Collections.IEnumerable items, string deptCode)
        {
            List<V_B_Area> t = new List<V_B_Area>();
            foreach (V_B_Area item in items)
            {
                if (item.PCode == deptCode)
                {
                    item.F_Explan = true;
                    item.Children = GetChild(items, item.AreaCode);
                    t.Add(item);
                }
            }
            return t;
        }

        //protected override void Export()
        //{
        //    string _ID = "";
        //    var _Str = this.getExportWhereCondition(out _ID);
        //    ERP.Web.DomainService.Erp.DSErp _DS = new Web.DomainService.Erp.DSErp();

        //    var p = _DS.GetV_B_AreaListQuery(USysInfo.DBCode, _Str);
        //    _DS.Load(p, geted =>
        //    {
        //        if (geted.HasError)
        //        {
        //            MessageBox.Show(geted.Error.ToString());
        //            geted.MarkErrorAsHandled();
        //            return;
        //        }
        //        ComOpenURL.Open(_ID + ".xls");
        //    }, null);
        //}

    }
}
