
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonRTypeN : RadioButtonErp
    {
        public RadioButtonRTypeN()
            : base("IsEnableRType", "RT", ErpUIText.Get("ERP_RadioButtonRTypeN"), "CmdRBCdiRType", "N")
        {
            base.SetIsCheck("IsCheckRTypeN");
        }
    }

    public class RadioButtonRTypeRX : RadioButtonErp
    {
        public RadioButtonRTypeRX()
            : base("IsEnableRType", "RT", ErpUIText.Get("ERP_RadioButtonRTypeRX"), "CmdRBCdiRType", "RX")
        {
            base.SetIsCheck("IsCheckRTypeRX");
        }
    }

    public class RadioButtonRTypeST : RadioButtonErp
    {
        public RadioButtonRTypeST()
            : base("IsEnableRType", "RT", ErpUIText.Get("ERP_RadioButtonRTypeST"), "CmdRBCdiRType", "ST")
        {
            base.SetIsCheck("IsCheckRTypeST");
        }
    }
}
