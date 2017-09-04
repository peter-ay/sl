
namespace ERP.ViewModel
{
    public class VMCH_FocusCode : VMListCH
    {
        public VMCH_FocusCode()
            : base("KeyCode", "B_Lens_Focus")
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