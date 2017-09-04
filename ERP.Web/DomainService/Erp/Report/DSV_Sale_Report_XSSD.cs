
namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Report_XSSD> GetV_Sale_Report_XSSDPrint(string dbCode, int lgIndex, string rID, List<string> codes, string pCode, string rFormat, bool f_ShowMoney, bool f_IsBigFormat)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            ComReport cr = new ComReport();
            cr.GetReport(dbCode, lgIndex, rID, "XSSD", this.ObjectContext.V_Sale_Report_XSSD.Where(it => codes.Contains(it.ID)), pCode, rFormat, f_ShowMoney, f_IsBigFormat);
            return null;
        }
    }
}