

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Report_Stocks_Lens> GetV_Ware_Report_Stocks_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Report_Stocks_Lens> _Rs = this.ObjectContext.V_Ware_Report_Stocks_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCode.Contains(it)); });
            }
             
            return _Rs;
        }
    }
}