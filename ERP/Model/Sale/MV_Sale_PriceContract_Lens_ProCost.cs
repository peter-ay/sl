using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.ViewModel;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Sale_PriceContract_Lens_ProCost
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
            this.ID = "";
            this.BID = "";
            this.LensCode = "";
            this.F_Set = false;
            this.JY = false;
            this.UV = false;
            this.JS = "";
            this.RS = "";
            this.CS = "";
            this.SY = "";
            this.CB = "";
            this.ChB = "";
            this.KK = "";
            this.ZK = "";
            this.PiH = "";
            this.PG = "";
            this.JJ = "";
            this.OP = "";
            this.P1 = 0;
            this.P2 = 0;
            this.P1JM = 0;
            this.P2JM = 0;
            this.InvTitle = "";
        }

        partial void OnLensCodeChanged()
        {
            if (this.EditState != 1) return;

            var item = (from c in ComHelpLensCode.UHV_B_Material_LensSmart
                        where c.LensCode.MyStr() == this.LensCode.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
                this.InvTitle = item.LensName;
        }

        partial void OnP1Changed()
        {
            if (this.EditState != 1) return;
            try
            {
                this.P2 = P1.Value * 2;
            }
            catch { }
        }

        partial void OnP1JMChanged()
        {
            if (this.EditState != 1) return;
            try
            {
                this.P2JM = P1JM.Value * 2;
            }
            catch { }
        }

    }
}
