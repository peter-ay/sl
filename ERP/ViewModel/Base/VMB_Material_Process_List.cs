
namespace ERP.ViewModel
{
    public class VMB_Material_Process_List : VMList
    {
        public VMB_Material_Process_List()
            : base("ProCode", "B_Material_Process", "proCode", "proName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            //base.PrepareDDsInfoListSorts();
            this.DDsInfoList.AddDefaultSorts("ProClass");
        }
    }
}
