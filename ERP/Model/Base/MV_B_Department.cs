using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    partial class V_B_Department
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
       SelectedBillCode = this.DpCode,
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

        private List<V_B_Department> _Children = new List<V_B_Department>();
        public List<V_B_Department> Children
        {
            get
            {
                return _Children;
            }
            set
            {
                _Children = value;
                this.RaisePropertyChanged("Children");
            }
        }

        private bool _F_Explan = true;
        public bool F_Explan
        {
            get
            {
                return _F_Explan;
            }
            set
            {
                _F_Explan = value;
                this.RaisePropertyChanged("F_Explan");
            }
        }

        partial void OnCreated()
        {
            this.DpCode = "";
            this.DpName = "";
            this.PCode = "";
            this.DpProperty = "";
            this.Incharge = "";
            this.Tel = "";
            this.Remark = "";
            this.F_CX = false;
        }
    }
}
