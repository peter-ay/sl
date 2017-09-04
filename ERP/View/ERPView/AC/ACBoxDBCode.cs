using ERP.Common;

namespace ERP.View
{
    public class ACBoxDBCode : ACBoxErp
    {
        public ACBoxDBCode()
            : base("DBCode", "ACDataTemplateDataBase", "DContextMain.DBCode")
        {
            this.ItemsSource = ComHelpDBCode.UHV_S_DataBase;
        }
    }

    public class ACBoxDBCodeList : ACBoxErp
    {
        public ACBoxDBCodeList()
            : base("DBCode", "ACDataTemplateDataBase", "DBCode")
        {
            this.ItemsSource = ComHelpDBCode.UHV_S_DataBase;
            //this.SetInList();
        }
    }
}
