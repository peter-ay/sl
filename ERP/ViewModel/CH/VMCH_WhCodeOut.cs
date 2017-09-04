
using ERP.Common;
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMCH_WhCodeOut : VMListCH
    {
        public VMCH_WhCodeOut()
            : base("WhCode")
        {
        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.ExecuteCmdSearch();
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Warehouse_BrowseList";
        }

        protected override void PrepareDDsInfoListParameters()
        {
            this.DDsInfoList.Parameters.Add(new ComParameters() { ParameterName = "gpID", Value = USysInfo.F_WhCodeBrowse || USysInfo.F_Manager ? -99 : USysInfo.GpID });
        }
    }
}