
namespace ERP.ViewModel
{
    public class VMCH_PayWay : VMListCH
    {
        public VMCH_PayWay()
            : base("PayWayCode", "B_PayWay")
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