
using ERP.ViewModel;
namespace ERP.View
{
    public class MenuItemFile : MenuItemErp
    {
        public MenuItemFile()
            : base(ErpUIText.Get("ERP_File"))
        {

        }
    }

    public class MenuItemOthers : MenuItemErp
    {
        public MenuItemOthers()
            : base(ErpUIText.Get("ERP_Other"))
        {

        }
    }

    public class MenuItemTools : MenuItemErp
    {
        public MenuItemTools()
            : base(ErpUIText.Get("ERP_Tool"))
        {

        }
    }
}
