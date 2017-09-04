
namespace ERP.ViewModel
{
    public class VMB_Customer_List : VMList
    {
        public VMB_Customer_List()
            : base("CusCode", "B_Customer", "cusCode", "cusName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }
    }
}
