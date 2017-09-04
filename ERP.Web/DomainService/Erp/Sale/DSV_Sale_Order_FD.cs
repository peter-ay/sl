

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_Order_FD> GetV_Sale_Order_FDBill(string dbCode, string iD, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_Sale_Order_FD> rs = this.ObjectContext.V_Sale_Order_FD;
            if (gpID != -99)
            {
                rs = this.ObjectContext.V_Sale_Order_FD.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            if (iD == "") return rs;
            return rs.Where(item => item.ID == iD);
        }

    }
}