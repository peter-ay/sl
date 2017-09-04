using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_ProcessControl
    {
        public int Import(string dbCode, int lgIndex, string fileName)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSql = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("insert into B_ProcessControl(");
                strSql.Append("SubID,Mnumber,JuSe,ChaSe,ShuiYin,RanSe,UV,JingJia,Hardened,PaoGuang,CaiBian,CheBian,KaiKeng,PiHua,DaoBian,MianWan,ZuanKong,OtherProcess,ExtraProcess,IsForce)");
                strSql.Append(" values (");
                strSql.Append("@SubID,@Mnumber,@JuSe,@ChaSe,@ShuiYin,@RanSe,@UV,@JingJia,@Hardened,@PaoGuang,@CaiBian,@CheBian,@KaiKeng,@PiHua,@DaoBian,@MianWan,@ZuanKong,@OtherProcess,@ExtraProcess,@IsForce)");
                parameters = new SqlParameter[] {
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@Mnumber", SqlDbType.NVarChar,50),
					new SqlParameter("@JuSe", SqlDbType.NVarChar,30),
					new SqlParameter("@ChaSe", SqlDbType.NVarChar,30),
					new SqlParameter("@ShuiYin", SqlDbType.NVarChar,30),
					new SqlParameter("@RanSe", SqlDbType.NVarChar,30),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JingJia", SqlDbType.NVarChar,30),
					new SqlParameter("@Hardened", SqlDbType.Bit,1),
					new SqlParameter("@PaoGuang", SqlDbType.NVarChar,30),
					new SqlParameter("@CaiBian", SqlDbType.NVarChar,30),
					new SqlParameter("@CheBian", SqlDbType.NVarChar,30),
					new SqlParameter("@KaiKeng", SqlDbType.NVarChar,30),
					new SqlParameter("@PiHua", SqlDbType.NVarChar,30),
					new SqlParameter("@DaoBian", SqlDbType.NVarChar,30),
					new SqlParameter("@MianWan", SqlDbType.NVarChar,30),
					new SqlParameter("@ZuanKong", SqlDbType.NVarChar,30),
					new SqlParameter("@OtherProcess", SqlDbType.NVarChar,30),
					new SqlParameter("@ExtraProcess", SqlDbType.NVarChar,30),
					new SqlParameter("@IsForce", SqlDbType.Bit,1)};
                parameters[0].Value = --i;
                parameters[1].Value = dr["Mnumber"].ToString().Trim();
                parameters[2].Value = dr["JuSe"].ToString().Trim();
                parameters[3].Value = dr["ChaSe"].ToString().Trim();
                parameters[4].Value = dr["ShuiYin"].ToString().Trim();
                parameters[5].Value = dr["RanSe"].ToString().Trim();
                parameters[6].Value = Convert.ToBoolean(dr["UV"].ToString() == "" ? false : dr["UV"]);
                parameters[7].Value = dr["JingJia"].ToString().Trim();
                parameters[8].Value = Convert.ToBoolean(dr["Hardened"].ToString() == "" ? false : dr["Hardened"]);
                parameters[9].Value = dr["PaoGuang"].ToString().Trim();
                parameters[10].Value = dr["CaiBian"].ToString().Trim();
                parameters[11].Value = dr["CheBian"].ToString().Trim();
                parameters[12].Value = dr["KaiKeng"].ToString().Trim();
                parameters[13].Value = dr["PiHua"].ToString().Trim();
                parameters[14].Value = dr["DaoBian"].ToString().Trim();
                parameters[15].Value = dr["MianWan"].ToString().Trim();
                parameters[16].Value = dr["ZuanKong"].ToString().Trim();
                parameters[17].Value = dr["OtherProcess"].ToString().Trim();
                parameters[18].Value = dr["ExtraProcess"].ToString().Trim();
                parameters[19].Value = Convert.ToBoolean(dr["IsForce"].ToString() == "" ? false : dr["IsForce"]);

                strSql.Append("--" + i.ToString());
                htstrSql.Add(strSql.ToString(), parameters);
                strSql.Clear();
            }
            DbHelperSQL u = new DbHelperSQL(dbCode);
            u.ExecuteSqlTran(htstrSql);

            strSql.Clear();

            strSql.Append(@"
            ;DELETE
            FROM  B_ProcessControl
            WHERE B_ProcessControl.%%physloc%%
                    NOT IN (SELECT MIN(b.%%physloc%%)
                            FROM   B_ProcessControl b
				                GROUP BY 
						            b.Mnumber,b.JuSe,b.ChaSe,b.ShuiYin,b.RanSe,b.UV,b.JingJia,
						            b.Hardened,b.PaoGuang,b.CaiBian,b.CheBian,b.KaiKeng,
						            b.PiHua,b.DaoBian,b.MianWan,b.ZuanKong,b.OtherProcess,
						            b.ExtraProcess,b.IsForce)");

            strSql.Append(@";update B_ProcessControl
                                    set SubID=
                                    (select  N_ID from 
	                                    (select  ROW_NUMBER() OVER (ORDER BY Mnumber)  as N_ID,SubID
		                                    from B_ProcessControl s 
	                                    ) as a
	                                    where a.SubID=B_ProcessControl.SubID
                                    ) ");
            u.ExecuteSql(strSql.ToString());

            return htstrSql.Count;
        }
    }
}