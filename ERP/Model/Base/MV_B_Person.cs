using System;
using System.Linq;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Web.Entity
{
    partial class V_B_Person
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
       SelectedBillCode = this.PersonCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        }

        private string _DpCodeList;
        public string DpCodeList
        {
            set
            {
                this._DpCodeList = value;
                this.RaisePropertyChanged("DpCodeList");
            }
            get
            {
                return this.DpCode == "" ? "" : this.DpCode + ":" + this.DpName.UIStr();
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
            this.PersonCode = "";
            this.PersonName = "";
            this.DpCode = "";
            this.PersonProperty = "";
            this.DpName = "";
        }

        partial void OnDpCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpDpCode.UHV_B_Department
                        where c.DpCode.MyStr() == this.DpCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DpName = "";
            else
                this.DpName = item.DpName;
        }

    }
}
