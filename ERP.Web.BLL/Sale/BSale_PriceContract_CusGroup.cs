using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BSale_PriceContract_CusGroup : BLLBase
    {
        public BSale_PriceContract_CusGroup()
            : base(new DSale_PriceContract_CusGroup())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MSale_PriceContract_CusGroup).GpCode;
        }
    }
}
