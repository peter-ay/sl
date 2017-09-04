
namespace ERP.Web.DomainService.Man
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        //Group
        public IQueryable<V_S_UserGroup> GetV_S_UserGroupBill(string gpCode)
        {
            if (gpCode == "") return this.ObjectContext.V_S_UserGroup;
            return this.ObjectContext.V_S_UserGroup.Where(item => item.GpCode == gpCode);
        }

        public IQueryable<V_S_UserGroup> GetV_S_UserGroupAllList()
        {
            return this.ObjectContext.V_S_UserGroup;
        }

        public IQueryable<V_S_UserGroup> GetV_S_UserGroupList(string sWhere)
        {
            IQueryable<V_S_UserGroup> rs = this.ObjectContext.V_S_UserGroup;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("GpCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.GpCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("GpName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.GpName.Contains(it)); });
            }

            return rs;
        }

        public IQueryable<V_S_UserGroup> GetV_S_UserGroupByDBCodeList(string dbCode)
        {
            return this.ObjectContext.V_S_UserGroup.Where(item => item.DBCode == dbCode);
        }
    }
}


