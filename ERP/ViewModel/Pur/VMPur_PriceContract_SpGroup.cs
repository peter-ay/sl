
using GalaSoft.MvvmLight.Command;
using ERP.Common;
using ERP.Web.Entity;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMPur_PriceContract_SpGroup : VMBill
    {
        private V_Pur_PriceContract_SpGroup _DC
        {
            get
            {
                return this.DContextMain as V_Pur_PriceContract_SpGroup;
            }
        }

        public VMPur_PriceContract_SpGroup()
            : base("GpCode", "Pur_PriceContract_SpGroup")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        {
            if (string.IsNullOrEmpty(_DC.GpCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_SpGroupNull"));
                return false;
            }
            return true;
        }

        private RelayCommand _CmdEditPriceContractSpCode;
        /// <summary>
        /// Gets the CmdEditPriceContractSpCode.
        /// </summary>
        public RelayCommand CmdEditPriceContractSpCode
        {
            get
            {
                return _CmdEditPriceContractSpCode ?? (_CmdEditPriceContractSpCode = new RelayCommand(ExecuteCmdEditPriceContractSpCode));
            }
        }

        private void ExecuteCmdEditPriceContractSpCode()
        {
            //if (!CanExecuteCmdEditPriceContractSpCode())
            //{
            //    return;
            //}

            this.AssignNewWin();
        }

        private void AssignNewWin(string fCode = "Pur_PriceContract_SpCode", string vName = "")
        {
            if (this._DC == null || string.IsNullOrEmpty(this._DC.GpCode)) return;

            if (vName == "")
            {
                vName = ErpUIText.Get(fCode);
            }
            var _sCode = "" + "||" + this._DC.GpCode + "||" + this._DC.GpName;
            ComAssignWins.Assign(_sCode, fCode, vName);
        }
    }
}
