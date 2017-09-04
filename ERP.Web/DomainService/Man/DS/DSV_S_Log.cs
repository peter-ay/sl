
namespace ERP.Web.DomainService.Man
{
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        //Log
        public IQueryable<V_S_Log> GetV_S_LogList(string d1, string d2)
        {
            return this.ObjectContext.V_S_Log.Where(item => item.LogTimeSmall.CompareTo(d1) >= 0 && item.LogTimeSmall.CompareTo(d2) <= 0);
        }
    }
}


