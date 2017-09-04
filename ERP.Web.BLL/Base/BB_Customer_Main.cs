using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Customer_Main : BLLBase
    {
        public BB_Customer_Main()
            : base(new DB_Customer_Main())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Customer_Main).MainCusCode;
        }
    }
}
