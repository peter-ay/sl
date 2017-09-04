
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMSale_Order_FD : VMBill
    {
        #region property

        private V_Sale_Order_FD _DC
        {
            get
            {
                return this.DContextMain as V_Sale_Order_FD;
            }
        }

        #region UD类型

        private bool _IsEnableUD = false;
        public bool IsEnableUD
        {
            get { return _IsEnableUD; }
            set { _IsEnableUD = value; RaisePropertyChanged("IsEnableUD"); }
        }

        //
        private bool _IsCheckUD0 = true;
        public bool IsCheckUD0
        {
            get { return _IsCheckUD0; }
            set { _IsCheckUD0 = value; RaisePropertyChanged("IsCheckUD0"); }

        }
        private bool _IsCheckUD1 = true;
        public bool IsCheckUD1
        {
            get { return _IsCheckUD1; }
            set { _IsCheckUD1 = value; RaisePropertyChanged("IsCheckUD1"); }
        }

        private bool _IsCheckUD2 = false;
        public bool IsCheckUD2
        {
            get { return _IsCheckUD2; }
            set { _IsCheckUD2 = value; RaisePropertyChanged("IsCheckUD2"); }
        }

        private bool _IsCheckUD3 = false;
        public bool IsCheckUD3
        {
            get { return _IsCheckUD3; }
            set { _IsCheckUD3 = value; RaisePropertyChanged("IsCheckUD3"); }
        }

        #endregion

        #endregion

        public VMSale_Order_FD()
            : base("ID", "Sale_Order_FD", true)
        {
        }

        //protected override string PrepareDDsInfoMainQueryName()
        //{
        //    return "GetV_Sale_Order_FDBill";
        //}

        //protected override string PrepareDDsInfoSubQueryName()
        //{
        //    return "GetV_Sale_Order_FDDetailList";
        //}

        //protected override void PrepareDContextMain()
        //{
        //    this.DContextMain = new V_Sale_Order_FD();
        //}

        //protected override void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        //{
        //    base.PrepareDDsInfoMainParameters(ispnIndex);
        //    this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
        //}
        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();
            this.ReSetUD();
            //this.LoadFDDetail();
        }

        //private void LoadFDDetail()
        //{
        //    //this.ResetFD();
        //    var _DDS = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_Order_FDDetailList", _DDS_LoadedData, true);
        //    _DDS.QueryParameters.Add(new System.Windows.Controls.Parameter() { ParameterName = "iD", Value = this.CurrentIDCode });
        //    _DDS.Load();
        //}

        //private void _DDS_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        //{
        //    if (e.HasError)
        //    {
        //        e.MarkErrorAsHandled();
        //        return;
        //    }

        //    if (e.TotalEntityCount == 0) return;

        //    foreach (V_Sale_Order_FD_Detail item in e.Entities)
        //    {
        //        switch (item.SubID)
        //        {
        //            case 1:
        //                this._DC.FrameCode1 = item.FrameCode;
        //                this._DC.Qty1 = item.Qty.Value.ToString();
        //                this._DC.QtyCs1 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt1 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName1 = item.FrameName.ToString();
        //                break;
        //            case 2:
        //                this._DC.FrameCode2 = item.FrameCode;
        //                this._DC.Qty2 = item.Qty.Value.ToString();
        //                this._DC.QtyCs2 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt2 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName2 = item.FrameName.ToString();
        //                break;
        //            case 3:
        //                this._DC.FrameCode3 = item.FrameCode;
        //                this._DC.Qty3 = item.Qty.Value.ToString();
        //                this._DC.QtyCs3 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt3 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName3 = item.FrameName.ToString();
        //                break;
        //            case 4:
        //                this._DC.FrameCode4 = item.FrameCode;
        //                this._DC.Qty4 = item.Qty.Value.ToString();
        //                this._DC.QtyCs4 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt4 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName4 = item.FrameName.ToString();
        //                break;
        //            case 5:
        //                this._DC.FrameCode5 = item.FrameCode;
        //                this._DC.Qty5 = item.Qty.Value.ToString();
        //                this._DC.QtyCs5 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt5 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName5 = item.FrameName.ToString();
        //                break;
        //            case 6:
        //                this._DC.FrameCode6 = item.FrameCode;
        //                this._DC.Qty6 = item.Qty.Value.ToString();
        //                this._DC.QtyCs6 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt6 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName6 = item.FrameName.ToString();
        //                break;
        //            case 7:
        //                this._DC.FrameCode7 = item.FrameCode;
        //                this._DC.Qty7 = item.Qty.Value.ToString();
        //                this._DC.QtyCs7 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt7 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName7 = item.FrameName.ToString();
        //                break;
        //            case 8:
        //                this._DC.FrameCode8 = item.FrameCode;
        //                this._DC.Qty8 = item.Qty.Value.ToString();
        //                this._DC.QtyCs8 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt8 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName8 = item.FrameName.ToString();
        //                break;
        //            case 9:
        //                this._DC.FrameCode9 = item.FrameCode;
        //                this._DC.Qty9 = item.Qty.Value.ToString();
        //                this._DC.QtyCs9 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt9 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName9 = item.FrameName.ToString();
        //                break;
        //            case 10:
        //                this._DC.FrameCode10 = item.FrameCode;
        //                this._DC.Qty10 = item.Qty.Value.ToString();
        //                this._DC.QtyCs10 = item.QtyCs.Value.ToString();
        //                this._DC.QtyRt10 = item.QtyRt.Value.ToString();
        //                this._DC.FrameName10 = item.FrameName.ToString();
        //                break;

        //            default: break;
        //        }

        //        //try
        //        //{
        //        //    this._DC.GetType().GetProperty("FrameCode" + item.SubID.ToString()).SetValue(this._DC, item.FrameCode, null);
        //        //    this._DC.GetType().GetProperty("Qty" + item.SubID.ToString()).SetValue(this._DC, item.Qty.ToString(), null);
        //        //    this._DC.GetType().GetProperty("QtyCs" + item.SubID.ToString()).SetValue(this._DC, item.QtyCs.ToString(), null);
        //        //    this._DC.GetType().GetProperty("QtyRt" + item.SubID.ToString()).SetValue(this._DC, item.QtyRt.ToString(), null);
        //        //    this._DC.GetType().GetProperty("FrameName" + item.SubID.ToString()).SetValue(this._DC, item.FrameName, null);
        //        //}
        //        //catch { }

        //    }
        //} 

        private void ReSetUD()
        {
            try
            {
                switch (_DC.UD)
                {
                    case 1:
                        this.IsCheckUD1 = true;
                        break;
                    case 2:
                        this.IsCheckUD2 = true;
                        break;
                    case 3:
                        this.IsCheckUD3 = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MSale_Order();
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnableUD = false;
            //var cDC = this.DContextMain as V_Sale_Order_FD;
            //this.IsEnableXYInPut = false;

            switch (uBillState)
            {
                case UBillState.View:

                    break;
                case UBillState.Drop:

                    break;

                case UBillState.New:
                    this.IsEnableUD = true;
                    break;
                case UBillState.Edit:
                    this.IsEnableUD = true; 
                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.CusCode = " " + this._DC.CusCode;
            this._DC.CusCode = this._DC.CusCode.Trim();
            ///////////////////////////////////////////////
            this._DC.WhCode = " " + this._DC.WhCode;
            this._DC.WhCode = this._DC.WhCode.Trim();
            ///////////////////////////////////////////////////////////////
            this._DC.FrameCode1 = " " + this._DC.FrameCode1;
            this._DC.FrameCode1 = this._DC.FrameCode1.Trim();
            this._DC.FrameCode2 = " " + this._DC.FrameCode2;
            this._DC.FrameCode2 = this._DC.FrameCode2.Trim();
            this._DC.FrameCode3 = " " + this._DC.FrameCode3;
            this._DC.FrameCode3 = this._DC.FrameCode3.Trim();
            this._DC.FrameCode4 = " " + this._DC.FrameCode4;
            this._DC.FrameCode4 = this._DC.FrameCode4.Trim();
            this._DC.FrameCode5 = " " + this._DC.FrameCode5;
            this._DC.FrameCode5 = this._DC.FrameCode5.Trim();
            this._DC.FrameCode6 = " " + this._DC.FrameCode6;
            this._DC.FrameCode6 = this._DC.FrameCode6.Trim();
            this._DC.FrameCode7 = " " + this._DC.FrameCode7;
            this._DC.FrameCode7 = this._DC.FrameCode7.Trim();
            this._DC.FrameCode8 = " " + this._DC.FrameCode8;
            this._DC.FrameCode8 = this._DC.FrameCode8.Trim();
            this._DC.FrameCode9 = " " + this._DC.FrameCode9;
            this._DC.FrameCode9 = this._DC.FrameCode9.Trim();
            this._DC.FrameCode10 = " " + this._DC.FrameCode10;
            this._DC.FrameCode10 = this._DC.FrameCode10.Trim();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override string PrepareDSBill()
        {
            return "Sale_Order";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MSale_Order;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();

            _CM.Sub_FD_Detail = new List<MSale_Order_FD_Detail>();
            MSale_Order_FD_Detail _item = null;
            int _SubID = 1;
            string _FCode = "";
            int _Qty = 0;
            for (int i = 1; i <= 10; i++)
            {
                //try { _FCode = this._DC.GetType().GetProperty("FrameCode" + i.ToString()).GetValue(this._DC, null).ToString(); }
                //catch { _FCode = ""; }
                //try { _Qty = System.Convert.ToInt32(this._DC.GetType().GetProperty("Qty" + i.ToString()).GetValue(this._DC, null).ToString()); }
                //catch { _Qty = 0; }

                //switch (i)
                //{
                //    case 1:
                //        _FCode = this._DC.FrameCode1;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty1); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 2:
                //        _FCode = this._DC.FrameCode2;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty2); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 3:
                //        _FCode = this._DC.FrameCode3;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty3); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 4:
                //        _FCode = this._DC.FrameCode4;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty4); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 5:
                //        _FCode = this._DC.FrameCode5;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty5); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 6:
                //        _FCode = this._DC.FrameCode6;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty6); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 7:
                //        _FCode = this._DC.FrameCode7;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty7); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 8:
                //        _FCode = this._DC.FrameCode8;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty8); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 9:
                //        _FCode = this._DC.FrameCode9;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty9); }
                //        catch { _Qty = 0; }
                //        break;
                //    case 10:
                //        _FCode = this._DC.FrameCode10;
                //        try { _Qty = System.Convert.ToInt32(this._DC.Qty10); }
                //        catch { _Qty = 0; }
                //        break;

                //    default: break;
                //}
                switch (i)
                {
                    case 1:
                        _FCode = this._DC.FrameCode1;
                        _Qty = this._DC.Qty1;
                        break;
                    case 2:
                        _FCode = this._DC.FrameCode2;
                        _Qty = this._DC.Qty2;
                        break;
                    case 3:
                        _FCode = this._DC.FrameCode3;
                        _Qty = this._DC.Qty3;
                        break;
                    case 4:
                        _FCode = this._DC.FrameCode4;
                        _Qty = this._DC.Qty4;
                        break;
                    case 5:
                        _FCode = this._DC.FrameCode5;
                        _Qty = this._DC.Qty5;
                        break;
                    case 6:
                        _FCode = this._DC.FrameCode6;
                        _Qty = this._DC.Qty6;
                        break;
                    case 7:
                        _FCode = this._DC.FrameCode7;
                        _Qty = this._DC.Qty7;
                        break;
                    case 8:
                        _FCode = this._DC.FrameCode8;
                        _Qty = this._DC.Qty8;
                        break;
                    case 9:
                        _FCode = this._DC.FrameCode9;
                        _Qty = this._DC.Qty9;
                        break;
                    case 10:
                        _FCode = this._DC.FrameCode10;
                        _Qty = this._DC.Qty10;
                        break;

                    default: break;
                }

                if (!string.IsNullOrEmpty(_FCode))
                {
                    _item = new MSale_Order_FD_Detail()
                    {
                        SubID = _SubID++,
                        FrameCode = _FCode,
                        Qty = _Qty,
                        DeliveryName = "",
                        ID = _CM.ID,
                        Price = 0,
                        QtyCs = 0,
                        QtyRt = 0,
                    };
                    _CM.Sub_FD_Detail.Add(_item);
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override bool VerifySave()
        {
            //////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(_DC.CusCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////////
            //if ((this.DContextSub.Count) <= 0)
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_SumQtyLess"));
            //    return false;
            //}

            ///////////////////////////////////////////////////////////////
            //if (string.IsNullOrEmpty(_DC.WhCode) && string.IsNullOrEmpty(_DC.SpCode))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_WGorWhCode"));
            //    return false;
            //}

            //if (!string.IsNullOrEmpty(_DC.WhCode) && !string.IsNullOrEmpty(_DC.SpCode))
            //{
            //    MessageErp.ErrorMessage(ErpUIText.Get("Sale_OrderSD_Err_WGandWhCode"));
            //    return false;
            //}

            return true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand<string> _CmdRBUDCheck;
        /// <summary>
        /// Gets the CmdRBUDCheck.
        /// </summary>
        public RelayCommand<string> CmdRBUDCheck
        {
            get
            {
                return _CmdRBUDCheck
                    ?? (_CmdRBUDCheck = new RelayCommand<string>(ExecuteCmdRBUDCheck));
            }
        }

        private void ExecuteCmdRBUDCheck(string parameter)
        {
            try
            {
                _DC.UD = Convert.ToByte(parameter);
            }
            catch
            {
                if (_DC != null)
                {
                    _DC.UD = 1;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
