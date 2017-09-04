using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_PriceContract_CusGroup
    {
        public int Import(string dbCode, int lgIndex, string fileName)
        {
            DbHelperOledb oledb = new DbHelperOledb();
            DataSet ds = oledb.ChangeExcelToDataSet(fileName);

            Hashtable htstrSqlMain = new Hashtable();
            Hashtable htstrSqlSub = new Hashtable();

            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Delete Sale_PriceContract_CusGroup  ;");
            parameters = new SqlParameter[] { };
            htstrSqlMain.Add(strSql.ToString(), parameters);
            strSql.Clear();

            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Append("Delete Sale_PriceContract_CusGroup where GpCode=@GpCode ;");
                strSql.Append("insert into Sale_PriceContract_CusGroup(");
                strSql.Append("GpCode,GpName)");
                strSql.Append(" values (@GpCode,@GpName);");
                parameters = new SqlParameter[] {
					new SqlParameter("@GpCode", SqlDbType.NVarChar,30),
					new SqlParameter("@GpName", SqlDbType.NVarChar,10)};
                parameters[0].Value = dr["GpCode"].ToString();
                parameters[1].Value = dr["GpName"].ToString();

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