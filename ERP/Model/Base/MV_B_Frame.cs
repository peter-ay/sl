using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace ERP.Web.Entity
{
    partial class V_B_Material_Frame
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
                       SelectedBillCode = this.FrameCode,
                       VMName = this.GetType().Name.Substring(2)
                   }, USysMessages.UpdateSelectedCode);
            }
        }

        partial void OnCreated()
        {
            this.FrameCode = "";
            this.FrameName = "";
            this.Brand = "";
            this.Family = "";
            this.Material = "";
            this.Width = 0;
            this.Heigh = 0;
            this.Leg_Length = 0;
            this.Bridge = 0;
            this.Colour = "";
            this.Origin = "";
        }

    }
}
