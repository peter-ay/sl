
using ERP.Utility;
using ERP.Common;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
namespace ERP.ViewModel
{
    public class VMB_Material_LensClass_Brand_List : VMList
    {
        public VMB_Material_LensClass_Brand_List()
            : base("SN", "B_Material_LensClass_Brand", isAutoRefresh: true)
        {
            this.IsShowExportBool = true;
            this.IsShowImportBool = true;
        }

        //protected override void Export()
        //{
        //    string _ID = "";
        //    var _Str = this.getExportWhereCondition(out _ID);
        //    ERP.Web.DomainService.Erp.DSErp _DS = new Web.DomainService.Erp.DSErp();

        //    var p = _DS.GetV_B_Material_LensClass_BrandListQuery(USysInfo.DBCode, _Str);
        //    _DS.Load(p, geted =>
        //    {
        //        if (geted.HasError)
        //        {
        //            MessageBox.Show(geted.Error.ToString());
        //            geted.MarkErrorAsHandled();
        //            return;
        //        }
        //        ComOpenURL.Open(_ID + ".xls");
        //    }, null);
        //}
    }
}
