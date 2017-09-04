

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceTemplate_LensRecord> GetV_Sale_PriceTemplate_LensRecordList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceTemplate_LensRecord> rs = this.ObjectContext.V_Sale_PriceTemplate_LensRecord;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensCode.Contains(it)); });
            }
            //rs = rs.Where(item => item.LensCode.ToUpper().Trim() == (str.ToUpper().Trim()));
            str = sArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensName.Contains(it)); });
            }
            return rs; 
        }
    }
}