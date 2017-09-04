
namespace ERP.Web.DomainService.Man
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        public IQueryable<V_U_ProcessClass> GetV_U_ProcessClassAllList()
        {
            return this.ObjectContext.V_U_ProcessClass;
        }
    }
}


