
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_TransferWay : VMListCH
    {
        public VMCH_TransferWay()
            : base("TransferWayCode")
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