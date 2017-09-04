
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonOG1 : RadioButtonErp
    {
        public RadioButtonOG1()
            : base("IsEnableOG", "Og", ErpUIText.Get("ERP_RadioButtonOG1"), "CmdRBCdiOG", "1")
        {
            this.SetIsCheck("IsCheckOG1");
        }
    }

    public class RadioButtonOG2 : RadioButtonErp
    {
        public RadioButtonOG2()
            : base("IsEnableOG", "Og", ErpUIText.Get("ERP_RadioButtonOG2"), "CmdRBCdiOG", "2")
        {
            this.SetIsCheck("IsCheckOG2");
        }
    }

    public class RadioButtonOGALL : RadioButtonErp
    {
        public RadioButtonOGALL()
            : base("", "Og", ErpUIText.Get("ERP_RadioButtonOGALL"), "CmdRBCdiOG", "-1")
        {
            this.SetIsCheck("IsCheckOGALL");
        }
    }

    //public class RadioButtonOG : RadioButtonErp
    //{
    //    public RadioButtonOG()
    //        : base("", "Og", ErpUIText.Get("ERP_Y"), "CmdRBCdiOG", "1")
    //    {
    //    }
    //}

    //public class RadioButtonUnOG : RadioButtonErp
    //{
    //    public RadioButtonUnOG()
    //        : base("", "Og", ErpUIText.Get("ERP_N"), "CmdRBCdiOG", "0")
    //    {
    //    }
    //}
}
