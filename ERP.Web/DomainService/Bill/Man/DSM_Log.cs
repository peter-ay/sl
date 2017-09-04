
namespace ERP.Web.DomainService.Bill
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using ERP.Web.Interface;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSM_Log : DomainService
    {
        private BLLBase bll = new BS_Log();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MS_Log t)
        {
            return bll.Add(dbCode, lgIndex, t, false);
        }

        [Invoke]
        public void Update<T>(string dbCode, int lgIndex, MS_Log t)
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


