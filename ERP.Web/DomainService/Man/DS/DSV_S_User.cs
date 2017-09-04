
namespace ERP.Web.DomainService.Man
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ERP.Web.Common;
    using ERP.Web.Entity;

    public partial class DSMan
    {

        public IQueryable<V_S_User> GetV_S_UserBill(string userCode)
        {
            if (userCode == "") return this.ObjectContext.V_S_User;
            return this.ObjectContext.V_S_User.Where(item => item.UserCode == userCode);
        }

        public IQueryable<V_S_User> GetV_S_UserAllList()
        {
            return this.ObjectContext.V_S_User;
        }

        public IQueryable<V_S_User> GetV_S_UserList(string sWhere)
        {
            IQueryable<V_S_User> rs = this.ObjectContext.V_S_User;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("UserCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.UserCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("UserName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.UserName.Contains(it)); });
            }

            return rs;
        }

        public IQueryable<V_S_User> GetV_S_UserByGpCodeList(string gpCode)
        {
            IQueryable<V_S_User> rs = this.ObjectContext.V_S_User;
            var rsg = this.ObjectContext.V_S_User_GroupDataBase.Where(item => item.GpCode == gpCode).Select(items => items.UserCode);
            return rs.Where(item => rsg.Contains(item.UserCode));
        }

    }
}


