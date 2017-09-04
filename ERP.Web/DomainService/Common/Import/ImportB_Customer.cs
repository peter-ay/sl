using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Customer : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Customer from B_Customer;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Customer where CusCode=@CusCode;");
                //
                strSql.Append("insert into #B_Customer(");
                strSql.Append("CusCode,CusName,PCode,CusAddress,AreaCode,DpCode,DpCodeCX,PersonCode,Fax,Email,ContactPerson,Tel,DAddress,BarCode,F_Stop,F_NoticeRepeatOBill,PrintShowPriceType,PrintCode,Remark,BrowseRight)");
                strSql.Append(" values (");
                strSql.Append("@CusCode,@CusName,@PCode,@CusAddress,@AreaCode,@DpCode,@DpCodeCX,@PersonCode,@Fax,@Email,@ContactPerson,@Tel,@DAddress,@BarCode,@F_Stop,@F_NoticeRepeatOBill,@PrintShowPriceType,@PrintCode,@Remark,@BrowseRight)");
                parameters = new SqlParameter[] {
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCodeCX", SqlDbType.VarChar,10),
					new SqlParameter("@PersonCode", SqlDbType.VarChar,10),
					new SqlParameter("@Fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@DAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@BarCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@F_NoticeRepeatOBill", SqlDbType.Bit,1),
					new SqlParameter("@PrintShowPriceType", SqlDbType.TinyInt,1),
					new SqlParameter("@PrintCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000)};
                parameters[0].Value = dr["CusCode"].ToString().Trim();
                parameters[1].Value = dr["CusName"].ToString().Trim();
                parameters[2].Value = dr["PCode"].ToString().Trim();
                parameters[3].Value = dr["CusAddress"].ToString().Trim();
                parameters[4].Value = dr["AreaCode"].ToString().Trim();
                parameters[5].Value = dr["DpCode"].ToString().Trim();
                parameters[6].Value = dr["DpCodeCX"].ToString().Trim();
                parameters[7].Value = dr["PersonCode"].ToString().Trim();
                parameters[8].Value = dr["Fax"].ToString().Trim();
                parameters[9].Value = dr["Email"].ToString().Trim();
                parameters[10].Value = dr["ContactPerson"].ToString().Trim();
                parameters[11].Value = dr["Tel"].ToString().Trim();
                parameters[12].Value = dr["DAddress"].ToString().Trim();
                parameters[13].Value = dr["BarCode"].ToString().Trim();
                parameters[14].Value = dr["F_Stop"].ToString().Trim().GetBoolStr();//dr["F_Stop"].ToString().Trim();
                parameters[15].Value = dr["F_NoticeRepeatOBill"].ToString().Trim().GetBoolStr();//dr["F_NoticeRepeatOBill"].ToString().Trim();
                parameters[16].Value = dr["PrintShowPriceType"].ToString().Trim().GetIntStr();//dr["PrintShowPriceType"].ToString().Trim();
                parameters[17].Value = dr["PrintCode"].ToString().Trim();
                parameters[18].Value = dr["Remark"].ToString().Trim();
                parameters[19].Value = dr["BrowseRight"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Customer;");
            strSql.Append("insert into B_Customer select * from #B_Customer;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}