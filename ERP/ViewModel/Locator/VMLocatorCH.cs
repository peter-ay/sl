using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{

    public partial class VMLocator
    {
        partial void RegisterViewModelCH()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<VMCH_DataBase>();
            SimpleIoc.Default.Register<VMCH_DeptCode>();
            SimpleIoc.Default.Register<VMCH_AreaCode>();
            SimpleIoc.Default.Register<VMCH_PayWay>();
            SimpleIoc.Default.Register<VMCH_TradeWay>();
            SimpleIoc.Default.Register<VMCH_ForeignCurrency>();
            SimpleIoc.Default.Register<VMCH_Person>();
            SimpleIoc.Default.Register<VMCH_TransferWay>();
            SimpleIoc.Default.Register<VMCH_BrandCode>();
            SimpleIoc.Default.Register<VMCH_ApplyCode>();
            SimpleIoc.Default.Register<VMCH_FocusCode>();
            SimpleIoc.Default.Register<VMCH_RefractionCode>();
            SimpleIoc.Default.Register<VMCH_TechnologyCode>();
            SimpleIoc.Default.Register<VMCH_TextureCode>();
            SimpleIoc.Default.Register<VMCH_SupplierCode>();
            SimpleIoc.Default.Register<VMCH_CusCode>();
            SimpleIoc.Default.Register<VMCH_CusMnumber>();
            SimpleIoc.Default.Register<VMCH_FrameCode>();
            SimpleIoc.Default.Register<VMCH_LensCode>();
            SimpleIoc.Default.Register<VMCH_LensCodeSale>();
            SimpleIoc.Default.Register<VMCH_WhCodeBrowse>();
            SimpleIoc.Default.Register<VMCH_WhCodeIn>();
            SimpleIoc.Default.Register<VMCH_WhCodeOut>();
            SimpleIoc.Default.Register<VMCH_CusGroupPC>();
            SimpleIoc.Default.Register<VMCH_SpGroupPC>();
            SimpleIoc.Default.Register<VMCH_PDChoose>();
        }

        public VMCH_DataBase CH_DataBase
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_DataBase>();
            }
        }

        public VMCH_DeptCode CH_DeptCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_DeptCode>();
            }
        }

        public VMCH_AreaCode CH_AreaCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_AreaCode>();
            }
        }

        public VMCH_PayWay CH_PayWay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_PayWay>();
            }
        }

        public VMCH_TradeWay CH_TradeWay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_TradeWay>();
            }
        }

        public VMCH_ForeignCurrency CH_ForeignCurrency
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_ForeignCurrency>();
            }
        }

        public VMCH_Person CH_Person
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_Person>();
            }
        }

        public VMCH_TransferWay CH_TransferWay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_TransferWay>();
            }
        }

        public VMCH_BrandCode CH_BrandCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_BrandCode>();
            }
        }

        public VMCH_ApplyCode CH_ApplyCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_ApplyCode>();
            }
        }

        public VMCH_FocusCode CH_FocusCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_FocusCode>();
            }
        }

        public VMCH_RefractionCode CH_RefractionCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_RefractionCode>();
            }
        }

        public VMCH_TechnologyCode CH_TechnologyCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_TechnologyCode>();
            }
        }

        public VMCH_TextureCode CH_TextureCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_TextureCode>();
            }
        }

        public VMCH_SupplierCode CH_SupplierCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_SupplierCode>();
            }
        }

        public VMCH_CusCode CH_CusCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_CusCode>();
            }
        }

        public VMCH_CusMnumber CH_CusMnumber
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_CusMnumber>();
            }
        }

        public VMCH_FrameCode CH_FrameCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_FrameCode>();
            }
        }

        public VMCH_LensCode CH_LensCode
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_LensCode>();
            }
        }

        public VMCH_LensCodeSale CH_LensCodeSale
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_LensCodeSale>();
            }
        }

        public VMCH_WhCodeBrowse CH_WhCodeBrowse
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_WhCodeBrowse>();
            }
        }

        public VMCH_WhCodeIn CH_WhCodeIn
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_WhCodeIn>();
            }
        }

        public VMCH_WhCodeOut CH_WhCodeOut
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_WhCodeOut>();
            }
        }

        public VMCH_CusGroupPC CH_CusGroupPC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_CusGroupPC>();
            }
        }

        public VMCH_SpGroupPC CH_SpGroupPC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_SpGroupPC>();
            }
        }

        public VMCH_PDChoose CH_PDChoose
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMCH_PDChoose>();
            }
        }
    }
}