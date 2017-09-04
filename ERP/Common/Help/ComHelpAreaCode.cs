using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpAreaCode
    {
        private static ObservableCollection<V_B_Area> uHV_B_Area = new ObservableCollection<V_B_Area>();
        public static ObservableCollection<V_B_Area> UHV_B_Area
        {
            get
            {
                return uHV_B_Area;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_AreaAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_B_Area.Clear();
            foreach (V_B_Area t in e.Entities)
            {
                uHV_B_Area.Add(t);
            }
        }
    }
}
