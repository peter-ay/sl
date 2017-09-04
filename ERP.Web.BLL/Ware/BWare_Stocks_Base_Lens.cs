using ERP.Web.DAL;
using ERP.Web.Model;

namespace ERP.Web.BLL
{
    public partial class BWare_Stocks_Base_Lens : BLLBase
    {
        public BWare_Stocks_Base_Lens()
            : base(new DWare_Stocks_Base_Lens())
        {

        }

        protected override string GetPKCodeValue<T>(T t)
        {
            MWare_Stocks_Base_Lens model = t as MWare_Stocks_Base_Lens;
            return model.WhCode + model.LensCode + model.F_LR;
        }
    }
}
