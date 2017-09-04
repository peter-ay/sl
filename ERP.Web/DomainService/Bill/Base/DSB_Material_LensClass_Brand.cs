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
    using System.Collections.Generic;
    using System.Text;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSB_Material_LensClass_Brand : DomainService
    {
        private BLLBase bll = new BB_Material_LensClass_Brand();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MB_Material_LensClass_Brand t)
        {
            return bll.Add(dbCode, lgIndex, t, false);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MB_Material_LensClass_Brand t)
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

