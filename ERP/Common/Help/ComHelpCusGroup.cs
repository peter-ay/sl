using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpCusGroup
    {
        private static ObservableCollection<V_Sale_PriceContract_CusGroup> uHV_Sale_PriceContract_CusGroup = new ObservableCollection<V_Sale_PriceContract_CusGroup>();
        public static ObservableCollection<V_Sale_PriceContract_CusGroup> UHV_Sale_PriceContract_CusGroup
        {
            get
            {
                return uHV_Sale_PriceContract_CusGroup;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_Sale_PriceContract_CusGroupAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_Sale_PriceContract_CusGroup.Clear();
            foreach (V_Sale_PriceContract_CusGroup t in e.Entities)
            {
                uHV_Sale_PriceContract_CusGroup.Add(t);
            }
        }
    }
}
