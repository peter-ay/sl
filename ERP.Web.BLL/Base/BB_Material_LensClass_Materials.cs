using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Materials : BLLBase
    {
        public BB_Material_LensClass_Materials()
            : base(new DB_Material_LensClass_Materials())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MB_Material_LensClass_Materials model = t as MB_Material_LensClass_Materials;
            return model.KeyCode;
        }
    }
}
