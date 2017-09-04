using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Sale_Rec_PD
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

        partial void OnCreated()
        {
            this.EditState = 1;
            ////////////////////////////////////////
            ID = "";
            BCode = "";
            BDate = System.DateTime.Now; ;
            BType = "XSRCPD";
            StCode = "DSH";
            StName = ErpUIText.Get("ERP_New");
            CusCode = "";
            Remark = "";
            Maker = USysInfo.UserCode;
            MName = "";
            Checker = "";
            ChName = "";
            LensCode = "";
            F_LR = "";
            BCodeSale = "";
            OBCodeSale = "";
            RemarkSale = "";
            NotesSale = "";
            CusName = "";
            LensName = "";
        }

        partial void OnLensCodeChanged()
        {
            if (EditState != 1) return;
            this.LensName = "";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(it => it.LensCode.MyStr() == this.LensCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensName = _Rs.LensName;
        }

    }
}
