
namespace ERP.ViewModel
{
    public class VMCH_Person : VMListCH
    {
        public VMCH_Person()
            : base("PersonCode", "B_Person")
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