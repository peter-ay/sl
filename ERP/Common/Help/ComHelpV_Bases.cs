using ERP.Web.Entity;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComHelpV_Bases
    {
        private static ObservableCollection<V_B_WareHouse> _UV_B_WareHouse = new ObservableCollection<V_B_WareHouse>();
        public static ObservableCollection<V_B_WareHouse> UV_B_WareHouse
        {
            get
            {
                return _UV_B_WareHouse;
            }
        }

        private static ObservableCollection<V_B_Supplier> _UV_B_Supplier = new ObservableCollection<V_B_Supplier>();
        public static ObservableCollection<V_B_Supplier> UV_B_Supplier
        {
            get
            {
                return _UV_B_Supplier;
            }
        }


        public static void Load()
        {
            LoadWH();
            LoadSP();
        }

        private static void LoadSP()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_SupplierHelpListQuery", SP_LoadedData, true);
            dds.Load();
        }

        private static void SP_LoadedData(object s, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UV_B_Supplier.Clear();
            foreach (V_B_Supplier t in e.Entities)
            {
                _UV_B_Supplier.Add(t);
            }
        }

        private static void LoadWH()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_WareHouseHelpListQuery", WH_LoadedData, true);
            dds.Load();
        }

        private static void WH_LoadedData(object s, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UV_B_WareHouse.Clear();
            foreach (V_B_WareHouse t in e.Entities)
            {
                _UV_B_WareHouse.Add(t);
            }
        }


    }
}
