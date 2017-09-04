
using ERP.Behavior;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.View
{
    public class TBReadOnlyEdit : TextBoxErp
    {
        public TBReadOnlyEdit()
            : base()
        {
            this.Width = 0;
            this.Height = 0;
            var bd = new System.Windows.Data.Binding("IsReadOnlyEdit");
            this.SetBinding(TextBoxErp.IsReadOnlyProperty, bd);
        }
    }
}
