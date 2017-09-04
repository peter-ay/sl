
using ERP.ViewModel;
namespace ERP.View
{

    public class RBBtnExportModel1 : RadioButtonErp
    {
        public RBBtnExportModel1()
            : base("", "EM", ErpUIText.Get("ERP_RBBtnExportModel1"), "CmdRBExportModel", "1")
        {
        }
    }

    public class RBBtnExportModel2 : RadioButtonErp
    {
        public RBBtnExportModel2()
            : base("", "EM", ErpUIText.Get("ERP_RBBtnExportModel2"), "CmdRBExportModel", "2")
        {
        }
    }
}
