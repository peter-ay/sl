
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Customer> GetV_B_CustomerBill(string dbCode, string cusCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Customer> _Rs = this.ObjectContext.V_B_Customer;
            if (cusCode == "") return _Rs;
            return _Rs.Where(item => item.CusCode == cusCode);
        }

        public IQueryable<V_B_Customer> GetV_B_CustomerAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Customer;
        }

        public IQueryable<V_B_Customer> GetV_B_CustomerRightBrowseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Customer> _Rs = this.ObjectContext.V_B_Customer;

            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            return _Rs;
        }

        public IQueryable<V_B_Customer_Browse> GetV_B_CustomerRightBrowseGpCode(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Customer_Browse> _Rs = this.ObjectContext.V_B_Customer_Browse.Where(it => it.GpCode == gpCode);
            return _Rs;
        }

        public IQueryable<V_B_Customer> GetV_B_CustomerList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Customer> _Rs = this.ObjectContext.V_B_Customer;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("CusName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusName.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("DpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.DpCode.Contains(it)); });
            }

            #region SupplierDefaultCusCode

            _Str = _SArray.GetSptstrValue("SDIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var spCode = _SArray.GetSptstrValue("SpCode");
                var _RSCusCode = this.ObjectContext.V_B_Supplier_Default_CusCode.Where(item => item.SpCode.ToUpper() == spCode).Select(item2 => item2.CusCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSCusCode.Contains(item.CusCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSCusCode.Contains(item.CusCode));
                }
            }

            #endregion

            #region PriceContractCusCode

            _Str = _SArray.GetSptstrValue("PCIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var cusType = _SArray.GetSptstrValue("GpCode");
                var _RSCusCode = this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.Where(item => item.GpCode.ToUpper() == cusType).Select(item2 => item2.CusCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSCusCode.Contains(item.CusCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSCusCode.Contains(item.CusCode));
                }
            }

            #endregion

            #region CusCodeBrowseRight

            _Str = _SArray.GetSptstrValue("BrowseIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var cusType = _SArray.GetSptstrValue("GpCode");
                var _RSCusCode = this.ObjectContext.V_B_Customer_Browse.Where(item => item.GpCode.ToUpper() == cusType).Select(item2 => item2.CusCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSCusCode.Contains(item.CusCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSCusCode.Contains(item.CusCode));
                }
            }

            #endregion

            return _Rs;
        }

    }
}