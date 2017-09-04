using ERP.Common;

namespace ERP.View
{
    public class ACBoxForeignCurrCode : ACBoxErp
    {
        public ACBoxForeignCurrCode()
            : base("ForeignCurrCode", "ACDataTemplateForeignCurrCode", "DContextMain.ForeignCurrCode")
        {
            this.ItemsSource = ComHelpForeignCurrCode.UHV_B_ForeignCurrency;
        }
    }

    public class ACBoxForeignCurrCodeList : ACBoxErp
    {
        public ACBoxForeignCurrCodeList()
            : base("ForeignCurrCode", "ACDataTemplateForeignCurrCode", "ForeignCurrCode")
        {
            this.ItemsSource = ComHelpForeignCurrCode.UHV_B_ForeignCurrency;
            //this.SetInList();
        }
    }
}
