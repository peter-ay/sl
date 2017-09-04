
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Material_Lens_Sales> GetV_B_Material_Lens_SalesBill(string dbCode, string lensCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (lensCode == "") return this.ObjectContext.V_B_Material_Lens_Sales;
            return this.ObjectContext.V_B_Material_Lens_Sales.Where(item => item.LensCode == lensCode);
        }

        public IQueryable<V_B_Material_Lens_Sales> GetV_B_Material_Lens_SalesAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_Lens_Sales;
        }

        public IQueryable<V_B_Material_Lens_Sales> GetV_B_Material_Lens_SalesList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Lens_Sales> rs = this.ObjectContext.V_B_Material_Lens_Sales;
            var sArray = sWhere.GetSptstr();
            string str = "";

            //var str = sArray.GetSptstrValue("F_Sale");
            //if (!string.IsNullOrEmpty(str))
            //{
            //    if (str == "1")
            //        rs = rs.Where(item => item.F_Sale == true);
            //    else
            //        rs = rs.Where(item => item.F_Sale == false);
            //}

            //str = sArray.GetSptstrValue("F_Pur");
            //if (!string.IsNullOrEmpty(str))
            //{
            //    if (str == "1")
            //        rs = rs.Where(item => item.F_Pur == true);
            //    else
            //        rs = rs.Where(item => item.F_Pur == false);
            //}

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

        //Lens_Price
        //public IQueryable<V_B_Material_Lens_Sales_Price> GetV_B_Material_Lens_Sales_PriceList(string dbCode, string sWhere)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_B_Material_Lens_Sales_Price> rs = this.ObjectContext.V_B_Material_Lens_Sales_Price;
        //    var sArray = sWhere.GetSptstr();

        //    var str = sArray.GetSptstrValue("LensCode");
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        rs = rs.Where(item => item.LensCode == str);
        //    }

        //    return rs;
        //}

        //Lens_ProCost
        //public IQueryable<V_B_Material_Lens_Sales_ProCost> GetV_B_Material_Lens_Sales_ProCostList(string dbCode, string sWhere)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    IQueryable<V_B_Material_Lens_Sales_ProCost> rs = this.ObjectContext.V_B_Material_Lens_Sales_ProCost;
        //    var sArray = sWhere.GetSptstr();

        //    var str = sArray.GetSptstrValue("LensCode");
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        rs = rs.Where(item => item.LensCode == str);
        //    }

        //    return rs;
        //}
    }
}