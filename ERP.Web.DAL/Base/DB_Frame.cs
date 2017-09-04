using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;


namespace ERP.Web.DAL
{
    public partial class DB_Frame : DALBase
    {
        public DB_Frame()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Frame with (nolock)");
            strSql.Append(" where FrameCode=@FrameCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "FrameCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Frame;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Frame(");
            strSql.Append("FrameCode,FrameName,Brand,Family,Material,Width,Heigh,Leg_Length,Bridge,Colour,Origin)");
            strSql.Append(" values (");
            strSql.Append("@FrameCode,@FrameName,@Brand,@Family,@Material,@Width,@Heigh,@Leg_Length,@Bridge,@Colour,@Origin)");
            SqlParameter[] parameters = {
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
					new SqlParameter("@FrameName", SqlDbType.VarChar,50),
					new SqlParameter("@Brand", SqlDbType.VarChar,30),
					new SqlParameter("@Family", SqlDbType.VarChar,30),
					new SqlParameter("@Material", SqlDbType.VarChar,30),
					new SqlParameter("@Width", SqlDbType.Decimal,9),
					new SqlParameter("@Heigh", SqlDbType.Decimal,9),
					new SqlParameter("@Leg_Length", SqlDbType.Decimal,9),
					new SqlParameter("@Bridge", SqlDbType.Decimal,9),
					new SqlParameter("@Colour", SqlDbType.VarChar,20),
					new SqlParameter("@Origin", SqlDbType.VarChar,20)};
            parameters[0].Value = model.FrameCode;
            parameters[1].Value = model.FrameName;
            parameters[2].Value = model.Brand;
            parameters[3].Value = model.Family;
            parameters[4].Value = model.Material;
            parameters[5].Value = model.Width;
            parameters[6].Value = model.Heigh;
            parameters[7].Value = model.Leg_Length;
            parameters[8].Value = model.Bridge;
            parameters[9].Value = model.Colour;
            parameters[10].Value = model.Origin;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Frame;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Frame set ");
            strSql.Append("FrameName=@FrameName,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("Family=@Family,");
            strSql.Append("Material=@Material,");
            strSql.Append("Width=@Width,");
            strSql.Append("Heigh=@Heigh,");
            strSql.Append("Leg_Length=@Leg_Length,");
            strSql.Append("Bridge=@Bridge,");
            strSql.Append("Colour=@Colour,");
            strSql.Append("Origin=@Origin");
            strSql.Append(" where FrameCode=@FrameCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@FrameName", SqlDbType.VarChar,50),
					new SqlParameter("@Brand", SqlDbType.VarChar,30),
					new SqlParameter("@Family", SqlDbType.VarChar,30),
					new SqlParameter("@Material", SqlDbType.VarChar,30),
					new SqlParameter("@Width", SqlDbType.Decimal,9),
					new SqlParameter("@Heigh", SqlDbType.Decimal,9),
					new SqlParameter("@Leg_Length", SqlDbType.Decimal,9),
					new SqlParameter("@Bridge", SqlDbType.Decimal,9),
					new SqlParameter("@Colour", SqlDbType.VarChar,20),
					new SqlParameter("@Origin", SqlDbType.VarChar,20),
					new SqlParameter("@FrameCode", SqlDbType.VarChar,30)};
            parameters[0].Value = model.FrameName;
            parameters[1].Value = model.Brand;
            parameters[2].Value = model.Family;
            parameters[3].Value = model.Material;
            parameters[4].Value = model.Width;
            parameters[5].Value = model.Heigh;
            parameters[6].Value = model.Leg_Length;
            parameters[7].Value = model.Bridge;
            parameters[8].Value = model.Colour;
            parameters[9].Value = model.Origin;
            parameters[10].Value = model.FrameCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
