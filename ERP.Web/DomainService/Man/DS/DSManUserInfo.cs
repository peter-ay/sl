
namespace ERP.Web.DomainService.Man
{
    using ERP.Web.DBUtility;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using ERP.Web.Common;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSManUserInfo : DomainService
    {
        [Invoke]
        public void UpdateUserPassword(string userCode, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_User set UserPassword=@UserPassword ");
            strSql.Append("where UserCode=@UserCode");

            SqlParameter[] parameters = {
					new SqlParameter("@UserPassword", SqlDbType.NVarChar,100),
					new SqlParameter("@UserCode", SqlDbType.NVarChar,20)};
            parameters[0].Value = password;
            parameters[1].Value = userCode;

            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}