
namespace ERP.ViewModel
{
    public class VMB_LensRough_List : VMList
    {
        public VMB_LensRough_List()
            : base("RCode", "B_LensRough", "rcode", "rName", isAutoRefresh: true)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }
    }
}
