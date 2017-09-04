using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComHelpSpCode
    {
        private static ObservableCollection<V_B_Supplier> uHV_B_Supplier = new ObservableCollection<V_B_Supplier>();
        public static ObservableCollection<V_B_Supplier> UHV_B_Supplier
        {
            get
            {
                return uHV_B_Supplier;
            }
        }
        // 
        private static ObservableCollection<V_B_Supplier> _UHV_B_SupplierRightBrowse = new ObservableCollection<V_B_Supplier>();
        public static ObservableCollection<V_B_Supplier> UHV_B_SupplierRightBrowse
        {
            get
            {
                return _UHV_B_SupplierRightBrowse;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_SupplierAllList, dds_LoadedData1, true);
            dds.Load();
        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_SupplierRightBrowse, ddsSmartBrowseRight_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager || USysInfo.F_SpCodeBrowse ? -99 : USysInfo.GpID });
            dds.Load();
        }

        private static void dds_LoadedData1(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_B_Supplier.Clear();
            foreach (V_B_Supplier t in e.Entities)
            {
                uHV_B_Supplier.Add(t);
            }
        }

        private static void ddsSmartBrowseRight_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            UHV_B_SupplierRightBrowse.Clear();
            foreach (V_B_Supplier t in e.Entities)
            {
                _UHV_B_SupplierRightBrowse.Add(t);
            }

            //USysFlag.IsReadyCusCodeSmartBrowseRight = true;
        }
    }
}
