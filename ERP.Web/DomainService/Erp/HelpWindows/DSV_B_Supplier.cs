namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_B_Supplier> GetV_B_SupplierHelpList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            return this.ObjectContext.V_B_Supplier;
        }
    }
}