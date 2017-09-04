using System;

namespace ERP.Web.Entity
{
    public partial class V_U_ProcessClass
    {
        public string KeyNameUI
        {
            get
            {
                return this.KeyName.UIStr();
            }
        }

    }
}
