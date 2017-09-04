
using ERP.Utility;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMB_Customer : VMBill
    {
        #region Property
        private V_B_Customer _DC
        {
            get
            {
                return this.DContextMain as V_B_Customer;
            }
        }

        private bool _IsEnableYN = false;
        public bool IsEnableYN
        {
            get { return _IsEnableYN; }
            set { _IsEnableYN = value; RaisePropertyChanged("IsEnableYN"); }
        }


        #endregion

        public VMB_Customer()
            : base("CusCode", "B_Customer")
        {
            this.IsChildWindow = true;
        }

        #region Method

        protected override bool VerifySave()
        {

            if (string.IsNullOrEmpty(_DC.CusCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }

            return true;
        }

        protected override void ChangeBillSate(Utility.UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsEnableYN = false;
            switch (uBillState)
            {
                case UBillState.View:

                    break;

                case UBillState.New:
                    this.IsEnableYN = true;
                    this.IsCheckYNAll = true;
                    break;

                case UBillState.Edit:
                    this.IsEnableYN = true;
                    break;

                case UBillState.Drop:

                    break;

                default:
                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.AreaCode = " " + this._DC.AreaCode;
            this._DC.AreaCode = this._DC.AreaCode.Trim();

            this._DC.PersonCode = " " + this._DC.PersonCode;
            this._DC.PersonCode = this._DC.PersonCode.Trim();

            this._DC.DpCode = " " + this._DC.DpCode;
            this._DC.DpCode = this._DC.DpCode.Trim();
        }

        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            //var _DC = this.DContextMain as V_B_Customer;
            switch (_DC.PrintShowPriceType)
            {
                case 1:
                    this.IsCheckYN = true;
                    break;

                case 2:
                    this.IsCheckUnYN = true;
                    break;

                default:
                    this.IsCheckYNAll = true;
                    break;
            }
        }

        private RelayCommand<string> _CmdRBCdiYN;

        /// <summary>
        /// Gets the CmdRBCdiYN.
        /// </summary>
        public RelayCommand<string> CmdRBCdiYN
        {
            get
            {
                return _CmdRBCdiYN
                    ?? (_CmdRBCdiYN = new RelayCommand<string>(ExecuteCmdRBCdiYN));
            }
        }

        private void ExecuteCmdRBCdiYN(string parameter)
        {
            try
            {
                this._DC.PrintShowPriceType = System.Convert.ToByte(parameter);
            }
            catch { }
        }

        #endregion
    }
}
