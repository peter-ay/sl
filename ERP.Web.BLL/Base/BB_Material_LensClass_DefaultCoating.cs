using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_DefaultCoating : BLLBase
    {
        public BB_Material_LensClass_DefaultCoating()
            : base(new DB_Material_LensClass_DefaultCoating())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Material_LensClass_DefaultCoating).KeyCode;
        }
    }
}
