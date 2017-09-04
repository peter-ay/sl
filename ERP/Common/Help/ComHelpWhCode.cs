using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComHelpWhCode
    {
        private static ObservableCollection<V_B_Warehouse> _UHV_B_Warehouse = new ObservableCollection<V_B_Warehouse>();
        public static ObservableCollection<V_B_Warehouse> UHV_B_Warehouse
        {
            get
            {
                return _UHV_B_Warehouse;
            }
        }

        private static ObservableCollection<V_B_Warehouse> _UHV_B_Warehouse_Browse = new ObservableCollection<V_B_Warehouse>();
        public static ObservableCollection<V_B_Warehouse> UHV_B_Warehouse_Browse
        {
            get
            {
                return _UHV_B_Warehouse_Browse;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }


        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_WarehouseAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_Warehouse_BrowseList, ddsBrowse_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager || USysInfo.F_WhCodeBrowse ? -99 : USysInfo.GpID });
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Warehouse.Clear();
            foreach (V_B_Warehouse t in e.Entities)
            {
                _UHV_B_Warehouse.Add(t);
            }
        }

        private static void ddsBrowse_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Warehouse_Browse.Clear();
            foreach (V_B_Warehouse t in e.Entities)
            {
                _UHV_B_Warehouse_Browse.Add(t);
            }
        }
    }
}
