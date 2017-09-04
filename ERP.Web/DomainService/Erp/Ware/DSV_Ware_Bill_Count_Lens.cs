

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Bill_Count_PD> GetV_Ware_Bill_Count_PDBill(string dbCode, string iD, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_Ware_Bill_Count_PD> _Rs = this.ObjectContext.V_Ware_Bill_Count_PD;
            if (iD != "")
                return _Rs.Where(item => item.ID == iD);
            else
                return _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        }

        //public IQueryable<V_Ware_Bill_SO_PD_Detail> GetV_Ware_Bill_SO_PDDetailList(string dbCode, string iD)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    return this.ObjectContext.V_Ware_Bill_SO_PD_Detail.Where(item => item.ID == iD);
        //}

        public IQueryable<V_Ware_Bill_Count_Lens> GetV_Ware_Bill_Count_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Bill_Count_Lens> _Rs = this.ObjectContext.V_Ware_Bill_Count_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCode.Contains(it)); });
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

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            return _Rs;
        }
    }
}