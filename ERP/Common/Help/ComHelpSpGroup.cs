using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpSpGroup
    {
        private static ObservableCollection<V_Pur_PriceContract_SpGroup> uHV_Pur_PriceContract_SpGroup = new ObservableCollection<V_Pur_PriceContract_SpGroup>();
        public static ObservableCollection<V_Pur_PriceContract_SpGroup> UHV_Pur_PriceContract_SpGroup
        {
            get
            {
                return uHV_Pur_PriceContract_SpGroup;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_Pur_PriceContract_SpGroupAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_Pur_PriceContract_SpGroup.Clear();
            foreach (V_Pur_PriceContract_SpGroup t in e.Entities)
            {
                uHV_Pur_PriceContract_SpGroup.Add(t);
            }
        }
    }
}
