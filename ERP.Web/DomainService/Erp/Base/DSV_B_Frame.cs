
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Material_Frame> GetV_B_Material_FrameBill(string dbCode, string frameCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (frameCode == "") return this.ObjectContext.V_B_Material_Frame;
            return this.ObjectContext.V_B_Material_Frame.Where(item => item.FrameCode == frameCode);
        }

        public IQueryable<V_B_Material_Frame> GetV_B_Material_FrameAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_Frame;
        }

        public IQueryable<V_B_Material_Frame> GetV_B_Material_FrameList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Material_Frame> rs = this.ObjectContext.V_B_Material_Frame;
            var sArray = sWhere.GetSptstr();

            var str = sArray.GetSptstrValue("FrameCode");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.FrameCode.Contains(it)); });
            }

            str = sArray.GetSptstrValue("FrameName");
            if (!string.IsNullOrEmpty(str))
            {
                str.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.FrameName.Contains(it)); });
            }
            return rs;
        }
    }
}