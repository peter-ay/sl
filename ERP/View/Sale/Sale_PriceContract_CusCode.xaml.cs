
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public partial class Sale_PriceContract_CusCode : ChildWindowErp
    {
        public Sale_PriceContract_CusCode()
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

