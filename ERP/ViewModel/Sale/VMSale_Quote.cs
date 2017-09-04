
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
using ERP.Web.DomainService.Bill;
using ERP.Web.Model;
using System.Windows;
namespace ERP.ViewModel
{
    public class VMSale_Quote : VMBill
    {
        #region property

        private V_Sale_Quote _DC
        {
            get
            {
                return this.DContextMain as V_Sale_Quote;
            }
        }

        #region IsShowProcess
        private Visibility _IsShowACProcessCF = Visibility.Visible;
        public Visibility IsShowACProcessCF
        {
            get { return _IsShowACProcessCF; }
            set
            {
                _IsShowACProcessCF = value;
                RaisePropertyChanged("IsShowACProcessCF");
            }
        }

        private Visibility _IsShowACProcessKF = Visibility.Collapsed;
        public Visibility IsShowACProcessKF
        {
            get { return _IsShowACProcessKF; }
            set
            {
                _IsShowACProcessKF = value;
                RaisePropertyChanged("IsShowACProcessKF");
            }
        }
        #endregion

        #endregion

        public VMSale_Quote()
            : base("ID", "Sale_Quote")
        {
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<bool>(this, USysMessages.QuoteProcessUpdate, (msg) =>
            {
                if (msg)
                {
                    this.IsShowACProcessCF = Visibility.Visible;
                    this.IsShowACProcessKF = Visibility.Collapsed;
                }
                else
                {
                    this.IsShowACProcessCF = Visibility.Collapsed;
                    this.IsShowACProcessKF = Visibility.Visible;
                }
            });
        }

        protected override void OnReturnMsgEnd(string hKeyCode)
        {
            if (hKeyCode == "CusCode")
                this.IsFocusMain = true;
        }

        protected override void OnReturnNoMsgEnd(string hKeyCode)
        {
            if (hKeyCode == "CusCode")
                this.IsFocusMain = true;
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsReadOnlyMain = false;
            this.IsReadOnlyEdit = false;

            this.ResetACIsVisibility(true);
            this.ResetHBIsVisibility(true);

            switch (uBillState)
            {
                case UBillState.View:

                    break;
                case UBillState.Drop:

                    break;
                case UBillState.New:

                    //UResetProcess.Set(true);
                    this.IsFocusReturn = true;
                    break;
                case UBillState.Edit:

                    break;
            }
        }

        #region methods

        protected override void FixEditACBug()
        {
            this._DC.CusCode = " " + this._DC.CusCode;
            this._DC.CusCode = this._DC.CusCode.Trim();
            ///////////////////////////////////////////
            this._DC.LensCode = " " + this._DC.LensCode;
            this._DC.LensCode = this._DC.LensCode.Trim();
            ///////////////////////////////////////////////
            ////////////////////////////////////////////////////
            this._DC.D1 = " " + this._DC.D1;
            this._DC.D1 = this._DC.D1.Trim();
            this._DC.D3 = " " + this._DC.D3;
            this._DC.D3 = this._DC.D3.Trim();
            this._DC.P1 = " " + this._DC.P1;
            this._DC.P1 = this._DC.P1.Trim();
            this._DC.P3 = " " + this._DC.P3;
            this._DC.P3 = this._DC.P3.Trim();
            //////////////////////////////////////////////////////////
            this._DC.BASE = " " + this._DC.BASE;
            this._DC.BASE = this._DC.BASE.Trim();
            ////////////////////////////////////////////////////////////
            this._DC.JJ = " " + this._DC.JJ;
            this._DC.JJ = this._DC.JJ.Trim();
            this._DC.CS = " " + this._DC.CS;
            this._DC.CS = this._DC.CS.Trim();
            this._DC.RS = " " + this._DC.RS;
            this._DC.RS = this._DC.RS.Trim();
            this._DC.RSName = " " + this._DC.RSName;
            this._DC.RSName = this._DC.RSName.Trim();
            this._DC.JS = " " + this._DC.JS;
            this._DC.JS = this._DC.JS.Trim();
            this._DC.SY = " " + this._DC.SY;
            this._DC.SY = this._DC.SY.Trim();
            this._DC.ZK = " " + this._DC.ZK;
            this._DC.ZK = this._DC.ZK.Trim();
            this._DC.OP = " " + this._DC.OP;
            this._DC.OP = this._DC.OP.Trim();
            this._DC.CB = " " + this._DC.CB;
            this._DC.CB = this._DC.CB.Trim();
            this._DC.PG = " " + this._DC.PG;
            this._DC.PG = this._DC.PG.Trim();
            this._DC.KK = " " + this._DC.KK;
            this._DC.KK = this._DC.KK.Trim();
            this._DC.ChB = " " + this._DC.ChB;
            this._DC.ChB = this._DC.ChB.Trim();
            this._DC.PiH = " " + this._DC.PiH;
            this._DC.PiH = this._DC.PiH.Trim();
        }

        protected override void PrepareModelToSave()
        {
            var _Model = this.CurrentModel as MSale_Quote;
            _Model.Sub_SD = new MSale_Quote_SD();
            _Model.Sub_SD_Process = new MSale_Quote_SD_Process();
            ComCopyProperties.Copy(_Model, _DC);
            ComCopyProperties.Copy(_Model.Sub_SD, _DC);
            ComCopyProperties.Copy(_Model.Sub_SD_Process, _DC);
        }

        protected override bool CanExecuteCmdSave()
        {
            return true;
        }

        protected override void Quote()
        {
            this.Save();
        }

        protected override void OnSaveCompleted(System.ServiceModel.DomainServices.Client.InvokeOperation<string> geted)
        {
            this.ResetResult();
            base.OnSaveCompleted(geted);
        }

        private void ResetResult()
        {
            this._DC.Price = 0;
            this._DC.PriceJM = 0;
            this._DC.ProCost = 0;
            this._DC.ProReport = "";
            this._DC.ProCostReport = "";
            this._DC.BCodePC = "";
        }

        protected override void OnLoadMainEndRetSetDContextMain(System.ServiceModel.DomainServices.Client.Entity item)
        {
            V_Sale_Quote _Item = item as V_Sale_Quote;
            this._DC.CusCode = _Item.CusCode;
            this._DC.LensCode = _Item.LensCode;
            this._DC.Price = _Item.Price;
            this._DC.PriceJM = _Item.PriceJM;
            this._DC.ProCost = _Item.ProCost;
            this._DC.ProReport = _Item.ProReport;
            this._DC.ProCostReport = _Item.ProCostReport;
            this._DC.BCodePC = _Item.BCodePC;
        }

        #endregion

    }
}
