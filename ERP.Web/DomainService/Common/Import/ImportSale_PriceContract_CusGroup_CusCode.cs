using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_PriceContract_CusGroup_CusCode
    {
        public int Import(string dbCode, int lgIndex, string fileName, string BID)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSqlMain = new Hashtable();
            Hashtable htstrSqlSub = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Delete Sale_PriceContract_CusGroup_CusCode where GpCode=@GpCode ;");
            parameters = new SqlParameter[] {
					new SqlParameter("@GpCode", SqlDbType.VarChar,22)};
            parameters[0].Value = BID;
            htstrSqlMain.Add(strSql.ToString(), parameters);
            strSql.Clear();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("insert into Sale_PriceContract_CusGroup_CusCode(");
                strSql.Append("GpCode,CusCode)");
                strSql.Append(" values (@GpCode,@CusCode);");
                parameters = new SqlParameter[] {
					new SqlParameter("@GpCode", SqlDbType.NVarChar,30),
					new SqlParameter("@CusCode", SqlDbType.NVarChar,10)};
                parameters[0].Value = dr["GpCode"].ToString();
                parameters[1].Value = dr["CusCode"].ToString();

                strSql.Append("--" + i++.ToString());
                htstrSqlSub.Add(strSql.ToString(), parameters);
                strSql.Clear();
            }
            DbHelperSQL u = new DbHelperSQL(dbCode);
            u.ExecuteSqlTran(htstrSqlMain,htstrSqlSub);

            return htstrSqlSub.Count;
        }
    }
}