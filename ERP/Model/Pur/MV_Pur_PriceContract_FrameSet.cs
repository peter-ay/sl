using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.ViewModel;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Pur_PriceContract_FrameSet
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

        //public string EditUI
        //{
        //    get
        //    {
        //        return ErpUIText.Get("ERP_Edit");
        //    }
        //    set
        //    {

        //    }
        //}

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
            this.FrameCode = "";
            this.FQty = 1;
            this.LensCode = "";
            this.LQty = 2;
            this.Price = 0;
            this.Price_ProCost = 0; 
            this.InvTitle = "";
        }

        partial void OnFrameCodeChanged()
        {
            if (this.EditState != 1) return;

            var item = (from c in ComHelpFrameCode.UHV_B_Material_Frame
                        where c.FrameCode.MyStr() == this.FrameCode.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
                this.InvTitle = item.FrameName;
        }

    }
}
