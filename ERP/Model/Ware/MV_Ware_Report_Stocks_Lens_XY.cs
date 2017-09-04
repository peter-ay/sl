using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    partial class V_Ware_Report_Stocks_Lens_XY
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

        public string MsgLR
        {
            get
            {
                if (string.IsNullOrEmpty(this.F_LR))
                    return "";
                else
                    return "[" + this.F_LR + "]";
            }
        }

        public string MsgQty
        {
            get
            {
                return "[" + this.Qty.ToString() + "]";
            }
        }

        public string MsgShow
        {
            get
            {
                if (this.CodeLevel == 3)
                    return this.KeyName + this.MsgLR + this.MsgQty;
                else
                    return this.KeyCode + ":" + this.KeyName + this.MsgLR + this.MsgQty;
            }
        }

        private List<V_Ware_Report_Stocks_Lens_XY> _Children = new List<V_Ware_Report_Stocks_Lens_XY>();
        public List<V_Ware_Report_Stocks_Lens_XY> Children
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
