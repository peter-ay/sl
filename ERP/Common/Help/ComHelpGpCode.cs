using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpGpCode
    {
        private static ObservableCollection<V_S_UserGroup> _UHV_S_UserGroup = new ObservableCollection<V_S_UserGroup>();
        public static ObservableCollection<V_S_UserGroup> UHV_S_UserGroup
        {
            get
            {
                return _UHV_S_UserGroup;
            }
        }

        private static ObservableCollection<V_S_UserGroup> _UHV_S_UserGroupByDataBase = new ObservableCollection<V_S_UserGroup>();
        public static ObservableCollection<V_S_UserGroup> UHV_S_UserGroupByDataBase
        {
            get
            {
                return _UHV_S_UserGroupByDataBase;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_UserGroupAllList, dds_LoadedData);
            dds.Load();

        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_UserGroupByDBCodeList, dds_LoadedDataByDataBase, true);
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_S_UserGroup.Clear();
            foreach (V_S_UserGroup t in e.Entities)
            {
                _UHV_S_UserGroup.Add(t);
            }
        }

        private static void dds_LoadedDataByDataBase(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_S_UserGroupByDataBase.Clear();
            foreach (V_S_UserGroup t in e.Entities)
            {
                _UHV_S_UserGroupByDataBase.Add(t);
            }
        }
    }
}
