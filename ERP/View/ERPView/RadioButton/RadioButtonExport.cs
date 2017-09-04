
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonExportALL : RadioButtonErp
    {
        public RadioButtonExportALL()
            : base("", "Ex", ErpUIText.Get("ERP_All"), "CmdRBCdiExport", "-1")
        {
        }
    }

    public class RadioButtonExport : RadioButtonErp
    {
        public RadioButtonExport()
            : base("", "Ex", ErpUIText.Get("ERP_YDao"), "CmdRBCdiExport", "1")
        {
        }
    }

    public class RadioButtonUnExport : RadioButtonErp
    {
        public RadioButtonUnExport()
            : base("", "Ex", ErpUIText.Get("ERP_WDao"), "CmdRBCdiExport", "0")
        {
        }
    }
}
