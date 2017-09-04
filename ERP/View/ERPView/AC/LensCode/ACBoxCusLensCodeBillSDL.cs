using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ACBoxCusLensCodeBillSDL : ACBoxLensCodeBill
    {
        public ACBoxCusLensCodeBillSDL()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.LensCodeL")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            this.InitMessages();
            base.SetGotFocus("LensCodeL");
            ///////////////
            this.ItemsSource = null;
            this.ItemsourceCount = 0;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeSDLTextUpdateBegin, (msg) =>
            {
                if (this.Text != null)
                    this._Text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeSDLTextUpdateEnd, (msg) =>
            {
                if (this.Text != null)
                    this.Text = this._Text;
                this.ItemsSource = ComHelpLensCode.UHV_B_CusLensCodeSmartSDL;
                this.ItemsourceCount = ComHelpLensCode.UHV_B_CusLensCodeSmartSDL.Count;
            });
        }
    }
}
