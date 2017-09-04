
using ERP.Behavior;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.View
{
    public class TBReadOnlyMain : TextBoxErp
    {
        public TBReadOnlyMain()
            : base()
        {
            this.Width = 0;
            this.Height = 0;
            var bd = new System.Windows.Data.Binding("IsReadOnlyMain");
            this.SetBinding(TextBoxErp.IsReadOnlyProperty, bd);
        }
    }
}
