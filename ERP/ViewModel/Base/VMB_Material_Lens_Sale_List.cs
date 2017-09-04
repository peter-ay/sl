
using ERP.Common;
namespace ERP.ViewModel
{
    public class VMB_Material_Lens_Sale_List : VMList
    {
        public VMB_Material_Lens_Sale_List()
            : base("LensCode", "B_Material_Lens", "lenscode", "lensName", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return "GetV_B_Material_Lens_SaleList";
        }

        protected override string PrepareDeleteTableName()
        {
            return "B_Material_Lens";
        }

        protected override void Export()
        {
            //base.Export();
            ComExport.Export("B_Material_Lens", " LensLevel=2");
        }

        protected override void Import()
        {
            //base.Import();
            ComImport.Import("B_Material_Lens2");
        }
    }
}
