using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DSale_PriceContract_Lens_ProCost : DALBase
    {
        public DSale_PriceContract_Lens_ProCost()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sale_PriceContract_Lens_ProCost with (nolock)");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MSale_PriceContract_Lens_ProCost;
            StringBuilder strSql = new StringBuilder();
            //////////////////////////////////////////
            strSql.Append("delete Sale_PriceContract_Lens_ProCost ");
            strSql.Append("where BID=@BID and LensCode=@LensCode and F_Set=@F_Set ");
            strSql.Append("and JY=@JY and UV=@UV and JS=@JS and RS=@RS and CS=@CS  ");
            strSql.Append("and SY=@SY and CB=@CB and ChB=@ChB and KK=@KK and ZK=@ZK  ");
            strSql.Append("and PiH=@PiH and PG=@PG and JJ=@JJ and OP=@OP ;  ");
            /////////////////////////////////////////
            strSql.Append("insert into Sale_PriceContract_Lens_ProCost(");
            strSql.Append("ID,BID,LensCode,F_Set,InvTitle,JY,UV,JS,RS,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP,P1,P2,P1JM,P2JM)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@LensCode,@F_Set,@InvTitle,@JY,@UV,@JS,@RS,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP,@P1,@P2,@P1JM,@P2JM)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,25),
					new SqlParameter("@BID", SqlDbType.VarChar,25),
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@F_Set", SqlDbType.Bit,1),
					new SqlParameter("@InvTitle", SqlDbType.NVarChar,40),
					new SqlParameter("@JY", SqlDbType.Bit,1),
					new SqlParameter("@UV", SqlDbType.Bit,1),
					new SqlParameter("@JS", SqlDbType.VarChar,15),
					new SqlParameter("@RS", SqlDbType.VarChar,15),
					new SqlParameter("@CS", SqlDbType.VarChar,15),
					new SqlParameter("@SY", SqlDbType.VarChar,15),
					new SqlParameter("@CB", SqlDbType.VarChar,15),
					new SqlParameter("@ChB", SqlDbType.VarChar,15),
					new SqlParameter("@KK", SqlDbType.VarChar,15),
					new SqlParameter("@ZK", SqlDbType.VarChar,15),
					new SqlParameter("@PiH", SqlDbType.VarChar,15),
					new SqlParameter("@PG", SqlDbType.VarChar,15),
					new SqlParameter("@JJ", SqlDbType.VarChar,15),
					new SqlParameter("@OP", SqlDbType.VarChar,15),
					new SqlParameter("@P1", SqlDbType.Decimal,9),
					new SqlParameter("@P2", SqlDbType.Decimal,9),
                    new SqlParameter("@P1JM", SqlDbType.Decimal,9),
					new SqlParameter("@P2JM", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BID;
            parameters[2].Value = model.LensCode;
            parameters[3].Value = model.F_Set;
            parameters[4].Value = model.InvTitle;
            parameters[5].Value = model.JY;
            parameters[6].Value = model.UV;
            parameters[7].Value = model.JS;
            parameters[8].Value = model.RS;
            parameters[9].Value = model.CS;
            parameters[10].Value = model.SY;
            parameters[11].Value = model.CB;
            parameters[12].Value = model.ChB;
            parameters[13].Value = model.KK;
            parameters[14].Value = model.ZK;
            parameters[15].Value = model.PiH;
            parameters[16].Value = model.PG;
            parameters[17].Value = model.JJ;
            parameters[18].Value = model.OP;
            parameters[19].Value = model.P1;
            parameters[20].Value = model.P2;
            parameters[21].Value = model.P1JM;
            parameters[22].Value = model.P2JM;
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
