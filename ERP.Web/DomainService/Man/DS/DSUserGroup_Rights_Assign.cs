

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
    public class DSUserGroup_Rights_Assign : DomainService
    {
        [Invoke]
        public void Update(int gpID, List<string> codes, bool add = false)
        {
            StringBuilder strSql = new StringBuilder();
            codes.ForEach(item =>
            {
                strSql.Append("update S_Function set FunRight=HKOERP.dbo.SF_GetRightValue(FunRight,@GpID,@f_IO)  ");
                strSql.Append("where FunCode='" + item + "' ;");
            });
            SqlParameter[] parameters = {
					new SqlParameter("@GpID", SqlDbType.Int),
                    new SqlParameter("@f_IO", SqlDbType.Bit)};
            parameters[0].Value = gpID;
            parameters[1].Value = add;
            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }

        [Invoke]
        public void UpdateAll(int gpID, bool add = false)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Function set FunRight=HKOERP.dbo.SF_GetRightValue(FunRight,@GpID,@f_IO)  ");
            SqlParameter[] parameters = {
					new SqlParameter("@GpID", SqlDbType.Int),
                    new SqlParameter("@f_IO", SqlDbType.Bit)};
            parameters[0].Value = gpID;
            parameters[1].Value = add;
            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }

        [Invoke]
        public void CopyRights(string groupCode, List<string> codes)
        {
            StringBuilder strSql = new StringBuilder();
            DbHelperSQL dbsql = new DbHelperSQL(ComDBName.ERP);
            codes.ForEach(item =>
            {
                strSql.Clear();
                strSql.Append("SP_S_UserGroup_CopyRights");
                SqlParameter[] parameters = {
					new SqlParameter("@GpCodeFrom", SqlDbType.NVarChar,30),
                    new SqlParameter("@GpCodeTo", SqlDbType.NVarChar,30)};
                parameters[0].Value = groupCode;
                parameters[1].Value = item;
                dbsql.RunProcedure(strSql.ToString(), parameters);
            });
        }

    }
}