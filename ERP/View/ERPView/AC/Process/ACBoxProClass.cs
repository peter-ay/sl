using ERP.Common;

namespace ERP.View
{
    public class ACBoxProClass : ACBoxErp
    {
        public ACBoxProClass()
            : base("KeyCode", "ACDataTemplateProClass", "DContextMain.ProClass")
        {
            this.ItemsSource = ComHelpProCode.UHV_B_Material_ProcessClass;
        }
    }
}
