using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;
using ERP.Web.Entity;
using System.Data.Objects.DataClasses;

namespace ERP.Web.DomainService.Erp
{
    public partial class DSErp
    {
        private ReportViewer _ReportViewer;

        private void ReportPrepareParameter(string pCode, string f_ShowMoney, string bType, string scanType, string lgIndex)
        {
            if (pCode == "SL") pCode = "CN";
            ReportParameter[] para = new ReportParameter[5];
            para[0] = new ReportParameter("PCode", pCode, false);
            para[1] = new ReportParameter("F_ShowMoney", f_ShowMoney, false);
            para[2] = new ReportParameter("BType", bType, false);
            para[3] = new ReportParameter("ScanType", scanType, false);
            para[4] = new ReportParameter("LgIndex", lgIndex, false);
            this._ReportViewer.LocalReport.SetParameters(para);
            this._ReportViewer.LocalReport.Refresh();
        }

        private ReportViewer ReportPrepare(string reportCode, IQueryable<EntityObject> ds)
        {
            this._ReportViewer = new ReportViewer();
            this._ReportViewer.ProcessingMode = ProcessingMode.Local;
            this._ReportViewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Report/Template/" + reportCode + ".rdlc");
            this._ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DS", ds));
            return this._ReportViewer;
        }

        private void ReportToFile(string rID, string rFormat, string rExtension)
        {
            string _FileName = rID + "." + rExtension;
            string mimeType, encoding, extension, deviceInfo;
            string[] streamids;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = rFormat;
            deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            byte[] bytes = _ReportViewer.LocalReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            string fullFileName = HttpContext.Current.Server.MapPath("~/Report/Reports/" + _FileName);
            File.WriteAllBytes(fullFileName, bytes);
        }
    }
}