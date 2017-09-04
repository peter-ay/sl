
namespace ERP.ViewModel
{
    public class VMCH_ForeignCurrency : VMListCH
    {
        public VMCH_ForeignCurrency()
            : base("ForeignCurrCode", "B_ForeignCurrency")
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