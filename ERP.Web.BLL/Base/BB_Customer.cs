using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Customer : BLLBase
    {
        public BB_Customer()
            : base(new DB_Customer())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Customer).CusCode;
        }
    }
}
