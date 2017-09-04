using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Sale_PriceContract
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

        public string CusGroupList
        {
            get
            {
                return this.CusGroup + ":" + this.CusGpName;
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
            this.BType = "XSPC";
            this.PriCode = 1;
            this.StCode = "DSH";
            this.CusGroup = "";
            this.GpNameNew = "";
            this.EndDate = DateTime.Now.AddYears(2);
            this.Maker = USysInfo.UserCode;
            this.Remark = "";
            this.StName = ErpUIText.Get("ERP_New");
        }

        partial void OnCusGroupChanged()
        {
            if (this.EditState != 1) return;

            var item = (from c in ComHelpCusGroup.UHV_Sale_PriceContract_CusGroup
                        where c.GpCode.MyStr() == this.CusGroup.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
                this.CusGpName = item.GpName;
        }

    }
}
