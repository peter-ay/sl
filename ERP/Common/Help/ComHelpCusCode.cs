using System.Collections.ObjectModel;
using System.Windows.Controls;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpCusCode
    {
        private static ObservableCollection<V_B_Customer> _UHV_B_Customer = new ObservableCollection<V_B_Customer>();
        public static ObservableCollection<V_B_Customer> UHV_B_Customer
        {
            get
            {
                return _UHV_B_Customer;
            }
        }
        // 
        private static ObservableCollection<V_B_Customer> _UHV_B_CustomerRightBrowse = new ObservableCollection<V_B_Customer>();
        public static ObservableCollection<V_B_Customer> UHV_B_CustomerRightBrowse
        {
            get
            {
                return _UHV_B_CustomerRightBrowse;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_CustomerAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_CustomerRightBrowse, ddsSmartBrowseRight_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager || USysInfo.F_CusCodeBrowse ? -99 : USysInfo.GpID });
            dds.Load();
        }

        private static void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Customer.Clear();
            foreach (V_B_Customer t in e.Entities)
            {
                _UHV_B_Customer.Add(t);
            }
        }

        private static void ddsSmartBrowseRight_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            _UHV_B_CustomerRightBrowse.Clear();
            foreach (V_B_Customer t in e.Entities)
            {
                _UHV_B_CustomerRightBrowse.Add(t);
            }

            //USysFlag.IsReadyCusCodeSmartBrowseRight = true;
        }

    }
}
