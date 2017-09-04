using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;
using ERP.Web.Model;
using ERP.Web.Interface;

namespace ERP.Web.DAL
{
    public partial class DB_Material_LensClass_Brand : DALBase
    {
        public DB_Material_LensClass_Brand()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Material_LensClass_Brand with (nolock)");
            strSql.Append(" where KeyCode=@KeyCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyCode", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "KeyCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MB_Material_LensClass_Brand model = t as MB_Material_LensClass_Brand;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Material_LensClass_Brand(");
            strSql.Append("KeyCode,KeyName,SN)");
            strSql.Append(" values (");
            strSql.Append("@KeyCode,@KeyName,@SN)");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyCode", SqlDbType.VarChar,10),
					new SqlParameter("@KeyName", SqlDbType.NVarChar,30),
					new SqlParameter("@SN", SqlDbType.Int,4)};
            parameters[0].Value = model.KeyCode;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.SN;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Material_LensClass_Brand;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Material_LensClass_Brand set ");
            strSql.Append("KeyName=@KeyName,");
            strSql.Append("SN=@SN");
            strSql.Append(" where KeyCode=@KeyCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyName", SqlDbType.NVarChar,30),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@KeyCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.SN;
            parameters[2].Value = model.KeyCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Material_LensClass_Brand;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Material_LensClass_Brand set ");
            strSql.Append("KeyName=@KeyName,");
            strSql.Append("SN=@SN");
            strSql.Append(" where KeyCode=@KeyCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyName", SqlDbType.NVarChar,30),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@KeyCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.SN;
            parameters[2].Value = model.KeyCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

    }
}
