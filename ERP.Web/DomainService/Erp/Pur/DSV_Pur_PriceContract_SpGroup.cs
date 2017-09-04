

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Pur_PriceContract_SpGroup> GetV_Pur_PriceContract_SpGroupBill(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (gpCode == "") return this.ObjectContext.V_Pur_PriceContract_SpGroup;
            return this.ObjectContext.V_Pur_PriceContract_SpGroup.Where(item => item.GpCode == gpCode);
        }

        public IQueryable<V_Pur_PriceContract_SpGroup> GetV_Pur_PriceContract_SpGroupAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Pur_PriceContract_SpGroup;
        }

        public IQueryable<V_Pur_PriceContract_SpGroup> GetV_Pur_PriceContract_SpGroupList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Pur_PriceContract_SpGroup> _Rs = this.ObjectContext.V_Pur_PriceContract_SpGroup;
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

            _Str = _SArray.GetSptstrValue("SpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it =>
                {
                    var _SCode = (from c in this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode
                                  where c.SpCode.Contains(it)
                                  select c).Select(item2 => item2.GpCode).Distinct();
                    _Rs = _Rs.Where(item => _SCode.Contains(item.GpCode));
                });
            }

            return _Rs;
        }
    }
}