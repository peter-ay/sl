
namespace ERP.Web.DomainService.Bill
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using ERP.Web.Interface;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSB_Person : DomainService
    {
        private BLLBase bll = new BB_Person();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MB_Person t)
        {
            return bll.Add(dbCode, lgIndex, t,false);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MB_Person t)
        {
            bll.Update(dbCode, lgIndex, t,false);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }
    }
}


