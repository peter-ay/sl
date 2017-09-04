
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.View
{
    /// <summary>
    /// Description for ErpLogin.
    /// </summary>
    public partial class Login : UserControlErp
    {
        /// <summary>
        /// Initializes a new instance of the ErpLogin class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, USysMessages.UserLogined, (msg) =>
            {
                this.LayoutRoot.Children.Clear();
                this.LayoutRoot.Children.Add(new MainPage());
            });
        }
    }
}