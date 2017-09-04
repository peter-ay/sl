
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonLensTypeALL : RadioButtonErp
    {
        public RadioButtonLensTypeALL()
            : base("IsEnableLensType", "LT", ErpUIText.Get("ERP_RadioButtonLensTypeALL"), "CmdRBCdiLensType", "")
        {
            base.SetIsCheck("IsCheckLensTypeALL");
        }
    }

    public class RadioButtonLensTypeST : RadioButtonErp
    {
        public RadioButtonLensTypeST()
            : base("IsEnableLensType", "LT", ErpUIText.Get("ERP_RadioButtonLensTypeST"), "CmdRBCdiLensType", "ST")
        {
            base.SetIsCheck("IsCheckLensTypeST");
        }
    }

    public class RadioButtonLensTypeRX : RadioButtonErp
    {
        public RadioButtonLensTypeRX()
            : base("IsEnableLensType", "LT", ErpUIText.Get("ERP_RadioButtonLensTypeRX"), "CmdRBCdiLensType", "RX")
        {
            base.SetIsCheck("IsCheckLensTypeRX");
        }
    }

    public class RadioButtonLensTypeOT : RadioButtonErp
    {
        public RadioButtonLensTypeOT()
            : base("IsEnableLensType", "LT", ErpUIText.Get("ERP_RadioButtonLensTypeOT"), "CmdRBCdiLensType", "OT")
        {
            base.SetIsCheck("IsCheckLensTypeOT");
        }
    }
}
