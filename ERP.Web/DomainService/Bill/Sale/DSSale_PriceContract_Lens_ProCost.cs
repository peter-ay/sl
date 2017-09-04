
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
    public class DSSale_PriceContract_Lens_ProCost : DomainService
    {
        private BLLBase bll = new BSale_PriceContract_Lens_ProCost();
         
        [Invoke]
        public string Add(string dbCode, int lgIndex, MSale_PriceContract_Lens_ProCost t)
        {
            return bll.Add(dbCode, lgIndex, t, false);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MSale_PriceContract_Lens_ProCost t)
        {
            bll.Update(dbCode, lgIndex, t, false);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }
    }
}


