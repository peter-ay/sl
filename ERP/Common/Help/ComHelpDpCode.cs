using System.Collections.ObjectModel;
using ERP.Utility;
using ERP.Web.Entity;
using System.Windows.Controls;

namespace ERP.Common
{
    public class ComHelpDpCode
    {
        private static ObservableCollection<V_B_Department> _UHV_B_Department = new ObservableCollection<V_B_Department>();
        public static ObservableCollection<V_B_Department> UHV_B_Department
        {
            get
            {
                return _UHV_B_Department;
            }
        }

        private static ObservableCollection<V_B_Department> _UHV_B_DepartmentCX = new ObservableCollection<V_B_Department>();
        public static ObservableCollection<V_B_Department> UHV_B_DepartmentCX
        {
            get
            {
                return _UHV_B_DepartmentCX;
            }
        }

        private static ObservableCollection<V_B_Department> _UHV_B_DepartmentRightBrowse = new ObservableCollection<V_B_Department>();
        public static ObservableCollection<V_B_Department> UHV_B_DepartmentRightBrowse
        {
            get
            {
                return _UHV_B_DepartmentRightBrowse;
            }
        }

        private static ObservableCollection<V_B_Department> _UHV_B_DepartmentRightBrowseCX = new ObservableCollection<V_B_Department>();
        public static ObservableCollection<V_B_Department> UHV_B_DepartmentRightBrowseCX
        {
            get
            {
                return _UHV_B_DepartmentRightBrowseCX;
            }
        }

        public static void Load()
        {
            Load1();
            Load2();
        }

        private static void Load1()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_DepartmentAllList, dds_LoadedData, true);
            dds.Load();
        }

        private static void Load2()
        {
            var dds = ComDDSFactory.Get(ComDSFactory.Erp, UDSMethods.V_B_DepartmentRightBrowseList, ddsBrowseRight_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "gpID", Value = USysInfo.F_Manager || USysInfo.F_DpCodeBrowse ? -99 : USysInfo.GpID });
            dds.Load();
        }

        private static void dds_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Department.Clear();
            _UHV_B_DepartmentCX.Clear();
            foreach (V_B_Department t in e.Entities)
            {
                _UHV_B_Department.Add(t);
                if (t.F_CX == true)
                {
                    _UHV_B_DepartmentCX.Add(t);
                }
            }
        }

        private static void ddsBrowseRight_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_DepartmentRightBrowse.Clear();
            _UHV_B_DepartmentRightBrowseCX.Clear();
            foreach (V_B_Department t in e.Entities)
            {
                _UHV_B_DepartmentRightBrowse.Add(t);
                if (t.F_CX == true)
                {
                    _UHV_B_DepartmentRightBrowseCX.Add(t);
                }
            }
        }
    }
}
