using System;
using GalaSoft.MvvmLight.Messaging;
using ERP.Utility;

namespace ERP.Web.Entity
{
    public partial class V_S_User_GroupDataBase
    {
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
                Messenger.Default.Send<USelectedBillCodes>(
                   new USelectedBillCodes()
                   {
                       IsAdd = value,
                       SelectedBillCode = this.UserCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        public string DBNameUI
        {
            get
            {
                return this.DBName.UIStr();
            }
        }

        public string GpNameUI
        {
            get
            {
                return this.GpName.UIStr();
            }
        }

        private string msg;
        public string Msg
        {
            get { return msg; }
            set
            {
                msg = value;
                this.RaisePropertyChanged("Msg");
            }
        } 
    }
}
