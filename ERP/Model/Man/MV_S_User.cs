using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Web.Entity
{
    public partial class V_S_User
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

        partial void OnCreated()
        {
            this.UserCode = "";
            this.UserName = "";
            this.UserPassword = "";
            this.UserExplain = "";
            this.F_Admin = false;
            this.F_Stop = false;
            this.F_Super = false;
            this.LastLoginDate = DateTime.Now;
            this.LoginDate = DateTime.Now;
            this.UserImage = "";
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
