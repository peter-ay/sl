using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BS_User : BLLBase
    {
        public BS_User()
            : base(new DS_User())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MS_User).UserCode;
        }
    }
}
