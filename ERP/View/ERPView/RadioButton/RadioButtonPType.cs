
using ERP.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public class RadioButtonPType1 : RadioButtonErp
    {
        public RadioButtonPType1()
            : base("IsEnablePType", "PT", ErpUIText.Get("ERP_RadioButtonPType1"), "CmdRBCdiPType", "1")
        {
            this.SetIsCheck("IsCheckPType1");
        }
    }

    public class RadioButtonPType2 : RadioButtonErp
    {
        public RadioButtonPType2()
            : base("IsEnablePType", "PT", ErpUIText.Get("ERP_RadioButtonPType2"), "CmdRBCdiPType", "2")
        {
            this.SetIsCheck("IsCheckPType2");
        }
    }
}
