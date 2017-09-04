

namespace ERP.Web.DomainService.Man
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using ERP.Web.DBUtility;
    using ERP.Web.Common;

    [EnableClientAccess()]
    public class DSUserGroup_DataBase_Assign : DomainService
    {
        [Invoke]
        public void Update(string dbCode, List<string> codes, bool add = false)
        {
            StringBuilder strSql = new StringBuilder();

            codes.ForEach(item =>
            {
                strSql.Append("update S_UserGroup set DBCode='' ");
                strSql.Append("where DBCode=@DBCode and GpCode='" + item + "' ;");
                if (add)
                {
                    strSql.Append("update S_UserGroup set DBCode=@DBCode ");
                    strSql.Append("where GpCode='" + item + "' ;");
                }
            });


            SqlParameter[] parameters = {
					new SqlParameter("@DBCode", SqlDbType.VarChar,30)};
            parameters[0].Value = dbCode;

            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}