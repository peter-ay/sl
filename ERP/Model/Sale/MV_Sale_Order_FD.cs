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
    partial class V_Sale_Order_FD
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

        #region ExtendQty

        public int SumQty
        {
            get
            {
                return
                    this.Qty1
                    + this.Qty2
                    + this.Qty3
                    + this.Qty4
                    + this.Qty5
                    + this.Qty6
                    + this.Qty7
                    + this.Qty8
                    + this.Qty9
                    + this.Qty10;
            }
            set { this.RaisePropertyChanged("SumQty"); }
        }



        public int SumQtyCs
        {
            get
            {
                return
                    this.QtyCs1
                  + this.QtyCs2
                  + this.QtyCs3
                  + this.QtyCs4
                  + this.QtyCs5
                  + this.QtyCs6
                  + this.QtyCs7
                  + this.QtyCs8
                  + this.QtyCs9
                  + this.QtyCs10;
            }
            set { this.RaisePropertyChanged("SumQtyCs"); }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public int SumQtyRt
        {
            get
            {
                return
                 this.QtyRt1
                + this.QtyRt2
                + this.QtyRt3
                + this.QtyRt4
                + this.QtyRt5
                + this.QtyRt6
                + this.QtyRt7
                + this.QtyRt8
                + this.QtyRt9
                + this.QtyRt10;
            }
            set { this.RaisePropertyChanged("SumQtyRt"); }
        }

        #endregion


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
            this.BType = "XSFD";
            this.StCode = "DSH";
            this.StName = ErpUIText.Get("ERP_New");
            this.Remark = "";
            this.Notes = "";
            this.Maker = USysInfo.UserCode;
            this.Checker = "";
            this.FBCode = "";
            this.WhCode = "";
            this.SpCode = "";
            this.OGType = 1;
            this.CusName = "";
            this.TypeName = "";
            this.WhName = "";

            this.FrameCode1 = "";
            this.FrameCode2 = "";
            this.FrameCode3 = "";
            this.FrameCode4 = "";
            this.FrameCode5 = "";
            this.FrameCode6 = "";
            this.FrameCode7 = "";
            this.FrameCode8 = "";
            this.FrameCode9 = "";
            this.FrameCode10 = "";
            //
            this.FrameName1 = "";
            this.FrameName2 = "";
            this.FrameName3 = "";
            this.FrameName4 = "";
            this.FrameName5 = "";
            this.FrameName6 = "";
            this.FrameName7 = "";
            this.FrameName8 = "";
            this.FrameName9 = "";
            this.FrameName10 = "";
            //
            this.Qty1 = 0;
            this.Qty2 = 0;
            this.Qty3 = 0;
            this.Qty4 = 0;
            this.Qty5 = 0;
            this.Qty6 = 0;
            this.Qty7 = 0;
            this.Qty8 = 0;
            this.Qty9 = 0;
            this.Qty10 = 0;
            //
            this.QtyCs1 = 0;
            this.QtyCs2 = 0;
            this.QtyCs3 = 0;
            this.QtyCs4 = 0;
            this.QtyCs5 = 0;
            this.QtyCs6 = 0;
            this.QtyCs7 = 0;
            this.QtyCs8 = 0;
            this.QtyCs9 = 0;
            this.QtyCs10 = 0;
            //
            this.QtyRt1 = 0;
            this.QtyRt2 = 0;
            this.QtyRt3 = 0;
            this.QtyRt4 = 0;
            this.QtyRt5 = 0;
            this.QtyRt6 = 0;
            this.QtyRt7 = 0;
            this.QtyRt8 = 0;
            this.QtyRt9 = 0;
            this.QtyRt10 = 0;
        }

        partial void OnCusCodeChanged()
        {
            //if (EditState != 1)
            //    return;
            //this.CusName = "";
            //ComHelpFrameCode.LoadCusFrameCode(this.CusCode);

            //var _ds = ComHelpCusCode.UHV_B_CustomerSmartBrowseRight.Where(item => item.CusCode.ToUpper() == this.CusCode.MyStr()).FirstOrDefault();
            //if (_ds == null) return;
            //this.CusName = _ds.CusName;
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

        partial void OnWhCodeChanged()
        {
            if (EditState != 1) return;
            this.WhName = "";
            var _Rs = ComHelpWhCode.UHV_B_Warehouse.Where(it => it.WhCode.MyStr() == this.WhCode.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.WhName = _Rs.WhName;
        }

        partial void OnFrameCode1Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode1.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName1 = _Rs.FrameName;
        }

        partial void OnFrameCode2Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode2.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName2 = _Rs.FrameName;
        }

        partial void OnFrameCode3Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode3.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName3 = _Rs.FrameName;
        }

        partial void OnFrameCode4Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode4.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName4 = _Rs.FrameName;
        }

        partial void OnFrameCode5Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode5.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName5 = _Rs.FrameName;
        }

        partial void OnFrameCode6Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode6.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName6 = _Rs.FrameName;
        }

        partial void OnFrameCode7Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode7.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName7 = _Rs.FrameName;
        }

        partial void OnFrameCode8Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode8.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName8 = _Rs.FrameName;
        }

        partial void OnFrameCode9Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode9.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName9 = _Rs.FrameName;
        }

        partial void OnFrameCode10Changed()
        {
            if (EditState != 1) return;
            var _Rs = ComHelpFrameCode.UHV_B_CusFrameCode.Where(it => it.FrameCode.MyStr() == this.FrameCode10.MyStr()).FirstOrDefault();
            if (_Rs == null) return;
            this.FrameName10 = _Rs.FrameName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        partial void OnQty1Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty2Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty3Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty4Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty5Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty6Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty7Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty8Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty9Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }

        partial void OnQty10Changed()
        {
            if (EditState != 1) return;
            this.RaisePropertyChanged("SumQty");
        }
    }
}
