using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_B_Warehouse
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
       SelectedBillCode = this.WhCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        } 

        public string DeptCodeList
        {
            get
            {
                return this.DpCode == "" ? "" : this.DpCode + ":" + this.DpName.UIStr();
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
            this.WhCode = "";
            this.WhName = "";
            this.WhAddress = "";
            this.DpCode = "";
            this.Tel = "";
            this.ManageMan = "";
            this.F_Stop = false;
            this.Remark = "";
            this.DpName = "";
        }

        partial void OnDpCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpDpCode.UHV_B_Department
                        where c.DpCode == this.DpCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DpName = "";
            else
                this.DpName = item.DpName;
        }

    }
}
