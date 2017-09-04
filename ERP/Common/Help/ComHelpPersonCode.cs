using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpPersonCode
    {
        private static ObservableCollection<V_B_Person> uHV_B_Person = new ObservableCollection<V_B_Person>();
        public static ObservableCollection<V_B_Person> UHV_B_Person
        {
            get
            {
                return uHV_B_Person;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_PersonAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            uHV_B_Person.Clear();
            foreach (V_B_Person t in e.Entities)
            {
                uHV_B_Person.Add(t);
            }
        }
    }
}
