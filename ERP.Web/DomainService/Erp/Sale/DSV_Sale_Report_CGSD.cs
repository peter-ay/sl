

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Report_CGSD> GetV_Sale_Report_CGSDList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Sale_Report_CGSD;
        }
    }
}