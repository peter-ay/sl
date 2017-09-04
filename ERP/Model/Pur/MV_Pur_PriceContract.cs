using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Pur_PriceContract
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
                        SelectedBillCode = this.ID,
                        VMName = this.GetType().Name.Substring(2)
                    }, USysMessages.UpdateSelectedCode);
            }
        }

        public string StNameUI
        {
            get
            {
                return this.StName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("StNameUI");
            }
        }

        public string PriNameUI
        {
            get
            {
                return this.PriName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("PriNameUI");
            }
        }

        public string SpGroupList
        {
            get
            {
                return this.SpGroup + ":" + this.SpGpName;
            }
        }

        partial void OnStNameChanged()
        {
            this.StNameUI = "";
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
            this.EditState = 1;
            this.BegDate = DateTime.Now;
            this.Checker = "";
            this.BCode = "";
            this.OBCode = "";
            this.BDate = DateTime.Now;
            this.BType = "CGPC";
            this.PriCode = 1;
            this.StCode = "DSH";
            this.SpGroup = "";
            this.GpNameNew = "";
            this.EndDate = DateTime.Now.AddYears(2);
            this.Maker = USysInfo.UserCode;
            this.Remark = "";
            this.StName = ErpUIText.Get("ERP_New");
        }

        partial void OnSpGroupChanged()
        {
            if (this.EditState != 1) return;

            var item = (from c in ComHelpSpGroup.UHV_Pur_PriceContract_SpGroup
                        where c.GpCode.MyStr() == this.SpGroup.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
                this.SpGpName = item.GpName;
        }

    }
}
