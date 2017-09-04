
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_LensRough> GetV_B_LensRoughBill(string dbCode, string rCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (rCode == "") return this.ObjectContext.V_B_LensRough;
            return this.ObjectContext.V_B_LensRough.Where(item => item.RCode == rCode);
        }

        public IQueryable<V_B_LensRough> GetV_B_LensRoughAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_LensRough;
        }

        public IQueryable<V_B_LensRough> GetV_B_LensRoughList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_LensRough> rs = this.ObjectContext.V_B_LensRough;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("RCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.RCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("RName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.RName.Contains(it)); });
            }
            return rs;
        }

        //Lens_Price
        //public IQueryable<V_B_LensRough_Price> GetV_B_LensRough_PriceList(string dbCode, string sWhere)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_B_LensRough_Price> rs = this.ObjectContext.V_B_LensRough_Price;
        //    var sArray = sWhere.GetSptstr();

        //    var str = sArray.GetSptstrValue("RCode");
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        rs = rs.Where(item => item.RCode == str);
        //    }

        //    return rs;
        //}

        //Lens_ProCost
        //public IQueryable<V_B_LensRough_ProCost> GetV_B_LensRough_ProCostList(string dbCode, string sWhere)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_B_LensRough_ProCost> rs = this.ObjectContext.V_B_LensRough_ProCost;
        //    var sArray = sWhere.GetSptstr();

        //    var str = sArray.GetSptstrValue("RCode");
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        rs = rs.Where(item => item.RCode == str);
        //    }

        //    return rs;
        //}
    }
}