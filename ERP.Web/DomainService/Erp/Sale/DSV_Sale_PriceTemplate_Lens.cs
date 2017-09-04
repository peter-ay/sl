

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceTemplate_Lens> GetV_Sale_PriceTemplate_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceTemplate_Lens> rs = this.ObjectContext.V_Sale_PriceTemplate_Lens;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("LensCode"); 
            rs = rs.Where(item => item.LensCode.ToUpper().Trim() == (str.ToUpper().Trim()));
            return rs;
        }
    }
}