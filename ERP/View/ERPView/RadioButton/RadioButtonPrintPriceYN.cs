
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonPrintPriceY : RadioButtonErp
    {
        public RadioButtonPrintPriceY()
            : base("IsEnablePPYN", "PPYN", ErpUIText.Get("ERP_RadioButtonPrintPriceY"), "CmdRBCdiPPYN", "1")
        {
        }
    }

    public class RadioButtonPrintPriceN : RadioButtonErp
    {
        public RadioButtonPrintPriceN()
            : base("IsEnablePPYN", "PPYN", ErpUIText.Get("ERP_RadioButtonPrintPriceN"), "CmdRBCdiPPYN", "0")
        {
        }
    }
}
