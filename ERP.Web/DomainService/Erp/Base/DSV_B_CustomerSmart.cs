
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_CustomerSmart> GetV_B_CustomerSmartList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_CustomerSmart> rs = this.ObjectContext.V_B_CustomerSmart;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("CusName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusName.Contains(it)); });
            }

            //////////////////////////////////////////////////////////////////////////////////////

            #region PriceContractCusCode

            str = sArray.GetSptstrValue("PCIncludeState");
            if (!string.IsNullOrEmpty(str) && str != "-1")
            {
                var cusType = sArray.GetSptstrValue("GpCode");
                var _RSCusCode = this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.Where(item => item.GpCode.ToUpper() == cusType).Select(item2 => item2.CusCode);
                if (str == "0")
                {
                    rs = rs.Where(item => !_RSCusCode.Contains(item.CusCode));
                }
                else
                {
                    rs = rs.Where(item => _RSCusCode.Contains(item.CusCode));
                }
            }


            #endregion


            return rs;
        }

        //    public IQueryable<V_B_CustomerSmart> GetV_B_User_CustomerSmartList
        //(string dbCode, int gpID)
        //    {
        //        this.ObjectContext.ChangeDataBase(dbCode);

        //        var codeList = from c in this.GetV_B_CustomerSmartBrowseRight().
        //                       Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1")
        //                       select c.CusCode;

        //        var rs = this.ObjectContext.V_B_CustomerSmart.Where(item => codeList.Contains(item.CusCode.ToUpper()));
        //        return rs;
        //    }

    }
}