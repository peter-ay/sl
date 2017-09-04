
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonBarCodeScanALL : RadioButtonErp
    {
        public RadioButtonBarCodeScanALL()
            : base("", "De", ErpUIText.Get("ERP_All"), "CmdRBCdiBarCodeScan", "-1")
        {
        }
    }

    public class RadioButtonBarCodeScan : RadioButtonErp
    {
        public RadioButtonBarCodeScan()
            : base("", "De", ErpUIText.Get("ERP_YS"), "CmdRBCdiBarCodeScan", "1")
        {
        }
    }

    public class RadioButtonUnBarCodeScan : RadioButtonErp
    {
        public RadioButtonUnBarCodeScan()
            : base("", "De", ErpUIText.Get("ERP_WS"), "CmdRBCdiBarCodeScan", "0")
        {
        }
    }
}
