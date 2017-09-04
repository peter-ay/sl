
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonOutGoodALL : RadioButtonErp
    {
        public RadioButtonOutGoodALL()
            : base("", "Og", ErpUIText.Get("ERP_All"), "CmdRBCdiOutGood", "-1")
        {
        }
    }

    public class RadioButtonOutGood : RadioButtonErp
    {
        public RadioButtonOutGood()
            : base("", "Og", ErpUIText.Get("ERP_BenDi"), "CmdRBCdiOutGood", "1")
        {
        }
    }

    public class RadioButtonUnOutGood : RadioButtonErp
    {
        public RadioButtonUnOutGood()
            : base("", "Og", ErpUIText.Get("ERP_WaiGou"), "CmdRBCdiOutGood", "0")
        {
        }
    }
}
