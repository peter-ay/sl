
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;
    using System.Data;

    public partial class DSErp
    {
        public IQueryable<V_B_Area> GetV_B_AreaBill(string dbCode, string areaCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Area> _Rs = this.ObjectContext.V_B_Area;

            if (areaCode == "") return _Rs;
            return _Rs.Where(item => item.AreaCode == areaCode);
        }

        public IQueryable<V_B_Area> GetV_B_AreaAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Area;
        }

        public IQueryable<V_B_Area> GetV_B_AreaList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Area> _Rs = this.ObjectContext.V_B_Area;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("AreaCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.AreaCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("AreaName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.AreaName.Contains(it)); });
            }

            //_Str = _SArray.GetSptstrValue("F_LE");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    _F_LE = true;
            //}

            //_Str = _SArray.GetSptstrValue("F_LEID");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    _F_LEID = _Str;
            //}

            //if (_F_LE)
            //{
            //    _Rs = this.ObjectContext.V_B_Area;
            //    this.PrepareExportList_V_B_Area(_Rs, _F_LEID);
            //}

            return _Rs;
        }

        //private void PrepareExportList_V_B_Area(IQueryable<V_B_Area> _Rs, string _F_LEID)
        //{
        //    _DT = new DataTable();
        //    var _RSLE = _Rs.ToList();
        //    _DT.Columns.Add("AreaCode");
        //    _DT.Columns.Add("AreaName");
        //    _DT.Columns.Add("PCode");

        //    foreach (var item in _RSLE)
        //    {
        //        var _dr = _DT.Rows.Add();
        //        _dr[0] = item.AreaCode;
        //        _dr[1] = item.AreaName;
        //        _dr[2] = item.PCode;
        //    }

        //    ERP.Web.DomainService.Common.DSExport.ExportListLens(_DT, _F_LEID);
        //}
    }
}