using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public abstract partial class VMBill : VMErp
    {
        #region property

        private bool flag_Next = false;
        private bool flag_Previous = false;
        private bool _IsAddGpID = false;

        #endregion

        public VMBill(string idCode, string modelName = "", bool isAddGpID = false)
            : base()
        {
            this.IDCode = idCode;
            this.ModelName = modelName;
            this._IsAddGpID = isAddGpID;
            this.InitMessage();
        }

        #region Methods

        private void InitMessage()
        {
            Messenger.Default.Register<string>(this, this.VMName + "_NewFromList", (msg) =>
            {
                this.ExecuteCmdNew();
            });
            Messenger.Default.Register<string>(this, this.VMName + "_ShowFromList", (msg) =>
            {
                this.LoadBill(msg);
            });
            Messenger.Default.Register<string>(this, USysMessages.KeyCodeEnter, (msg) =>
            {
                this.CallKeyCodeEnter(msg);
            });
        }

        #endregion

    }
}
