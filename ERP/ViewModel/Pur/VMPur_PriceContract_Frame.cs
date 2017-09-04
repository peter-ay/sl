
using GalaSoft.MvvmLight.Command;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Messaging;
using System;
namespace ERP.ViewModel
{
    public class VMPur_PriceContract_Frame : VMBill
    {
        #region Property

        private string _BID;

        private V_Pur_PriceContract_Frame _DC
        {
            get
            {
                return this.DContextMain as V_Pur_PriceContract_Frame;
            }
        }

        #region ListShowDetail
        private string _BCode = "";
        public string BCode
        {
            get { return _BCode; }
            set { _BCode = value; RaisePropertyChanged("BCode"); }
        }

        private string _CusType = "";
        public string GpCode
        {
            get { return _CusType; }
            set { _CusType = value; RaisePropertyChanged("CusType"); }
        }

        private string _CusTypeName = "";
        public string GpName
        {
            get { return _CusTypeName; }
            set { _CusTypeName = value; RaisePropertyChanged("CusTypeName"); }
        }
        #endregion




        #endregion

        public VMPur_PriceContract_Frame()
            : base("FrameCode", "Pur_PriceContract_Frame")
        {
            this.IsChildWindow = true;
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
