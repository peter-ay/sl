
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMB_Material_Lens_List : VMList
    {
        public VMB_Material_Lens_List()
            : base("LensCode", "B_Material_Lens", "lenscode", "lensName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Material_Lens_GeneralList";
        }

        protected override void Export()
        {
            //base.Export();
            ComExport.Export(this.VMNameAuthority.Replace("_List", ""), " LensLevel=1");
        }

        protected override void Import()
        {
            //base.Import();
            ComImport.Import("B_Material_Lens1");
        }
    }
}
