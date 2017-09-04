using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DPur_PriceContract_Lens : DALBase
    {
        public DPur_PriceContract_Lens()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pur_PriceContract_Lens with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MPur_PriceContract_Lens;
            StringBuilder strSql = new StringBuilder();
            //////////////////////////////////////////
            strSql.Append("delete Pur_PriceContract_Lens ");
            strSql.Append("where BID=@BID and LensCode=@LensCode ");
            strSql.Append("and SPH1=@SPH1 and SPH2=@SPH2 and CYL1=@CYL1 and CYL2=@CYL2 and X_ADD1=@X_ADD1 and X_ADD2=@X_ADD2 and Dia=@Dia;");
            /////////////////////////////////////////
            strSql.Append("insert into Pur_PriceContract_Lens(");
            strSql.Append("ID,BID,LensCode,SPH1,SPH2,CYL1,CYL2,X_ADD1,X_ADD2,Dia,P1,P2,InvTitle)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@LensCode,@SPH1,@SPH2,@CYL1,@CYL2,@X_ADD1,@X_ADD2,@Dia,@P1,@P2,@InvTitle)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@SPH1", SqlDbType.Int,4),
					new SqlParameter("@SPH2", SqlDbType.Int,4),
					new SqlParameter("@CYL1", SqlDbType.Int,4),
					new SqlParameter("@CYL2", SqlDbType.Int,4),
					new SqlParameter("@X_ADD1", SqlDbType.Int,4),
					new SqlParameter("@X_ADD2", SqlDbType.Int,4),
					new SqlParameter("@Dia", SqlDbType.Int,4),
					new SqlParameter("@P1", SqlDbType.Decimal,9),
					new SqlParameter("@P2", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BID;
            parameters[2].Value = model.LensCode;
            parameters[3].Value = model.SPH1;
            parameters[4].Value = model.SPH2;
            parameters[5].Value = model.CYL1;
            parameters[6].Value = model.CYL2;
            parameters[7].Value = model.X_ADD1;
            parameters[8].Value = model.X_ADD2;
            parameters[9].Value = model.Dia;
            parameters[10].Value = model.P1;
            parameters[11].Value = model.P2;
            parameters[12].Value = model.InvTitle;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {

        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
