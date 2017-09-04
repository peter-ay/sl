
using System.Windows.Controls;
using System.Windows.Data;
namespace ERP.View
{
    public partial class M_GroupUserAssign : ChildWindowErp
    {
        public M_GroupUserAssign()
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

