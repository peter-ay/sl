
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonCXNone : RadioButtonErp
    {
        public RadioButtonCXNone()
            : base("IsEnableCX", "Cx", ErpUIText.Get("ERP_CXNone"), "CmdRBCdiCX", "1")
        {
            this.SetIsCheck("IsCheckCXNone");
        }
    }

    public class RadioButtonCXLJ : RadioButtonErp
    {
        public RadioButtonCXLJ()
            : base("IsEnableCX", "Cx", ErpUIText.Get("ERP_CXLJ"), "CmdRBCdiCX", "2")
        {
            this.SetIsCheck("IsCheckCXLJ");
        }
    }

    public class RadioButtonCXFLJ : RadioButtonErp
    {
        public RadioButtonCXFLJ()
            : base("IsEnableCX", "Cx", ErpUIText.Get("ERP_CXFLJ"), "CmdRBCdiCX", "3")
        {
            this.SetIsCheck("IsCheckCXFLJ");
        }
    }

    public class RadioButtonCXALL : RadioButtonErp
    {
        public RadioButtonCXALL()
            : base("", "Cx", ErpUIText.Get("ERP_All"), "CmdRBCdiCX", "-1")
        {
        }
    }

    public class RadioButtonCX : RadioButtonErp
    {
        public RadioButtonCX()
            : base("", "Cx", ErpUIText.Get("ERP_Y"), "CmdRBCdiCX", "1")
        {
        }
    }

    public class RadioButtonUnCX : RadioButtonErp
    {
        public RadioButtonUnCX()
            : base("", "Cx", ErpUIText.Get("ERP_N"), "CmdRBCdiCX", "0")
        {
        }
    }
}
