
namespace ERP.ViewModel
{
    public class VMSale_Base_ReOrderReason_List : VMList
    {
        public VMSale_Base_ReOrderReason_List()
            : base("KeyCode", "Sale_Base_ReOrderReason")
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("SN");
        }
    }
}
