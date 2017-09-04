
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelLogin()
        {
            SimpleIoc.Default.Register<VMLogin>();
            SimpleIoc.Default.Register<VMLoginUserLogin>();
            SimpleIoc.Default.Register<VMLoginUserLogined>();
            SimpleIoc.Default.Register<VMLoginTab>();
            SimpleIoc.Default.Register<VMLoginHome>();
            SimpleIoc.Default.Register<VMLoginUserInfo>();
        }

        public VMLogin Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLogin>();
            }
        }

        public VMLoginUserLogin LoginUserLogin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLoginUserLogin>();
            }
        }

        public VMLoginUserLogined LoginUserLogined
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLoginUserLogined>();
            }
        }

        public VMLoginTab LoginTab
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLoginTab>();
            }
        }

        public VMLoginHome LoginHome
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLoginHome>();
            }
        }

        public VMLoginUserInfo LoginUserInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMLoginUserInfo>();
            }
        }
    }
}