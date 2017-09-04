using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpDBCode
    {
        private static ObservableCollection<V_S_DataBase> uHV_S_DataBase = new ObservableCollection<V_S_DataBase>();
        public static ObservableCollection<V_S_DataBase> UHV_S_DataBase
        {
            get
            {
                return uHV_S_DataBase;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_DataBaseAllList, dds_LoadedData);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_S_DataBase.Clear();
            foreach (V_S_DataBase t in e.Entities)
            {
                uHV_S_DataBase.Add(t);
            }
        }
    }
}
