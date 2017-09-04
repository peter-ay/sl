
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMCH_FrameCode : VMListCH
    {
        public VMCH_FrameCode()
            : base("FrameCode", "B_Frame", "FrameCode", "lensName")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Material_FrameList";
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }
    }
}