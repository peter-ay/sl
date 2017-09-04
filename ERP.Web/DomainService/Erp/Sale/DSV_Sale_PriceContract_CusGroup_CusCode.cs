

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceContract_CusGroup_CusCode> GetV_Sale_PriceContract_CusGroup_CusCodeList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceContract_CusGroup_CusCode> _Rs = this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("GpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.GpCode == it); });
            }

            return _Rs;
        }
    }
}