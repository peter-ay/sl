

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Quote> GetV_Sale_QuoteBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_Sale_Quote> _Rs = this.ObjectContext.V_Sale_Quote;
            if (iD == "") return _Rs;
            return _Rs.Where(item => item.ID == iD);
        }
    }
}