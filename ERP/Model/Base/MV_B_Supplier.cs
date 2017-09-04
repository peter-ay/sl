using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_B_Supplier
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
                Messenger.Default.Send<USelectedBillCodes>(
   new USelectedBillCodes()
   {
       IsAdd = value,
       SelectedBillCode = this.SpCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
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

        public string AreaCodeList
        {
            get
            {
                return this.AreaCode == "" ? "" : this.AreaCode + ":" + this.AreaName.UIStr();
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

        partial void OnCreated()
        {
            this.SpCode = "";
            this.SpName = "";
            this.AreaCode = "";
            this.AreaName = "";
            this.SpAddress = "";
            this.Email = "";
            this.Fax = "";
            this.ContactPerson = "";
            this.Phone = "";
            this.F_Stop = false;
            this.F_Semifinished = false;
            this.F_Garages = false;
            this.F_Cutting_Type = false;
            this.F_Stock = false;
            this.F_Comprehensive = false;
            this.Default_Priority = 1;
        }

        partial void OnAreaCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpAreaCode.UHV_B_Area
                        where c.AreaCode == this.AreaCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.AreaName = "";
            else
                this.AreaName = item.AreaName;
        }

    }
}
