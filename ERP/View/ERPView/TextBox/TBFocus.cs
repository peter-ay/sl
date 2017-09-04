
using ERP.Behavior;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.View
{
    public class TBFocusCycle : TextBoxErp
    {
        public TBFocusCycle()
            : base()
        {
            this.Width = 0;
            this.Height = 0;
            var bd = new System.Windows.Data.Binding("IsFocusReturn");
            this.SetBinding(BhFocusTBox.IsFocusedProperty, bd);
            this.GotFocus += (s1, e1) =>
            {
                Messenger.Default.Send<string>((""), USysMessages.ReturnFoucus);
            };
        }
    }

    public class TBFocusTabItem : TextBoxErp
    {
        public TBFocusTabItem()
            : base()
        {
            this.Width = 0;
            this.Height = 0;
            var bd = new System.Windows.Data.Binding("IsFocusTabItem");
            this.SetBinding(BhFocusTBox.IsFocusedProperty, bd);
            this.GotFocus += (s1, e1) =>
            {
                Messenger.Default.Send<string>((""), USysMessages.FocusTabItem);
            };
        }
    }

    public class TBFocusTabItemReturn : TextBoxErp
    {
        public TBFocusTabItemReturn()
            : base()
        {
            this.Width = 0;
            this.Height = 0;
            var bd = new System.Windows.Data.Binding("IsFocusTabItemReturn");
            this.SetBinding(BhFocusTBox.IsFocusedProperty, bd);
            this.GotFocus += (s1, e1) =>
            {
                Messenger.Default.Send<string>((""), USysMessages.ReturnTabItemFoucus);
            };
        }
    }
}
