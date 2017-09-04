using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ChildWindowErp : ChildWindow
    {
        private string _ViewName;
        private bool _IsMainID;
        private bool _IsInitButton = false;

        public ChildWindowErp()
        {
            _ViewName = this.GetType().Name;
            this.MyInit();
        }

        private void MyInit()
        {
            this.InitStyle();
            this.InitMessages();
            this.InitEvents();
            this.InitTitle();
        }

        protected virtual void InitTitle()
        {
            var bindingTitle = new Binding("UIText[" + this._ViewName + "_Title" + "]");
            this.SetBinding(ChildWindow.TitleProperty, bindingTitle);
        }

        public ChildWindowErp(string _viewname = "", bool isMainid = false)
        {
            if (!string.IsNullOrEmpty(_viewname))
                _ViewName = _viewname;
            else
                _ViewName = this.GetType().Name;

            _IsMainID = isMainid;
            this.MyInit();
        }

        protected override void OnOpened()
        {
            base.OnOpened();
            HtmlPage.Plugin.Focus();
            var tb = this.FindName("TB_Falg_RO") as TextBox;
            if (tb != null) tb.Focus();
            if (_IsMainID)
            {
                tb = this.FindName("TB_Falg_ID") as TextBox;
                if (tb != null) tb.Focus();
            }
            /////////////////////////
            if (!_IsInitButton)
            {
                try
                {
                    var bt1 = this.FindName("Btn_OK") as ButtonErp;
                    var bt2 = this.FindName("Btn_Cancel") as ButtonErp;
                    ComAddViewMethods.AddChildWindowDefaultButtonMethod(bt1, bt2);
                    _IsInitButton = true;
                }
                catch { }
            }
        }

        private void InitStyle()
        {
            this.Style = App.Current.Resources["ChildWindowStyle"] as Style;
            this.HasCloseButton = false;
            var bdFF = new Binding("UIText[ERP_Font]");
            this.SetBinding(ChildWindow.FontFamilyProperty, bdFF);
            var bdFS = new Binding("UIText[ERP_FontSize]");
            this.SetBinding(ChildWindow.FontSizeProperty, bdFS);
            //
        }

        private void InitEvents()
        {
            ComAddViewMethods.Add(this);
            ////////////////////////////////////////////////////////////////
            this.LayoutUpdated += new System.EventHandler(ChildWindowErp_LayoutUpdated);
        }

        void ChildWindowErp_LayoutUpdated(object sender, System.EventArgs e)
        {
            Messenger.Default.Send<double>(this.ActualHeight, "VM" + this.GetType().Name + "_ActualHeight");
        }

        private void InitMessages()
        {
            ///////////////////////////////////////////////////////////////////////////////////////// 
            Messenger.Default.Register<string>(this, USysMessages.GridEnter, (msg) =>
            {
                if (!this.RenderSize.IsEmpty && !this.RenderSize.Equals(new Size() { Height = 0, Width = 0 }) && this._ViewName.StartsWith("CH_"))
                    Messenger.Default.Send<bool>(true, _ViewName + "_Result");
            });
            ///////////////////////////////////////////////////////////////////////////////////////// 
            Messenger.Default.Register<bool>(this, _ViewName + "_Result", (msg) =>
            {
                if (this.RenderSize.IsEmpty || this.RenderSize.Equals(new Size() { Height = 0, Width = 0 })) return;
                this.DialogResult = msg;
                this.OnChildWindowClosed(msg);
                if (msg)
                {
                    TextBox stb = this.FindName("TB_SelectedItem") as TextBox;
                    if (stb == null) return;
                    Messenger.Default.Send<string>((stb.Text), _ViewName + "_Return");
                }
                else
                {
                    Messenger.Default.Send<string>("", _ViewName + "_ReturnNoMsg");
                }
            });
            ///////////////////////////////////////////////////////////////////////////////////////// 
            Messenger.Default.Register<string>(this, USysMessages.CloseChildWindow, (msg) =>
            {
                if (!this.RenderSize.IsEmpty && !this.RenderSize.Equals(new Size() { Height = 0, Width = 0 }))
                    Messenger.Default.Send<bool>(true, _ViewName + "_Result");
            });
        }

        protected virtual void OnChildWindowClosed(bool msg)
        {

        }
    }
}
