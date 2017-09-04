using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BB_Frame : BLLBase
    {
        public BB_Frame()
            : base(new DB_Frame())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MB_Frame model = t as MB_Frame;
            return (t as MB_Frame).FrameCode;
        }
    }
}
