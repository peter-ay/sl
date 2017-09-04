

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Pur_PriceContract> GetV_Pur_PriceContractBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (iD == "") return this.ObjectContext.V_Pur_PriceContract;
            return this.ObjectContext.V_Pur_PriceContract.Where(item => item.ID == iD);
        }

        public IQueryable<V_Pur_PriceContract> GetV_Pur_PriceContractList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Pur_PriceContract> _Rs = this.ObjectContext.V_Pur_PriceContract;
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

            _Str = _SArray.GetSptstrValue("OBCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.OBCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("GpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpGroup.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("Pri");
            if (!string.IsNullOrEmpty(_Str) && _Str != "0")
            {
                var _Pri = System.Convert.ToInt16(_Str);
                _Rs = _Rs.Where(item => item.PriCode == _Pri);
            }

            _Str = _SArray.GetSptstrValue("ConCheck");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _Pri = System.Convert.ToInt16(_Str);
                if (_Pri == 1)
                {
                    _Rs = _Rs.Where(item => !string.IsNullOrEmpty(item.Checker));
                }
                else
                {
                    _Rs = _Rs.Where(item => string.IsNullOrEmpty(item.Checker));
                }
            }

            _Str = _SArray.GetSptstrValue("SpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it =>
                {
                    var _SCode = (from c in this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode
                                  where c.SpCode.Contains(it)
                                  select c).Select(item2 => item2.GpCode).Distinct();
                    _Rs = _Rs.Where(item => _SCode.Contains(item.SpGroup));
                });
            }

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it =>
                {
                    var _SCode = (from c in this.ObjectContext.V_Pur_PriceContract_Lens
                                  where c.LensCode.Contains(it)
                                  select c).Select(item2 => item2.BID).Distinct();
                    _Rs = _Rs.Where(item => _SCode.Contains(item.ID));
                });
            }

            return _Rs;
        }
    }
}