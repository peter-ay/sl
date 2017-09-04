
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        //public IQueryable<V_B_Material_Lens> GetV_B_Material_LensBill(string dbCode, string lensCode)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    if (lensCode == "") return this.ObjectContext.V_B_Material_Lens;
        //    return this.ObjectContext.V_B_Material_Lens.Where(item => item.LensCode == lensCode);
        //}

        public IQueryable<V_B_Material_LensSmart> GetV_B_Material_LensSmartXYTable(string dbCode, string lensCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_LensSmart.Where(it => it.LensCode.ToUpper() == lensCode.ToUpper());
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens_GeneralBill(string dbCode, string lensCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Material_Lens> _Rs = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensLevel == 1);
            if (lensCode == "") return _Rs;
            return _Rs.Where(item => item.LensCode == lensCode);
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens_SaleBill(string dbCode, string lensCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Material_Lens> _Rs = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensLevel == 2);
            if (lensCode == "") return _Rs;
            return _Rs.Where(item => item.LensCode == lensCode);
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_LensAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_Lens;
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Lens> _Rs = this.ObjectContext.V_B_Material_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            //var _Str = _SArray.GetSptstrValue("F_Sale");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    if (_Str == "1")
            //        _Rs = _Rs.Where(item => item.F_Sale == true);
            //    else
            //        _Rs = _Rs.Where(item => item.F_Sale == false);
            //}

            //_Str = _SArray.GetSptstrValue("F_Pur");
            //if (!string.IsNullOrEmpty(_Str))
            //{
            //    if (_Str == "1")
            //        _Rs = _Rs.Where(item => item.F_Pur == true);
            //    else
            //        _Rs = _Rs.Where(item => item.F_Pur == false);
            //}

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensName.Contains(it)); });
            }

            #region SupplierDefaultLensCode

            _Str = _SArray.GetSptstrValue("SDIncludeState");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var spCode = _SArray.GetSptstrValue("SpCode");
                var _RSLensCode = this.ObjectContext.V_B_Supplier_Default_Lens.Where(item => item.SpCode.ToUpper() == spCode).Select(item2 => item2.LensCode);
                if (_Str == "0")
                {
                    _Rs = _Rs.Where(item => !_RSLensCode.Contains(item.LensCode));
                }
                else
                {
                    _Rs = _Rs.Where(item => _RSLensCode.Contains(item.LensCode));
                }
            }

            #endregion

            return _Rs;
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens_GeneralList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Lens> rs = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensLevel == 1);
            var sArray = sWhere.GetSptstr();
            string str = "";

            str = sArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensName.Contains(it)); });
            }
            return rs;
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens_SaleList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Lens> rs = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensLevel == 2);
            var sArray = sWhere.GetSptstr();
            string str = "";

            str = sArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensName.Contains(it)); });
            }
            return rs;
        }

        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens_PurList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Lens> rs = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensLevel == 1);
            var sArray = sWhere.GetSptstr();
            string str = "";

            str = sArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("LensName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.LensName.Contains(it)); });
            }
            return rs;
        }

        public IQueryable<V_B_Material_LensSmart> GetV_B_Material_LensByCusCodeList(string dbCode, string cusCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            cusCode = cusCode.GetMyStr();

            var cusGroupList = from c in this.GetV_Sale_PriceContract_CusGroup_CusCode()
                               where c.CusCode.ToUpper() == cusCode
                               select c.GpCode;

            var bIDList = from c in this.GetV_Sale_PriceContract()
                          where cusGroupList.Contains(c.CusGroup) && !string.IsNullOrEmpty(c.Checker)
                          && c.BegDate <= (DateTime.Now) && c.EndDate >= (DateTime.Now)
                          select c.ID;

            var _CodesList = (from c in this.GetV_Sale_PriceContract_Lens()
                              where bIDList.Contains(c.BID)
                              select c.LensCode.ToUpper()).Distinct();

            var _Rs = this.ObjectContext.V_B_Material_LensSmart.Where(item => _CodesList.Contains(item.LensCode.ToUpper()));

            return _Rs;
        }

        public IQueryable<V_B_Material_LensSmart> GetV_B_Material_LensBySpCodeList(string dbCode, string spCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            spCode = spCode.GetMyStr();

            var cusGroupList = from c in this.GetV_Pur_PriceContract_SpGroup_SpCode()
                               where c.SpCode.ToUpper() == spCode
                               select c.GpCode;

            var bIDList = from c in this.GetV_Pur_PriceContract()
                          where cusGroupList.Contains(c.SpGroup) && !string.IsNullOrEmpty(c.Checker)
                          && c.BegDate <= (DateTime.Now) && c.EndDate >= (DateTime.Now)
                          select c.ID;

            var _CodesList = (from c in this.GetV_Pur_PriceContract_Lens()
                              where bIDList.Contains(c.BID)
                              select c.LensCode.ToUpper()).Distinct();

            var _Rs = this.ObjectContext.V_B_Material_LensSmart.Where(item => _CodesList.Contains(item.LensCode.ToUpper()));

            return _Rs;
        }
    }
}