using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Ware_Bill_SO_Pre_SD
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

        public string StNameUI
        {
            get
            {
                return this.StName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("StNameUI");
            }
        }

        partial void OnStNameChanged()
        {
            this.StNameUI = "";
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

        partial void OnLensCodeRChanged()
        {
            if (EditState != 1) return;
            this.LensNameR = "";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(it => it.LensCode.MyStr() == this.LensCodeR.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameR = _Rs.LensName;
        }

        partial void OnLensCodeLChanged()
        {
            if (EditState != 1) return;
            this.LensNameL = "";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(it => it.LensCode.MyStr() == this.LensCodeL.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameL = _Rs.LensName;
        }

        partial void OnWhCodeChanged()
        {
            if (EditState != 1) return;
            this.WhName = "";
            var _Rs = ComHelpWhCode.UHV_B_Warehouse.Where(it => it.WhCode.MyStr() == this.WhCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.WhName = _Rs.WhName;
        }

    }
}
