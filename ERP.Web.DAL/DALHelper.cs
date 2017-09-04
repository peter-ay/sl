
using System.Collections.Generic;
using System.Data.SqlClient;
using ERP.Web.DBUtility;
using System.Collections;
using System.Text;
using System.Data;
namespace ERP.Web.DAL
{
    public class DALHelper
    {
        public static readonly string ID = "ID";
        public static readonly string BCode = "BCode";
        public static readonly string Main = "Main";
        public static readonly string S0 = "S0";
        public static readonly string S1 = "S1";
        public static readonly string S2 = "S2";
        public static readonly string S3 = "S3";
        public static readonly string S4 = "S4";
        public static readonly string S5 = "S5";
        public static readonly string S6 = "S6";
        public static readonly string S7 = "S7";
        public static readonly string S8 = "S8";
        public static readonly string S9 = "S9";
        public static readonly string S10 = "S10";

        //public static Dictionary<string, string> DictionarySql = new Dictionary<string, string>();
        //public static Dictionary<string, SqlParameter[]> DictionarySqlPara = new Dictionary<string, SqlParameter[]>();

        public static string GetLanguageText(string code, int lgindex)
        {
            DbHelperSQL dbsql = new DbHelperSQL();
            return dbsql.GetLanguageText(code, lgindex);
        }

        public static void ExecuteSql(string dbCode, string strSql, SqlParameter[] parameters)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql, parameters);
        }

        public static void RunProcedure(string dbCode, string strSql, SqlParameter[] parameters)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.RunProcedure(strSql, parameters);
        }

        public static void RunProcedureTran(string dbCode, string strSql, SqlParameter[] parameters)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.RunProcedureTran(strSql, parameters);
        }

        public static Hashtable PrepareOrderID(string spName)
        {
            Hashtable ht = new Hashtable();
            var key = ID;
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append(spName);
            parameters = new SqlParameter[] { 
					new SqlParameter("@BillID", SqlDbType.NVarChar,30)};
            parameters[0].Value = "";
            parameters[0].Direction = ParameterDirection.Output;

            Dictionary<string, string> DictionarySql = new Dictionary<string, string>();
            DictionarySql.Add(key, strSql.ToString());
            Dictionary<string, SqlParameter[]> DictionarySqlPara = new Dictionary<string, SqlParameter[]>();
            DictionarySqlPara.Add(key, parameters);

            ht.Add(DictionarySql[key], DictionarySqlPara[key]);
            return ht;
        }

        public static Hashtable PrepareOrderCode(string spName, string prefix, string addition, string suffix, string sn)
        {
            Hashtable ht = new Hashtable();
            var key = BCode;
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            strSql.Append(spName);
            parameters = new SqlParameter[] {
					new SqlParameter("@Prefix", SqlDbType.VarChar,5),
					new SqlParameter("@Addition", SqlDbType.VarChar,5),
					new SqlParameter("@Suffix", SqlDbType.VarChar,10),
                    new SqlParameter("@SN", SqlDbType.VarChar,20),
					new SqlParameter("@BCode", SqlDbType.VarChar,40)};
            parameters[0].Value = prefix;
            parameters[1].Value = addition;
            parameters[2].Value = suffix;
            parameters[3].Value = sn;
            parameters[4].Value = "";
            parameters[4].Direction = ParameterDirection.Output;

            Dictionary<string, string> DictionarySql = new Dictionary<string, string>();
            DictionarySql.Add(key, strSql.ToString());
            Dictionary<string, SqlParameter[]> DictionarySqlPara = new Dictionary<string, SqlParameter[]>();
            DictionarySqlPara.Add(key, parameters);

            ht.Add(DictionarySql[key], DictionarySqlPara[key]);
            return ht;
        }
    }
}
