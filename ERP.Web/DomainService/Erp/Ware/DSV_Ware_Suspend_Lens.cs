

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;
    using System.Data;
    using ERP.Web.Common;

    public partial class DSErp
    {
        //
        //public IQueryable<V_Ware_Suspend_Lens> GetV_Ware_Suspend_LensBill(string dbCode, string iD, int gpID)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_Ware_Suspend_Lens> _Rs = this.ObjectContext.V_Ware_Suspend_Lens;
        //    if (gpID != -99)
        //    {
        //        _Rs = this.ObjectContext.V_Ware_Suspend_Lens.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        //    }
        //    if (iD == "") return _Rs;

        //    return _Rs.Where(item => item.ID == iD);
        //}
        //
        //public IQueryable<V_Ware_Suspend_Lens> GetV_Ware_Suspend_LensList(string dbCode, string sWhere)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_Ware_Suspend_Lens> _Rs = this.ObjectContext.V_Ware_Suspend_Lens;
        //    var _SArray = sWhere.GetSptstr();
        //    string _Str = "";

        //    _Str = _SArray.GetSptstrValue("WhCode");
        //    if (!string.IsNullOrEmpty(_Str))
        //    {
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
        //    }

        //    _Str = _SArray.GetSptstrValue("LensCode");
        //    if (!string.IsNullOrEmpty(_Str))
        //    {
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCode.Contains(it)); });
        //    }

        //    _Str = _SArray.GetSptstrValue("IOType");
        //    if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
        //    {
        //        var _IO = (_Str == "1");
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.F_IO.Value == _IO); });
        //    }

        //    _Str = _SArray.GetSptstrValue("SPH");
        //    if (!string.IsNullOrEmpty(_Str))
        //    {
        //        var _SPH = 0;
        //        try { _SPH = Convert.ToInt32(_Str); }
        //        catch { }
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SPH == _SPH); });
        //    }

        //    _Str = _SArray.GetSptstrValue("CYL");
        //    if (!string.IsNullOrEmpty(_Str))
        //    {
        //        var _CYL = 0;
        //        try { _CYL = Convert.ToInt32(_Str); }
        //        catch { }
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CYL == _CYL); });
        //    }

        //    _Str = _SArray.GetSptstrValue("X_ADD");
        //    if (!string.IsNullOrEmpty(_Str))
        //    {
        //        var _X_ADD = 0;
        //        try { _X_ADD = Convert.ToInt32(_Str); }
        //        catch { }
        //        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.X_ADD == _X_ADD); });
        //    }

        //    return _Rs;
        //}
    }
}