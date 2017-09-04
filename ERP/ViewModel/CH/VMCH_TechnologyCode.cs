
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_TechnologyCode : VMListCH
    {
        public VMCH_TechnologyCode()
            : base("KeyCode", "B_Lens_Technology")
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