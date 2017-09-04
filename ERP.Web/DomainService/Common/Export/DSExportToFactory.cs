
namespace ERP.Web.DomainService.Common
{
    using ADOX;
    using ERP.Web.DBUtility;
    using ERP.Web.DomainService.Erp;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using System.Web;
    using ERP.Web.Common;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSExportToFactory : DomainService
    {
        private bool _Is_CX = false;
        private string _add = "";

        //[Invoke]
        //public byte[] ExportExcelToFactory(List<string> billCodes, bool is_cx, string userCode)
        //{
        //    try
        //    {
        //        this._Is_CX = is_cx;
        //        if (is_cx)
        //        {
        //            _add = "_ED";
        //        }
        //        string mdbFile = HttpContext.Current.Server.MapPath("~/Export/" + userCode + ".mdb");
        //        if (!File.Exists(mdbFile))
        //        {
        //            this.CreateMdb(mdbFile);
        //        }
        //        string excelFile = HttpContext.Current.Server.MapPath("~/Export/" + userCode + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".xls");
        //        FillDateIntoMdb(mdbFile, excelFile, userCode, billCodes);
        //        byte[] _Rs = File.ReadAllBytes(excelFile);
        //        File.Delete(excelFile);
        //        return _Rs;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        [Invoke]
        public string Export(string dbCode, int lgIndex, string userCode, List<string> billCodes)
        {
            try
            {
                //this._Is_CX = is_cx;
                //if (is_cx)
                //{
                //    _add = "_ED";
                //}
                var bID = ComID.GetInstance().ID25;
                string mdbFile = HttpContext.Current.Server.MapPath("~/Export/" + userCode + ".mdb");
                if (!File.Exists(mdbFile))
                {
                    this.CreateMdb(mdbFile);
                }
                string excelFile = userCode + bID + ".xls";
                string excelFileFull = HttpContext.Current.Server.MapPath("~/Export/" + excelFile);
                FillDateIntoMdb(dbCode, lgIndex, mdbFile, excelFileFull, userCode, billCodes);
                return excelFile;
            }
            catch
            {
                throw;
            }
        }

        [Ignore]
        private void FillDateIntoMdb(string dbCode, int lgIndex, string mdbFile, string excelFileName, string user, List<string> billCodes)
        {
            string totleBillcode = "";
            string totleBillcodeForGenerate = "";
            foreach (var bill in billCodes)
            {
                totleBillcode += "'" + bill.Trim() + "',";
                totleBillcodeForGenerate += bill.Trim() + ",";
            }
            totleBillcode = totleBillcode.Substring(0, totleBillcode.Length - 1);
            totleBillcodeForGenerate = totleBillcodeForGenerate.Substring(0, totleBillcodeForGenerate.Length - 1);
            this._Is_CX = VerifyBCode(dbCode, lgIndex, totleBillcodeForGenerate);
            if (this._Is_CX)
            {
                _add = "_ED";
            }
            CreateSerialNum(dbCode, lgIndex, totleBillcodeForGenerate);
            this.PrepareExportToExcel(dbCode, lgIndex, mdbFile, excelFileName, totleBillcode);
        }

        [Ignore]
        private void PrepareExportToExcel(string dbCode, int lgIndex, string mdbFile, string excelFileName, string totleBillcode)
        {
            string sSql = "delete from [VTable]";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbFile + ";Persist Security Info=True";
            DbHelperOledb.ExecuteSql(sSql, connectionString);
            sSql = @"  
            select
            S1.SN  as SEQUENCE_NUM,S1.BCode as ORDER_NO,DAY(S1.BDate) as OUT_GOOD,'' as OUT_GOODTIME,
            S1.DiaR as RLENS_SIZE,S1.LensCodeRR as RLENS_TYPE,SPHR as RSPH,CYLR as RCYL,S1.AxisR as RAXIS,X_ADDR as RADDS, QtyR as RQTY,
            S1.DiaL as LLENS_SIZE,S1.LensCodeRL as LLENS_TYPE,SPHL as LSPH,CYLL as LCYL,S1.AxisL as LAXIS,X_ADDL as LADDS,QtyL as LQTY,
            S1.RSName as TINT_CODE,S1.RS as TINT_CONTENT,S1.UV,S1.JY as HARD,S1.JS as COATING,S1.CS as BR,S1.SY as MIR,
            S1.CTR as RCP,S1.CTL as LCP,S1.BASER as RBASE,S1.BASEL as LBASE,S1.DBR as RKNIFE_SIDER,S1.DBL as LKNIFE_SIDER,
            rtrim(ltrim(S1.D1R))+rtrim(ltrim(S1.D2R))+rtrim(ltrim(S1.D3R))+rtrim(ltrim(S1.D4R)) as RDECENTER,
            rtrim(ltrim(S1.D1L))+rtrim(ltrim(S1.D2L))+rtrim(ltrim(S1.D3L))+rtrim(ltrim(S1.D4L)) as LDECENTER,
            rtrim(ltrim(S1.P1R))+rtrim(ltrim(S1.P2R))+rtrim(ltrim(S1.P3R))+rtrim(ltrim(S1.P4R)) as RPRISM,
            rtrim(ltrim(S1.P1L))+rtrim(ltrim(S1.P2L))+rtrim(ltrim(S1.P3L))+rtrim(ltrim(S1.P4L)) as LPRISM,
            CONVERT(varchar(100), BDate , 23) as INPUT_DATE,CONVERT(varchar(100), GETDATE() , 23) OUTPUT_DATE,0 PRINTED,0 PRINT_BAG,
            '['+rtrim(ltrim(S1.BCode))+']'+';'+'[PD:'+PD+'];'+rtrim(ltrim(Notes)) as TBZM,
            isnull((select top 1 B1.Materials from B_Material_Lens B1 with (nolock) where B1.LensCode=S1.LensCodeRR),'') LENS_MATERIAL,
            isnull((select top 1 BCode+right(rtrim(ltrim(S1.OBCode)),5) from B_Material_Lens B1 with(nolock) where substring(BCode,4,12)=substring(S1.OBCode,1,4)),'') as Barcode,
            PD,S1.PG as POLISH,S1.CB as AURO,S1.ChB as EDGE,S1.KK as SUPER,S1.PH as SPECIAL,'' as SPECIAL_CODE
            from  
            V_Sale_Order_SD S1 
            where  S1.ID in (" + totleBillcode + @") order by S1.BCode";

            DbHelperSQL db = new DbHelperSQL(dbCode);
            DataSet ds = db.Query(sSql);
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["RAXIS"].ToString() == "")
                {
                    dr["RAXIS"] = "0";
                }
                if (dr["LAXIS"].ToString() == "")
                {
                    dr["LAXIS"] = "0";
                }
                if (Convert.ToInt32(dr["RQTY"]) <= 0)
                {
                    dr["RSPH"] = "0";
                    dr["RCYL"] = "0";
                    dr["RAXIS"] = "0";
                }
                if (Convert.ToInt32(dr["LQTY"]) <= 0)
                {
                    dr["LSPH"] = "0";
                    dr["LCYL"] = "0";
                    dr["LAXIS"] = "0";
                }
                sSql = "Insert  into [VTable] values ('" + dr["ORDER_NO"].ToString().Trim() + "','" + dr["SEQUENCE_NUM"].ToString().Trim() + _add + "','";
                sSql += dr["OUT_GOOD"].ToString().Trim() + "','" + dr["OUT_GOODTIME"].ToString().Trim() + "'," + (dr["RLENS_SIZE"].ToString().Trim() == "" ? "0" : dr["RLENS_SIZE"].ToString().Trim()).Trim() + ",'";
                sSql += dr["RLENS_TYPE"].ToString().Trim() + "'," + dr["RSPH"].ToString().Trim() + "," + dr["RCYL"].ToString().Trim() + ",'" + dr["RAXIS"].ToString().Trim() + "',";
                sSql += dr["RADDS"].ToString().Trim() + "," + Convert.ToInt32(dr["RQTY"]) + "," + (dr["LLENS_SIZE"].ToString().Trim() == "" ? "0" : dr["LLENS_SIZE"].ToString().Trim()).Trim() + ",'" + dr["LLENS_TYPE"].ToString().Trim() + "',";
                sSql += dr["LSPH"].ToString().Trim() + "," + dr["LCYL"].ToString().Trim() + ",'" + dr["LAXIS"].ToString().Trim() + "'," + dr["LADDS"].ToString().Trim() + ",";
                sSql += Convert.ToInt32(dr["LQTY"]) + ",'" + dr["TINT_CODE"].ToString().Trim() + "','" + dr["TINT_CONTENT"].ToString().Trim() + "'," + Convert.ToByte(dr["UV"]) + ",";
                sSql += Convert.ToByte(dr["HARD"]) + ",'" + dr["COATING"].ToString().Trim() + "','" + dr["BR"].ToString().Trim() + "','" + dr["MIR"].ToString().Trim() + "','";
                sSql += dr["RCP"].ToString().Trim() + "','" + dr["LCP"].ToString().Trim() + "','" + dr["RBASE"].ToString().Trim() + "','" + dr["LBASE"].ToString().Trim() + "',";
                sSql += Convert.ToByte(dr["RKNIFE_SIDER"]) + "," + Convert.ToByte(dr["LKNIFE_SIDER"]) + ",'" + dr["RDECENTER"].ToString().Trim() + "','" + dr["LDECENTER"].ToString().Trim() + "','";
                sSql += dr["RPRISM"].ToString().Trim() + "','" + dr["LPRISM"].ToString().Trim() + "','" + dr["INPUT_DATE"].ToString().Trim() + "','" + dr["OUTPUT_DATE"].ToString().Trim() + "',";
                sSql += Convert.ToByte(dr["PRINTED"]) + "," + Convert.ToByte(dr["PRINT_BAG"]) + ",'" + dr["TBZM"].ToString().Trim() + "','" + dr["LENS_MATERIAL"].ToString().Trim() + "','" + dr["Barcode"].ToString().Trim() + "','";
                sSql += dr["PD"].ToString().Trim() + "','" + dr["POLISH"].ToString().Trim() + "','" + dr["AURO"].ToString().Trim() + "','" + dr["EDGE"].ToString().Trim() + "','" + dr["SUPER"].ToString().Trim() + "','";
                sSql += dr["SPECIAL"].ToString().Trim() + "','')";
                DbHelperOledb.ExecuteSql(sSql, connectionString);
            }

