using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Material_Lens : BLLBase
    {
        public BB_Material_Lens()
            : base(new DB_Material_Lens())
        {
        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Material_Lens).LensCode;
        }
    }
}
