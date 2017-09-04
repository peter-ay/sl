using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Usage : BLLBase
    {
        public BB_Material_LensClass_Usage()
            : base(new DB_Material_LensClass_Usage())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MB_Material_LensClass_Usage model = t as MB_Material_LensClass_Usage;
            return (t as MB_Material_LensClass_Usage).KeyCode;
        }
    }
}
