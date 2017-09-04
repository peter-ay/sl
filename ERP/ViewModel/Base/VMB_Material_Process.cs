
using ERP.Web.Entity;
using ERP.Utility;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMB_Material_Process : VMBill
    {
        private V_B_Material_Process _DC
        {
            get
            {
                return this.DContextMain as V_B_Material_Process;
            }
        }

        public VMB_Material_Process()
            : base("ProCode", "B_Material_Process")
        {
            this.IsChildWindow = true;
        }

        protected override bool VerifySave()
        {

            if (string.IsNullOrEmpty(_DC.ProCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_ProCodeNull"));
                return false;
            }

            return true;
        }

        protected override void FixEditACBug()
        {
            this._DC.ProClass = " " + this._DC.ProClass;
            this._DC.ProClass = this._DC.ProClass.Trim();
        }

    }
}
