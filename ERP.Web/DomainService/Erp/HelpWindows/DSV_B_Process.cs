namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        public IQueryable<V_B_Material_Process> GetV_B_Material_ProcessHelpList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Material_Process;
        }
    }
}