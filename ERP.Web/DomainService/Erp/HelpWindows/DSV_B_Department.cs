namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        //public IQueryable<V_B_Warehouse> GetV_B_WareHouseHelpList(string dbCode)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    return this.ObjectContext.V_B_Warehouse;
        //}

        public IQueryable<V_B_Department> GetV_B_Department_RightBrowseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Department> _Rs = this.ObjectContext.V_B_Department;

            if (gpID == -99) return _Rs;
            return _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        }

        //public IQueryable<V_B_Department> GetV_B_Department_UseRightHelpList(string dbCode, int gpID)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    if (gpID == -99)
        //        return this.ObjectContext.V_B_Department;

        //    return this.ObjectContext.V_B_Department.Where
        //        (item => item.UseRight.Substring(gpID - 1, 1) == "1");
        //}

    }
}