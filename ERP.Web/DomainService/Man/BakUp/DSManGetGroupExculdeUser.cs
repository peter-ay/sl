
namespace ERP.Web.DomainService.Man
{
    using System.Collections.Generic;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        public IQueryable<V_S_User> GetGroupExculdeUser(string groupCode)
        {
            var db = from b in this.ObjectContext.V_S_Group
                     where b.GroupCode == groupCode
                     select b;

            string database = db.FirstOrDefault().DBCode;

            List<string> groupCodes = new List<string>();
            var g = from c in this.ObjectContext.V_S_Group
                    where c.DBCode == database
                    orderby c.GroupCode
                    select c;
            if (g.Count() > 0)
            {
                g.ToList().ForEach(item => groupCodes.Add(item.GroupCode));
            }

            List<string> userCodes = new List<string>();
            var p = from c in this.ObjectContext.V_S_User_GroupDataBase
                    where groupCodes.Contains(c.GroupCode)
                    orderby c.UserCode
                    select c;
            if (p.Count() > 0)
            {
                p.ToList().ForEach(item => userCodes.Add(item.UserCode));
            }

            return this.ObjectContext.V_S_User.Where(item => !userCodes.Contains(item.UserCode));
        }
    }
}


