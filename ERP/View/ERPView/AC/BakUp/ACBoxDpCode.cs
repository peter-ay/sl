using ERP.Common;

namespace ERP.View
{
    public class ACBoxDpCode : ACBoxErp
    {
        public ACBoxDpCode()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCode")
        {
            this.ItemsSource = ComHelpV_B_Department.UHV_B_Department;
        }
    }

    public class ACBoxDpCodeList : ACBoxErp
    {
        public ACBoxDpCodeList()
            : base("DpCode", "ACDataTemplateDpCode", "DpCode", true)
        {
            this.ItemsSource = ComHelpV_B_Department.UHV_B_Department;
            this.SetInList();
        }
    }
}
