using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Person : BLLBase
    {
        public BB_Person()
            : base(new DB_Person())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Person).PersonCode;
        }
    }
}
