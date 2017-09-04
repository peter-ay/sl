using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_PriceContract_FrameSet
    {
        public int Import(string dbCode, int lgIndex, string fileName, string BID)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSqlMain = new Hashtable();
            Hashtable htstrSqlSub = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete Sale_PriceContract_FrameSet where BID=@BID ;");
            parameters = new SqlParameter[] {
					new SqlParameter("@BID", SqlDbType.VarChar,25)};
            parameters[0].Value = BID;
            htstrSqlMain.Add(strSql.ToString(), parameters);
            strSql.Clear();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("delete Sale_PriceContract_FrameSet ");
                strSql.Append("where BID=@BID and FrameCode=@FrameCode and FQty=@FQty ");
                strSql.Append("and LensCode=@LensCode and LQty=@LQty ;");
                ////////////////////////
                strSql.Append("insert into Sale_PriceContract_FrameSet(");
                strSql.Append("ID,BID,FrameCode,FQty,LensCode,LQty,Price,Price_ProCost,PriceJM,Price_ProCostJM,InvTitle)");
                strSql.Append(" values (");
                strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@FrameCode,@FQty,@LensCode,@LQty,@Price,@Price_ProCost,@PriceJM,@Price_ProCostJM,@InvTitle)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
					new SqlParameter("@FQty", SqlDbType.Int,4),
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@LQty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Price_ProCost", SqlDbType.Decimal,9),
                    new SqlParameter("@PriceJM", SqlDbType.Decimal,9),
					new SqlParameter("@Price_ProCostJM", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
                parameters[0].Value = "";
                parameters[1].Value = BID;
                parameters[2].Value = dr["FrameCode"].ToString();
                parameters[3].Value = dr["FQty"].ToString();
                parameters[4].Value = dr["LensCode"].ToString();
                parameters[5].Value = dr["LQty"].ToString();
                parameters[6].Value = dr["Price"].ToString();
                parameters[7].Value = dr["Price_ProCost"].ToString();
                parameters[8].Value = dr["PriceJM"].ToString();
                parameters[9].Value = dr["Price_ProCostJM"].ToString();
                parameters[10].Value = dr["InvTitle"].ToString();

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