
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonIOTypeALL : RadioButtonErp
    {
        public RadioButtonIOTypeALL()
            : base("", "IOType", ErpUIText.Get("ERP_RadioButtonIOTypeALL"), "CmdRBCdiIOType", "-1")
        {
            this.SetIsCheck("IsCheckIOTypeALL");
        }
    }

    public class RadioButtonIOTypeIn : RadioButtonErp
    {
        public RadioButtonIOTypeIn()
            : base("IsEnableIOType", "IOType", ErpUIText.Get("ERP_RadioButtonIOTypeIn"), "CmdRBCdiIOType", "1")
        {
            this.SetIsCheck("IsCheckIOTypeIn");
        }
    }

    public class RadioButtonIOTypeOut : RadioButtonErp
    {
        public RadioButtonIOTypeOut()
            : base("IsEnableIOType", "IOType", ErpUIText.Get("ERP_RadioButtonIOTypeOut"), "CmdRBCdiIOType", "0")
        {
            this.SetIsCheck("IsCheckIOTypeOut");
        }
    }

}
