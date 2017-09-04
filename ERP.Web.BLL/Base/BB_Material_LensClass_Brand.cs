using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Brand : BLLBase
    {
        public BB_Material_LensClass_Brand()
            : base(new DB_Material_LensClass_Brand())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Material_LensClass_Brand).KeyCode;
        }
    }
}
