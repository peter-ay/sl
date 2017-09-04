namespace ERP.ViewModel
{
    public class VMCH_RefractionCode : VMListCH
    {
        public VMCH_RefractionCode()
            : base("KeyCode", "B_Lens_Refraction")
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