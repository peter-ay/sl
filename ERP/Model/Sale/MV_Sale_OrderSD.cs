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
    partial class V_Sale_Order_SD
    {
        private bool _IsNoticeForRepeat = false;
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
            this._IsNoticeForRepeat = false;
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
            this.BType = "XSSD";
            this.StCode = "DSH";
            this.StName = ErpUIText.Get("ERP_New");
            this.Remark = "";
            this.Notes = "";
            this.Maker = USysInfo.UserCode;
            this.Checker = "";
            this.FBCode = "";
            this.OGType = 1;
            this.WhCode = ComHelpWhCode.UHV_B_WarehouseBrowseRight.OrderBy(item => item.Priority).FirstOrDefault().WhCode;
            this.DpCodeWG = "";
            this.DpCodeJG = "";
            this.LensCodeR = "";
            this.LensCodeRR = "";
            this.SPHR = 0;
            this.CYLR = 0;
            this.X_ADDR = 0;
            this.QtyR = 1;
            this.DiaR = 0;
            this.AxisR = 180;
            this.CTR = "";
            this.D1R = "";
            this.D2R = "";
            this.D3R = "";
            this.D4R = "";
            this.P1R = "";
            this.P2R = "";
            this.P3R = "";
            this.P4R = "";
            this.DBR = false;
            this.BASER = "";
            this.LensCodeL = "";
            this.LensCodeRL = "";
            this.SPHL = 0;
            this.CYLL = 0;
            this.X_ADDL = 0;
            this.QtyL = 1;
            this.DiaL = 0;
            this.AxisL = 180;
            this.CTL = "";
            this.D1L = "";
            this.D2L = "";
            this.D3L = "";
            this.D4L = "";
            this.P1L = "";
            this.P2L = "";
            this.P3L = "";
            this.P4L = "";
            this.DBL = false;
            this.BASEL = "";
            this.CXType = 1;
            this.UV = false;
            this.JY = false;
            this.JJ = "";
            this.CS = "";
            this.RS = "";
            this.RSName = "";
            this.JS = "";
            this.SY = "";
            this.ZK = "";
            this.OP = "";
            this.ChB = "";
            this.PG = "";
            this.KK = "";
            this.CB = "";
            this.PH = "";
            this.CusName = "";
            this.DpNameWG = "";
            this.DpNameJG = "";
            this.TypeName = "";
            this.LensNameR = "";
            this.LensNameL = "";
            this.LensNameRR = "";
            this.LensNameRL = "";
        }

        partial void OnCusCodeChanged()
        {
            if (EditState != 1)
                return;
            this.CusName = "";
            ComHelpLensCode.LoadCusLensCodeSmartSDR(this.CusCode);
            ComHelpLensCode.LoadCusLensCodeSmartSDL(this.CusCode);

            var _Rs = ComHelpCusCode.UHV_B_CustomerSmartBrowseRight.Where(item => item.CusCode.ToUpper() == this.CusCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.CusName = _Rs.CusName;
            if (string.IsNullOrEmpty(this.DpNameJG))
            {
                this.DpCodeJG = _Rs.DpCode;
            }
            //_IsNoticeForRepeat = _ds.F_NoticeRepeatOBill.Value;

            //if (_IsNoticeForRepeat)
            //{
            //    NoticeForRepeat();
            //}
        }

        private void NoticeForRepeat()
        {
            //if (string.IsNullOrEmpty(this.OBillCode) || _NoticeCount != 0 || !string.IsNullOrEmpty(this.BillCode))
            //    return;

            //var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_Order_SDQuery", dds_LoadedData);
            //dds.FilterDescriptors.Add(new FilterDescriptor() { PropertyPath = "OBillCode", Value = this.OBillCode });
            //dds.Load();
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
            var _Rs = ComHelpLensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeR.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameR = _Rs.LensName;
            Messenger.Default.Send(_Rs.LensType == 1, USysMessages.SDProcessUpdate);
        }

        partial void OnLensCodeLChanged()
        {
            if (EditState != 1) return;
            this.LensNameL = "";
            var _Rs = ComHelpLensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeL.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameL = _Rs.LensName;
        }

        partial void OnLensCodeRRChanged()
        {
            if (EditState != 1) return;
            this.LensNameRR = "";
            var _Rs = ComHelpLensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeRR.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameRR = _Rs.LensName;
        }

        partial void OnLensCodeRLChanged()
        {
            if (EditState != 1) return;
            this.LensNameRL = "";
            var _Rs = ComHelpLensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeRL.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.LensNameRL = _Rs.LensName;
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

        partial void OnDpCodeJGChanged()
        {
            if (EditState != 1) return;
            this.DpNameJG = "";
            var _Rs = ComHelpDpCode.UHV_B_Department.Where(it => it.DpCode.MyStr() == this.DpCodeJG.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.DpNameJG = _Rs.DpName;
        }

        partial void OnDpCodeWGChanged()
        {
            if (EditState != 1) return;
            this.DpNameWG = "";
            var _Rs = ComHelpDpCode.UHV_B_Department.Where(it => it.DpCode.MyStr() == this.DpCodeWG.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.DpNameWG = _Rs.DpName;
        }
    }
}
