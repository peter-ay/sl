using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_Process : BLLBase
    {
        public BB_Material_Process()
            : base(new DB_Material_Process())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Material_Process).ProCode;
        }
    }
}
