
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonUDAll : RadioButtonErp
    {
        public RadioButtonUDAll()
            : base("IsEnableUD", "UD", ErpUIText.Get("ERP_RadioButtonUDAll"), "CmdRBUDCheck", "-1")
        {
            this.SetIsCheck("IsCheckUD0");
        }

    }
    public class RadioButtonUD1 : RadioButtonErp
    {
        public RadioButtonUD1()
            : base("IsEnableUD", "UD", ErpUIText.Get("ERP_RadioButtonUD1"), "CmdRBUDCheck", "1")
        {
            this.SetIsCheck("IsCheckUD1");
        }
    }

    public class RadioButtonUD2 : RadioButtonErp
    {
        public RadioButtonUD2()
            : base("IsEnableUD", "UD", ErpUIText.Get("ERP_RadioButtonUD2"), "CmdRBUDCheck", "2")
        {
            this.SetIsCheck("IsCheckUD2");
        }
    }

    public class RadioButtonUD3 : RadioButtonErp
    {
        public RadioButtonUD3()
            : base("IsEnableUD", "UD", ErpUIText.Get("ERP_RadioButtonUD3"), "CmdRBUDCheck", "3")
        {
            this.SetIsCheck("IsCheckUD3");
        }
    }
}
