
using ERP.Web.Entity;
using ERP.View;
using ERP.Utility;
namespace ERP.ViewModel
{
    public class VMB_Warehouse : VMBill
    {
        private V_B_Warehouse _DC
        {
            get
            {
                return this.DContextMain as V_B_Warehouse;
            }
        }

        public VMB_Warehouse()
            : base("WhCode", "B_Warehouse")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        {
            if (string.IsNullOrEmpty(_DC.WhCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_WhCodeNull"));
                return false;
            }

            return true;
        }

        protected override void FixEditACBug()
        {
            this._DC.DpCode = " " + this._DC.DpCode;
            this._DC.DpCode = this._DC.DpCode.Trim();
        }
    }
}
