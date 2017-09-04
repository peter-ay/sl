using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace ERP.Web.Entity
{
    partial class V_B_Accessory
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
       SelectedBillCode = this.AccessoryCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        }

        public string FrameNameUI
        {
            get
            {
                return this.AccessoryName.UIStr();
            }
        }

        partial void OnCreated()
        {
            this.AccessoryCode = "";
            this.AccessoryName = "";
            this.P1 = "";
            this.P2 = "";
            this.P3 = "";
            this.P4 = "";
            this.P5 = "";
            this.P6 = "";
            this.P7 = "";
            this.P8 = "";
            this.P9 = "";
            this.P10 = "";
            this.Remark = "";
            this.AccessoryType = "";
        }
    }
}
