
namespace ERP.Web.DomainService.Bill
{
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.Interface;
    using System.Data.SqlClient;
    using System.Data;
    using ERP.Web.DBUtility;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSM_User : DomainService
    {
        private BLLBase bll = new BS_User();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MS_User t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MS_User t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void ResetPassword(string dbCode, int lgIndex, string userCode)
        {
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] { 
                     new SqlParameter("@LgIndex", SqlDbType.Int),
                    new SqlParameter("@PKCode",SqlDbType.NVarChar,30)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = userCode;
            DbHelperSQL dbh = new DbHelperSQL(dbCode);

            dbh.RunProcedure("SP_S_User_ResetPassword", parameters);
        }
    }
}


