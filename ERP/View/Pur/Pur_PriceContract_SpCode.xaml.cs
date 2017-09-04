
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public partial class Pur_PriceContract_SpCode : ChildWindowErp
    {
        public Pur_PriceContract_SpCode()
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

