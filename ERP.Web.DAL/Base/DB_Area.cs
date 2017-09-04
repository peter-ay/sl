using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Area : DALBase
    {
        public DB_Area()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Area with (nolock)");
            strSql.Append(" where AreaCode=@AreaCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,10)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "AreaCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Area;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Area(");
            strSql.Append("AreaCode,AreaName,PCode)");
            strSql.Append(" values (");
            strSql.Append("@AreaCode,@AreaName,@PCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,10),
					new SqlParameter("@AreaName", SqlDbType.NVarChar,100),
					new SqlParameter("@PCode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.AreaCode;
            parameters[1].Value = model.AreaName;
            parameters[2].Value = model.PCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Area;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Area set ");
            strSql.Append("AreaName=@AreaName,");
            strSql.Append("PCode=@PCode");
            strSql.Append(" where AreaCode=@AreaCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaName", SqlDbType.NVarChar,100),
					new SqlParameter("@PCode", SqlDbType.NVarChar,10),
					new SqlParameter("@AreaCode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.AreaName;
            parameters[1].Value = model.PCode;
            parameters[2].Value = model.AreaCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }


    }
}
