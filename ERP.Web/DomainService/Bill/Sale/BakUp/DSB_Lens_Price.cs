
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
        public void AddPrice(string dbCode, int lgIndex, MB_Lens t)
        {
            var model = t.Sub_Price;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Lens_Price(");
            strSql.Append("ID,LensCode,SPH1,SPH2,CYL1,CYL2,ADD1,ADD2,Dia,P1,P2)");
            strSql.Append(" values (");
            strSql.Append("(select HKOERP.dbo.SF_GetID()),@LensCode,@SPH1,@SPH2,@CYL1,@CYL2,@ADD1,@ADD2,@Dia,@P1,@P2)");
            SqlParameter[] parameters = { 
					new SqlParameter("@LensCode", SqlDbType.VarChar,30),
					new SqlParameter("@SPH1", SqlDbType.Int,4),
					new SqlParameter("@SPH2", SqlDbType.Int,4),
					new SqlParameter("@CYL1", SqlDbType.Int,4),
					new SqlParameter("@CYL2", SqlDbType.Int,4),
					new SqlParameter("@ADD1", SqlDbType.Int,4),
					new SqlParameter("@ADD2", SqlDbType.Int,4),
					new SqlParameter("@Dia", SqlDbType.Int,4),
					new SqlParameter("@P1", SqlDbType.Decimal,9),
					new SqlParameter("@P2", SqlDbType.Decimal,9)};
            parameters[0].Value = model.LensCode;
            parameters[1].Value = model.SPH1;
            parameters[2].Value = model.SPH2;
            parameters[3].Value = model.CYL1;
            parameters[4].Value = model.CYL2;
            parameters[5].Value = model.ADD1;
            parameters[6].Value = model.ADD2;
            parameters[7].Value = model.Dia;
            parameters[8].Value = model.P1;
            parameters[9].Value = model.P2;
            DALHelper.ExecuteSql(dbCode, strSql.ToString(), parameters);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        [Invoke]
        public void DeletePrice(string dbCode, int lgIndex, List<string> codes)
        {
            string str = "";
            codes.ForEach(item => { str += item + ";"; });
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Delete_B_Lens_Price);
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@LgIndex", SqlDbType.Int),
            new SqlParameter("@PKCode", SqlDbType.VarChar,2000)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = str;
            DALHelper.RunProcedure(dbCode, strSql.ToString(), parameters);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        [Invoke]
        public void CopyPrice(string dbCode, int lgIndex, string FromLensCode, string ToLensCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Copy_B_Lens_Price);
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
        public void EditPrice(string dbCode, int lgIndex, List<string> codes, decimal p1, decimal p2)
        {
            string str = "";
            codes.ForEach(item => { str += item + ";"; });
            StringBuilder strSql = new StringBuilder();
            strSql.Append(SPName.SP_Edit_B_Lens_Price);
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


