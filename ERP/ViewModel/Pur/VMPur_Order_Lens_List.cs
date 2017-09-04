using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using ERP.Web.Entity;

namespace ERP.ViewModel
{
    public class VMPur_Order_Lens_List : VMList
    {

        #region Property

        #region SearchCondition

        private string _DpCode;
        public string DpCode
        {
            get { return _DpCode; }
            set { _DpCode = value; RaisePropertyChanged("DpCode"); }
        }

        private string _CusCode;
        public string CusCode
        {
            get { return _CusCode; }
            set { _CusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string _SpCode;
        public string SpCode
        {
            get { return _SpCode; }
            set { _SpCode = value; RaisePropertyChanged("SpCode"); }
        }

        private string _BCode1;
        public string BCode1
        {
            get { return _BCode1; }
            set { _BCode1 = value; RaisePropertyChanged("BCode1"); }
        }

        private string _BCode2;
        public string BCode2
        {
            get { return _BCode2; }
            set { _BCode2 = value; RaisePropertyChanged("BCode2"); }
        }

        //private string _OBCode;
        //public string OBCode
        //{
        //    get { return _OBCode; }
        //    set { _OBCode = value; RaisePropertyChanged("OBCode"); }
        //}

        private string _FBCode;
        public string FBCode
        {
            get { return _FBCode; }
            set { _FBCode = value; RaisePropertyChanged("FBCode"); }
        }

        private string _DN1;
        public string DN1
        {
            get { return _DN1; }
            set { _DN1 = value; RaisePropertyChanged("DN1"); }
        }

        private string _DN2;
        public string DN2
        {
            get { return _DN2; }
            set { _DN2 = value; RaisePropertyChanged("DN2"); }
        }

        private string _LenCode;
        public string LenCode
        {
            get { return _LenCode; }
            set { _LenCode = value; RaisePropertyChanged("LenCode"); }
        }

        private string _SCBType = "";
        private int _SCDelivery = -1;
        private int _SCCX = -1;
        private int _SCUD = -1;

        private bool isDeliveryAll = true;
        public bool IsDeliveryAll
        {
            get { return isDeliveryAll; }
            set { isDeliveryAll = value; RaisePropertyChanged("IsDeliveryAll"); }
        }

        private bool isExportAll = true;
        public bool IsExportAll
        {
            get { return isExportAll; }
            set { isExportAll = value; RaisePropertyChanged("IsExportAll"); }
        }

        private bool isCXAll = true;
        public bool IsCXAll
        {
            get { return isCXAll; }
            set { isCXAll = value; RaisePropertyChanged("IsCXAll"); }
        }

        private bool isOutGoodAll = true;
        public bool IsOutGoodAll
        {
            get { return isOutGoodAll; }
            set { isOutGoodAll = value; RaisePropertyChanged("IsOutGoodAll"); }
        }

        private bool _BillTypeALL = true;
        public bool BillTypeALL
        {
            get { return _BillTypeALL; }
            set { _BillTypeALL = value; RaisePropertyChanged("BillTypeALL"); }
        }

        #region UD类型
        //
        private bool _IsCheckUD0 = true;
        public bool IsCheckUD0
        {
            get { return _IsCheckUD0; }
            set { _IsCheckUD0 = value; RaisePropertyChanged("IsCheckUD0"); }
        }

        #endregion

        #endregion

        #endregion


        public VMPur_Order_Lens_List()
            : base("ID", "Pur_Order_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.SpCode = "";
            this.DpCode = "";
            this.Checker = "";
            this.Maker = "";
            this.CusCode = "";
            this.BCode1 = "";
            this.BCode2 = "";
            this.OBCode = "";
            this.LenCode = "";
            this.DN1 = "";
            this.DN2 = "";
            this._SCBType = "";
            this.FBCode = "";
            this._SCCX = -1;
            this._SCDelivery = -1;
            this.IsCheckAll = true;
            this.BTypeAll = true;
            this.IsCXAll = true;
            this.IsDeliveryAll = true;
            this.IsCheckUD0 = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "GpID" + USptstr.Str2 + (USysInfo.F_Manager || USysInfo.F_CusCodeBrowse ? -99 : USysInfo.GpID);
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "Maker" + USptstr.Str2 + this.Maker;
            _SWhere += USptstr.Str1 + "SCUD" + USptstr.Str2 + this._SCUD;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
            _SWhere += USptstr.Str1 + "BType" + USptstr.Str2 + this._SCBType;
        }

        #region Cdi

        private RelayCommand<string> _CmdRBCdiCX;

        /// <summary>
        /// Gets the CmdRBCdiCX.
        /// </summary>
        public RelayCommand<string> CmdRBCdiCX
        {
            get
            {
                return _CmdRBCdiCX
                    ?? (_CmdRBCdiCX = new RelayCommand<string>(
                    p =>
                    {
                        this._SCCX = Convert.ToInt32(p);
                    }));
            }
        }
        /////////////////////////////
        private RelayCommand<string> _CmdRBCdiDelivery;

        /// <summary>
        /// Gets the CmdRBCdiDelivery.
        /// </summary>
        public RelayCommand<string> CmdRBCdiDelivery
        {
            get
            {
                return _CmdRBCdiDelivery
                    ?? (_CmdRBCdiDelivery = new RelayCommand<string>(
                    p =>
                    {
                        this._SCDelivery = Convert.ToInt32(p);
                    }));
            }
        }
        //////////////////////////////////////////

        private RelayCommand<string> _CmdRBCdiBillType;

        public RelayCommand<string> CmdRBCdiBillType
        {
            get
            {
                return _CmdRBCdiBillType
                    ?? (_CmdRBCdiBillType = new RelayCommand<string>(
                    p =>
                    {
                        _SCBType = p;
                    }));
            }
        }
        //////////////////////////////////////////////////
        private RelayCommand<string> _CmdRBUDCheck;

        public RelayCommand<string> CmdRBUDCheck
        {
            get
            {
                return _CmdRBUDCheck
                    ?? (_CmdRBUDCheck = new RelayCommand<string>(
                    p =>
                    {
                        this._SCUD = Convert.ToInt32(p);
                    }));
            }
        }

        #endregion

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            //string _FunCode = "";
            //string _BillType = "";
            //V_Pur_Order_Lens _DC = parameter as V_Pur_Order_Lens;
            //_BillType = _DC.BType;

            //switch (_BillType)
            //{
            //    case "XSSD":
            //        _FunCode = "Sale_OrderSD";
            //        break;
            //    case "XSPD":
            //        _FunCode = "Sale_OrderPD";
            //        break;
            //    default:
            //        break;
            //}
            //ComOpenWins.Open("", _FunCode);
            //Messenger.Default.Send<string>((_DC.ID), "VM" + _FunCode + "_ShowFromList");
        }

        //////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            //if (this.GridListSelectedCodes.Count == 0) return;
            //var _Str = this.getExportWhereCondition();
            //ERP.Web.DomainService.Erp.DSErp _DS = new Web.DomainService.Erp.DSErp();

            //var p = _DS.GetV_Pur_Order_LensListQuery("SL", _Str);
            //_DS.Load(p);
        }

    }
}
