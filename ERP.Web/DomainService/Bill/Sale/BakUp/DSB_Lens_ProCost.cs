
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.DomainServices.Server;
using System.Text;
using ERP.Web.Common;
using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.DomainService.Bill
{
    public partial class DSB_Lens
    {
        [Invoke]
        public void AddProCost(string dbCode, int lgIndex, MB_Lens t)
        {
            var model = t.Sub_ProCost;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Lens_ProCost(");
            strSql.Append("ID,LensCode,F_Set,InvTitle,JY,UV,JS,RS,CS,SY,CB,ChB,KK,ZK,PiH,PG,JJ,OP,P1,P2)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@LensCode,@F_Set,@InvTitle,@JY,@UV,@JS,@RS,@CS,@SY,@CB,@ChB,@KK,@ZK,@PiH,@PG,@JJ,@OP,@P1,@P2)");
            SqlParameter[] parameters = { 
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
					new SqlParameter("@P2", SqlDbType.Decimal,9)};
            parameters[0].Value = model.LensCode;
            parameters[1].Value = model.F_Set;
            parameters[2].Value = model.InvTitle;
            parameters[3].Value = model.JY;
            parameters[4].Value = model.UV;
            parameters[5].Value = model.JS;
            parameters[6].Value = model.RS;
            parameters[7].Value = model.CS;
            parameters[8].Value = model.SY;
            parameters[9].Value = model.CB;
            parameters[10].Value = model.ChB;
            parameters[11].Value = model.KK;
            parameters[12].Value = model.ZK;
            parameters[13].Value = model.PiH;
            parameters[14].Value = model.PG;
            parameters[15].Value = model.JJ;
            parameters[16].Value = model.OP;
            parameters[17].Value = model.P1;
            parameters[18].Value = model.P2;
            DALHelper.ExecuteSql(dbCode, strSql.ToString(), parameters);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        [Invoke]
        public void DeleteProCost(string dbCode, int lgIndex, List<string> codes)
        {
            string str = "";
            codes.ForEach(item => { str += item + ";"; });
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Delete_B_Lens_ProCost);
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@LgIndex", SqlDbType.Int),
            new SqlParameter("@PKCode", SqlDbType.VarChar,2000)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = str;
            DALHelper.RunProcedure(dbCode, strSql.ToString(), parameters);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        [Invoke]
        public void CopyProCost(string dbCode, int lgIndex, string FromLensCode, string ToLensCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Copy_B_Lens_ProCost);
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@LgIndex", SqlDbType.Int),
            new SqlParameter("@FromCode", SqlDbType.VarChar,30),
            new SqlParameter("@ToCode", SqlDbType.VarChar,30)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = FromLensCode;
            parameters[2].Value = ToLensCode;
            DALHelper.RunProcedure(dbCode, strSql.ToString(), parameters);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        [Invoke]
        public void EditProCost(string dbCode, int lgIndex, List<string> codes, decimal p1, decimal p2)
        {
            string str = "";
            codes.ForEach(item => { str += item + ";"; });
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Edit_B_Lens_ProCost);
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@LgIndex", SqlDbType.Int),
            new SqlParameter("@PKCode", SqlDbType.VarChar,2000),
            new SqlParameter("@P1", SqlDbType.Decimal,9),
            new SqlParameter("@P2", SqlDbType.Decimal,9)
            };
            parameters[0].Value = lgIndex;
            parameters[1].Value = str;
            parameters[2].Value = p1;
            parameters[3].Value = p2;
            DALHelper.RunProcedure(dbCode, strSql.ToString(), parameters);
        }

    }
}


