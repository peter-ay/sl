

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        //public IQueryable<V_Pur_Order_Lens> GetV_Pur_Order_LensBill(string dbCode, string iD)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    if (iD == "") return this.ObjectContext.V_Pur_Order_Lens;
        //    return this.ObjectContext.V_Pur_Order_Lens.Where(item => item.ID == iD);
        //}

        public IQueryable<V_Pur_Order_Lens> GetV_Pur_Order_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Pur_Order_Lens> _Rs = this.ObjectContext.V_Pur_Order_Lens;
            var sArray = sWhere.GetSptstr();

            var _Str = sArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(_Str);
                    _Rs = this.ObjectContext.V_Pur_Order_Lens.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

            _Str = sArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCode.Contains(it)); });
            }

            _Str = sArray.GetSptstrValue("D1");
            if (!string.IsNullOrEmpty(_Str))
            {
                var d1vs = System.Convert.ToDateTime(_Str);
                _Rs = _Rs.Where(item => item.BDate.Value >= d1vs);
            }

            _Str = sArray.GetSptstrValue("D2");
            if (!string.IsNullOrEmpty(_Str))
            {
                var d2vs = System.Convert.ToDateTime(_Str);
                _Rs = _Rs.Where(item => item.BDate.Value <= d2vs);
            }

            //_Str = sArray.GetSptstrValue("OBCode");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.OBCode.Contains(it)); });
            //}

            //_Str = sArray.GetSptstrValue("CusCode");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusCode.Contains(it)); });
            //}

            _Str = sArray.GetSptstrValue("Maker");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.Maker.Contains(it)); });
            }


            return _Rs;
        }
    }
}