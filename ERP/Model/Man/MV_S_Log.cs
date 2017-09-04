using System;

namespace ERP.Web.Entity
{
    public partial class V_S_Log
    {
        public string DBNameUI
        {
            get
            {
                return this.DBName.UIStr();
            }
        }

        public string FunNameUI
        {
            get
            {
                return this.FunName.UIStr();
            }
        }

    }
}
