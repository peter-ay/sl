using ERP.Common;

namespace ERP.View
{
    public class ACBoxDpCode : ACBoxErp
    {
        public ACBoxDpCode()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCode")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_Department;
        }
    }

    public class ACBoxDpCodeCX : ACBoxErp
    {
        public ACBoxDpCodeCX()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCodeCX")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_DepartmentCX;
        }
    }

    public class ACBoxDpCodeList : ACBoxErp
    {
        public ACBoxDpCodeList()
            : base("DpCode", "ACDataTemplateDpCode", "DpCode")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_Department;
            //this.SetInList();
        }
    }

    public class ACBoxDpCodeBrowseRight : ACBoxErp
    {
        public ACBoxDpCodeBrowseRight()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCode")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_DepartmentRightBrowse;
        }
    }

    public class ACBoxDpCodeBrowseRightWG : ACBoxErp
    {
        public ACBoxDpCodeBrowseRightWG()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCodeWG")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_DepartmentRightBrowse;
        }
    }

    public class ACBoxDpCodeBrowseRightJG : ACBoxErp
    {
        public ACBoxDpCodeBrowseRightJG()
            : base("DpCode", "ACDataTemplateDpCode", "DContextMain.DpCodeJG")
        {
            this.ItemsSource = ComHelpDpCode.UHV_B_DepartmentRightBrowseCX;
        }
    }
}
