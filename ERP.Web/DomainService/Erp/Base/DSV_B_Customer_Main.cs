
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Customer_Main> GetV_B_Customer_MainBill(string dbCode, string mainCusCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Customer_Main> _Rs = this.ObjectContext.V_B_Customer_Main;
            if (mainCusCode == "") return _Rs;
            return _Rs.Where(item => item.MainCusCode == mainCusCode);
        }
        public IQueryable<V_B_Customer_Main> GetV_B_Customer_MainList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Customer_Main> _Rs = this.ObjectContext.V_B_Customer_Main;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("MainCusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.MainCusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("MainCusName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.MainCusName.Contains(it)); });
            }

            return _Rs;
        }

        public IQueryable<V_B_Customer_Acc> GetV_B_Customer_Main_CusIncludeListByMainCusCode(string mainCusCode)
        {
            return this.ObjectContext.V_B_Customer_Acc.Where(item => item.PCode == mainCusCode);
        }

    }
}