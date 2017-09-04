using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_PriceContract_Lens_ProCost
    {
        public int Import(string dbCode, int lgIndex, string fileName, string BID)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSqlMain = new Hashtable();
            Hashtable htstrSqlSub = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete Sale_PriceContract_Lens_ProCost where BID=@BID ;");
            parameters = new SqlParameter[] {
					new SqlParameter("@BID", SqlDbType.VarChar,25)};
            parameters[0].Value = BID;
            htstrSqlMain.Add(strSql.ToString(), parameters);
            strSql.Clear();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("delete Sale_PriceContract_Lens_ProCost ");
                strSql.Append("where BID=@BID and LensCode=@LensCode and F_Set=@F_Set ");
                strSql.Append("and JY=@JY and UV=@UV and JS=@JS and RS=@RS and CS=@CS  ");
                strSql.Append("and SY=@SY and CB=@CB and ChB=@ChB and KK=@KK and ZK=@ZK  ");
                strSql.Append("and PiH=@PiH and PG=@PG and JJ=@JJ and OP=@OP ;  ");
                ////////////////////////
                strSql.Append("insert into Sale_PriceContract_Lens_ProCost(");
                strSql.Append("ID,BID,LensCode,F_Set,InvTitle,JY,UV,JS,RS,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP,P1,P2,P1JM,P2JM)");
                strSql.Append(" values (");
                strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@LensCode,@F_Set,@InvTitle,@JY,@UV,@JS,@RS,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP,@P1,@P2,@P1JM,@P2JM)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@F_Set", SqlDbType.Bit,1),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,40),
					new SqlParameter("@JY", SqlDbType.Bit,1),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JS", SqlDbType.VarChar,15),
					new SqlParameter("@RS", SqlDbType.VarChar,15),
					new SqlParameter("@CS", SqlDbType.VarChar,15),
					new SqlParameter("@SY", SqlDbType.VarChar,15),
					new SqlParameter("@CB", SqlDbType.VarChar,15),
					new SqlParameter("@ChB", SqlDbType.VarChar,15),
					new SqlParameter("@KK", SqlDbType.VarChar,15),
					new SqlParameter("@ZK", SqlDbType.VarChar,15),
					new SqlParameter("@PiH", SqlDbType.VarChar,15),
					new SqlParameter("@PG", SqlDbType.VarChar,15),
					new SqlParameter("@JJ", SqlDbType.VarChar,15),
					new SqlParameter("@OP", SqlDbType.VarChar,15),
					new SqlParameter("@P1", SqlDbType.Decimal,9),
					new SqlParameter("@P2", SqlDbType.Decimal,9),
                    new SqlParameter("@P1JM", SqlDbType.Decimal,9),
					new SqlParameter("@P2JM", SqlDbType.Decimal,9)};
                parameters[0].Value = "";
                parameters[1].Value = BID;
                parameters[2].Value = dr["LensCode"].ToString();
                parameters[3].Value = System.Convert.ToBoolean(dr["F_Set"].ToString() == "" ? false : dr["F_Set"]);
                parameters[4].Value = dr["InvTitle"].ToString();
                parameters[5].Value = System.Convert.ToBoolean(dr["JY"].ToString() == "" ? false : dr["JY"]);
                parameters[6].Value = System.Convert.ToBoolean(dr["UV"].ToString() == "" ? false : dr["UV"]);
                parameters[7].Value = dr["JS"].ToString();
                parameters[8].Value = dr["RS"].ToString();
                parameters[9].Value = dr["CS"].ToString();
                parameters[10].Value = dr["SY"].ToString();
                parameters[11].Value = dr["CB"].ToString();
                parameters[12].Value = dr["ChB"].ToString();
                parameters[13].Value = dr["KK"].ToString();
                parameters[14].Value = dr["ZK"].ToString();
                parameters[15].Value = dr["PiH"].ToString();
                parameters[16].Value = dr["PG"].ToString();
                parameters[17].Value = dr["JJ"].ToString();
                parameters[18].Value = dr["OP"].ToString();
                parameters[19].Value = dr["P1"].ToString();
                parameters[20].Value = dr["P2"].ToString();
                parameters[21].Value = dr["P1JM"].ToString();
                parameters[25].Value = dr["P2JM"].ToString();

                strSql.Append("--" + i++.ToString());
                htstrSqlSub.Add(strSql.ToString(), parameters);
                strSql.Clear();
            }
            DbHelperSQL u = new DbHelperSQL(dbCode);
            u.ExecuteSqlTran(htstrSqlMain, htstrSqlSub);

            return htstrSqlSub.Count;
        }
    }
}