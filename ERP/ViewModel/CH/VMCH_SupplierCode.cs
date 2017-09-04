
namespace ERP.ViewModel
{
    public class VMCH_SupplierCode : VMListCH
    {
        public VMCH_SupplierCode()
            : base("SpCode", "B_Supplier")
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