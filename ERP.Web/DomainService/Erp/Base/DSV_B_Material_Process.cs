
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Material_Process> GetV_B_Material_ProcessBill(string dbCode, string proCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Material_Process> _Rs = this.ObjectContext.V_B_Material_Process;
            if (proCode == "") return _Rs;
            return _Rs.Where(item => item.ProCode == proCode);
        }

        public IQueryable<V_B_Material_Process> GetV_B_Material_ProcessAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_Process;
        }

        public IQueryable<V_B_Material_Process> GetV_B_Material_ProcessList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Process> _Rs = this.ObjectContext.V_B_Material_Process;
            var _SArray = sWhere.GetSptstr();

            var _Str = _SArray.GetSptstrValue("ProCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.ProCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("ProName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.ProName.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("ProClass");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.ProClass.Contains(it)); });
            }

            #region SupplierDefaultProCode

            _Str = _SArray.GetSptstrValue("SDIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var spCode = _SArray.GetSptstrValue("SpCode");
                var _RSProCode = this.ObjectContext.V_B_Supplier_Default_ProCode.Where(item => item.SpCode.ToUpper() == spCode).Select(item2 => item2.ProCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSProCode.Contains(item.ProCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSProCode.Contains(item.ProCode));
                }
            }

            #endregion

            return _Rs;
        }
    }
}