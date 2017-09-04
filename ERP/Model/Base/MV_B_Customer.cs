using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    public partial class V_B_Customer
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
                       SelectedBillCode = this.CusCode,
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

        private string _PersonCodeList;
        public string PersonCodeList
        {
            set
            {
                this._PersonCodeList = value;
                this.RaisePropertyChanged("PersonCodeList");
            }
            get
            {
                return this.PersonCode == "" ? "" : this.PersonCode + ":" + this.PersonName.UIStr();
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
            CusCode = "";
            PCode = "";
            BarCode = "";
            CusName = "";
            CusAddress = "";
            DAddress = "";
            AreaCode = "";
            DpCode = "";
            DpCodeCX = "";
            PersonCode = "";
            Tel = "";
            ContactPerson = "";
            F_Stop = false;
            F_NoticeRepeatOBill = true;
            DpName = "";
            PersonName = "";
            AreaName = "";
            Fax = "";
            Email = "";
            PrintCode = "";
            PrintShowPriceType = 0;
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

        partial void OnDpCodeCXChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpDpCode.UHV_B_Department
                        where c.DpCode.MyStr() == this.DpCodeCX.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DpNameCX = "";
            else
                this.DpNameCX = item.DpName;
        }

        partial void OnAreaCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpAreaCode.UHV_B_Area
                        where c.AreaCode.MyStr() == this.AreaCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.AreaName = "";
            else
                this.AreaName = item.AreaName;
        }

        partial void OnPersonCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpPersonCode.UHV_B_Person
                        where c.PersonCode.MyStr() == this.PersonCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.PersonName = "";
            else
                this.PersonName = item.PersonName;
        }

    }

}
