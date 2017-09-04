
namespace ERP.Web.DomainService.Bill
{
    using ERP.Web.BLL;
    using ERP.Web.Common;
    using ERP.Web.DBUtility;
    using ERP.Web.Model;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.Interface;
    using System.Collections.Generic;
    using System.Text;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSSale_Quote : DomainService
    {
        private BLLBase bll = new BSale_Quote();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MSale_Quote t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

    }
}


