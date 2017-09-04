namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {

        public IQueryable<V_B_Material_Frame> GetV_B_Material_FrameHelpList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            return this.ObjectContext.V_B_Material_Frame;
        }

        public IQueryable<V_B_Material_Frame> GetV_B_CusFrameHelpList(string dbCode, string cusCode)
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

            var _CodesList = (from c in this.GetV_Sale_PriceContract_Frame()
                              where bIDList.Contains(c.BID)
                              select c.FrameCode.ToUpper()).Distinct();

            var rs = this.ObjectContext.V_B_Material_Frame.
                Where(item => _CodesList.Contains(item.FrameCode.ToUpper()));

            return rs;
        }
    }
}