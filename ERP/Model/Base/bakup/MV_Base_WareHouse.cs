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

        public string WhNameUI
        {
            get
            {
                return this.WhName.UIStr();
            }
        }

        public string AddressUI
        {
            get
            {
                return this.Address.UIStr();
            }
        }

        public string DeptCodeList
        {
            get
            {
                return this.DeptCode == "" ? "" : this.DeptCode + ":" + this.DpName.UIStr();
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
            this.Address = "";
            this.DeptCode = "";
            this.Phone = "";
            this.ManageMan = "";
            this.F_Stop = false;
            this.Remark = "";
            this.DpName = "";
        }

        partial void OnDeptCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpV_B_Department.UHV_B_Department
                        where c.DpCode == this.DeptCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DpName = "";
            else
                this.DpName = item.DpName;
        }

    }
}
