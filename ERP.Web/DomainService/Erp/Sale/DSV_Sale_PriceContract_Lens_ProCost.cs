

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceContract_Lens_ProCost> GetV_Sale_PriceContract_Lens_ProCostList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceContract_Lens_ProCost> _Rs = this.ObjectContext.V_Sale_PriceContract_Lens_ProCost;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.InvTitle.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("BID");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BID == it); });
            }

            return _Rs;
        }
    }
}