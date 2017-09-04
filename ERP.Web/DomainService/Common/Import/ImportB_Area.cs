using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Area : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Area from B_Area;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Area where AreaCode=@AreaCode;");
                //
                strSql.Append("insert into #B_Area(");
                strSql.Append("AreaCode,AreaName,PCode)");
                strSql.Append(" values (");
                strSql.Append("@AreaCode,@AreaName,@PCode)");
                parameters = new SqlParameter[] {
                                new SqlParameter("@AreaCode", SqlDbType.NVarChar,10),
                                new SqlParameter("@AreaName", SqlDbType.NVarChar,100),
                                new SqlParameter("@PCode", SqlDbType.NVarChar,10)};
                parameters[0].Value = dr["AreaCode"].ToString().Trim();
                parameters[1].Value = dr["AreaName"].ToString().Trim();
                parameters[2].Value = dr["PCode"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Area;");
            strSql.Append("insert into B_Area select * from #B_Area;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}