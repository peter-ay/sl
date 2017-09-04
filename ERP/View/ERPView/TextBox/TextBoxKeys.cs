using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class TextBoxKeyCode : TextBoxErp
    {
        public TextBoxKeyCode()
            : base()
        {
            var binding = new Binding("SKeyCode") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.MaxLength = 30;
            var bindingf = new Binding("IsFocusMain") { Mode = BindingMode.OneWay };
            this.SetBinding(ERP.Behavior.BhFocusTBox.IsFocusedProperty, bindingf);
        }
    }

    public class TextBoxKeyCodeRO : TextBoxErp
    {
        public TextBoxKeyCodeRO()
            : base()
        {
            var binding = new Binding("SKeyCode") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.ReSetRO();
        }
    }

    public class TBKeyCode2 : TextBoxErp
    {
        public TBKeyCode2()
            : base()
        {
            var binding = new Binding("SKeyCode2") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.MaxLength = 30;
        }
    }



    public class TextBoxKeyName : TextBoxErp
    {
        public TextBoxKeyName()
            : base()
        {
            var binding = new Binding("SKeyName") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.MaxLength = 50;
        }
    }

    public class TextBoxKeyNameRO : TextBoxErp
    {
        public TextBoxKeyNameRO()
            : base()
        {
            var binding = new Binding("SKeyName") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.ReSetRO();
        }
    }

    public class TextBoxSelectItem : TextBoxErp
    {
        public TextBoxSelectItem()
            : base()
        {
            var binding = new Binding("SelectedItem") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.IsReadOnly = true;
        }
    }

    public class TBSelectItem2 : TextBoxErp
    {
        public TBSelectItem2()
            : base()
        {
            var binding = new Binding("SelectedItem2") { Mode = BindingMode.TwoWay };
            this.SetBinding(TextBox.TextProperty, binding);
            this.IsReadOnly = true;
        }
    }
}
