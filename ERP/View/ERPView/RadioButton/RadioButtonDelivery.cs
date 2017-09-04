
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonDeliveryALL : RadioButtonErp
    {
        public RadioButtonDeliveryALL()
            : base("", "De", ErpUIText.Get("ERP_All"), "CmdRBCdiDelivery", "-1")
        {
        }
    }

    public class RadioButtonDelivery : RadioButtonErp
    {
        public RadioButtonDelivery()
            : base("", "De", ErpUIText.Get("ERP_RadioButtonDelivery_DN"), "CmdRBCdiDelivery", "1")
        {
        }
    }

    public class RadioButtonUnDelivery : RadioButtonErp
    {
        public RadioButtonUnDelivery()
            : base("", "De", ErpUIText.Get("ERP_RadioButtonDelivery_UnDN"), "CmdRBCdiDelivery", "0")
        {
        }
    }
}
