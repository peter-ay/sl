

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        //public IQueryable<V_Sale_Invoice_SD> GetV_Sale_Invoice_SDBill(string dbCode, string iD, int gpID)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    IQueryable<V_Sale_Invoice_SD> _Rs = this.ObjectContext.V_Sale_Invoice_SD;
        //    if (gpID != -99)
        //    {
        //        _Rs = this.ObjectContext.V_Sale_Invoice_SD.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        //    }

        //    if (iD == "") return _Rs;
        //    return _Rs.Where(item => item.ID == iD);
        //}

        public IQueryable<V_Sale_Delivery_Lens> GetV_Sale_Delivery_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_Delivery_Lens> _Rs = this.ObjectContext.V_Sale_Delivery_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(_Str);
                    _Rs = this.ObjectContext.V_Sale_Delivery_Lens.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

            _Str = _SArray.GetSptstrValue("BCodeSale");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCodeSale.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("BCodeXSDD");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCodeXSDD.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("BCodeXSDD_Scan");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCodeXSDD == (it)); });
            }

            _Str = _SArray.GetSptstrValue("DN");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.DN.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("DN_Scan");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.DN == (it)); });
            }

            _Str = _SArray.GetSptstrValue("F_SCTime");
            if (!string.IsNullOrEmpty(_Str) && _Str == "1")
            {
                _Str = _SArray.GetSptstrValue("D1");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d1vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDateSale.Value >= d1vs);
                }

                _Str = _SArray.GetSptstrValue("D2");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d2vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDateSale.Value <= d2vs);
                }
            }

            _Str = _SArray.GetSptstrValue("OBCodeSale");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.OBCodeSale.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("SCDelivery");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _SCD = System.Convert.ToInt16(_Str);
                if (_SCD == 1)
                {
                    _Rs = _Rs.Where(item => !string.IsNullOrEmpty(item.DN));
                }
                else
                {
                    _Rs = _Rs.Where(item => string.IsNullOrEmpty(item.DN));
                }
            }


            return _Rs;
        }
    }
}