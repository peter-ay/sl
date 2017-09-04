using ERP.Common;

namespace ERP.View
{
    public class ACBoxWhCodeBrowseRight : ACBoxErp
    {
        public ACBoxWhCodeBrowseRight()
            : base("WhCode", "ACDataTemplateWhCode", "DContextMain.WhCode")
        {
            this.ItemsSource = ComHelpWhCode.UHV_B_Warehouse_Browse;
        }
    }
}
