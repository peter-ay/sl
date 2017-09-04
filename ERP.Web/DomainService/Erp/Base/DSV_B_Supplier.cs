
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Supplier> GetV_B_SupplierBill(string dbCode, string spCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (spCode == "") return this.ObjectContext.V_B_Supplier;
            return this.ObjectContext.V_B_Supplier.Where(item => item.SpCode == spCode);
        }

        public IQueryable<V_B_Supplier> GetV_B_SupplierAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Supplier;
        }

        public IQueryable<V_B_Supplier> GetV_B_SupplierRightBrowseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Supplier> _Rs = this.ObjectContext.V_B_Supplier;

            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            return _Rs;
        }

        public IQueryable<V_B_Supplier_Browse> GetV_B_SupplierRightBrowseGpCode(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Supplier_Browse> _Rs = this.ObjectContext.V_B_Supplier_Browse.Where(it => it.GpCode == gpCode);
            return _Rs;
        }

        public IQueryable<V_B_Supplier> GetV_B_SupplierList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Supplier> _Rs = this.ObjectContext.V_B_Supplier;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("spCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("spName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpName.Contains(it)); });
            }

            #region PriceContractSpCode

            _Str = _SArray.GetSptstrValue("PCIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var cusType = _SArray.GetSptstrValue("GpCode");
                var _RSSpCode = this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode.Where(item => item.GpCode.ToUpper() == cusType).Select(item2 => item2.SpCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSSpCode.Contains(item.SpCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSSpCode.Contains(item.SpCode));
                }
            }

            #endregion

            return _Rs;
        }

        public IQueryable<V_B_Supplier_Default> GetV_B_Supplier_DefaultList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Supplier_Default> _Rs = this.ObjectContext.V_B_Supplier_Default;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("spCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("spName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpName.Contains(it)); });
            }

            return _Rs;
        }

        public IQueryable<V_B_Supplier_Default_CusCode> GetV_B_Supplier_Default_CusCodeList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Supplier_Default_CusCode> _Rs = this.ObjectContext.V_B_Supplier_Default_CusCode;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("spCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            return _Rs;
        }

        public IQueryable<V_B_Supplier_Default_Lens> GetV_B_Supplier_Default_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Supplier_Default_Lens> _Rs = this.ObjectContext.V_B_Supplier_Default_Lens;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("spCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            return _Rs;
        }

        public IQueryable<V_B_Supplier_Default_ProCode> GetV_B_Supplier_Default_ProCodeList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Supplier_Default_ProCode> _Rs = this.ObjectContext.V_B_Supplier_Default_ProCode;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("spCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            return _Rs;
        }

    }
}