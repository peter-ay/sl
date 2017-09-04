
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMCH_LensCodeSale : VMListCH
    {
        public VMCH_LensCodeSale()
            : base("LensCode", "B_Lens", "lensCode", "lensName")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Material_Lens_SaleList";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_Sale" + USptstr.Str2 + "1";
        }
    }
}