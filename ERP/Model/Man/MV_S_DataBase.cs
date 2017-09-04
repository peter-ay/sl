using System;

namespace ERP.Web.Entity
{
    public partial class V_S_DataBase
    {
        public string DBNameUI
        {
            get
            {
                return this.DBName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("DBNameUI");
            }
        }

        partial void OnDBNameChanged()
        {
            this.DBNameUI = "";
        }
    }
}
