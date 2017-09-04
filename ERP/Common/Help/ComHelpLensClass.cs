using System.Collections.ObjectModel;
using ERP.Web.Entity;

namespace ERP.Common
{
    public class ComHelpLensClass
    {
        private static ObservableCollection<V_B_Material_LensClass_Usage> _UHV_B_Material_LensClass_Usage = new ObservableCollection<V_B_Material_LensClass_Usage>();
        public static ObservableCollection<V_B_Material_LensClass_Usage> UHV_B_Material_LensClass_Usage
        {
            get
            {
                return _UHV_B_Material_LensClass_Usage;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_Brand> _UHV_B_Material_LensClass_Brand = new ObservableCollection<V_B_Material_LensClass_Brand>();
        public static ObservableCollection<V_B_Material_LensClass_Brand> UHV_B_Material_LensClass_Brand
        {
            get
            {
                return _UHV_B_Material_LensClass_Brand;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_Focus> _UHV_B_Material_LensClass_Focus = new ObservableCollection<V_B_Material_LensClass_Focus>();
        public static ObservableCollection<V_B_Material_LensClass_Focus> UHV_B_Material_LensClass_Focus
        {
            get
            {
                return _UHV_B_Material_LensClass_Focus;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_Index> _UHV_B_Material_LensClass_Index = new ObservableCollection<V_B_Material_LensClass_Index>();
        public static ObservableCollection<V_B_Material_LensClass_Index> UHV_B_Material_LensClass_Index
        {
            get
            {
                return _UHV_B_Material_LensClass_Index;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_Design> _UHV_B_Material_LensClass_Design = new ObservableCollection<V_B_Material_LensClass_Design>();
        public static ObservableCollection<V_B_Material_LensClass_Design> UHV_B_Material_LensClass_Design
        {
            get
            {
                return _UHV_B_Material_LensClass_Design;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_Materials> _UHV_B_Material_LensClass_Materials = new ObservableCollection<V_B_Material_LensClass_Materials>();
        public static ObservableCollection<V_B_Material_LensClass_Materials> UHV_B_Material_LensClass_Materials
        {
            get
            {
                return _UHV_B_Material_LensClass_Materials;
            }
        }

        private static ObservableCollection<V_B_Material_LensClass_DefaultCoating> _UHV_B_Material_LensClass_DefaultCoating = new ObservableCollection<V_B_Material_LensClass_DefaultCoating>();
        public static ObservableCollection<V_B_Material_LensClass_DefaultCoating> UHV_B_Material_LensClass_DefaultCoating
        {
            get
            {
                return _UHV_B_Material_LensClass_DefaultCoating;
            }
        }

        public static void Load()
        {
            var dds1 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_UsageAllList", dds_LoadedData1, true);
            dds1.Load();
            var dds2 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_BrandAllList", dds_LoadedData2, true);
            dds2.Load();
            var dds3 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_FocusAllList", dds_LoadedData3, true);
            dds3.Load();
            var dds4 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_IndexAllList", dds_LoadedData4, true);
            dds4.Load();
            var dds5 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_DesignAllList", dds_LoadedData5, true);
            dds5.Load();
            var dds6 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_MaterialsAllList", dds_LoadedData6, true);
            dds6.Load();
            var dds7 = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensClass_DefaultCoatingAllList", dds_LoadedData7, true);
            dds7.Load();
        }

        private static void dds_LoadedData1(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Usage.Clear();
            foreach (V_B_Material_LensClass_Usage t in e.Entities)
            {
                _UHV_B_Material_LensClass_Usage.Add(t);
            }
        }

        private static void dds_LoadedData2(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Brand.Clear();
            foreach (V_B_Material_LensClass_Brand t in e.Entities)
            {
                _UHV_B_Material_LensClass_Brand.Add(t);
            }
        }

        private static void dds_LoadedData3(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Focus.Clear();
            foreach (V_B_Material_LensClass_Focus t in e.Entities)
            {
                _UHV_B_Material_LensClass_Focus.Add(t);
            }
        }

        private static void dds_LoadedData4(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Index.Clear();
            foreach (V_B_Material_LensClass_Index t in e.Entities)
            {
                _UHV_B_Material_LensClass_Index.Add(t);
            }
        }

        private static void dds_LoadedData5(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Design.Clear();
            foreach (V_B_Material_LensClass_Design t in e.Entities)
            {
                _UHV_B_Material_LensClass_Design.Add(t);
            }
        }

        private static void dds_LoadedData6(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_Materials.Clear();
            foreach (V_B_Material_LensClass_Materials t in e.Entities)
            {
                _UHV_B_Material_LensClass_Materials.Add(t);
            }
        }

        private static void dds_LoadedData7(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            _UHV_B_Material_LensClass_DefaultCoating.Clear();
            foreach (V_B_Material_LensClass_DefaultCoating t in e.Entities)
            {
                _UHV_B_Material_LensClass_DefaultCoating.Add(t);
            }
        }
    }
}
