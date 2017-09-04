using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Warehouse : BLLBase
    {
        public BB_Warehouse()
            : base(new DB_Warehouse())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Warehouse).WhCode;
        }
    }
}
