
using ERP.Common;
using GalaSoft.MvvmLight.Messaging;
using ERP.Utility;
namespace ERP.View
{
    public class ACBoxCusFrameCodeBill : ACBoxFrameCodeBill
    {
        public ACBoxCusFrameCodeBill()
        {
            //this.ItemsSource = ComHelpFrameCode.UHV_B_CusFrameCode;
            //this._ItemsourceCount = ComHelpFrameCode.UHV_B_CusFrameCode.Count;
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.ACBoxFrameCodeTextUpdateBegin, (msg) =>
            {
                if (this.Text != null)
                    this._Text = this.Text.Trim();
            });
            Messenger.Default.Register<string>(this, USysMessages.ACBoxFrameCodeTextUpdateEnd, (msg) =>
            {
                if (this.Text != null)
                    this.Text = this._Text;
            });
        }
    }
}
