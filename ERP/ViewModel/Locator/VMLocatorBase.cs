using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelBase()
        {
            SimpleIoc.Default.Register<VMB_Customer_List>();
            SimpleIoc.Default.Register<VMB_Customer_Acc_List>();
            SimpleIoc.Default.Register<VMB_Customer_Main_List>();
            SimpleIoc.Default.Register<VMB_Customer>();
            SimpleIoc.Default.Register<VMB_Customer_Acc>();
            SimpleIoc.Default.Register<VMB_Customer_Main>();
            SimpleIoc.Default.Register<VMB_Customer_Right_Browse>();
            SimpleIoc.Default.Register<VMB_Department_List>();
            SimpleIoc.Default.Register<VMB_Department>();
            SimpleIoc.Default.Register<VMB_Department_Right_Browse>();
            SimpleIoc.Default.Register<VMB_Area_List>();
            SimpleIoc.Default.Register<VMB_Area>();
            SimpleIoc.Default.Register<VMB_Material_Frame_List>();
            SimpleIoc.Default.Register<VMB_Material_Frame>();
            SimpleIoc.Default.Register<VMB_Material_Lens_List>();
            SimpleIoc.Default.Register<VMB_Material_Lens>();
            SimpleIoc.Default.Register<VMB_Material_Lens_Sale_List>();
            SimpleIoc.Default.Register<VMB_Material_Lens_Sale>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Index>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Index_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Brand>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Brand_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Focus>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Focus_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Usage>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Usage_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Design>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Design_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Materials>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_Materials_List>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_DefaultCoating>();
            SimpleIoc.Default.Register<VMB_Material_LensClass_DefaultCoating_List>();
            SimpleIoc.Default.Register<VMB_Material_Process_List>();
            SimpleIoc.Default.Register<VMB_Material_Process>();
            SimpleIoc.Default.Register<VMB_Person_List>();
            SimpleIoc.Default.Register<VMB_Person>();
            SimpleIoc.Default.Register<VMB_Supplier>();
            SimpleIoc.Default.Register<VMB_Supplier_List>();
            SimpleIoc.Default.Register<VMB_Supplier_Right_Browse>();
            SimpleIoc.Default.Register<VMB_Supplier_Default_List>();
            SimpleIoc.Default.Register<VMB_Supplier_Default_CusCode>();
            SimpleIoc.Default.Register<VMB_Supplier_Default_Lens>();
            SimpleIoc.Default.Register<VMB_Supplier_Default_ProCode>();
            SimpleIoc.Default.Register<VMB_Warehouse>();
            SimpleIoc.Default.Register<VMB_Warehouse_List>();
            SimpleIoc.Default.Register<VMB_Warehouse_Right_Browse>();
            SimpleIoc.Default.Register<VMB_Warehouse_Right_Use>();
        }

        public VMB_Customer_List B_Customer_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_List>();
            }
        }

        public VMB_Customer_Acc_List B_Customer_Acc_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_Acc_List>();
            }
        }

        public VMB_Customer_Main_List B_Customer_Main_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_Main_List>();
            }
        }

        public VMB_Customer B_Customer
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer>();
            }
        }

        public VMB_Customer_Acc B_Customer_Acc
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_Acc>();
            }
        }

        public VMB_Customer_Main B_Customer_Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_Main>();
            }
        }

        public VMB_Customer_Right_Browse B_Customer_Right_Browse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Customer_Right_Browse>();
            }
        }

        public VMB_Department_List B_Department_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Department_List>();
            }
        }

        public VMB_Department B_Department
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Department>();
            }
        }

        public VMB_Department_Right_Browse B_Department_Right_Browse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Department_Right_Browse>();
            }
        }

        public VMB_Area_List B_Area_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Area_List>();
            }
        }

        public VMB_Area B_Area
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Area>();
            }
        }


        public VMB_Material_Frame_List B_Material_Frame_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Frame_List>();
            }
        }

        public VMB_Material_Frame B_Material_Frame
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Frame>();
            }
        }

        public VMB_Material_Lens_List B_Material_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Lens_List>();
            }
        }

        public VMB_Material_Lens B_Material_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Lens>();
            }
        }

        public VMB_Material_Lens_Sale_List B_Material_Lens_Sale_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Lens_Sale_List>();
            }
        }

        public VMB_Material_Lens_Sale B_Material_Lens_Sale
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Lens_Sale>();
            }
        }

        public VMB_Material_LensClass_Index B_Material_LensClass_Index
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Index>();
            }
        }

        public VMB_Material_LensClass_Index_List B_Material_LensClass_Index_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Index_List>();
            }
        }

        public VMB_Material_LensClass_Brand B_Material_LensClass_Brand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Brand>();
            }
        }

        public VMB_Material_LensClass_Brand_List B_Material_LensClass_Brand_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Brand_List>();
            }
        }

        public VMB_Material_LensClass_Focus B_Material_LensClass_Focus
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Focus>();
            }
        }

        public VMB_Material_LensClass_Focus_List B_Material_LensClass_Focus_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Focus_List>();
            }
        }

        public VMB_Material_LensClass_Usage B_Material_LensClass_Usage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Usage>();
            }
        }

        public VMB_Material_LensClass_Usage_List B_Material_LensClass_Usage_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Usage_List>();
            }
        }

        public VMB_Material_LensClass_Design B_Material_LensClass_Design
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Design>();
            }
        }

        public VMB_Material_LensClass_Design_List B_Material_LensClass_Design_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Design_List>();
            }
        }

        public VMB_Material_LensClass_Materials B_Material_LensClass_Materials
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Materials>();
            }
        }

        public VMB_Material_LensClass_Materials_List B_Material_LensClass_Materials_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_Materials_List>();
            }
        }

        public VMB_Material_LensClass_DefaultCoating B_Material_LensClass_DefaultCoating
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_DefaultCoating>();
            }
        }

        public VMB_Material_LensClass_DefaultCoating_List B_Material_LensClass_DefaultCoating_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_LensClass_DefaultCoating_List>();
            }
        }

        public VMB_Material_Process_List B_Material_Process_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Process_List>();
            }
        }

        public VMB_Material_Process B_Material_Process
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Material_Process>();
            }
        }

        public VMB_Person_List B_Person_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Person_List>();
            }
        }

        public VMB_Person B_Person
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Person>();
            }
        }

        public VMB_Supplier_Default_Lens B_Supplier_Default_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_Default_Lens>();
            }
        }

        public VMB_Supplier_Default_ProCode B_Supplier_Default_ProCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_Default_ProCode>();
            }
        }

        public VMB_Supplier_Default_CusCode B_Supplier_Default_CusCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_Default_CusCode>();
            }
        }

        public VMB_Supplier_Default_List B_Supplier_Default_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_Default_List>();
            }
        }

        public VMB_Supplier_List B_Supplier_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_List>();
            }
        }

        public VMB_Supplier_Right_Browse B_Supplier_Right_Browse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier_Right_Browse>();
            }
        }

        public VMB_Supplier B_Supplier
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Supplier>();
            }
        }

        public VMB_Warehouse B_Warehouse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Warehouse>();
            }
        }

        public VMB_Warehouse_List B_Warehouse_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Warehouse_List>();
            }
        }

        public VMB_Warehouse_Right_Browse B_Warehouse_Right_Browse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Warehouse_Right_Browse>();
            }
        }

        public VMB_Warehouse_Right_Use B_Warehouse_Right_Use
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMB_Warehouse_Right_Use>();
            }
        }

    }
}
