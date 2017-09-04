using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Supplier : BLLBase
    {
        public BB_Supplier()
            : base(new DB_Supplier())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Supplier).SpCode;
        }

    }
}
