
namespace ERP.View
{
    public partial class LoginUserLogin : ChildWindowErp
    {
        public LoginUserLogin()
            : base(isMainid: true)
        {
            InitializeComponent();
        }

        protected override void InitTitle()
        {
            var bindingTitle = new System.Windows.Data.Binding("UIText[ERP_Title]");
            this.SetBinding(System.Windows.Controls.ChildWindow.TitleProperty, bindingTitle);
        }
    }
}

