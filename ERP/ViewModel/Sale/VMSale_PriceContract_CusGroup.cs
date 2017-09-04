
using GalaSoft.MvvmLight.Command;
using ERP.Common;
using ERP.Web.Entity;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMSale_PriceContract_CusGroup : VMBill
    {
        private V_Sale_PriceContract_CusGroup _DC
        {
            get
            {
                return this.DContextMain as V_Sale_PriceContract_CusGroup;
            }
        }

        public VMSale_PriceContract_CusGroup()
            : base("GpCode", "Sale_PriceContract_CusGroup")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        {
            if (string.IsNullOrEmpty(_DC.GpCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusGroupNull"));
                return false;
            }
            return true;
        }

        private RelayCommand _CmdEditPriceContractCusCode;
        /// <summary>
        /// Gets the CmdEditPriceContractCusCode.
        /// </summary>
        public RelayCommand CmdEditPriceContractCusCode
        {
            get
            {
                return _CmdEditPriceContractCusCode ?? (_CmdEditPriceContractCusCode = new RelayCommand(ExecuteCmdEditPriceContractCusCode));
            }
        }

        private void ExecuteCmdEditPriceContractCusCode()
        {
            //if (!CanExecuteCmdEditPriceContractCusCode())
            //{
            //    return;
            //}

            this.AssignNewWin();
        }

        private void AssignNewWin(string fCode = "Sale_PriceContract_CusCode", string vName = "")
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
