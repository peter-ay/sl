
namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Report_CGSD> GetV_Sale_Report_CGSDPrint(string dbCode, int lgIndex, string rID, List<string> codes)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            ComReport cr = new ComReport();
            cr.GetReport(dbCode, lgIndex, rID, "CGSD", this.ObjectContext.V_Sale_Report_CGSD.Where(it => codes.Contains(it.ID)));
            return null;
        }
    }
}