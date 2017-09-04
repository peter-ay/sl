using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelPur()
        {
            SimpleIoc.Default.Register<VMPur_Order_Lens_List>();
            //SimpleIoc.Default.Register<VMPur_PriceContract_SpGroup_List>();
            SimpleIoc.Default.Register<VMPur_Quote>();
            SimpleIoc.Default.Register<VMPur_PriceContract_List>();
            SimpleIoc.Default.Register<VMPur_PriceContract_SpGroup>();
            SimpleIoc.Default.Register<VMPur_PriceContract_SpGroup_List>();
            SimpleIoc.Default.Register<VMPur_PriceContract>();
            SimpleIoc.Default.Register<VMPur_PriceContract_SpCode>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Lens>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Lens_List>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Lens_ProCost>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Lens_ProCost_List>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Frame>();
            SimpleIoc.Default.Register<VMPur_PriceContract_Frame_List>();
            SimpleIoc.Default.Register<VMPur_PriceContract_FrameSet>();
            SimpleIoc.Default.Register<VMPur_PriceContract_FrameSet_List>();
        }
        public VMPur_Order_Lens_List Pur_Order_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_Order_Lens_List>();
            }
        }

        public VMPur_Quote Pur_Quote
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_Quote>();
            }
        }

        public VMPur_PriceContract_SpGroup_List Pur_PriceContract_SpGroup_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_SpGroup_List>();
            }
        }

        public VMPur_PriceContract_List Pur_PriceContract_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_List>();
            }
        }

        public VMPur_PriceContract_SpGroup Pur_PriceContract_SpGroup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_SpGroup>();
            }
        }

        public VMPur_PriceContract Pur_PriceContract
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract>();
            }
        }

        public VMPur_PriceContract_SpCode Pur_PriceContract_SpCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_SpCode>();
            }
        }

        public VMPur_PriceContract_Lens Pur_PriceContract_Lens
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Lens>();
            }
        }

        public VMPur_PriceContract_Lens_List Pur_PriceContract_Lens_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Lens_List>();
            }
        }

        public VMPur_PriceContract_Lens_ProCost Pur_PriceContract_Lens_ProCost
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Lens_ProCost>();
            }
        }

        public VMPur_PriceContract_Lens_ProCost_List Pur_PriceContract_Lens_ProCost_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Lens_ProCost_List>();
            }
        }

        public VMPur_PriceContract_Frame_List Pur_PriceContract_Frame_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Frame_List>();
            }
        }

        public VMPur_PriceContract_Frame Pur_PriceContract_Frame
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_Frame>();
            }
        }

        public VMPur_PriceContract_FrameSet Pur_PriceContract_FrameSet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_FrameSet>();
            }
        }

        public VMPur_PriceContract_FrameSet_List Pur_PriceContract_FrameSet_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMPur_PriceContract_FrameSet_List>();
            }
        }
    }
}
