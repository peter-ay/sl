
namespace ERP.Web.DomainService.Man
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        //V_S_User_GroupDataBase 
        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupDataBaseBill(string userCode)
        {
            if (userCode == "") return this.ObjectContext.V_S_User_GroupDataBase;
            return this.ObjectContext.V_S_User_GroupDataBase.Where(item => item.UserCode == userCode && !string.IsNullOrEmpty(item.DBCode));
        }

        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupDataBaseByGpCode(string gpCode)
        {
            if (gpCode == "") return this.ObjectContext.V_S_User_GroupDataBase;
            return this.ObjectContext.V_S_User_GroupDataBase.Where(item => item.GpCode == gpCode && !string.IsNullOrEmpty(item.DBCode));
        }

        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupIncludeListByUserCode(string userCode)
        {
            return this.ObjectContext.V_S_User_GroupDataBase.Where(item => item.UserCode == userCode && !string.IsNullOrEmpty(item.GpCode));
        }

        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupIncludeListByGpCode(string gpCode)
        {
            return this.ObjectContext.V_S_User_GroupDataBase.Where(item => item.GpCode == gpCode);
        }

        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupDataBaseAllList()
        {
            return this.ObjectContext.V_S_User_GroupDataBase.Where(item => !string.IsNullOrEmpty(item.UserCode));
        }

        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupDataBaseList(string userCode, string userName, string gpCode)
        {
            var rs = this.ObjectContext.V_S_User_GroupDataBase.Where(item => !string.IsNullOrEmpty(item.UserCode));

            if (!string.IsNullOrEmpty(userCode))
            {
                userCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.UserCode.Contains(it)); });
            }
            if (!string.IsNullOrEmpty(userName))
            {
                userName.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.UserName.Contains(it)); });
            }
            if (!string.IsNullOrEmpty(gpCode))
            {
                gpCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.GpCode == it); });
            }
            return rs;
        }
    }
}


