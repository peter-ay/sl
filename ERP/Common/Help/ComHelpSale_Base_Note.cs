using ERP.Web.Entity;
using System.Collections.ObjectModel;

namespace ERP.Common
{
    public class ComHelpSale_Base_Note
    {
        private static ObservableCollection<V_Sale_Base_Note> _UHV_Sale_Base_Note = new ObservableCollection<V_Sale_Base_Note>();
        public static ObservableCollection<V_Sale_Base_Note> UHV_Sale_Base_Note
        {
            get
            {
                return _UHV_Sale_Base_Note;
            }
        }

        public static void Load()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_B_NoteHelpListQuery", dds_LoadedData, true);
            dds.SortDescriptors.Add(new System.Windows.Controls.SortDescriptor() { PropertyPath = "SN", Direction = System.ComponentModel.ListSortDirection.Ascending });
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_Sale_Base_Note.Clear();
            foreach (V_Sale_Base_Note t in e.Entities)
            {
                _UHV_Sale_Base_Note.Add(t);
            }
        }
    }
}
