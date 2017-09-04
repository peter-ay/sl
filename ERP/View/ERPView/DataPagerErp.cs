using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class DataPagerErp : DataPager
    {
        public DataPagerErp()
        {
            this.FontFamily = new System.Windows.Media.FontFamily("Verdana");
            this.FontSize = 13;
            this.PageSize = 100;
            var binding = new Binding("DContextList");
            this.SetBinding(DataPagerErp.SourceProperty, binding);
        }
    }

    public class DataPagerErp2 : DataPager
    {
        public DataPagerErp2()
        {
            this.FontFamily = new System.Windows.Media.FontFamily("Verdana");
            this.FontSize = 13;
            this.PageSize = 100;
            var binding = new Binding("DContextList2");
            this.SetBinding(DataPagerErp2.SourceProperty, binding);
        }
    }

    public class DataPagerErpSub : DataPager
    {
        public DataPagerErpSub()
        {
            this.FontFamily = new System.Windows.Media.FontFamily("Verdana");
            this.FontSize = 13;
            this.PageSize = 100;
            var binding = new Binding("DContextSub");
            this.SetBinding(DataPagerErpSub.SourceProperty, binding);
        }
    }
}
