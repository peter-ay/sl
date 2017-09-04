using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DAL
{
    public class DALUtility
    {
        public string SpStr
        {
            get;
            set;
        }

        public string UserCode
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string VCode
        {
            get;
            set;
        }

        public string DBCode
        {
            get;
            set;
        }

        public int LgIndex
        {
            get;
            set;
        }

        public DALUtility()
        {

        }

        public DALUtility(string dbCode, int lgIndex)
        {
            this.DBCode = dbCode;
            this.LgIndex = lgIndex;
        }

        public DALUtility(string dbCode, int lgIndex, string spStr, string vCode)
            : this(dbCode, lgIndex)
        {
            this.SpStr = spStr;
            this.VCode = vCode;
        }

        public DALUtility(string dbCode, int lgIndex, string spStr, string vCode, string userCode, string userName)
            : this(dbCode, lgIndex, spStr, vCode)
        {
            this.UserCode = userCode;
            this.UserName = userName;
        }

        public bool Exists(string dbCode, string strSql, SqlParameter[] parameters)
        {
            bool _rs = false;
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            _rs = dbsql.Exists(strSql, parameters);
            return _rs;
        }

        public void Delete()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SpStr);
            SqlParameter[] parameters = {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@PKCode", SqlDbType.NVarChar,4000),
                    new SqlParameter("@UserCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,30),
                                        };
            parameters[0].Value = LgIndex;
            parameters[1].Value = VCode;
            parameters[2].Value = UserCode;
            parameters[3].Value = UserName;
            DALHelper.RunProcedureTran(DBCode, strSql.ToString(), parameters);
        }

        public void Check()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SpStr);
            SqlParameter[] parameters = {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@PKCode", SqlDbType.NVarChar,4000),
                    new SqlParameter("@UserCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,30),
                    };
            parameters[0].Value = LgIndex;
            parameters[1].Value = VCode;
            parameters[2].Value = UserCode;
            parameters[3].Value = UserName;
            DALHelper.RunProcedureTran(DBCode, strSql.ToString(), parameters);
        }

        public void UnCheck()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SpStr);
            SqlParameter[] parameters = {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@PKCode", SqlDbType.NVarChar,4000),
                    new SqlParameter("@UserCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,30),
                    };
            parameters[0].Value = LgIndex;
            parameters[1].Value = VCode;
            parameters[2].Value = UserCode;
            parameters[3].Value = UserName;
            DALHelper.RunProcedureTran(DBCode, strSql.ToString(), parameters);
        }

    }
}
