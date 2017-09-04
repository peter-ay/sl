
namespace ERP.ViewModel
{
    public class VMSale_Base_Note_List : VMList
    {
        public VMSale_Base_Note_List()
            : base("KeyCode", "Sale_Base_Note")
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
