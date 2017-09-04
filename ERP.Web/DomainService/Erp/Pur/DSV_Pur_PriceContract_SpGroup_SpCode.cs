

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Pur_PriceContract_SpGroup_SpCode> GetV_Pur_PriceContract_SpGroup_SpCodeList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Pur_PriceContract_SpGroup_SpCode> _Rs = this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode;
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