

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceContract_CusGroup> GetV_Sale_PriceContract_CusGroupBill(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (gpCode == "") return this.ObjectContext.V_Sale_PriceContract_CusGroup;
            return this.ObjectContext.V_Sale_PriceContract_CusGroup.Where(item => item.GpCode == gpCode);
        }

        public IQueryable<V_Sale_PriceContract_CusGroup> GetV_Sale_PriceContract_CusGroupAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Sale_PriceContract_CusGroup;
        }

        public IQueryable<V_Sale_PriceContract_CusGroup> GetV_Sale_PriceContract_CusGroupList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceContract_CusGroup> _Rs = this.ObjectContext.V_Sale_PriceContract_CusGroup;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("GpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.GpCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("GpName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.GpName.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it =>
                {
                    var _SCode = (from c in this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode
                                  where c.CusCode.Contains(it)
                                  select c).Select(item2 => item2.GpCode).Distinct();
                    _Rs = _Rs.Where(item => _SCode.Contains(item.GpCode));
                });
            }

            return _Rs;
        }
    }
}