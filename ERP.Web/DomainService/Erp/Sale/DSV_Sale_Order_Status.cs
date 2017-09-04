

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {

        public IQueryable<V_Sale_Order_Status> GetV_Sale_Order_StatusList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_Sale_Order_Status> _Rs = this.ObjectContext.V_Sale_Order_Status;
            var _SArray = sWhere.GetSptstr();
            string _Str = ""; bool flag = false;
            _Str = _SArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                flag = true;
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCode == (it)); });
            }

            _Str = _SArray.GetSptstrValue("OBCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                flag = true;
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.OBCode == (it)); });
            }

            if (!flag)
            {
                return _Rs.Where(item => item.BID == "");
            }

            return _Rs;
        }

    }
}