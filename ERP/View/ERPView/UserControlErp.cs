using System.Windows.Controls;
using ERP.Common;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Data;

namespace ERP.View
{
    public class UserControlErp : UserControl
    {
        public UserControlErp()
        {
            this.InitMessages();
            this.InitEvents();
            this.InitProperty();
            this.InitStyle();
        }

        private void InitStyle()
        {
            var bdFF = new Binding("UIText[ERP_Font]");
            this.SetBinding(ChildWindow.FontFamilyProperty, bdFF);
            var bdFS = new Binding("UIText[ERP_FontSize]");
            this.SetBinding(ChildWindow.FontSizeProperty, bdFS);
        }

        private void InitProperty()
        {

        }

        private void InitEvents()
        {
            ComAddViewMethods.Add(this);
            this.LayoutUpdated += new System.EventHandler(UserControlErp_LayoutUpdated);
        }

        void UserControlErp_LayoutUpdated(object sender, System.EventArgs e)
        {
            Messenger.Default.Send<double>(this.ActualHeight, "VM" + this.GetType().Name + "_ActualHeight");
        }

        private void InitMessages()
        {

        }
    }
}
