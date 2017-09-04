namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        //public IQueryable<V_B_CustomerSmartBrowseRight> GetV_B_CustomerSmartBrowseRightACList
        //    (string dbCode, int gpID)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    if (gpID == -99)
        //        return this.ObjectContext.V_B_CustomerSmartBrowseRight;

        //    return this.ObjectContext.V_B_CustomerSmartBrowseRight.Where
        //        (item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
        //}

    //    public IQueryable<V_B_CustomerSmartBrowseRight> GetV_B_CustomerSmartBrowseRightHelpList
    //(string dbCode, string sWhere)
    //    {
    //        this.ObjectContext.ChangeDataBase(dbCode);
    //        var sArray = sWhere.GetSptstr();
    //        IQueryable<V_B_CustomerSmartBrowseRight> rs = null;

    //        var str = sArray.GetSptstrValue("gpID");
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            if (str == "-99")
    //            {
    //                rs = this.ObjectContext.V_B_CustomerSmartBrowseRight;
    //            }
    //            else
    //            {
    //                rs = this.ObjectContext.V_B_CustomerSmartBrowseRight.Where
    //           (item => item.BrowseRight.Substring(System.Convert.ToInt32(str) - 1, 1) == "1");
    //            }
    //        }

    //        str = sArray.GetSptstrValue("CusCode");
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusCode.Contains(it)); });
    //        }

    //        str = sArray.GetSptstrValue("CusName");
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusName.Contains(it)); });
    //        }

    //        return rs;
    //    }
    }
}