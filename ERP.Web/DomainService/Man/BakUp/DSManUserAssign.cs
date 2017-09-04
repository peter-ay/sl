
namespace ERP.Web.DomainService.Man
{
    using ERP.Web.DBUtility;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using ERP.Web.Common;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSManUserAssign : DomainService
    {
        [Invoke]
        public void UpdateUserAssign(string groupCode, List<string> codes, bool add = false)
        {
            StringBuilder strSql = new StringBuilder();

            codes.ForEach(item =>
            {
                strSql.Append("delete  S_User_Group  ");
                strSql.Append("where GroupCode=@GroupCode and UserCode='" + item + "' ;");
                if (add)
                {
                    strSql.Append("insert into S_User_Group (UserCode,GroupCode) ");
                    strSql.Append("values('" + item + "',@GroupCode) ;");
                }
            });


            SqlParameter[] parameters = {
					new SqlParameter("@GroupCode", SqlDbType.NVarChar,30)};
            parameters[0].Value = groupCode;

            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}