

namespace ERP.ViewModel
{
    public class VMCH_BrandCode : VMListCH
    {
        public VMCH_BrandCode()
            : base("KeyCode", "B_Lens_Brand")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }
    }
}