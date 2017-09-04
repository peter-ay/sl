using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_LensClass_Index : BLLBase
    {
        public BB_Material_LensClass_Index()
            : base(new DB_Material_LensClass_Index())
        { }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Material_LensClass_Index).KeyCode;
        }
    }
}
