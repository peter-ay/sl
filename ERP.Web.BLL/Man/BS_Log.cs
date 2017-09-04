using ERP.Web.DAL;

namespace ERP.Web.BLL
{
    public partial class BS_Log : BLLBase
    {
        public BS_Log()
            : base(new DS_Log())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return "";
        }
    }
}
