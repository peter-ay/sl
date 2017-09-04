
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_ForeignCurrency> GetV_B_ForeignCurrencyBill(string dbCode, string foreignCurrCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (foreignCurrCode == "") return this.ObjectContext.V_B_ForeignCurrency;
            return this.ObjectContext.V_B_ForeignCurrency.Where(item => item.ForeignCurrCode == foreignCurrCode);
        }

        public IQueryable<V_B_ForeignCurrency> GetV_B_ForeignCurrencyAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_ForeignCurrency;
        }

        public IQueryable<V_B_ForeignCurrency> GetV_B_ForeignCurrencyList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_ForeignCurrency> rs = this.ObjectContext.V_B_ForeignCurrency;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("ForeignCurrCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.ForeignCurrCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("ForeignCurrName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.ForeignCurrName.Contains(it)); });
            }
            return rs;
        }
    }
}