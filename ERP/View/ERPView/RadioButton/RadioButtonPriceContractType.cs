
using ERP.ViewModel;
namespace ERP.View
{
    public class RadioButtonPriceContractTypeLens : RadioButtonErp
    {
        public RadioButtonPriceContractTypeLens()
            : base("IsEnablePriceContractType", "PCT", ErpUIText.Get("RadioButton_PriceContractTypeLens"), "CmdRBCdiPriceContractType", "1")
        {
            this.SetIsCheck("IsCheckPCTLens");
        }
    }

    public class RadioButtonPriceContractTypeFrame : RadioButtonErp
    {
        public RadioButtonPriceContractTypeFrame()
            : base("IsEnablePriceContractType", "PCT", ErpUIText.Get("RadioButton_PriceContractTypeFrame"), "CmdRBCdiPriceContractType", "2")
        {
            this.SetIsCheck("IsCheckPCTFrame");
        }
    }
}
