using ERP.Common;

namespace ERP.View
{
    public class ACBoxAreaCode : ACBoxErp
    {
        public ACBoxAreaCode()
            : base("AreaCode", "ACDataTemplateAreaCode", "DContextMain.AreaCode")
        {
            this.ItemsSource = ComHelpAreaCode.UHV_B_Area;
        }
    }

    //public class ACBoxAreaCodeList : ACBoxErp
    //{
    //    public ACBoxAreaCodeList()
    //        : base("AreaCode", "ACDataTemplateAreaCode", "AreaCode")
    //    {
    //        this.ItemsSource = ComHelpAreaCode.UHV_B_ForeignCurrency;
    //        //this.SetInList();
    //    }
    //}
}
