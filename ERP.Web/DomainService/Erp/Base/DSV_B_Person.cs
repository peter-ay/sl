
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Person> GetV_B_PersonBill(string dbCode, string personCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (personCode == "") return this.ObjectContext.V_B_Person;
            return this.ObjectContext.V_B_Person.Where(item => item.PersonCode == personCode);
        }

        public IQueryable<V_B_Person> GetV_B_PersonAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Person;
        }

        public IQueryable<V_B_Person> GetV_B_PersonList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Person> rs = this.ObjectContext.V_B_Person;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("PersonCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.PersonCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("PersonName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.PersonName.Contains(it)); });
            }
            return rs;
        } 
    }
}