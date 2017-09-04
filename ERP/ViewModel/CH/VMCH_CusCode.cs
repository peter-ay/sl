using ERP.Common;
using ERP.Utility;

namespace ERP.ViewModel
{
    public class VMCH_CusCode : VMListCH
    {
        public VMCH_CusCode()
            : base("CusCode", keyCode: "cusCode", keyName: "cusName")
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

        protected override void PrepareDDsInfoListParametersDetail()
        {
            _SWhere += USptstr.Str1 + "gpID" + USptstr.Str2 + (USysInfo.F_Manager || USysInfo.F_CusCodeBrowse ? -99 : USysInfo.GpID).ToString();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return UDSMethods.V_B_CustomerSmartBrowseRightHelpList;
        }
    }
}