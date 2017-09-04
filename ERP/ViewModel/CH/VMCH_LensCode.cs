
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMCH_LensCode : VMListCH
    {
        public VMCH_LensCode()
            : base("LensCode", "B_Lens", "lensCode", "lensName")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Material_LensList";
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }
    }
}