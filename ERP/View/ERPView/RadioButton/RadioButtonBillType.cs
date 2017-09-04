
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonBillTypeALL : RadioButtonErp
    {
        public RadioButtonBillTypeALL()
            : base("", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeALL"), "CmdRBCdiBillType", "")
        {
        }
    }

    public class RadioButtonBillTypeXSSD : RadioButtonErp
    {
        public RadioButtonBillTypeXSSD()
            : base("IsEnableBillType", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSSD"), "CmdRBCdiBillType", "XSSD")
        {
            this.SetIsCheck("IsCheckBillTypeXSSD");
        }
    }

    public class RadioButtonBillTypeXSCD : RadioButtonErp
    {
        public RadioButtonBillTypeXSCD()
            : base("IsEnableBillType", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSCD"), "CmdRBCdiBillType", "XSCD")
        {
            this.SetIsCheck("IsCheckBillTypeXSCD");
        }
    }

    public class RadioButtonBillTypeXSPD : RadioButtonErp
    {
        public RadioButtonBillTypeXSPD()
            : base("IsEnableBillType", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSPD"), "CmdRBCdiBillType", "XSPD")
        {
            this.SetIsCheck("IsCheckBillTypeXSPD");
        }
    }

    public class RadioButtonBillTypeXSFD : RadioButtonErp
    {
        public RadioButtonBillTypeXSFD()
            : base("IsEnableBillType", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSFD"), "CmdRBCdiBillType", "XSFD")
        {
            this.SetIsCheck("IsCheckBillTypeXSFD");
        }
    }

    public class RadioButtonBillTypeXSFS : RadioButtonErp
    {
        public RadioButtonBillTypeXSFS()
            : base("IsEnableBillType", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSFS"), "CmdRBCdiBillType", "XSFS")
        {
            this.SetIsCheck("IsCheckBillTypeXSFS");
        }
    }

    //报损
    public class RadioButtonBillTypeXSBS : RadioButtonErp
    {
        public RadioButtonBillTypeXSBS()
            : base("", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSBS"), "CmdRBCdiBillType", "XSBS")
        {
        }
    }

    //售後
    public class RadioButtonBillTypeXSSH : RadioButtonErp
    {
        public RadioButtonBillTypeXSSH()
            : base("", "Billtype", ErpUIText.Get("ERP_RadioButtonBillTypeXSSH"), "FRBCdiBillType", "XSSH")
        {
        }
    }

}
