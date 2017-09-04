using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    partial class V_B_Area
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
                       SelectedBillCode = this.AreaCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        //private string _AreaNameUI = "";
        //public string AreaNameUI
        //{
        //    get
        //    {
        //        return this.AreaName.UIStr();
        //    }
        //    set
        //    {
        //        this._AreaNameUI = value;
        //        this.RaisePropertyChanged("AreaNameUI");
        //    }
        //}

        partial void OnCreated()
        {
            this.AreaCode = "";
            this.AreaName = "";
            this.PCode = "";
        }

        private List<V_B_Area> _Children = new List<V_B_Area>();
        public List<V_B_Area> Children
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
    }
}
