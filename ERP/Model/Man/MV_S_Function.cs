using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    public partial class V_S_Function
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
                       SelectedBillCode = this.FunCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        private List<V_S_Function> _Children = new List<V_S_Function>();
        public List<V_S_Function> Children
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

        private string _Msg;
        public string Msg
        {
            get { return _Msg; }
            set
            {
                _Msg = value;
                this.RaisePropertyChanged("Msg");
            }
        }


        private string _FunNameUI;
        public string FunNameUI
        {
            get
            {
                _FunNameUI = this.FunName.UIStr();
                return _FunNameUI;
            }
            set
            {
                _FunNameUI = value;
                this.RaisePropertyChanged("FunNameUI");
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
