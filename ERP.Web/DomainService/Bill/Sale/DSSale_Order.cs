
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
    public class DSSale_Order : DomainService
    {
        private BLLBase bll = new BSale_Order();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MSale_Order t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MSale_Order t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void UpdateEdit(string dbCode, int lgIndex, MSale_Order t)
        {
            bll.UpdateEdit(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void Check(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Check(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void UnCheck(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.UnCheck(dbCode, lgIndex, vCode, userCode, userName);
        }
    }
}


