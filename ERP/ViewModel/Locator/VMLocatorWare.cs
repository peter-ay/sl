using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelWare()
        {
            SimpleIoc.Default.Register<VMWare_Bill_SO_Pending_PD_List>();
            SimpleIoc.Default.Register<VMWare_Bill_SO_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Bill_SO_Pre_SD>();
            SimpleIoc.Default.Register<VMWare_Bill_SO_Pre_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Bill_SO_SD>();
            SimpleIoc.Default.Register<VMWare_Bill_SO_PD>();
            SimpleIoc.Default.Register<VMWare_Bill_Transfer_Lens>();
            SimpleIoc.Default.Register<VMWare_Bill_Transfer_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Bill_Count_Lens>();
            SimpleIoc.Default.Register<VMWare_Bill_Count_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Bill_OI_Lens>();
            SimpleIoc.Default.Register<VMWare_Bill_OI_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Bill_BCI_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Report_Stocks_Lens_Detail_List>();
            SimpleIoc.Default.Register<VMWare_Report_Stocks_Lens_XY_List>();
            SimpleIoc.Default.Register<VMWare_Stocks_Base_Lens>();
            SimpleIoc.Default.Register<VMWare_Stocks_Base_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Suspend_Lens_List>();
            SimpleIoc.Default.Register<VMWare_Report_IO_Lens_List>();
        }

        public VMWare_Bill_SO_Pending_PD_List Ware_Bill_SO_Pending_PD_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_Pending_PD_List>();
            }
        }

        public VMWare_Bill_SO_Lens_List Ware_Bill_SO_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_Lens_List>();
            }
        }

        public VMWare_Bill_SO_Pre_SD Ware_Bill_SO_Pre_SD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_Pre_SD>();
            }
        }

        public VMWare_Bill_SO_Pre_Lens_List Ware_Bill_SO_Pre_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_Pre_Lens_List>();
            }
        }

        public VMWare_Bill_SO_SD Ware_Bill_SO_SD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_SD>();
            }
        }

        public VMWare_Bill_SO_PD Ware_Bill_SO_PD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_SO_PD>();
            }
        }

        public VMWare_Bill_OI_Lens Ware_Bill_OI_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_OI_Lens>();
            }
        }

        public VMWare_Bill_Transfer_Lens Ware_Bill_Transfer_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_Transfer_Lens>();
            }
        }

        public VMWare_Bill_Transfer_Lens_List Ware_Bill_Transfer_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_Transfer_Lens_List>();
            }
        }

        public VMWare_Bill_Count_Lens Ware_Bill_Count_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_Count_Lens>();
            }
        }

        public VMWare_Bill_Count_Lens_List Ware_Bill_Count_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_Count_Lens_List>();
            }
        }

        public VMWare_Bill_OI_Lens_List Ware_Bill_OI_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_OI_Lens_List>();
            }
        }

        public VMWare_Bill_BCI_Lens_List Ware_Bill_BCI_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Bill_BCI_Lens_List>();
            }
        }

        public VMWare_Report_Stocks_Lens_Detail_List Ware_Report_Stocks_Lens_Detail_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Report_Stocks_Lens_Detail_List>();
            }
        }

        public VMWare_Report_Stocks_Lens_XY_List Ware_Report_Stocks_Lens_XY_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Report_Stocks_Lens_XY_List>();
            }
        }

        public VMWare_Stocks_Base_Lens Ware_Stocks_Base_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Stocks_Base_Lens>();
            }
        }

        public VMWare_Stocks_Base_Lens_List Ware_Stocks_Base_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Stocks_Base_Lens_List>();
            }
        }

        public VMWare_Suspend_Lens_List Ware_Suspend_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Suspend_Lens_List>();
            }
        }

        public VMWare_Report_IO_Lens_List Ware_Report_IO_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMWare_Report_IO_Lens_List>();
            }
        }
    }
}
