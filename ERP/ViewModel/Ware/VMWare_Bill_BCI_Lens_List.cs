using System;
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using ERP.Web.Model;
using ERP.Web.DomainService.Bill;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMWare_Bill_BCI_Lens_List : VMList
    {
        #region SearchCondition

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        //private string _Maker = "";
        //public string Maker
        //{
        //    get { return _Maker; }
        //    set { _Maker = value; RaisePropertyChanged("Maker"); }
        //}

        private bool _IsCheckUnCheck = false;
        public bool IsCheckUnCheck
        {
            get { return _IsCheckUnCheck; }
            set { _IsCheckUnCheck = value; RaisePropertyChanged("IsCheckUnCheck"); }
        }

        #endregion

        #region BarCodeField

        private string _BarCodeInfo = "";
        public string BarCodeInfo
        {
            get { return _BarCodeInfo; }
            set { _BarCodeInfo = value; RaisePropertyChanged("BarCodeInfo"); }
        }

        private string _WhCodeInfo = "";
        public string WhCodeInfo
        {
            get { return _WhCodeInfo; }
            set { _WhCodeInfo = value; RaisePropertyChanged("WhCodeInfo"); }
        }

        private string _MsgInfo = "";
        public string MsgInfo
        {
            get { return _MsgInfo; }
            set { _MsgInfo = value; RaisePropertyChanged("MsgInfo"); }
        }

        #endregion

        public VMWare_Bill_BCI_Lens_List()
            : base("ID", "Ware_Bill_BCI_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.LensCode = "";
            this.WhCode = "";
            this.Maker = "";
            this.IsCheckAll = true;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            //return base.PrepareDDsInfoListQueryName();
            return "GetV_Ware_Bill_LensList";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "BType" + USptstr.Str2 + "KFBCIPD";
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "BCode" + USptstr.Str2 + this.BCode;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "Maker" + USptstr.Str2 + this.Maker;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("MDate", true);
        }

        protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            //var _DC = parameter as V_Ware_Bill_Lens;
            //var _ID = _DC.ID;
            //string _FunCode = "Ware_Bill_BCI_Lens";
            //var _VName = ErpUIText.Get(_FunCode);
            //ComAssignWins.Assign(_ID, _FunCode, _VName);
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            //var _DC = parameter as V_Ware_Bill_Lens;
            //var _FCode = "Sale_Order_SD";
            //if (_DC.BType == "KFSOPD")
            //{
            //    _FCode = "Sale_Order_PD";
            //}
            //var _VName = ErpUIText.Get(_FCode);
            //var _IDCode = _DC.FBCode;
            //ComAssignWins.Assign(_IDCode, _FCode, _VName);
        }

        protected override void ViewKeyDown(KeyEventArgs parameter)
        {
            //base.ViewKeyDown(parameter);
            switch (parameter.Key)
            {
                case Key.Enter:
                    parameter.Handled = true;
                    break;
                case Key.Escape:
                    this.ExecuteCmdExit();
                    parameter.Handled = true;
                    break;
            }
        }

        #region Cdi

        #endregion


        #region Methods

        //BarCodeInfoKeyDown
        private RelayCommand<KeyEventArgs> _BarCodeInfoKeyDown;

        /// <summary>
        /// Gets the BarCodeInfoKeyDown.
        /// </summary>
        public RelayCommand<KeyEventArgs> BarCodeInfoKeyDown
        {
            get
            {
                return _BarCodeInfoKeyDown
                    ?? (_BarCodeInfoKeyDown = new RelayCommand<KeyEventArgs>(
                    p =>
                    {
                        if (p.Key != Key.Enter)
                            return;
                        this.GetRecordBarCodeInfo();
                    }));
            }
        }

        private void GetRecordBarCodeInfo()
        {
            if (string.IsNullOrEmpty(this.WhCodeInfo))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_ErrWhCodeRequired"));
                return;
            }

            ComBarCodeLensInfo _BC = ComBarCodeLens.GetLensInfoFromBarCode(this.BarCodeInfo);
            if (null != _BC)
            {
                this.MsgInfo = _BC.LensCode + " | SPH:" + _BC.SPH.ToString() + " | CYL:" + _BC.CYL.ToString() + " | ADD:" + _BC.X_ADD.ToString() + _BC.F_LR;
                this.BarCodeInfo = "";
                this.SaveBarCode(_BC);
            }
        }

        private void SaveBarCode(ComBarCodeLensInfo _BC)
        {
            MWare_Bill _Model = new MWare_Bill()
            {
                BCode = "",
                BDate = System.DateTime.Now,
                BType = "KFBCIPD",
                CusCode = "",
                F_IO = true,
                F_SD = false,
                FBCode = "",
                Maker = USysInfo.UserCode,
                ID = "",
                MName = USysInfo.UserName,
                MType = "L",
                Remark = "",
                WhCode = this._WhCodeInfo,
            };
            _Model.Sub_PD = new MWare_Bill_PD()
            {
                F_LR = _BC.F_LR,
                ID = "",
                LensCode = _BC.LensCode
            };
            MWare_Bill_PD_Detail _Sub = new MWare_Bill_PD_Detail()
            {
                ID = "",
                SubID = 1,
                SPH = _BC.SPH,
                CYL = _BC.CYL,
                X_ADD = _BC.X_ADD,
                Price = 0,
                Qty = 1
            };
            _Model.Sub_PD_Detail = new System.Collections.Generic.List<MWare_Bill_PD_Detail>();
            _Model.Sub_PD_Detail.Add(_Sub);

            DSWare_Bill _DS = new DSWare_Bill();
            _DS.Add(USysInfo.DBCode, USysInfo.LgIndex, _Model, geted =>
                {
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }


                }, null);
        }


        #endregion
    }
}
