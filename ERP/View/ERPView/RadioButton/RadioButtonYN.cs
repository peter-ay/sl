
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonYNALL : RadioButtonErp
    {
        public RadioButtonYNALL()
            : base("IsEnableYN", "YN", ErpUIText.Get("ERP_YNAll"), "CmdRBCdiYN", "0")
        {
        }
    }

    public class RadioButtonYN : RadioButtonErp
    {
        public RadioButtonYN()
            : base("IsEnableYN", "YN", ErpUIText.Get("ERP_YN"), "CmdRBCdiYN", "1")
        {
        }
    }

    public class RadioButtonUnYN : RadioButtonErp
    {
        public RadioButtonUnYN()
            : base("IsEnableYN", "YN", ErpUIText.Get("ERP_UnYN"), "CmdRBCdiYN", "2")
        {
        }
    }
}
