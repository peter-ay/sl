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
using System.Collections;

namespace ERP.Web.DomainService.Erp
{
    public class ComReport
    {
        private ReportViewer _ReportViewer = new ReportViewer();
        private string dbCode; int lgIndex; string rID; string pCode; List<string> codes; string rType; bool f_ShowMoney; bool f_IsBigFormat; string rFormat; string rFormatFile; string bScanType;
        private string _FullFileName;
        private IEnumerable _dataSourceValue = null;

        //[Ignore]
        //public void GetReport(string dbCode, int lgIndex, string rID, string pCode, string rType, string rFormat, List<string> codes, bool f_ShowMoney, bool f_IsBigFormat)
        //{
        //    this.dbCode = dbCode; this.lgIndex = lgIndex; this.rID = rID; this.pCode = pCode; this.rFormat = rFormat;
        //    this.codes = codes; this.rType = rType; this.f_ShowMoney = f_ShowMoney; this.f_IsBigFormat = f_IsBigFormat;
        //    this.rFormatFile = rFormat;
        //    if (rFormat == "Excel")
        //        this.rFormatFile = "xls";
        //    _FullFileName = rID + "." + rFormatFile;
        //    Prepare();
        //    Export();
        //}

        [Ignore]
        public void GetReport(string dbCode, int lgIndex, string rID, string rType, IEnumerable dataSourceValue, string pCode = "CN", string rFormat = "PDF", bool f_ShowMoney = false, bool f_IsBigFormat = false)
        {
            this.dbCode = dbCode; this.lgIndex = lgIndex; this.rID = rID; this.pCode = pCode; this.rFormat = rFormat;
            this._dataSourceValue = dataSourceValue; this.rType = rType; this.f_ShowMoney = f_ShowMoney; this.f_IsBigFormat = f_IsBigFormat;
            this.rFormatFile = rFormat;
            if (rFormat == "Excel")
                this.rFormatFile = "xls";
            _FullFileName = rID + "." + rFormatFile;
            Prepare();
            Export();
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
                    foreach (ERP.Web.Entity.V_Sale_Report_XSSD it in ds.Value as IQueryable<ERP.Web.Entity.V_Sale_Report_XSSD>)
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
            //System.Collections.IEnumerable dataSourceValue = null;
            //switch (rType)
            //{
            //    case "CGSD":
            //        dataSourceValue = FillReportDataCGSD();
            //        break;
            //    case "XSSD":
            //        dataSourceValue = FillReportDataXSSD();
            //        break;
            //    default:
            //        break;
            //}
            _RDS = new ReportDataSource("DS", this._dataSourceValue);
            this._ReportViewer.LocalReport.DataSources.Add(_RDS);
        }

        private void PrepareReportParameter()
        {
            if (pCode == "SL") pCode = "CN";

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

        //private IQueryable<ERP.Web.Entity.V_Sale_Report_CGSD> FillReportDataCGSD()
        //{
        //    ERP.Web.DomainService.Erp.DSErp ds = new ERP.Web.DomainService.Erp.DSErp();
        //    return ds.GetV_Sale_Report_CGSD().Where(it => codes.Contains(it.ID));
        //}

        //private IQueryable<ERP.Web.Entity.V_Sale_Report_XSSD> FillReportDataXSSD()
        //{

        //    ERP.Web.DomainService.Erp.DSErp ds = new ERP.Web.DomainService.Erp.DSErp();
        //    return ds.GetV_Sale_Report_XSSD().Where(it => codes.Contains(it.ID));
        //}
    }
}