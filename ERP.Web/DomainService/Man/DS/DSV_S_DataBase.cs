
namespace ERP.Web.DomainService.Man
{
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        //DataBase
        public IQueryable<V_S_DataBase> GetV_S_DataBaseList()
        {
            return this.ObjectContext.V_S_DataBase;
        }

        public IQueryable<V_S_DataBase> GetV_S_DataBaseAllList()
        {
            return this.ObjectContext.V_S_DataBase;
        }
    }
}


