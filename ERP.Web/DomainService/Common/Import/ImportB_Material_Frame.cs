using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;
using System;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Material_Frame:ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Material_Frame from B_Material_Frame;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Material_Frame where FrameCode=@FrameCode;");
                //
                strSql.Append("insert into #B_Material_Frame(");
                strSql.Append("FrameCode,FrameName,Brand,Family,Material,Width,Heigh,Leg_Length,Bridge,Colour,Origin,F_Stop)");
                strSql.Append(" values (");
                strSql.Append("@FrameCode,@FrameName,@Brand,@Family,@Material,@Width,@Heigh,@Leg_Length,@Bridge,@Colour,@Origin,@F_Stop)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
					new SqlParameter("@FrameName", SqlDbType.VarChar,50),
					new SqlParameter("@Brand", SqlDbType.VarChar,30),
					new SqlParameter("@Family", SqlDbType.VarChar,30),
					new SqlParameter("@Material", SqlDbType.VarChar,30),
					new SqlParameter("@Width", SqlDbType.Decimal,9),
					new SqlParameter("@Heigh", SqlDbType.Decimal,9),
					new SqlParameter("@Leg_Length", SqlDbType.Decimal,9),
					new SqlParameter("@Bridge", SqlDbType.Decimal,9),
					new SqlParameter("@Colour", SqlDbType.VarChar,20),
					new SqlParameter("@Origin", SqlDbType.VarChar,20),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1)};
                parameters[0].Value = dr["FrameCode"].ToString().Trim();
                parameters[1].Value = dr["FrameName"].ToString().Trim();
                parameters[2].Value = dr["Brand"].ToString().Trim();
                parameters[3].Value = dr["Family"].ToString().Trim();
                parameters[4].Value = dr["Material"].ToString().Trim();
                parameters[5].Value = dr["Width"].ToString().Trim();
                parameters[6].Value = dr["Heigh"].ToString().Trim();
                parameters[7].Value = dr["Leg_Length"].ToString().Trim();
                parameters[8].Value = dr["Bridge"].ToString().Trim();
                parameters[9].Value = dr["Colour"].ToString().Trim();
                parameters[10].Value = dr["Origin"].ToString().Trim();
                parameters[11].Value = dr["F_Stop"].ToString().Trim().GetBoolStr();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Material_Frame;");
            strSql.Append("insert into B_Material_Frame select * from #B_Material_Frame;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}