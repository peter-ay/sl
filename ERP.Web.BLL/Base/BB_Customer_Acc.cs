using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Customer_Acc : BLLBase
    {
        public BB_Customer_Acc()
            : base(new DB_Customer_Acc())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Customer_Acc).AccCusCode;
        }
    }
}
