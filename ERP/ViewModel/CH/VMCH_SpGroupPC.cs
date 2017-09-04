

namespace ERP.ViewModel
{
    public class VMCH_SpGroupPC : VMListCH
    {
        public VMCH_SpGroupPC()
            : base("GpCode", "Pur_PriceContract_SpGroup", "gpCode", "GpName")
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