using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Focus : BLLBase
    {
        public BB_Material_LensClass_Focus()
            : base(new DB_Material_LensClass_Focus())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MB_Material_LensClass_Focus model = t as MB_Material_LensClass_Focus;
            return model.KeyCode;
        }
    }
}
