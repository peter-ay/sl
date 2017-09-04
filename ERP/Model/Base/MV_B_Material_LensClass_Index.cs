using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    partial class V_B_Material_LensClass_Index
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
                       SelectedBillCode = this.KeyCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        partial void OnCreated()
        {
            this.KeyCode = "";
            this.KeyName = "";
            this.SN = 1;
        }

    }
}
