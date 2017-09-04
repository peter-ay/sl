using System.Windows.Media;
using ERP.Common;

namespace ERP.View
{
    public class ComBoxGroup : ComBoxErp
    {
        public ComBoxGroup()
            : base("Template_Group")
        {
            this.FontFamily = (FontFamily)App.Current.Resources["FFV"];
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.ItemsSource = ComHelpGpCode.UHV_S_UserGroup;
        }
    }

    public class ComBoxGroupByDataBase : ComBoxErp
    {
        public ComBoxGroupByDataBase()
            : base("Template_Group")
        {
            this.FontFamily = (FontFamily)App.Current.Resources["FFV"];
            this.FontSize = (double)App.Current.Resources["FSV"];
            this.ItemsSource = ComHelpGpCode.UHV_S_UserGroupByDataBase;
        }
    }
}
