
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonIncludeALL : RadioButtonErp
    {
        public RadioButtonIncludeALL()
            : base("", "Ic", ErpUIText.Get("ERP_RadioButtonIncludeAll"), "CmdRBCdiInclude", "-1")
        {
        }
    }

    public class RadioButtonInclude : RadioButtonErp
    {
        public RadioButtonInclude()
            : base("", "Ic", ErpUIText.Get("ERP_RadioButtonIncludeYF"), "CmdRBCdiInclude", "1")
        {
        }
    }

    public class RadioButtonUnclude : RadioButtonErp
    {
        public RadioButtonUnclude()
            : base("", "Ic", ErpUIText.Get("ERP_RadioButtonIncludeWF"), "CmdRBCdiInclude", "0")
        {
        }
    }
}
