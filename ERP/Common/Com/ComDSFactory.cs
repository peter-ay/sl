using ERP.Web.DomainService.Erp;
using ERP.Web.DomainService.Man;
using System.ServiceModel.DomainServices.Client;

namespace ERP.Common
{
    public class ComDSFactory
    {
        public static DomainContext Man
        {
            get
            {
                return new DSMan();
            }
        }

        public static DomainContext Erp
        {
            get
            {
                return new DSErp();
            }
        }
    }
}
