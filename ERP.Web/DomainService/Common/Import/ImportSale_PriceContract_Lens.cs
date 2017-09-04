using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportSale_PriceContract_Lens : ImportBaseBID
    {
        //public int Import(string dbCode, int lgIndex, string fileName, string BID)
        //{
        //    DbHelperOledb oledb = new DbHelperOledb();
        //    DataSet ds = oledb.ChangeExcelToDataSet(fileName);

        //    Hashtable htstrSqlMain = new Hashtable();
        //    Hashtable htstrSqlSub = new Hashtable();

        //    SqlParameter[] parameters = null;
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("Delete Sale_PriceContract_Lens where BID=@BID ;");
        //    parameters = new SqlParameter[] {
        //            new SqlParameter("@BID", SqlDbType.VarChar,25)};
        //    parameters[0].Value = BID;
        //    htstrSqlMain.Add(strSql.ToString(), parameters);
        //    strSql.Clear();

        //    int i = 1;
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        strSql.Append("delete Sale_PriceContract_Lens ");
        //        strSql.Append("where BID=@BID and LensCode=@LensCode ");
        //        strSql.Append("and SPH1=@SPH1 and SPH2=@SPH2 ");
        //        strSql.Append("and CYL1=@CYL1 and CYL2=@CYL2 ");
        //        strSql.Append("and X_ADD1=@ADD1 and X_ADD2=@ADD2 and Dia=@Dia;");
        //        ////////////////////////
        //        strSql.Append("insert into Sale_PriceContract_Lens(");
        //        strSql.Append("ID,BID,LensCode,SPH1,SPH2,CYL1,CYL2,ADD1,ADD2,Dia,P1,P2,P1JM,P2JM,InvTitle)");
        //        strSql.Append(" values (");
        //        strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@LensCode,@SPH1,@SPH2,@CYL1,@CYL2,@ADD1,@ADD2,@Dia,@P1,@P2,@P1JM,@P2JM,@InvTitle)");
        //        parameters = new SqlParameter[] {
        //            new SqlParameter("@ID", SqlDbType.VarChar,25),
        //            new SqlParameter("@BID", SqlDbType.VarChar,25),
        //            new SqlParameter("@LensCode", SqlDbType.VarChar,30),
        //            new SqlParameter("@SPH1", SqlDbType.Int,4),
        //            new SqlParameter("@SPH2", SqlDbType.Int,4),
        //            new SqlParameter("@CYL1", SqlDbType.Int,4),
        //            new SqlParameter("@CYL2", SqlDbType.Int,4),
        //            new SqlParameter("@X_ADD1", SqlDbType.Int,4),
        //            new SqlParameter("@X_ADD2", SqlDbType.Int,4),
        //            new SqlParameter("@Dia", SqlDbType.Int,4),
        //            new SqlParameter("@P1", SqlDbType.Decimal,9),
        //            new SqlParameter("@P2", SqlDbType.Decimal,9),
        //            new SqlParameter("@P1JM", SqlDbType.Decimal,9),
        //            new SqlParameter("@P2JM", SqlDbType.Decimal,9),
        //            new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
        //        parameters[0].Value = "";
        //        parameters[1].Value = BID;
        //        parameters[2].Value = dr["LensCode"].ToString();
        //        parameters[3].Value = dr["SPH1"].ToString();
        //        parameters[4].Value = dr["SPH2"].ToString();
        //        parameters[5].Value = dr["CYL1"].ToString();
        //        parameters[6].Value = dr["CYL2"].ToString();
        //        parameters[7].Value = dr["X_ADD1"].ToString();
        //        parameters[8].Value = dr["X_ADD2"].ToString();
        //        parameters[9].Value = dr["Dia"].ToString();
        //        parameters[10].Value = dr["P1"].ToString();
        //        parameters[11].Value = dr["P2"].ToString();
        //        parameters[12].Value = dr["P1JM"].ToString();
        //        parameters[13].Value = dr["P2JM"].ToString();
        //        parameters[14].Value = dr["InvTitle"].ToString();

        //        strSql.Append("--" + i++.ToString());
        //        htstrSqlSub.Add(strSql.ToString(), parameters);
        //        strSql.Clear();
        //    }
        //    DbHelperSQL u = new DbHelperSQL(dbCode);
        //    u.ExecuteSqlTran(htstrSqlMain, htstrSqlSub);

        //    return htstrSqlSub.Count;
        //}

        protected override void PrepareImport(SqlCommand cmd, DataSet ds, string bID)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #Sale_PriceContract_Lens from Sale_PriceContract_Lens ;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #Sale_PriceContract_Lens ");
                strSql.Append("where BID=@BID and LensCode=@LensCode ");
                strSql.Append("and SPH1=@SPH1 and SPH2=@SPH2 ");
                strSql.Append("and CYL1=@CYL1 and CYL2=@CYL2 ");
                strSql.Append("and X_ADD1=@X_ADD1 and X_ADD2=@X_ADD2 and Dia=@Dia;");
                ////////////////////////
                strSql.Append("insert into #Sale_PriceContract_Lens(");
                strSql.Append("ID,BID,LensCode,SPH1,SPH2,CYL1,CYL2,X_ADD1,X_ADD2,Dia,P1,P2,P1JM,P2JM,InvTitle)");
                strSql.Append(" values (");
                strSql.Append("(select HKOERP.dbo.SF_GetID()),@BID,@LensCode,@SPH1,@SPH2,@CYL1,@CYL2,@X_ADD1,@X_ADD2,@Dia,@P1,@P2,@P1JM,@P2JM,@InvTitle)");
                parameters = new SqlParameter[] {
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
                            new SqlParameter("@P1JM", SqlDbType.Decimal,9),
                            new SqlParameter("@P2JM", SqlDbType.Decimal,9),
                            new SqlParameter("@InvTitle", SqlDbType.NVarChar,50)};
                parameters[0].Value = "";
                parameters[1].Value = bID;
                parameters[2].Value = dr["LensCode"].ToString();
                parameters[3].Value = dr["SPH1"].ToString();
                parameters[4].Value = dr["SPH2"].ToString();
                parameters[5].Value = dr["CYL1"].ToString();
                parameters[6].Value = dr["CYL2"].ToString();
                parameters[7].Value = dr["X_ADD1"].ToString();
                parameters[8].Value = dr["X_ADD2"].ToString();
                parameters[9].Value = dr["Dia"].ToString();
                parameters[10].Value = dr["P1"].ToString();
                parameters[11].Value = dr["P2"].ToString();
                parameters[12].Value = dr["P1JM"].ToString();
                parameters[13].Value = dr["P2JM"].ToString();
                parameters[14].Value = dr["InvTitle"].ToString();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete Sale_PriceContract_Lens where BID=@BID;");
            strSql.Append("insert into Sale_PriceContract_Lens select * from #Sale_PriceContract_Lens;");
            cmd.CommandText = strSql.ToString();
            parameters = new SqlParameter[] {
                        new SqlParameter("@BID", SqlDbType.VarChar,25)};
            parameters[0].Value = bID;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }
    }
}