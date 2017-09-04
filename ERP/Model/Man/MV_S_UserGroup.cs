using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.Common;
using System.Linq;
namespace ERP.Web.Entity
{
    public partial class V_S_UserGroup
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
                       SelectedBillCode = this.GpCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        private int _EditState = 0;
        public int EditState
        {
            get { return _EditState; }
            set
            {
                _EditState = value;
                this.RaisePropertyChanged("EditState");
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

        partial void OnCreated()
        {
            this.GpCode = "";
            this.GpName = "";
            this.DBCode = "";
            this.GpExplain = "";
            this.GpID = -1;
            this.F_RBCusCode = false;
            this.F_RBWhCode = false;
            this.F_RUWhCode = false;
            this.F_RBSpCode = false;
            this.F_RBDpCode = false;
        }

        partial void OnDBNameChanged()
        {
            this.DBNameUI = "";
        }

        partial void OnDBCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpDBCode.UHV_S_DataBase
                        where c.DBCode == this.DBCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DBName = "";
            else
                this.DBName = item.DBNameUI;
        }
    }
}
