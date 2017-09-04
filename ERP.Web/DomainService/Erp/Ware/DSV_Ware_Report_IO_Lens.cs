

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Report_IO_Lens> GetV_Ware_Report_IO_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Report_IO_Lens> _Rs = this.ObjectContext.V_Ware_Report_IO_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("D1");
            if (!string.IsNullOrEmpty(_Str))
            {
                var d1vs = System.Convert.ToDateTime(_Str);
                _Rs = _Rs.Where(item => item.MDate.Value >= d1vs);
            }

            _Str = _SArray.GetSptstrValue("D2");
            if (!string.IsNullOrEmpty(_Str))
            {
                var d2vs = System.Convert.ToDateTime(_Str).AddDays(1);
                _Rs = _Rs.Where(item => item.MDate.Value <= d2vs);
            }

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

            _Str = _SArray.GetSptstrValue("F_LR");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.F_LR == (it)); });
            }

            _Str = _SArray.GetSptstrValue("SPH");
            if (!string.IsNullOrEmpty(_Str))
            {
                var _SPH = 0;
                try { _SPH = Convert.ToInt32(_Str); }
                catch { }
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SPH == _SPH); });
            }

            _Str = _SArray.GetSptstrValue("CYL");
            if (!string.IsNullOrEmpty(_Str))
            {
                var _CYL = 0;
                try { _CYL = Convert.ToInt32(_Str); }
                catch { }
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CYL == _CYL); });
            }

            _Str = _SArray.GetSptstrValue("X_ADD");
            if (!string.IsNullOrEmpty(_Str))
            {
                var _X_ADD = 0;
                try { _X_ADD = Convert.ToInt32(_Str); }
                catch { }
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.X_ADD == _X_ADD); });
            }

            return _Rs;
        }
    }
}