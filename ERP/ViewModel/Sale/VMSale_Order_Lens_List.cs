using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using ERP.Web.Entity;
using ERP.View;

namespace ERP.ViewModel
{
    public class VMSale_Order_Lens_List : VMList
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

        private string _LensCode;
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _WhCode;
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private string _SCBType = "";
        private int _SCDelivery = -1;
        private int _SCCX = -1;
        private int _SCUD = -1;
        private int _SCOG = -1;
        private string _LensType = "";

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

        private bool _IsCheckOGALL = true;
        public bool IsCheckOGALL
        {
            get { return _IsCheckOGALL; }
            set { _IsCheckOGALL = value; RaisePropertyChanged("IsCheckOGALL"); }
        }

        private bool _BillTypeALL = true;
        public bool BillTypeALL
        {
            get { return _BillTypeALL; }
            set { _BillTypeALL = value; RaisePropertyChanged("BillTypeALL"); }
        }

        //IsCheckLensTypeALL
        private bool _IsCheckLensTypeALL = true;
        public bool IsCheckLensTypeALL
        {
            get { return _IsCheckLensTypeALL; }
            set { _IsCheckLensTypeALL = value; RaisePropertyChanged("IsCheckLensTypeALL"); }
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


        public VMSale_Order_Lens_List()
            : base("ID", "Sale_Order_Lens")
        {

        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.SpCode = "";
            this.WhCode = "";
            this.DpCode = "";
            this.Checker = "";
            this.Maker = "";
            this.CusCode = "";
            this.BCode = "";
            this.OBCode = "";
            this.LensCode = "";
            this._SCBType = "";
            this.FBCode = "";
            this._SCCX = -1;
            this._SCDelivery = -1;
            this._SCOG = -1;
            this._LensType = "";
            this.IsCheckAll = true;
            this.BTypeAll = true;
            this.IsCXAll = true;
            this.IsDeliveryAll = true;
            this.IsCheckUD0 = true;
            this.IsCheckLensTypeALL = true;
            this.IsCheckOGALL = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "GpID" + USptstr.Str2 + (USysInfo.F_Manager || USysInfo.F_CusCodeBrowse ? -99 : USysInfo.GpID);
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "OBCode" + USptstr.Str2 + this.OBCode;
            _SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            _SWhere += USptstr.Str1 + "Maker" + USptstr.Str2 + this.Maker;
            _SWhere += USptstr.Str1 + "SCUD" + USptstr.Str2 + this._SCUD;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
            _SWhere += USptstr.Str1 + "BType" + USptstr.Str2 + this._SCBType;
            _SWhere += USptstr.Str1 + "F_JM" + USptstr.Str2 + "0";
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "SpCode" + USptstr.Str2 + this.SpCode;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "LensType" + USptstr.Str2 + this._LensType;
            _SWhere += USptstr.Str1 + "SCOG" + USptstr.Str2 + this._SCOG;
        }

        #region Cdi
        //
        private RelayCommand<string> _CmdRBCdiCX;

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
        //
        private RelayCommand<string> _CmdRBCdiDelivery;

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
        //
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
        //
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
        //
        private RelayCommand<string> _CmdRBCdiLensType;

        public RelayCommand<string> CmdRBCdiLensType
        {
            get
            {
                return _CmdRBCdiLensType
                    ?? (_CmdRBCdiLensType = new RelayCommand<string>(
                    p =>
                    {
                        this._LensType = p;
                    }));
            }
        }
        //
        private RelayCommand<string> _CmdRBCdiOG;

        public RelayCommand<string> CmdRBCdiOG
        {
            get
            {
                return _CmdRBCdiOG
                    ?? (_CmdRBCdiOG = new RelayCommand<string>(
                    p =>
                    {
                        this._SCOG = Convert.ToInt32(p);
                    }));
            }
        }

        #endregion

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            string _FunCode = "";
            string _BillType = "";
            V_Sale_Order_Lens _DC = parameter as V_Sale_Order_Lens;
            _BillType = _DC.BType;

            switch (_BillType)
            {
                case "XSSD":
                    _FunCode = "Sale_Order_SD";
                    break;
                case "XSPD":
                    _FunCode = "Sale_Order_PD";
                    break;
                case "XSCD":
                    _FunCode = "Sale_Order_SD_ReOrder";
                    break;
                default:
                    break;
            }
            ComOpenWins.Open("", _FunCode);
            Messenger.Default.Send<string>((_DC.ID), "VM" + _FunCode + "_ShowFromList");
        }

        //
        protected override void Export()
        {
            ////if (this.GridListSelectedCodes.Count == 0) return;
            //var _Str = this.getExportWhereCondition();
            //ERP.Web.DomainService.Erp.DSErp _DS = new Web.DomainService.Erp.DSErp();

            //var p = _DS.GetV_Sale_Order_LensListQuery("SL", _Str);
            //_DS.Load(p);
        }

        protected override void Export2()
        {
            ERP.Web.DomainService.Common.DSExportToFactory _DS = new ERP.Web.DomainService.Common.DSExportToFactory();
            var _bID = UID.ID;
            Messenger.Default.Send<string>("", USysMessages.FunLoadBegin);
            _DS.Export(USysInfo.DBCode, USysInfo.LgIndex, USysInfo.UserCode, this.GridListSelectedCodes, geted =>
            {
                Messenger.Default.Send<string>("", USysMessages.FunLoadEnd);
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                var _file = geted.Value.ToString();
                this.Load();
                ComOpenURL.Open(_file);
            }, null);
        }

        protected override void ExportList()
        {
            string _ID = "";
            var _Str = this.getExportWhereCondition(out _ID);
            ERP.Web.DomainService.Erp.DSErp _DS = new Web.DomainService.Erp.DSErp();

            var p = _DS.GetV_Sale_Order_LensListQuery(USysInfo.DBCode, _Str);
            _DS.Load(p, geted =>
            {
                ComOpenURL.Open(_ID + ".xls");
            }, null);
        }

        #region CmdNew

        private RelayCommand _CmdNewSD;

        public RelayCommand CmdNewSD
        {
            get
            {
                return _CmdNewSD
                    ?? (_CmdNewSD = new RelayCommand(ExecuteCmdNewSD));
            }
        }

        private void ExecuteCmdNewSD()
        {
            ComOpenWins.Open("", "Sale_Order_SD", f_CheckRight: false);
        }



        private RelayCommand _CmdNewPD;

        public RelayCommand CmdNewPD
        {
            get
            {
                return _CmdNewPD
                    ?? (_CmdNewPD = new RelayCommand(ExecuteCmdNewPD));
            }
        }

        private void ExecuteCmdNewPD()
        {
            ComOpenWins.Open("", "Sale_Order_PD", f_CheckRight: false);
        }

        #endregion

        //
        protected override void Delete()
        {

        }

        protected override void Print()
        {
            if (this.GridListSelectedCodes.Count <= 0) return;
            this.PrintXSSD(this.GridListSelectedCodes);
        }
    }
}
