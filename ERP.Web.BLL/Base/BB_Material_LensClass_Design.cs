using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Design : BLLBase
    {
        public BB_Material_LensClass_Design()
            : base(new DB_Material_LensClass_Design())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MB_Material_LensClass_Design model = t as MB_Material_LensClass_Design;
            return model.KeyCode;
        }
    }
}
