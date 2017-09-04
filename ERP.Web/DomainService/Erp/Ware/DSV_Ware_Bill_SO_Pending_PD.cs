

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Bill_SO_Pending_PD> GetV_Ware_Bill_SO_Pending_PDBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (iD == "") return this.ObjectContext.V_Ware_Bill_SO_Pending_PD;
            return this.ObjectContext.V_Ware_Bill_SO_Pending_PD.Where(item => item.ID == iD);
        }

        public IQueryable<V_Ware_Bill_SO_Pending_PD> GetV_Ware_Bill_SO_Pending_PDList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Bill_SO_Pending_PD> _Rs = this.ObjectContext.V_Ware_Bill_SO_Pending_PD;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("OGType");
            if (!string.IsNullOrEmpty(_Str))
            {
                var _OGType = Convert.ToByte(_Str);
                _Rs = _Rs.Where(item => item.OGType.Value == _OGType);
            }

            _Str = _SArray.GetSptstrValue("F_SCTime");
            if (!string.IsNullOrEmpty(_Str) && _Str == "1")
            {
                _Str = _SArray.GetSptstrValue("D1");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d1vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDate.Value >= d1vs);
                }

                _Str = _SArray.GetSptstrValue("D2");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d2vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDate.Value <= d2vs);
                }
            }

            return _Rs;
        }
    }
}