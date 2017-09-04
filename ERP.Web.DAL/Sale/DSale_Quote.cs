using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;
using ERP.Web.DBUtility;

namespace ERP.Web.DAL
{
    public partial class DSale_Quote : DALBase
    {
        public DSale_Quote()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sale_Quote with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MSale_Quote model = t as MSale_Quote;
            StringBuilder strSql = new StringBuilder();
            /////////////////////////////////////////////////////////////////////////////
            strSql.Append("Delete Sale_Quote where Maker=@Maker ;");
            ////////////////////////////////////////////////////////////////////////////
            strSql.Append("insert into Sale_Quote(");
            strSql.Append("ID,BType,CusCode,Maker,MName,MDate,BCodePC)");
            strSql.Append(" values (");
            strSql.Append("@ID,@BType,@CusCode,@Maker,@MName,@MDate,@BCodePC)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BType", SqlDbType.VarChar,5),
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
					new SqlParameter("@Maker", SqlDbType.VarChar,10),
					new SqlParameter("@MName", SqlDbType.VarChar,30),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@BCodePC", SqlDbType.VarChar,25)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BType;
            parameters[2].Value = model.CusCode;
            parameters[3].Value = model.Maker;
            parameters[4].Value = model.MName;
            parameters[5].Value = System.DateTime.Now;
            parameters[6].Value = model.BCodePC;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {
            MSale_Quote model = t as MSale_Quote;
            MSale_Quote_SD modelSD = model.Sub_SD;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete Sale_Quote_SD where ID not in (select ID from Sale_Quote with (nolock));  ");
            ///////////////////////////////////////////////////////////////
            strSql.Append("insert into Sale_Quote_SD(");
            strSql.Append("ID,Dia,LensCode,SPH,CYL,Axis,X_ADD,Qty,BASE,CT,DB,D1,D2,D3,D4,P1,P2,P3,P4,Price,PriceJM,ProCost,InvTitle,ProReport,ProCostReport)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Dia,@LensCode,@SPH,@CYL,@Axis,@X_ADD,@Qty,@BASE,@CT,@DB,@D1,@D2,@D3,@D4,@P1,@P2,@P3,@P4,@Price,@PriceJM,@ProCost,@InvTitle,@ProReport,@ProCostReport)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,30),
					new SqlParameter("@Dia", SqlDbType.Int,4),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@SPH", SqlDbType.Int,4),
					new SqlParameter("@CYL", SqlDbType.Int,4),
					new SqlParameter("@Axis", SqlDbType.Int,4),
					new SqlParameter("@X_ADD", SqlDbType.Int,4),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@BASE", SqlDbType.VarChar,10),
					new SqlParameter("@CT", SqlDbType.VarChar,10),
					new SqlParameter("@DB", SqlDbType.Bit,1),
					new SqlParameter("@D1", SqlDbType.VarChar,10),
					new SqlParameter("@D2", SqlDbType.VarChar,10),
					new SqlParameter("@D3", SqlDbType.VarChar,10),
					new SqlParameter("@D4", SqlDbType.VarChar,10),
					new SqlParameter("@P1", SqlDbType.VarChar,10),
					new SqlParameter("@P2", SqlDbType.VarChar,10),
					new SqlParameter("@P3", SqlDbType.VarChar,10),
					new SqlParameter("@P4", SqlDbType.VarChar,10),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PriceJM", SqlDbType.Decimal,9),
					new SqlParameter("@ProCost", SqlDbType.Decimal,9),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@ProReport", SqlDbType.NVarChar,200),
					new SqlParameter("@ProCostReport", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = modelSD.Dia;
            parameters[2].Value = modelSD.LensCode;
            parameters[3].Value = modelSD.SPH;
            parameters[4].Value = modelSD.CYL;
            parameters[5].Value = modelSD.Axis;
            parameters[6].Value = modelSD.X_ADD;
            parameters[7].Value = modelSD.Qty;
            parameters[8].Value = modelSD.BASE;
            parameters[9].Value = modelSD.CT;
            parameters[10].Value = modelSD.DB;
            parameters[11].Value = modelSD.D1;
            parameters[12].Value = modelSD.D2;
            parameters[13].Value = modelSD.D3;
            parameters[14].Value = modelSD.D4;
            parameters[15].Value = modelSD.P1;
            parameters[16].Value = modelSD.P2;
            parameters[17].Value = modelSD.P3;
            parameters[18].Value = modelSD.P4;
            parameters[19].Value = modelSD.Price;
            parameters[20].Value = modelSD.PriceJM;
            parameters[21].Value = modelSD.ProCost;
            parameters[22].Value = modelSD.InvTitle;
            parameters[23].Value = modelSD.ProReport;
            parameters[24].Value = modelSD.ProCostReport;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MSale_Quote_SD_Process modelSD_Process = model.Sub_SD_Process;
            strSql.Clear();
            strSql.Append("Delete Sale_Quote_SD_Process where ID not in (select ID from Sale_Quote with (nolock));  ");
            ///////////////////////////////////////////////////////////////
            strSql.Append("insert into Sale_Quote_SD_Process(");
            strSql.Append("ID,JY,UV,JS,RS,RSName,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP)");
            strSql.Append(" values (");
            strSql.Append("@ID,@JY,@UV,@JS,@RS,@RSName,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP)");
            parameters = new SqlParameter[]{
					new SqlParameter("@ID", SqlDbType.VarChar,30),
					new SqlParameter("@JY", SqlDbType.Bit,1),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JS", SqlDbType.VarChar,15),
					new SqlParameter("@RS", SqlDbType.VarChar,15),
					new SqlParameter("@RSName", SqlDbType.NVarChar,30),
					new SqlParameter("@CS", SqlDbType.VarChar,15),
					new SqlParameter("@SY", SqlDbType.VarChar,15),
					new SqlParameter("@CB", SqlDbType.VarChar,15),
					new SqlParameter("@ChB", SqlDbType.VarChar,15),
					new SqlParameter("@KK", SqlDbType.VarChar,15),
					new SqlParameter("@ZK", SqlDbType.VarChar,15),
					new SqlParameter("@PiH", SqlDbType.VarChar,15),
					new SqlParameter("@PG", SqlDbType.VarChar,15),
					new SqlParameter("@JJ", SqlDbType.VarChar,15),
					new SqlParameter("@OP", SqlDbType.VarChar,15)};
            parameters[0].Value = model.ID;
            parameters[1].Value = modelSD_Process.JY;
            parameters[2].Value = modelSD_Process.UV;
            parameters[3].Value = modelSD_Process.JS;
            parameters[4].Value = modelSD_Process.RS;
            parameters[5].Value = modelSD_Process.RSName;
            parameters[6].Value = modelSD_Process.CS;
            parameters[7].Value = modelSD_Process.SY;
            parameters[8].Value = modelSD_Process.CB;
            parameters[9].Value = modelSD_Process.ChB;
            parameters[10].Value = modelSD_Process.KK;
            parameters[11].Value = modelSD_Process.ZK;
            parameters[12].Value = modelSD_Process.PiH;
            parameters[13].Value = modelSD_Process.PG;
            parameters[14].Value = modelSD_Process.JJ;
            parameters[15].Value = modelSD_Process.OP;
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
