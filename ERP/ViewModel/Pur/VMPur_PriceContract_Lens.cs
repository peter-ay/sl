
using GalaSoft.MvvmLight.Command;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMPur_PriceContract_Lens : VMBill
    {
        #region Property

        private string _BID;

        private V_Pur_PriceContract_Lens _DC
        {
            get
            {
                return this.DContextMain as V_Pur_PriceContract_Lens;
            }
        }

        #region ListShowDetail
        private string _BCode = "";
        public string BCode
        {
            get { return _BCode; }
            set { _BCode = value; RaisePropertyChanged("BCode"); }
        }

        private string _GpCode = "";
        public string GpCode
        {
            get { return _GpCode; }
            set { _GpCode = value; RaisePropertyChanged("GpCode"); }
        }

        private string _GpName = "";
        public string GpName
        {
            get { return _GpName; }
            set { _GpName = value; RaisePropertyChanged("GpName"); }
        }
        #endregion




        #endregion

        public VMPur_PriceContract_Lens()
            : base("LensCode", "Pur_PriceContract_Lens")
        {
            this.IsChildWindow = true;
            this.IsShowAC = System.Windows.Visibility.Visible;
            this.InitMessage();
        }

        private void InitMessage()
        {
            Messenger.Default.Register<string>(this, this.VMName + "_RefreshID", (msg) =>
            {
                this.RefreshID(msg);
            });
        }

        private void RefreshID(string msg)
        {
            var _Str = msg.Split(new string[] { "||" }, StringSplitOptions.None);
            this._BID = _Str[0].ToString();
            this.BCode = _Str[1].ToString();
            this.GpCode = _Str[2].ToString();
            this.GpName = _Str[3].ToString();
        }

        protected override bool VerifySave()
        {
            if (_DC.LensCode == "")
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_LensCodeNull"));
                return false;
            }

            return true;
        }

        protected override bool CanExecuteCmdSave()
        {
            return true;
        }

        protected override void OnSaveCompleted2(string id)
        {

        }

        protected override void PrepareModelToSave()
        {
            this._DC.BID = this._BID;
            base.PrepareModelToSave();
        }

    }
}
