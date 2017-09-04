

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        //public IQueryable<V_Sale_Order_Frame> GetV_Sale_Order_FrameBill(string dbCode, string iD)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    if (iD == "") return this.ObjectContext.V_Sale_Order_Frame;
        //    return this.ObjectContext.V_Sale_Order_Frame.Where(item => item.ID == iD);
        //}

        public IQueryable<V_Sale_Order_Frame> GetV_Sale_Order_FrameList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_Order_Frame> rs = this.ObjectContext.V_Sale_Order_Frame;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(str))
            {
                if (str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(str);
                    rs = this.ObjectContext.V_Sale_Order_Frame.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

            str = sArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.BCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("D1");
            if (!string.IsNullOrEmpty(str))
            {
                var d1vs = System.Convert.ToDateTime(str);
                rs = rs.Where(item => item.BDate.Value >= d1vs);
            }

            str = sArray.GetSptstrValue("D2");
            if (!string.IsNullOrEmpty(str))
            {
                var d2vs = System.Convert.ToDateTime(str);
                rs = rs.Where(item => item.BDate.Value <= d2vs);
            }

            str = sArray.GetSptstrValue("OBCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.OBCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("Maker");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.Maker.Contains(it)); });
            }

            str = sArray.GetSptstrValue("ConUD");
            if (!string.IsNullOrEmpty(str) && str != "-1")
            {
                var _UD = System.Convert.ToInt16(str);
                rs = rs.Where(item => item.UD == _UD);
            }

            str = sArray.GetSptstrValue("ConCheck");
            if (!string.IsNullOrEmpty(str) && str != "-1")
            {
                var _UD = System.Convert.ToInt16(str);
                if (_UD == 1)
                {
                    rs = rs.Where(item => !string.IsNullOrEmpty(item.Checker));
                }
                else
                {
                    rs = rs.Where(item => string.IsNullOrEmpty(item.Checker));
                }
            }


            return rs;
        }
    }
}