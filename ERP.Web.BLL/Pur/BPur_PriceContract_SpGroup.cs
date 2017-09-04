using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BPur_PriceContract_SpGroup : BLLBase
    {
        public BPur_PriceContract_SpGroup()
            : base(new DPur_PriceContract_SpGroup())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            return (t as MPur_PriceContract_SpGroup).GpCode;
        }
    }
}
