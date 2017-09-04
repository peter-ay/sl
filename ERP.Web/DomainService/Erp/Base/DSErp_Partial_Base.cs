
namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_B_Process> GetV_B_ProcessList(string dbCode, string processCode, string processName)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_B_Process.Where(item => !string.IsNullOrEmpty(item.ProID));

            //if (!string.IsNullOrEmpty(processCode))
            //{
            //    processCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.ProcessCode.ToUpper().Contains(it)); });
            //}

            //if (!string.IsNullOrEmpty(processName))
            //{
            //    processName.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.ProcessName.ToUpper().Contains(it)); });
            //}

            return rs;
        }




          
        public IQueryable<V_B_Warehouse> GetV_Common_User_WarehouseUseList
            (string dbCode, string userCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            //var codeList = from c in this.GetV_Common_User_WareHouseUse()
            //               where c.UserCode == userCode
            //               select c.WhCode.ToUpper();

            //var rs = this.ObjectContext.V_B_Warehouse.Where(item => codeList.Contains(item.WhCode.ToUpper()));
            //return rs;
            return this.ObjectContext.V_B_Warehouse;
        }
         
        public IQueryable<V_B_Warehouse> GetV_Common_User_WarehouseBrowseList
            (string dbCode, string userCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            //var codeList = from c in this.GetV_Common_User_WareHouseBrowse()
            //               where c.UserCode == userCode
            //               select c.WhCode.ToUpper();

            //var rs = this.ObjectContext.V_B_Warehouse.Where(item => codeList.Contains(item.WhCode.ToUpper()));
            //return rs;
            return this.ObjectContext.V_B_Warehouse;
        }
    }
}