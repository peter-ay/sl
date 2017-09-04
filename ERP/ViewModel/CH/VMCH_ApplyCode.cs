

namespace ERP.ViewModel
{
    public class VMCH_ApplyCode : VMListCH
    {
        public VMCH_ApplyCode()
            : base("KeyCode", "B_Lens_Apply")
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