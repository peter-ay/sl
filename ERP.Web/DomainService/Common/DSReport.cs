
namespace ERP.Web.DomainService.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using Microsoft.Reporting.WebForms;
    using System.Web;
    using System.IO;
    using System.Data;
    using ERP.Web.DBUtility;
    using ERP.Web.Common;
    using System.Data.SqlClient;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSReport : DomainService
    {
        private ReportViewer _ReportViewer = new ReportViewer();
        private string dbCode; int lgIndex; string userCode; string userName; string rID; string pCode; List<string> codes; string rType; bool f_ShowMoney; bool f_IsBigFormat; string rFormat; string rFormatFile; string bScanType;
        private string _FullFileName;

        [Invoke]
        public string GetReport(string dbCode, int lgIndex, string userCode, string userName, string rID, string pCode, string rType, string rFormat, List<string> codes, bool f_ShowMoney, bool f_IsBigFormat)
        {
            this.dbCode = dbCode; this.lgIndex = lgIndex; this.rID = rID; this.pCode = pCode; this.rFormat = rFormat;
            this.codes = codes; this.rType = rType; this.f_ShowMoney = f_ShowMoney; this.f_IsBigFormat = f_IsBigFormat;
            this.userCode = userCode; this.userName = userName;
            this.rFormatFile = rFormat;
            if (rFormat == "Excel")
                this.rFormatFile = "xls";
            _FullFileName = rID + "." + rFormatFile;
            Prepare();
            Export();
            return _FullFileName;
        }

        private void Export()
        {
            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = rFormat;//In local processing mode, supported extensions are Excel, PDF, Word, and Image. 
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = _ReportViewer.LocalReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            string fullFileName = HttpContext.Current.Server.MapPath("~/Report/Reports/" + _FullFileName);
            File.WriteAllBytes(fullFileName, bytes);
        }

        private void Prepare()
        {
            this._ReportViewer.ProcessingMode = ProcessingMode.Local;
            this._ReportViewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Report/Template/" + rType + ".rdlc");
            this.PrepareReportDataSources();
            this.PrepareReportParameter();
            this.PrepareReportQRCode();
        }

        private void PrepareReportQRCode()
        {
            switch (rType)
            {
                case "XSSD":
                    var ds = this._ReportViewer.LocalReport.DataSources.First();
                    foreach (ERP.Web.Entity.V_Sale_Report_Lens it in ds.Value as IQueryable<ERP.Web.Entity.V_Sale_Report_Lens>)
                    {
                        it.Rt5 = QRCodesErp.GetQR(it.BCode);
                    }
                    break;

                default:
                    break;
            }
        }

        private void PrepareReportDataSources()
        {
            ReportDataSource _RDS = null;
            System.Collections.IEnumerable dataSourceValue = null;
            switch (rType)
            {
                case "CGSD":
                    dataSourceValue = FillReportDataCGSD();
                    break;
                case "XSSD":
                    dataSourceValue = FillReportDataXSSD();
                    break;
                default:
                    break;
            }
            _RDS = new ReportDataSource("DS", dataSourceValue);
            this._ReportViewer.LocalReport.DataSources.Add(_RDS);
        }

        private void PrepareReportParameter()
        {
            if (pCode == "SL") pCode = "HKOCN";

            switch (rType)
            {
                case "XSSD":
                    bScanType = "DN";
                    break;

                case "XSPD":
                case "KSMOP":
                case "KSMOWP":
                    bScanType = "BN";
                    break;

                case "KSMIS":
                case "KSMIP":
                    bScanType = "RN";
                    break;

                case "KSMOJ":
                case "KSMOWJ":
                    bScanType = "CN";
                    break;

                case "KSMIJ":
                    bScanType = "CR";
                    break;

                case "KSJMJS":
                    bScanType = "CB";
                    break;

                case "XSFD":
                    bScanType = "FN";
                    break;

                case "XSFS":
                    bScanType = "FP";
                    break;

                case "KSFI":
                    bScanType = "FR";
                    break;

                default:
                    break;
            }

            ReportParameter[] para = new ReportParameter[5];
            para[0] = new ReportParameter("PCode", pCode, false);
            para[1] = new ReportParameter("F_ShowMoney", f_ShowMoney ? "1" : "0", false);
            para[2] = new ReportParameter("BType", rType, false);
            para[3] = new ReportParameter("ScanType", bScanType, false);
            para[4] = new ReportParameter("LgIndex", lgIndex.ToString(), false);
            this._ReportViewer.LocalReport.SetParameters(para);
            this._ReportViewer.LocalReport.Refresh();
        }

        private IQueryable<ERP.Web.Entity.V_Sale_Report_CGSD> FillReportDataCGSD()
        {
            ERP.Web.DomainService.Erp.DSErp ds = new ERP.Web.DomainService.Erp.DSErp();
            return ds.GetV_Sale_Report_CGSDList(dbCode).Where(it => codes.Contains(it.ID));
        }

        private IQueryable<ERP.Web.Entity.V_Sale_Report_Lens> FillReportDataXSSD()
        {
            //
            this.GenerateDNXSSD();
            ERP.Web.DomainService.Erp.DSErp ds = new ERP.Web.DomainService.Erp.DSErp();
            return ds.GetV_Sale_Report_LensList(dbCode).Where(it => codes.Contains(it.IDSale));
        }

        private void GenerateDNXSSD()
        {
            string totleBillcode = "";
            string totleBillcodeForGenerate = "";
            foreach (var bill in codes)
            {
                totleBillcode += "'" + bill.Trim() + "',";
                totleBillcodeForGenerate += bill.Trim() + ",";
            }
            totleBillcode = totleBillcode.Substring(0, totleBillcode.Length - 1);
            totleBillcodeForGenerate = totleBillcodeForGenerate.Substring(0, totleBillcodeForGenerate.Length - 1);

            DbHelperSQL dbh = new DbHelperSQL(dbCode);
            string spName = "SP_Sale_Order_PrintXSSD";
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
                    new SqlParameter("@UserCode", SqlDbType.VarChar,10),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,30),
					new SqlParameter("@BCodes", SqlDbType.NVarChar,4000),
                    new SqlParameter("@F_BigFormat", SqlDbType.Bit),
					};
            parameters[0].Value = lgIndex;
            parameters[1].Value = userCode;
            parameters[2].Value = userName;
            parameters[3].Value = totleBillcodeForGenerate;
            parameters[4].Value = Convert.ToInt16(f_IsBigFormat);
            dbh.RunProcedureTran(spName, parameters);
        }
    }
}


