
namespace ERP.ViewModel
{
    public class VMB_Warehouse_List : VMList
    {
        public VMB_Warehouse_List()
            : base("WhCode", "B_Warehouse", "whCode", "whName")
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }
    }
}
