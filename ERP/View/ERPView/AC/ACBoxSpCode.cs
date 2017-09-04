using ERP.Common;

namespace ERP.View
{
    public class ACBoxSpCodeBrowseRight : ACBoxErp
    {
        public ACBoxSpCodeBrowseRight()
            : base("SpCode", "ACDataTemplateSpCode", "DContextMain.SpCode")
        {
            this.ItemsSource = ComHelpSpCode.UHV_B_Supplier;
        }
    }
}
