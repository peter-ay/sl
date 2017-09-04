
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelLogin();
        partial void RegisterViewModelBase();
        partial void RegisterViewModelMan();
        partial void RegisterViewModelPur();
        partial void RegisterViewModelSale();
        partial void RegisterViewModelWare();
        partial void RegisterViewModelAr();
        partial void RegisterViewModelCH();

        public VMLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            this.RegisterViewModel();
            this.RegisterViewModelLogin();
            this.RegisterViewModelBase();
            this.RegisterViewModelMan();
            this.RegisterViewModelPur();
            this.RegisterViewModelSale();
            this.RegisterViewModelWare();
            this.RegisterViewModelAr();
            this.RegisterViewModelCH();
        }

        private void RegisterViewModel()
        {
            SimpleIoc.Default.Register<VMMainPage>();
            SimpleIoc.Default.Register<VMMessageWindowErp>();
            SimpleIoc.Default.Register<VMXYInput>();
        }

        public VMMainPage Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMMainPage>();
            }
        }

        public VMMessageWindowErp MessageWindowErp
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMMessageWindowErp>();
            }
        }

        public VMXYInput XYInput
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMXYInput>();
            }
        }
    }
}