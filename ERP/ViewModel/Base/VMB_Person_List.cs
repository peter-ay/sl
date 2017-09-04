
namespace ERP.ViewModel
{
    public class VMB_Person_List : VMList
    {
        public VMB_Person_List()
            : base("PersonCode", "B_Person", "personCode", "personName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }
    }
}
