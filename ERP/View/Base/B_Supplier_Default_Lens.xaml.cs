
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public partial class B_Supplier_Default_Lens : ChildWindowErp
    {
        public B_Supplier_Default_Lens()
        {
            InitializeComponent();
        }

        protected override void InitTitle()
        {
            this.ClearValue(ChildWindow.TitleProperty);
            var bindingTitle = new Binding("Title");
            this.SetBinding(ChildWindow.TitleProperty, bindingTitle);
        }
    }
}

