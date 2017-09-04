using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;
using System.Windows.Controls;

namespace ERP.Web.Entity
{
    partial class V_Sale_Order_PD
    {
        //private bool _IsNoticeForRepeat = false;
        private int _NoticeCount = 0;

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

        public string TypeNameUI
        {
            get
            {
                return this.TypeName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("TypeNameUI");
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

        partial void OnTypeNameChanged()
        {
            this.TypeNameUI = "";
        }

        partial void OnStNameChanged()
        {
            this.StNameUI = "";
        }

        private string _MyNotes;
        public string MyNotes
        {
            get { return _MyNotes; }
            set
            {
                _MyNotes = value;
                this.RaisePropertyChanged("MyNotes");
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
            //this._IsNoticeForRepeat = false;
            this._NoticeCount = 0;
            this.EditState = 1;
            ////////////////////////////////////////
            this.MyNotes = "";
            /////////////////////////////////
            this.ID = "";
            this.UD = 1;
            this.BCode = "";
            this.BDate = DateTime.Now;
            this.CsDate = DateTime.Now.AddDays(2);
            this.OBCode = "";
            this.CusCode = "";
            this.WhName = "";
            this.SpName = "";
            this.SpCode = "";
            this.BType = "XSPD";
            this.F_LR = "";
            this.StCode = "DSH";
            this.StName = ErpUIText.Get("ERP_New");
            this.Remark = "";
            this.Notes = "";
            this.Maker = USysInfo.UserCode;
            this.Checker = "";
            this.FBCode = "";
            this.WhCode = ComHelpWhCode.UHV_B_Warehouse_Browse.Count == 0 ? "" : ComHelpWhCode.UHV_B_Warehouse_Browse.OrderBy(item => item.Priority).FirstOrDefault().WhCode;
            this.OGType = 1;
            this.LensCode = "";
            this.LensCodeR = "";
            this.LensName = "";
            this.CusName = "";
            this.TypeName = "";
            this.LensNameR = "";
        }

        partial void OnCusCodeChanged()
        {
            if (EditState != 1)
                return;
            this.CusName = "";
            ComHelpLensCode.LoadCusLensCodeSmartPD(this.CusCode);

            var _Rs = ComHelpCusCode.UHV_B_CustomerRightBrowse.Where(item => item.CusCode.ToUpper() == this.CusCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.CusName = _Rs.CusName;
        }
         
        private void dds_LoadedData(object s, System.Windows.Controls.LoadedDataEventArgs geted)
        {
            if (geted.HasError)
            {
                geted.MarkErrorAsHandled();
                return;
            }

            var item = geted.Entities.FirstOrDefault() as V_Sale_Order_SD;
            if (null == item)
                return;

            if (_NoticeCount != 0)
                return;

            _NoticeCount++;
            var _msg = ErpUIText.Get("Sale_Bill_LensCode_SD_Err_OBillCodeSame") + item.OBCode;
            MessageWindowErp u = new MessageWindowErp(_msg, MessageWindowErp.MessageType.Info);
            u.Closed += (s1, e1) =>
            {
                Messenger.Default.Send<string>("", USysMessages.OBillCodeFocus);
                return;
            };
            u.Show();
        }

        partial void OnLensCodeRChanged()
        {
            if (EditState != 1) return;
            this.LensNameR = "";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(it => it.LensCode.MyStr() == this.LensCodeR.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameR = _Rs.LensName;
        }

        partial void OnLensCodeChanged()
        {
            if (EditState != 1) return;
            this.LensName = "";
            var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(it => it.LensCode.MyStr() == this.LensCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensName = _Rs.LensName;
        }

        partial void OnSpCodeChanged()
        {
            if (EditState != 1) return;
            this.SpName = "";
            var _Rs = ComHelpSpCode.UHV_B_Supplier.Where(it => it.SpCode.MyStr() == this.SpCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.SpName = _Rs.SpName;
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
