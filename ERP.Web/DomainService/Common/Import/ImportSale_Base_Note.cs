using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;
using System;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_Base_Note : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #Sale_Base_Note from Sale_Base_Note;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #Sale_Base_Note where KeyCode=@KeyCode;");
                //
                strSql.Append("insert into #Sale_Base_Note(");
                strSql.Append("KeyCode,KeyName,SN)");
                strSql.Append(" values (");
                strSql.Append("@KeyCode,@KeyName,@SN)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@KeyCode", SqlDbType.VarChar,4),
					new SqlParameter("@KeyName", SqlDbType.NVarChar,20),
					new SqlParameter("@SN", SqlDbType.Int,4)};
                parameters[0].Value = dr["KeyCode"].ToString().Trim();
                parameters[1].Value = dr["KeyName"].ToString().Trim();
                parameters[2].Value = dr["SN"].ToString().Trim().GetIntStr();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete Sale_Base_Note;");
            strSql.Append("insert into Sale_Base_Note select * from #Sale_Base_Note;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}