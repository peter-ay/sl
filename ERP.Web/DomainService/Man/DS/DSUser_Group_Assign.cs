

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
    public class DSUser_Group_Assign : DomainService
    {
        [Invoke]
        public void Update(string userCode, List<string> codes, bool f_Add = false)
        {
            StringBuilder strSql = new StringBuilder();

            codes.ForEach(item =>
            {
                strSql.Append("update S_User set UserRight=HKOERP.dbo.SF_GetRightValue(isnull(UserRight,HKOERP.dbo.SF_GetRightDefaultValue()),(select GpID from HKOERP.dbo.S_UserGroup  A1 with (nolock) where GpCode='" + item + "'),@f_ADD)  ");
                strSql.Append("where UserCode=@UserCode ;");
            });


            SqlParameter[] parameters = {
                    new SqlParameter("@UserCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@f_ADD", SqlDbType.Bit)};
            parameters[0].Value = userCode;
            parameters[1].Value = f_Add;
            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}