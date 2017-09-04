namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_B_Warehouse> GetV_B_WareHouseHelpList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            return this.ObjectContext.V_B_Warehouse;
        }

        public IQueryable<V_B_Warehouse> GetV_B_Warehouse_BrowseRightHelpList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (gpID == -99)
                return this.ObjectContext.V_B_Warehouse;

            return this.ObjectContext.V_B_Warehouse.Where
                (item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        }

        public IQueryable<V_B_Warehouse> GetV_B_Warehouse_UseRightHelpList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (gpID == -99)
                return this.ObjectContext.V_B_Warehouse;

            return this.ObjectContext.V_B_Warehouse.Where
                (item => item.UseRight.Substring(gpID - 1, 1) == "1");
        }

    }
}