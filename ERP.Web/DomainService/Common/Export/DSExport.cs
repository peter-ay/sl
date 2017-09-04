
namespace ERP.Web.DomainService.Common
{
    using System;
    using System.Data;
    using System.IO;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Web;
    using ERP.Web.DBUtility;
    using GemBox.Spreadsheet;
    using System.Collections.Generic;
    using ERP.Web.Common;


    [EnableClientAccess()]
    public class DSExport : DomainService
    {
        //[Invoke]
        //public byte[] Export(string dbCode, int lgIndex, string user, string tableName, string where = " 1=1", string orderby = " ", string selectItems = "*")
        //{
        //    DbHelperSQL u = new DbHelperSQL(dbCode);
        //    string fileName = HttpContext.Current.Server.MapPath("~/Export/[" + dbCode + "]" + user + "[" + tableName + "]" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".xls");
        //    string sQuery = "select " + selectItems + " from " + tableName + " where " + where + orderby;
        //    DataSet ds = u.Query(sQuery);
        //    CreateExcelFile(ds, fileName, tableName);
        //    var rs = File.ReadAllBytes(fileName);
        //    //File.Delete(fileName);
        //    return rs;
        //}

        [Invoke]
        public string Export(string dbCode, int lgIndex, string user, string tableName, string where = " 1=1", string orderby = " ", string selectItems = "*")
        {
            DbHelperSQL u = new DbHelperSQL(dbCode);
            string fileName = dbCode + user + tableName + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + ".xls";
            string fullFileName = HttpContext.Current.Server.MapPath("~/Export/" + fileName);
            string sQuery = "select " + selectItems + " from " + tableName + " where " + where;
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sQuery += " order by " + orderby;
            }
            DataSet ds = u.Query(sQuery);
            try
            {
                File.Delete(fullFileName);
            }
            catch { }
            CreateExcelFile(ds, fullFileName, tableName);
            return fileName;
        }

        [Ignore]
        private void CreateExcelFile(DataSet ds, string fileName, string tableName)
        {
            if (ds.Tables[0].Rows.Count >= 0)
            {
                if (fileName != "")
                {
                    try
                    {
                        ExcelFile excelFile = new ExcelFile();
                        ExcelWorksheet sheet = excelFile.Worksheets.Add(tableName);
                        DataTable dt = ds.Tables[0];
                        int columns = dt.Columns.Count;
                        int rows = dt.Rows.Count;
                        for (int j = 0; j < columns; j++)
                        {
                            sheet.Cells[0, j].Style.Font.Name = "Verdana";
                            sheet.Cells[0, j].Value = dt.Columns[j].ColumnName;
                        }
                        for (int i = 1; i <= rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                sheet.Cells[i, j].Style.Font.Name = "Verdana";
                                if (dt.Columns[j].DataType == typeof(System.Boolean))
                                {
                                    if (dt.Rows[i - 1][j].ToString().Trim() == "1" || dt.Rows[i - 1][j].ToString().Trim() == "True")
                                    {
                                        sheet.Cells[i, j].Value = "1";
                                    }
                                    else
                                    {
                                        sheet.Cells[i, j].Value = "0";
                                    }
                                }
                                else
                                {
                                    sheet.Cells[i, j].Value = dt.Rows[i - 1][j].ToString().Trim();
                                }
                            }
                        }
                        excelFile.SaveXls(fileName);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        //[Ignore]
        //public static void ExportTest(List<string> Codes)
        //{
        //    var fileName = HttpContext.Current.Server.MapPath("~/Export/" + "PPP.xls");
        //    var tableName = "PPP";
        //    ExcelFile excelFile = new ExcelFile();
        //    ExcelWorksheet sheet = excelFile.Worksheets.Add(tableName);
        //    //DataTable dt = ds.Tables[0];
        //    //int columns = dt.Columns.Count;
        //    //int rows = dt.Rows.Count;
        //    //for (int j = 0; j < columns; j++)
        //    //{
        //    //    //sheet.Cells[0, j].Style.Font.Name = "Verdana";
        //    //    sheet.Cells[0, j].Value = dt.Columns[j].ColumnName;
        //    //}
        //    //for (int i = 1; i <= rows; i++)
        //    //{
        //    //    for (int j = 0; j < columns; j++)
        //    //    {
        //    //        //sheet.Cells[i, j].Style.Font.Name = "Verdana";
        //    //        sheet.Cells[i, j].Value = dt.Rows[i - 1][j].ToString().Trim();
        //    //    }
        //    //}

        //    for (int j = 0; j < Codes.Count; j++)
        //    {
        //        sheet.Cells[j, 1].Value = Codes[j].ToString();
        //    }

        //    excelFile.SaveXls(fileName);
        //}

        [Ignore]
        public static string ExportListLens(DataTable dt, string fID)
        {
            var fileName = HttpContext.Current.Server.MapPath("~/Export/" + fID + ".xls");
            var tableName = "V1";
            ExcelFile excelFile = new ExcelFile();
            ExcelWorksheet sheet = excelFile.Worksheets.Add(tableName);
            int columns = dt.Columns.Count;
            int rows = dt.Rows.Count;
            for (int j = 0; j < columns; j++)
            {
                sheet.Cells[0, j].Style.Font.Name = "Verdana";
                sheet.Cells[0, j].Value = dt.Columns[j].ColumnName;
            }
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sheet.Cells[i, j].Style.Font.Name = "Verdana";
                    sheet.Cells[i, j].Value = dt.Rows[i - 1][j].ToString().Trim();
                }
            }

            excelFile.SaveXls(fileName);
            return fileName;
        }
    }
}


