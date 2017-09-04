

namespace ERP.ViewModel
{
    public class VMCH_AreaCode : VMListCH
    {
        public VMCH_AreaCode()
            : base("AreaCode", "B_Area")
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