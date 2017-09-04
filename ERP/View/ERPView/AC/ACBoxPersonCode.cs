using ERP.Common;

namespace ERP.View
{
    public class ACBoxPersonCode : ACBoxErp
    {
        public ACBoxPersonCode()
            : base("PersonCode", "ACDataTemplatePersonCode", "DContextMain.PersonCode")
        {
            this.ItemsSource = ComHelpPersonCode.UHV_B_Person;
        }
    }

}
