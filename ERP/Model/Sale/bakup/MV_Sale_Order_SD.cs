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

        public string StateNameUI
        {
            get
            {
                return this.StateName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("StateNameUI");
            }
        }

        partial void OnTypeNameChanged()
        {
            this.TypeNameUI = "";
        }

        partial void OnStateNameChanged()
        {
            this.StateNameUI = "";
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
            this.MyNotes = "";
            /////////////////////////////////
            this.ID = "";
            this.UD = 1;
            this.BCode = "";
            this.OdDate = DateTime.Now;
            this.CsDate = DateTime.Now.AddDays(2);
            this.OBCode = "";
            this.CusCode = "";
            this.SpCode = "";
            this.BType = 31;
            this.BState = 1;
            this.Remark = "";
            this.Notes = "";
            this.Maker = USysInfo.UserCode;
            this.Checker = "";
            this.FBCode = "";
            this.WhCode = "";
            //this.TempAddress = "";
            this.DpCodeWG = "";
            this.DpCodeJG = "";
            //this.Flag_ReOrder = false;
            //this.Flag_UnLock = false;
            //this.Flag_CX = false;
            //this.Flag_Cancel = false;
            //this.Flag_Close = false;
            //this.Flag_Import = false;
            //this.Flag_WebOrder = false;
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
            this.StateName = ErpUIText.Get("ERP_New");
            this.TypeName = "";
            this.LensNameR = "";
            this.LensNameL = "";
            this.LensNameRR = "";
            this.LensNameRL = "";
            this.WhName = "";
            this.SpName = "";
        }

        partial void OnCusCodeChanged()
        {
            if (EditState != 1)
                return;

            //ComHelpV_B_LensCode.LoadCusLensCodeSmart(this.CusCode);

            this.CusName = "";
            //this.ForeignCurrName = "";
            //this.PayWayName = "";
            //this.TradeWayName = "";
            //this.TransferWayName = "";
            //this.PersonCode = "";
            //this.DeliveryAddress = "";
            //this.AreaName = "";
            //this.DeptName = "";

            var _ds = ComHelpV_B_Customer.UHV_B_CustomerSmartBrowseRight.Where(item => item.CusCode.ToUpper() == this.CusCode.MyStr()).FirstOrDefault();
            if (_ds == null) return;
            this.CusName = _ds.CusName;
            //this.ForeignCurrName = _ds.ForeignCurrName; 
            //this.TradeWayName = _ds.TradeWayName;
            //this.TransferWayName = _ds.TransferWayName;
            //this.PersonCode = _ds.PersonCode;
            //this.DeliveryAddress = _ds.DeliveryAddress;
            //this.AreaName = _ds.AreaName;
            //this.DeptName = _ds.DeptName;

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

        //partial void OnLensCodeRChanged()
        //{
        //if (EditState != 1) return;
        //this.MnameR = "";

        //var rs = ComHelpV_B_LensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeR.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.MnameR = rs.Mname;
        //UResetProcess.Set(rs.IsCheFang == true);
        //}

        //partial void OnLensCodeLChanged()
        //{
        //if (EditState != 1) return;
        //this.MnameL = "";
        //var rs = ComHelpV_B_LensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCodeL.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.MnameL = rs.Mname;
        //}

        //partial void OnLensCode_ReplaceRChanged()
        //{
        //if (EditState != 1) return;
        //this.MnameReplaceR = "";
        //var rs = ComHelpV_B_LensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCode_ReplaceR.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.MnameReplaceR = rs.Mname;
        //}

        //partial void OnLensCode_ReplaceLChanged()
        //{
        //if (EditState != 1) return;
        //this.MnameReplaceL = "";
        //var rs = ComHelpV_B_LensCode.UHV_B_LensCodeSmart.Where(it => it.LensCode.MyStr() == this.LensCode_ReplaceL.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.MnameReplaceL = rs.Mname;
        //}

        //partial void OnSupplierCodeChanged()
        //{
        //if (EditState != 1) return;
        //this.SupplierName = "";

        //var rs = ComHelpV_B_Supplier.UHV_B_Supplier.Where(it => it.SupplierCode.MyStr() == this.SupplierCode.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.SupplierName = rs.SupplierNameUI;
        //}

        //partial void OnWhCodeChanged()
        //{
        //if (EditState != 1) return;
        //this.WhName = "";

        //var rs = ComHelpV_B_Warehouse.UHV_B_Warehouse.Where(it => it.WhCode.MyStr() == this.WhCode.MyStr()).FirstOrDefault();
        //if (rs == null) return;

        //this.WhName = rs.WhNameUI;
        //}
    }
}
