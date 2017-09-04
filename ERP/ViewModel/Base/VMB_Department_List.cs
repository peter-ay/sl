
using System.Collections.ObjectModel;
using ERP.Web.Entity;
using ERP.Common;
using System.Collections.Generic;
using System.Linq;

namespace ERP.ViewModel
{
    public class VMB_Department_List : VMList
    {
        private ObservableCollection<V_B_Department> _SourceTree = new ObservableCollection<V_B_Department>();
        public ObservableCollection<V_B_Department> SourceTree
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

        private V_B_Department _SelectedItem;
        public new V_B_Department SelectedItem
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

        public VMB_Department_List()
            : base("DpCode", "B_Department", "dpCode", "dpName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void OnLoadMainBegin()
        {
            this.SourceTree.Clear();
            this.SourceTree.Add(new V_B_Department() { DpName = ErpUIText.Get("ERP_Loading") });
        }

        protected override void OnLoadMainEnd()
        {
            var items = this.DContextList;
            this.SourceTree.Clear();

            bool _ftemp = false;

            foreach (V_B_Department item in items)
            {
                if (!string.IsNullOrEmpty(((V_B_Department)item).PCode))
                {
                    _ftemp = false;
                    foreach (V_B_Department item2 in items)
                    {
                        if (item2.DpCode == item.PCode)
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

        private void InitChild(V_B_Department item, System.Collections.IEnumerable items)
        {
            V_B_Department it;
            it = new V_B_Department();
            ComCopyProperties.Copy(it, item);
            it.F_Explan = true;
            it.Children = GetChild(items, ((V_B_Department)item).DpCode);
            this.SourceTree.Add(it);
        }

        private System.Collections.Generic.List<V_B_Department> GetChild(System.Collections.IEnumerable items, string DpCode)
        {
            List<V_B_Department> t = new List<V_B_Department>();
            foreach (V_B_Department item in items)
            {
                if (item.PCode == DpCode)
                {
                    item.F_Explan = true;
                    item.Children = GetChild(items, item.DpCode);
                    t.Add(item);
                }
            }
            return t;
        }
    }
}
