using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelSale()
        {
            SimpleIoc.Default.Register<VMSale_Base_Note_List>();
            SimpleIoc.Default.Register<VMSale_Base_ReOrderReason_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract_CusGroup>();
            SimpleIoc.Default.Register<VMSale_PriceContract_CusGroup_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract>();
            SimpleIoc.Default.Register<VMSale_PriceContract_CusCode>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Lens>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Lens_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Lens_ProCost>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Lens_ProCost_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Frame>();
            SimpleIoc.Default.Register<VMSale_PriceContract_Frame_List>();
            SimpleIoc.Default.Register<VMSale_PriceContract_FrameSet>();
            SimpleIoc.Default.Register<VMSale_PriceContract_FrameSet_List>();
            SimpleIoc.Default.Register<VMSale_Quote>();
            SimpleIoc.Default.Register<VMSale_Order_Lens_List>();
            SimpleIoc.Default.Register<VMSale_Order_JM_List>();
            SimpleIoc.Default.Register<VMSale_Order_Frame_List>();
            SimpleIoc.Default.Register<VMSale_Order_SD>();
            SimpleIoc.Default.Register<VMSale_Order_SD_ReOrder>();
            SimpleIoc.Default.Register<VMSale_Order_SD_PrintPreView>();
            SimpleIoc.Default.Register<VMSale_Order_PD>();
            SimpleIoc.Default.Register<VMSale_Order_JM>();
            SimpleIoc.Default.Register<VMSale_Order_FD>();
            SimpleIoc.Default.Register<VMSale_Order_Status_List>();
            SimpleIoc.Default.Register<VMSale_Delivery_Lens_List>();
            SimpleIoc.Default.Register<VMSale_Invoice_SD>();
            SimpleIoc.Default.Register<VMSale_Rec_PD>();
            SimpleIoc.Default.Register<VMSale_Rec_Lens_List>();
            SimpleIoc.Default.Register<VMSale_Delivery_ScanPrint_List>();
        }

        public VMSale_Base_Note_List Sale_Base_Note_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Base_Note_List>();
            }
        }

        public VMSale_Base_ReOrderReason_List Sale_Base_ReOrderReason_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Base_ReOrderReason_List>();
            }
        }

        //public VMSale_PriceTemplate_Lens_List Sale_PriceTemplate_Lens_List
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMSale_PriceTemplate_Lens_List>();
        //    }
        //}

        //public VMSale_PriceTemplate_Lens_ProCost_List Sale_PriceTemplate_Lens_ProCost_List
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMSale_PriceTemplate_Lens_ProCost_List>();
        //    }
        //}

        //public VMSale_PriceTemplate_LensRecord_List Sale_PriceTemplate_LensRecord_List
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMSale_PriceTemplate_LensRecord_List>();
        //    }
        //}

        public VMSale_PriceContract_List Sale_PriceContract_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_List>();
            }
        }

        public VMSale_PriceContract_CusGroup Sale_PriceContract_CusGroup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_CusGroup>();
            }
        }

        public VMSale_PriceContract_CusGroup_List Sale_PriceContract_CusGroup_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_CusGroup_List>();
            }
        }

        public VMSale_PriceContract Sale_PriceContract
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract>();
            }
        }

        public VMSale_PriceContract_CusCode Sale_PriceContract_CusCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_CusCode>();
            }
        }

        public VMSale_PriceContract_Lens Sale_PriceContract_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Lens>();
            }
        }

        public VMSale_PriceContract_Lens_List Sale_PriceContract_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Lens_List>();
            }
        }

        public VMSale_PriceContract_Lens_ProCost Sale_PriceContract_Lens_ProCost
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Lens_ProCost>();
            }
        }

        public VMSale_PriceContract_Lens_ProCost_List Sale_PriceContract_Lens_ProCost_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Lens_ProCost_List>();
            }
        }

        public VMSale_PriceContract_Frame_List Sale_PriceContract_Frame_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Frame_List>();
            }
        }

        public VMSale_PriceContract_Frame Sale_PriceContract_Frame
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_Frame>();
            }
        }

        public VMSale_PriceContract_FrameSet Sale_PriceContract_FrameSet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_FrameSet>();
            }
        }

        public VMSale_PriceContract_FrameSet_List Sale_PriceContract_FrameSet_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_PriceContract_FrameSet_List>();
            }
        }

        public VMSale_Quote Sale_Quote
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Quote>();
            }
        }

        public VMSale_Order_Lens_List Sale_Order_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_Lens_List>();
            }
        }

        public VMSale_Order_JM_List Sale_Order_JM_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_JM_List>();
            }
        }

        public VMSale_Order_Frame_List Sale_Order_Frame_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_Frame_List>();
            }
        }

        public VMSale_Order_SD Sale_Order_SD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_SD>();
            }
        }

        public VMSale_Order_SD_ReOrder Sale_Order_SD_ReOrder
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_SD_ReOrder>();
            }
        }

        public VMSale_Order_SD_PrintPreView Sale_Order_SD_PrintPreView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_SD_PrintPreView>();
            }
        }

        public VMSale_Order_PD Sale_Order_PD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_PD>();
            }
        }

        public VMSale_Order_JM Sale_Order_JM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_JM>();
            }
        }

        public VMSale_Order_FD Sale_Order_FD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_FD>();
            }
        }

        public VMSale_Order_Status_List Sale_Order_Status_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Order_Status_List>();
            }
        }

        //public VMSale_OrderLens_SDPrintPreView Sale_OrderLens_SDPrintPreView
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMSale_OrderLens_SDPrintPreView>();
        //    }
        //}

        public VMSale_Delivery_Lens_List Sale_Delivery_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Delivery_Lens_List>();
            }
        }

        public VMSale_Invoice_SD Sale_Invoice_SD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Invoice_SD>();
            }
        }

        public VMSale_Rec_PD Sale_Rec_PD
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Rec_PD>();
            }
        }

        public VMSale_Rec_Lens_List Sale_Rec_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Rec_Lens_List>();
            }
        }

        public VMSale_Delivery_ScanPrint_List Sale_Delivery_ScanPrint_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMSale_Delivery_ScanPrint_List>();
            }
        }
    }
}
