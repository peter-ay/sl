
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonCheckALL : RadioButtonErp
    {
        public RadioButtonCheckALL()
            : base("", "Ch", ErpUIText.Get("ERP_RadioButtonCheckALL"), "CmdRBCdiCheck", "-1")
        {
        }
    }

    public class RadioButtonCheck : RadioButtonErp
    {
        public RadioButtonCheck()
            : base("", "Ch", ErpUIText.Get("ERP_RadioButtonCheck"), "CmdRBCdiCheck", "1")
        {
        }
    }

    public class RadioButtonUnCheck : RadioButtonErp
    {
        public RadioButtonUnCheck()
            : base("", "Ch", ErpUIText.Get("ERP_RadioButtonUnCheck"), "CmdRBCdiCheck", "0")
        {
        }
    }

    //In
    public class RadioButtonCheckALLIn : RadioButtonErp
    {
        public RadioButtonCheckALLIn()
            : base("", "ChIn", ErpUIText.Get("ERP_RadioButtonCheckALL"), "CmdRBCdiCheckIn", "-1")
        {
        }
    }

    public class RadioButtonCheckIn : RadioButtonErp
    {
        public RadioButtonCheckIn()
            : base("", "ChIn", ErpUIText.Get("ERP_RadioButtonCheck"), "CmdRBCdiCheckIn", "1")
        {
        }
    }

    public class RadioButtonUnCheckIn : RadioButtonErp
    {
        public RadioButtonUnCheckIn()
            : base("", "ChIn", ErpUIText.Get("ERP_RadioButtonUnCheck"), "CmdRBCdiCheckIn", "0")
        {
        }
    }

    //Out
    public class RadioButtonCheckALLOut : RadioButtonErp
    {
        public RadioButtonCheckALLOut()
            : base("", "ChOut", ErpUIText.Get("ERP_RadioButtonCheckALL"), "CmdRBCdiCheckOut", "-1")
        {
        }
    }

    public class RadioButtonCheckOut : RadioButtonErp
    {
        public RadioButtonCheckOut()
            : base("", "ChOut", ErpUIText.Get("ERP_RadioButtonCheck"), "CmdRBCdiCheckOut", "1")
        {
        }
    }

    public class RadioButtonUnCheckOut : RadioButtonErp
    {
        public RadioButtonUnCheckOut()
            : base("", "ChOut", ErpUIText.Get("ERP_RadioButtonUnCheck"), "CmdRBCdiCheckOut", "0")
        {
        }
    }
}
