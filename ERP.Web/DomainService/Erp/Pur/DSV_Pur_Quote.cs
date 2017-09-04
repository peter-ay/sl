

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Pur_Quote> GetV_Pur_QuoteBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_Pur_Quote> _Rs = this.ObjectContext.V_Pur_Quote;
            if (iD == "") return _Rs;
            return _Rs.Where(item => item.ID == iD);
        }
    }
}