

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_Sale_PriceContract_Frame> GetV_Sale_PriceContract_FrameList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_PriceContract_Frame> rs = this.ObjectContext.V_Sale_PriceContract_Frame;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("FrameCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.FrameCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("FrameName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.InvTitle.Contains(it)); });
            }

            str = sArray.GetSptstrValue("BID");
            rs = rs.Where(item => item.BID.ToUpper().Trim() == (str.ToUpper().Trim()));

            return rs;
        }
    }
}