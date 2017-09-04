using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Department : BLLBase
    {
        public BB_Department()
            : base(new DB_Department())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Department).DpCode;
        }
    }
}
