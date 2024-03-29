﻿
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
    public class DSPur_PriceContract_SpGroup : DomainService
    {
        private BLLBase bll = new BPur_PriceContract_SpGroup();
         

        [Invoke]
        public string Add(string dbCode, int lgIndex, MPur_PriceContract_SpGroup t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MPur_PriceContract_SpGroup t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode,  userCode,  userName);
        }
    }
}


