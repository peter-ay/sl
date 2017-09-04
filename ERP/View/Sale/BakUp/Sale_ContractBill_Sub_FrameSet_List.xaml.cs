

using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public partial class Sale_ContractBill_Sub_FrameSet_List : ChildWindowErp
    {
        public Sale_ContractBill_Sub_FrameSet_List()
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

