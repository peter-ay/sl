
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_DataBase : VMListCH
    {
        public VMCH_DataBase()
            : base("DataBaseCode", "S_DataBase")
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

        protected override System.ServiceModel.DomainServices.Client.DomainContext PrepareDDsInfoListDomaincontext()
        {
            return ComDSFactory.Man;
        }
    }
}