
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Warehouse> GetV_B_WarehouseBill(string dbCode, string whCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (whCode == "") return this.ObjectContext.V_B_Warehouse;
            return this.ObjectContext.V_B_Warehouse.Where(item => item.WhCode == whCode);
        }

        public IQueryable<V_B_Warehouse> GetV_B_WarehouseAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Warehouse;
        }

        public IQueryable<V_B_Warehouse> GetV_B_Warehouse_BrowseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Warehouse> _Rs = this.ObjectContext.V_B_Warehouse;
            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            return _Rs;
        }

        public IQueryable<V_B_Warehouse> GetV_B_Warehouse_UseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Warehouse> _Rs = this.ObjectContext.V_B_Warehouse;
            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.UseRight.Substring(gpID - 1, 1) == "1");
            }
            return _Rs;
        }

        public IQueryable<V_B_Warehouse_Browse> GetV_B_Warehouse_BrowseByGpCode(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Warehouse_Browse> _Rs = this.ObjectContext.V_B_Warehouse_Browse.Where(it => it.GpCode == gpCode);
            return _Rs;
        }

        public IQueryable<V_B_Warehouse_Use> GetV_B_Warehouse_UseByGpCode(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Warehouse_Use> _Rs = this.ObjectContext.V_B_Warehouse_Use.Where(it => it.GpCode == gpCode);
            return _Rs;
        }

        public IQueryable<V_B_Warehouse> GetV_B_WarehouseList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Warehouse> rs = this.ObjectContext.V_B_Warehouse;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.WhCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("WhName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.WhName.Contains(it)); });
            }
            return rs;
        }
    }
}