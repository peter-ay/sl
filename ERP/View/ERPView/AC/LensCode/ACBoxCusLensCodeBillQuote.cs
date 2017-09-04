using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.View
{
    public class ACBoxCusLensCodeBillQuote : ACBoxLensCodeBill
    {
        public ACBoxCusLensCodeBillQuote()
        {
            this.InitMessages();
            this.ItemsSource = null;
            this.ItemsourceCount = 0;
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeQuoteTextUpdateBegin, (msg) =>
            {
                if (this.Text != null)
                    this._Text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxLensCodeQuoteTextUpdateEnd, (msg) =>
            {
                if (this.Text != null)
                    this.Text = this._Text;
                this.ItemsSource = ComHelpLensCode.UHV_B_CusLensCodeSmartQuote;
                this.ItemsourceCount = ComHelpLensCode.UHV_B_CusLensCodeSmartQuote.Count;
            });
        }
    }
}
