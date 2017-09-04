
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonPrintBigFormatY : RadioButtonErp
    {
        public RadioButtonPrintBigFormatY()
            : base("IsEnablePPYN", "PBFYN", ErpUIText.Get("ERP_RadioButtonPrintBigFormatY"), "CmdRBCdiPPYN", "1")
        {
        }
    }

    public class RadioButtonPrintBigFormatN : RadioButtonErp
    {
        public RadioButtonPrintBigFormatN()
            : base("IsEnablePPYN", "PBFYN", ErpUIText.Get("ERP_RadioButtonPrintBigFormatN"), "CmdRBCdiPPYN", "0")
        {
        }
    }
}
