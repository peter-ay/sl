using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpForeignCurrCode
    {
        private static ObservableCollection<V_B_ForeignCurrency> uHV_B_ForeignCurrency = new ObservableCollection<V_B_ForeignCurrency>();
        public static ObservableCollection<V_B_ForeignCurrency> UHV_B_ForeignCurrency
        {
            get
            {
                return uHV_B_ForeignCurrency;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_ForeignCurrencyAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_B_ForeignCurrency.Clear();
            foreach (V_B_ForeignCurrency t in e.Entities)
            {
                uHV_B_ForeignCurrency.Add(t);
            }
        }
    }
}
