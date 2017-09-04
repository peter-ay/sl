
namespace ERP.ViewModel
{
    public class VMB_Supplier_List : VMList
    {
        public VMB_Supplier_List()
            : base("SpCode", "B_Supplier", "spCode", "spName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        } 
    }
}
