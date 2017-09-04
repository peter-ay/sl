
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMSale_Order_Status_List : VMList
    {
        public VMSale_Order_Status_List()
            : base("ID", "Sale_Order_Status")
        {

        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BID");
            this.DDsInfoList.AddDefaultSorts("ID");
        }
    }
}
