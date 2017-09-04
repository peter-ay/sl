
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMCH_LensCodePur : VMListCH
    {
        public VMCH_LensCodePur()
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
            return "GetV_B_Material_Lens_PurList";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_Pur" + USptstr.Str2 + "1";
        }
    }
}