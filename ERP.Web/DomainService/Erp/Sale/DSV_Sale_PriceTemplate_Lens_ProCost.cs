

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceTemplate_Lens_ProCost> GetV_Sale_PriceTemplate_Lens_ProCostList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceTemplate_Lens_ProCost> rs = this.ObjectContext.V_Sale_PriceTemplate_Lens_ProCost;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("LensCode"); 
            rs = rs.Where(item => item.LensCode.ToUpper().Trim() == (str.ToUpper().Trim()));
            return rs;
        }
    }
}