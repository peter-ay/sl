using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_B_LensRough
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
       SelectedBillCode = this.RCode,
       VMName = this.GetType().Name.Substring(2)
   }, USysMessages.UpdateSelectedCode);
            }
        }

        private string _TypeNameUI = "";
        public string TypeNameUI
        {
            get
            {
                return this.TypeName.UIStr();
            }
            set
            {
                this._TypeNameUI = value;
                this.RaisePropertyChanged("TypeNameUI");
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
            this.RCode = "";
            this.RName = "";
            this.SPH1 = 0;
            this.SPH2 = 0;
            this.CYL1 = 0;
            this.CYL2 = 0;
            this.ADD1 = 0;
            this.ADD2 = 0;
            this.F_Stop = false;
            this.F_LR = false;
            this.F_CA = false;
        }


    }
}
