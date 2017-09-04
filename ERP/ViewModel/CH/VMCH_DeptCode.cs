
namespace ERP.ViewModel
{
    public class VMCH_DeptCode : VMListCH
    {
        public VMCH_DeptCode()
            : base("DpCode", "B_Department")
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