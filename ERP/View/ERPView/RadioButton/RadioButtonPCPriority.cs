
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonPCPri0 : RadioButtonErp
    {
        public RadioButtonPCPri0()
            : base("IsEnablePCPri", "PCPri", ErpUIText.Get("ERP_PCPri0"), "CmdRBPCPriCheck", "0")
        {
            this.SetIsCheck("IsCheckPCPri0");
        }
    }

    public class RadioButtonPCPri1 : RadioButtonErp
    {
        public RadioButtonPCPri1()
            : base("IsEnablePCPri", "PCPri", ErpUIText.Get("ERP_PCPri1"), "CmdRBPCPriCheck", "1")
        {
            this.SetIsCheck("IsCheckPCPri1");
        }
    }

    public class RadioButtonPCPri2 : RadioButtonErp
    {
        public RadioButtonPCPri2()
            : base("IsEnablePCPri", "PCPri", ErpUIText.Get("ERP_PCPri2"), "CmdRBPCPriCheck", "2")
        {
            this.SetIsCheck("IsCheckPCPri2");
        }
    }

    public class RadioButtonPCPri3 : RadioButtonErp
    {
        public RadioButtonPCPri3()
            : base("IsEnablePCPri", "PCPri", ErpUIText.Get("ERP_PCPri3"), "CmdRBPCPriCheck", "3")
        {
            this.SetIsCheck("IsCheckPCPri3");
        }
    }

    public class RadioButtonPCPri4 : RadioButtonErp
    {
        public RadioButtonPCPri4()
            : base("IsEnablePCPri", "PCPri", ErpUIText.Get("ERP_PCPri4"), "CmdRBPCPriCheck", "4")
        {
            this.SetIsCheck("IsCheckPCPri4");
        }
    }
}
