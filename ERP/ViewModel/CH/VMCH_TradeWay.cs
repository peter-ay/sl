
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_TradeWay : VMListCH
    {
        public VMCH_TradeWay()
            : base("TradeWayCode")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override System.ServiceModel.DomainServices.Client.DomainContext PrepareDDsInfoListDomaincontext()
        {
            throw new System.NotImplementedException();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            throw new System.NotImplementedException();
        }
    }
}