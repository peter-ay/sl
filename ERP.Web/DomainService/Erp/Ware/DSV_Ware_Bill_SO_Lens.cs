

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Bill_SO_SD> GetV_Ware_Bill_SO_SDBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (iD == "") return this.ObjectContext.V_Ware_Bill_SO_SD;
            return this.ObjectContext.V_Ware_Bill_SO_SD.Where(item => item.ID == iD);
        }

        public IQueryable<V_Ware_Bill_SO_PD> GetV_Ware_Bill_SO_PDBill(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (iD == "") return this.ObjectContext.V_Ware_Bill_SO_PD;
            return this.ObjectContext.V_Ware_Bill_SO_PD.Where(item => item.ID == iD);
        }

        public IQueryable<V_Ware_Bill_SO_PD_Detail> GetV_Ware_Bill_SO_PDDetailList(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Ware_Bill_SO_PD_Detail.Where(item => item.ID == iD);
        }

        public IQueryable<V_Ware_Bill_SO_Lens> GetV_Ware_Bill_SO_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Bill_SO_Lens> _Rs = this.ObjectContext.V_Ware_Bill_SO_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(_Str);
                    _Rs = _Rs.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

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

            _Str = _SArray.GetSptstrValue("BCodeSale");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCodeSale.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("F_WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str == "1")
                    _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => !string.IsNullOrEmpty(item.WhCode)); });
                else
                    _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => string.IsNullOrEmpty(item.WhCode)); });
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

            _Str = _SArray.GetSptstrValue("BTypeSale");
            if (!string.IsNullOrEmpty(_Str))
            {
                switch (_Str)
                {
                    case "XSSD":
                        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BType == "KFSOSD" || item.BType == "KFSOSDWG"); });
                        break;
                    case "XSPD":
                        _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BType == "KFSOPD" || item.BType == "KFSOPDWG"); });
                        break;
                    default: break;
                }
            }

            return _Rs;
        }
    }
}