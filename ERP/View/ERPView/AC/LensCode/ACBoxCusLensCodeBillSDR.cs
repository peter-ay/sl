using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;

namespace ERP.View
{
    public class ACBoxCusLensCodeBillSDR : ACBoxLensCodeBill
    {
        public ACBoxCusLensCodeBillSDR()
        {
            this.ClearValue(ACBoxErp.TextProperty);
            var bd = new Binding("DContextMain.LensCodeR")
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false
            };
            this.SetBinding(AutoCompleteBox.TextProperty, bd);
            //base.SetLostFocus("LensCodeR");
            //////////////////////////////////////////////////////////////////////////////////////////////////
            this.InitMessages();
            ///////////////
            this.ItemsSource = null;
            this.ItemsourceCount = 0;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeSDRTextUpdateBegin, (msg) =>
            {
                if (this.Text != null)
                    this._Text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeSDRTextUpdateEnd, (msg) =>
            {
                if (this.Text != null)
                    this.Text = this._Text;
                this.ItemsSource = ComHelpLensCode.UHV_B_CusLensCodeSmartSDR;
                this.ItemsourceCount = ComHelpLensCode.UHV_B_CusLensCodeSmartSDR.Count;
            });
        }
    }
}
