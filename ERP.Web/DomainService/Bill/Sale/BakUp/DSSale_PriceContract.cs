
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


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSSale_PriceContract : DomainService
    {
        private IDAL bll = new BSale_PriceContract();

        [Invoke]
        public bool Exists(string dbCode, int lgIndex, string vCode)
        {
            return bll.Exists(dbCode, lgIndex, vCode);
        }

        [Invoke]
        public string Add(string dbCode, int lgIndex, MSale_PriceContract t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MSale_PriceContract t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode)
        {
            bll.Delete(dbCode, lgIndex, vCode);
        }
    }
}


