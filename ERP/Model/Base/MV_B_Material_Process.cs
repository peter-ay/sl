using System;
using System.Linq;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.Web.Entity
{
    partial class V_B_Material_Process
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
       SelectedBillCode = this.ProCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        }

        //private string _ProClassList;
        //public string ProClassList
        //{
        //    set
        //    {
        //        this._ProClassList = value;
        //        this.RaisePropertyChanged("ProClassList");
        //    }
        //    get
        //    {
        //        return this.ProClass == "" ? "" : this.ProClass + ":" + this.ProClassName.UIStr();
        //    }
        //}

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

        private string _ProClassNameUI;
        public string ProClassNameUI
        {
            set
            {
                this._ProClassNameUI = value;
                this.RaisePropertyChanged("ProClassNameUI");
            }
            get
            {
                return ProClassName.UIStr();
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
            this.ProCode = "";
            this.ProName = "";
            this.ProClass = "";
            this.ProClassNameUI = "";
            this.F_RX = false;
            this.F_ST = false;
        }

        partial void OnProClassChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpProCode.UHV_B_Material_ProcessClass
                        where c.KeyCode.MyStr() == this.ProClass.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
            {
                this.ProClassName = "";
                this.ProClassNameUI = "";
            }
            else
            {
                this.ProClassName = item.KeyNameUI;
                this.ProClassNameUI = item.KeyNameUI;
            }
        }

    }
}
