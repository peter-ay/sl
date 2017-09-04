
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Customer_Acc> GetV_B_Customer_AccBill(string dbCode, string accCusCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Customer_Acc> _Rs = this.ObjectContext.V_B_Customer_Acc;
            if (accCusCode == "") return _Rs;
            return _Rs.Where(item => item.AccCusCode == accCusCode);
        }

        public IQueryable<V_B_Customer_Acc> GetV_B_Customer_AccList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Customer_Acc> _Rs = this.ObjectContext.V_B_Customer_Acc;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("AccCusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.AccCusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("AccCusName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.AccCusName.Contains(it)); });
            }

            return _Rs;
        }

        public IQueryable<V_B_Customer> GetV_B_Customer_Acc_CusIncludeListByAccCusCode(string accCusCode)
        {
            return this.ObjectContext.V_B_Customer.Where(item => item.PCode == accCusCode);
        }
    }
}