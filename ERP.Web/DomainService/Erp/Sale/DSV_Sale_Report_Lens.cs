

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Report_Lens> GetV_Sale_Report_LensList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Sale_Report_Lens;
        }
    }
}