            this.ExportToExcel(mdbFile, excelFileName);
        }

        [Ignore]
        private void ExportToExcel(string mdbFile, string excelFileName)
        {
            if (File.Exists(excelFileName))
            {
                FileInfo FinfoReport = new FileInfo(excelFileName);
                FinfoReport.Delete();
            }
            string exportExcel = "";
            try
            {
                if (_Is_CX)
                {
                    exportExcel = " SELECT *";
                    exportExcel += "  into [Excel 8.0;database=" + excelFileName + "].[VTable]   FROM   [VTable] WHERE (0=0) ";
                }
                else
                {
                    exportExcel = @" SELECT   SEQUENCE_NUM,ORDER_NO,OUT_GOOD,OUT_GOODTIME,
                                                        RLENS_SIZE,RLENS_TYPE,RSPH,RCYL,RAXIS,RADDS,RQTY,
                                                        LLENS_SIZE,LLENS_TYPE,LSPH,LCYL,LAXIS,LADDS,LQTY,
        						TINT_CODE,TINT_CONTENT,UV,HARD,COATING,BR,MIR,RCP,LCP,RBASE,LBASE,RKNIFE_SIDER,LKNIFE_SIDER,RDECENTER,LDECENTER,
        						RPRISM,LPRISM,INPUT_DATE,OUTPUT_DATE,PRINTED,PRINT_BAG,REMARK,LENS_MATERIAL,BarCode,SPECIAL_CODE,AURO";
                    exportExcel += "  into [Excel 8.0;database=" + excelFileName + "].[VTable]   FROM [VTable] WHERE (0=0) ";
                }
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdbFile;
                DbHelperOledb.ExecuteSql(exportExcel, connectionString);
            }
            catch
            {
                throw;
            }
        }

        [Ignore]
        private bool VerifyBCode(string dbCode, int lgIndex, string totleBillcode)
        {
            DbHelperSQL dbh = new DbHelperSQL(dbCode);
            string spName = "SP_Sale_Order_ExportToFactoryVerify";
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@BCodes", SqlDbType.NVarChar,4000),
                    new SqlParameter("@F_CX", SqlDbType.Bit)
					};
            parameters[0].Value = lgIndex;
            parameters[1].Value = totleBillcode;
            parameters[2].Value = 0;
            parameters[2].Direction = ParameterDirection.Output;
            dbh.RunProcedure(spName, parameters);
            var _Rs = Convert.ToBoolean(parameters[2].Value);
            return _Rs;
        }

        [Ignore]
        private void CreateSerialNum(string dbCode, int lgIndex, string totleBillcode)
        {
            DbHelperSQL dbh = new DbHelperSQL(dbCode);
            string spName = "SP_Sale_Order_ExportToFactory";
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@BCodes", SqlDbType.NVarChar,4000)
					};
            parameters[0].Value = lgIndex;
            parameters[1].Value = totleBillcode;
            dbh.RunProcedureTran(spName, parameters);
        }

        [Ignore]
        private void CreateMdb(string mdb)
        {
            string sSql;
            Catalog catalog = new Catalog();
            try
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mdb;
                catalog.Create(connectionString);
                if (null != catalog.ActiveConnection)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(catalog.ActiveConnection);
                }
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(catalog);
                sSql = @"CREATE TABLE [VTable]";
                sSql += @"([SEQUENCE_NUM] char(255) , [ORDER_NO] char(255) NOT NULL,";
                sSql += @"[OUT_GOOD] char(50),[OUT_GOODTIME] char(50), [RLENS_SIZE] int, [RLENS_TYPE] char(30),";
                sSql += @"[RSPH] int, [RCYL] int, [RAXIS] char(50) , [RADDS] int,";
                sSql += @"[RQTY] decimal(18, 6) NULL, [LLENS_SIZE] int NULL, [LLENS_TYPE] varchar(30) NULL,";
                sSql += @"[LSPH] int NULL, [LCYL] int NULL, [LAXIS] nvarchar(50) NULL, [LADDS] int NULL,";
                sSql += @"[LQTY] decimal(18, 6) NULL, [TINT_CODE] char(10) NULL, [TINT_CONTENT] char(10) NULL,";
                sSql += @"[UV] bit NULL, [HARD] bit NULL, [COATING] nvarchar(50) NULL, [BR] nchar(10) NULL,";
                sSql += @"[MIR] char(10) NULL, [RCP] nvarchar(50) NULL, [LCP] nvarchar(50) NULL, [RBASE] nvarchar(50) NULL,";
                sSql += @"[LBASE] nvarchar(50) NULL, [RKNIFE_SIDER] bit NULL, [LKNIFE_SIDER] bit NULL,";
                sSql += @"[RDECENTER] nvarchar(50) NULL, [LDECENTER] nvarchar(50) NULL, [RPRISM] nvarchar(50) NULL,";
                sSql += @"[LPRISM] nvarchar(50) NULL, [INPUT_DATE] datetime NOT NULL, [OUTPUT_DATE] datetime NULL,";
                sSql += @"[PRINTED] bit NULL,[PRINT_BAG] bit NULL,  [REMARK] varchar(255) NULL,";
                sSql += @"[LENS_MATERIAL] char(10) NULL, [BarCode] char(30) NULL,";
                sSql += @"[PD] char(30) NULL, [POLISH] char(30) NULL,";
                sSql += @"[AURO] char(30) NULL, [EDGE] char(30) NULL,";
                sSql += @"[SUPER] char(30) NULL, [SPECIAL] char(30) NULL, [SPECIAL_CODE] char(30) NULL";
                sSql += @") ";
                DbHelperOledb.ExecuteSql(sSql, connectionString);
            }
            catch
            {
                throw;
            }
        }

    }

}


