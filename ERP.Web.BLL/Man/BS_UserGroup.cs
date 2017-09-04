using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BS_UserGroup : BLLBase
    {
        public BS_UserGroup()
            : base(new DS_UserGroup())
        { }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MS_UserGroup).GpCode;
        }
    }
}
