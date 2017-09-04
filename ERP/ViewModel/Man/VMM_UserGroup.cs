
using ERP.Web.Entity;
using ERP.Utility;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMM_UserGroup : VMBill
    {
        private V_S_UserGroup _DC
        {
            get
            {
                return this.DContextMain as V_S_UserGroup;
            }
        }

        public VMM_UserGroup()
            : base("GpCode", "S_UserGroup")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        {

            if (string.IsNullOrEmpty(_DC.GpCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_GpCodeNull"));
                return false;
            }

            return true;
        }


        protected override void FixEditACBug()
        {
            this._DC.DBCode = " " + this._DC.DBCode;
            this._DC.DBCode = this._DC.DBCode.Trim();
        }

    }
}
