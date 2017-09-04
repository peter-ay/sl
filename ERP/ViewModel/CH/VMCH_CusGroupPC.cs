

namespace ERP.ViewModel
{
    public class VMCH_CusGroupPC : VMListCH
    {
        public VMCH_CusGroupPC()
            : base("GpCode", "Sale_PriceContract_CusGroup", "gpCode", "GpName")
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