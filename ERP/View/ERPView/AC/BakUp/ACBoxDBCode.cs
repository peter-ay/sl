using ERP.Common;

namespace ERP.View
{
    public class ACBoxDBCode : ACBoxErp
    {
        public ACBoxDBCode()
            : base("DBCode", "ACDataTemplateDataBase", "DContextMain.DBCode")
        {
            this.ItemsSource = ComHelpV_S_DataBase.UHV_S_DataBase;
        }
    }

    public class ACBoxDBCodeList : ACBoxErp
    {
        public ACBoxDBCodeList()
            : base("DBCode", "ACDataTemplateDataBase", "DBCode", true)
        {
            this.ItemsSource = ComHelpV_S_DataBase.UHV_S_DataBase;
            this.SetInList();
        }
    }
}
