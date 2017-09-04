
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonPCP1 : RadioButtonErp
    {
        public RadioButtonPCP1()
            : base("IsEnablePCP", "PCP", ErpUIText.Get("ERP_RadioButtonPCP1"), "CmdRBPCPCheck", "1")
        {
            this.SetIsCheck("IsCheckPCP1");
        }
    }

    public class RadioButtonPCP2 : RadioButtonErp
    {
        public RadioButtonPCP2()
            : base("IsEnablePCP", "PCP", ErpUIText.Get("ERP_RadioButtonPCP2"), "CmdRBPCPCheck", "2")
        {
            this.SetIsCheck("IsCheckPCP2");
        }
    }

    public class RadioButtonPCP3 : RadioButtonErp
    {
        public RadioButtonPCP3()
            : base("IsEnablePCP", "PCP", ErpUIText.Get("ERP_RadioButtonPCP3"), "CmdRBPCPCheck", "3")
        {
            this.SetIsCheck("IsCheckPCP3");
        }
    }

    public class RadioButtonPCP4 : RadioButtonErp
    {
        public RadioButtonPCP4()
            : base("IsEnablePCP", "PCP", ErpUIText.Get("ERP_RadioButtonPCP4"), "CmdRBPCPCheck", "4")
        {
            this.SetIsCheck("IsCheckPCP4");
        }
    }
}
