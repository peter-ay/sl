
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_TextureCode : VMListCH
    {
        public VMCH_TextureCode()
            : base("KeyCode", "B_Lens_Texture")
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