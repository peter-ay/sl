

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;

    public partial class DSErp
    {
        //public IQueryable<V_Sale_Report_Order> GetV_Sale_Report_OrderReport(string dbCode, int lgIndex, string rID, string reportCode, List<string> codes)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    IQueryable<V_Sale_Report_Order> _Rs = this.ObjectContext.V_Sale_Report_Order;
        //    _Rs = _Rs.Where(it => codes.Contains(it.ID));
        //    _Rs = _Rs.OrderBy(it => it.ID);
        //    var _Rp = this.ReportPrepare(reportCode, _Rs);
        //    var ds = _Rp.LocalReport.DataSources.First();
        //    foreach (V_Sale_Report_Order it in ds.Value as IQueryable<V_Sale_Report_Order>)
        //    {
        //        it.Rt5 = ERP.Web.Common.QRCodesErp.GetQR(it.BCode);
        //    }
        //    this.ReportPrepareParameter(dbCode, "1", reportCode, "", lgIndex.ToString());
        //    this.ReportToFile(rID, "PDF", "PDF");
        //    return null;
        //}
    }
}