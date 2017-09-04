using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Area : BLLBase
    {
        public BB_Area()
            : base(new DB_Area())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MB_Area).AreaCode;
        }
    }
}
