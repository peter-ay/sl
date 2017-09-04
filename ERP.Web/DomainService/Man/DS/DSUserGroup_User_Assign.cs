

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
    public class DSUserGroup_User_Assign : DomainService
    {
        [Invoke]
        public void Update(int gpID, List<string> codes, bool f_Add = false)
        {
            StringBuilder strSql = new StringBuilder();

            codes.ForEach(item =>
            {
                strSql.Append("update S_User set UserRight=HKOERP.dbo.SF_GetRightValue(isnull(UserRight,HKOERP.dbo.SF_GetRightDefaultValue()),@GpID,@f_Add)  ");
                strSql.Append("where UserCode='" + item + "' ;");
            });


            SqlParameter[] parameters = {
					new SqlParameter("@GpID", SqlDbType.Int),
                    new SqlParameter("@f_Add", SqlDbType.Bit)};
            parameters[0].Value = gpID;
            parameters[1].Value = f_Add;
            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }

    }
}