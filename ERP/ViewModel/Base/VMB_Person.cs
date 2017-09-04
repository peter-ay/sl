
using ERP.Web.Entity;
using ERP.Utility;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMB_Person : VMBill
    {
        private V_B_Person _DC
        {
            get
            {
                return this.DContextMain as V_B_Person;
            }
        }

        public VMB_Person()
            : base("PersonCode", "B_Person")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        { 

            if (string.IsNullOrEmpty(_DC.PersonCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_PersonCodeNull"));
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
