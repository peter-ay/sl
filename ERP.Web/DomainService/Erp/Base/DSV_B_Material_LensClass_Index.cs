
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;
    using System.Data;

    public partial class DSErp
    {
        public IQueryable<V_B_Material_LensClass_Index> GetV_B_Material_LensClass_IndexBill(string dbCode, string keyCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (keyCode == "") return this.ObjectContext.V_B_Material_LensClass_Index;
            return this.ObjectContext.V_B_Material_LensClass_Index.Where(item => item.KeyCode == keyCode);
        }

        public IQueryable<V_B_Material_LensClass_Index> GetV_B_Material_LensClass_IndexAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_LensClass_Index;
        }

        public IQueryable<V_B_Material_LensClass_Index> GetV_B_Material_LensClass_IndexList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_LensClass_Index> _Rs = this.ObjectContext.V_B_Material_LensClass_Index;

            string _Str = "";

            var _SArray = sWhere.GetSptstr();

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
            //    _Rs = this.ObjectContext.V_B_Material_LensClass_Index;
            //    this.PrepareExportList_B_Material_LensClass_Index(_Rs, _F_LEID);
            //}

            return _Rs;
        }

        //private void PrepareExportList_B_Material_LensClass_Index(IQueryable<V_B_Material_LensClass_Index> _Rs, string _F_LEID)
        //{
        //    _DT = new DataTable();
        //    var _RSLE = _Rs.ToList();
        //    _DT.Columns.Add("KeyCode");
        //    _DT.Columns.Add("KeyName");
        //    _DT.Columns.Add("SN");

        //    foreach (var item in _RSLE)
        //    {
        //        var _dr = _DT.Rows.Add();
        //        _dr[0] = item.KeyCode;
        //        _dr[1] = item.KeyName;
        //        _dr[2] = item.SN;
        //    }

        //    ERP.Web.DomainService.Common.DSExport.ExportListLens(_DT, _F_LEID);
        //}
    }
}