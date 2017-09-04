

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Bill_SO_Pre_SD> GetV_Ware_Bill_SO_Pre_SDBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (iD == "") return this.ObjectContext.V_Ware_Bill_SO_Pre_SD;
            return this.ObjectContext.V_Ware_Bill_SO_Pre_SD.Where(item => item.ID == iD);
        }

        public IQueryable<V_Ware_Bill_SO_Pre_Lens> GetV_Ware_Bill_SO_Pre_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Bill_SO_Pre_Lens> _Rs = this.ObjectContext.V_Ware_Bill_SO_Pre_Lens;
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

            _Str = _SArray.GetSptstrValue("PreBarCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BarCodeSOPre.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("SCCheck");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _UD = System.Convert.ToInt16(_Str);
                if (_UD == 1)
                {
                    _Rs = _Rs.Where(item => !string.IsNullOrEmpty(item.Checker));
                }
                else
                {
                    _Rs = _Rs.Where(item => string.IsNullOrEmpty(item.Checker));
                }
            }

            return _Rs;
        }
    }
}