
namespace ERP.ViewModel
{
    public class VMB_Material_Frame_List : VMList
    {
        public VMB_Material_Frame_List()
            : base("FrameCode", "B_Material_Frame", "frameCode", "frameName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        } 
    }
}
