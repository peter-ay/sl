
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using ERP.Web.Model;
using System;
using System.Collections.Generic;
using ERP.Web.DomainService.Bill;
using ERP.View;
namespace ERP.ViewModel
{
    public class VMWare_Bill_SO_Pre_Lens_List : VMList
    {
        #region SearchCondition

        private string _PreBarCode = "";
        public string PreBarCode
        {
            get { return _PreBarCode; }
            set { _PreBarCode = value; RaisePropertyChanged("PreBarCode"); }
        }

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set
            {
                _WhCode = value;
                if (this.BillMain != null)
                    this.BillMain.WhCode = _WhCode;
                RaisePropertyChanged("WhCode");
            }
        }

        #endregion

        #region Bill Property

        private V_Ware_Bill_SO_Pre_SD _BillMain;
        public V_Ware_Bill_SO_Pre_SD BillMain
        {
            get { return _BillMain; }
            set
            {
                _BillMain = value;
                RaisePropertyChanged("BillMain");
            }
        }

        //private bool _IsFocusBillWhCode;
        //public bool IsFocusBillWhCode
        //{
        //    get { return _IsFocusBillWhCode; }
        //    set
        //    {
        //        _IsFocusBillWhCode = false;
        //        RaisePropertyChanged("IsFocusBillWhCode");
        //        _IsFocusBillWhCode = true;
        //        RaisePropertyChanged("IsFocusBillWhCode");
        //    }
        //}

        private bool _IsFocusBillBarCodeR;
        public bool IsFocusBillBarCodeR
        {
            get { return _IsFocusBillBarCodeR; }
            set
            {
                _IsFocusBillBarCodeR = false;
                RaisePropertyChanged("IsFocusBillBarCodeR");
                _IsFocusBillBarCodeR = true;
                RaisePropertyChanged("IsFocusBillBarCodeR");
            }
        }

        private bool _IsFocusBillBarCodeL;
        public bool IsFocusBillBarCodeL
        {
            get { return _IsFocusBillBarCodeL; }
            set
            {
                _IsFocusBillBarCodeL = false;
                RaisePropertyChanged("IsFocusBillBarCodeL");
                _IsFocusBillBarCodeL = true;
                RaisePropertyChanged("IsFocusBillBarCodeL");
            }
        }

        private bool _IsFocusBillBarCode;
        public bool IsFocusBillBarCode
        {
            get { return _IsFocusBillBarCode; }
            set
            {
                _IsFocusBillBarCode = false;
                RaisePropertyChanged("IsFocusBillBarCode");
                _IsFocusBillBarCode = true;
                RaisePropertyChanged("IsFocusBillBarCode");
            }
        }

        #endregion

        public VMWare_Bill_SO_Pre_Lens_List()
            : base("ID", "Ware_Bill_SO_Pre_Lens")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            this.BillMain = new V_Ware_Bill_SO_Pre_SD() { EditState = 1, QtyR = 1, QtyL = 1 };
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.PreBarCode = "";
            this.WhCode = "";
            this.F_SCTime = true;
            this.IsCheckAll = false;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            _SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            _SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            _SWhere += USptstr.Str1 + "PreBarCode" + USptstr.Str2 + this.PreBarCode;
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "SCCheck" + USptstr.Str2 + this._ConCheck;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("BCode");
        }

        protected override void ViewKeyDown(KeyEventArgs parameter)
        {
            //base.ViewKeyDown(parameter);
            switch (parameter.Key)
            {
                //case Key.Enter:
                //    this.ExecuteCmdSearch();
                //    parameter.Handled = true;
                //    break;
                case Key.Escape:
                    this.ExecuteCmdExit();
                    //parameter.Handled = true;
                    break;
            }
        }

        //protected override void GridListClickID(System.ServiceModel.DomainServices.Client.Entity parameter)
        //{
        //    var _DC = parameter as V_Ware_Bill_SO_Pre_Lens;
        //    var _ID = _DC.ID;
        //    string _FunCode = "Ware_Bill_SO_SD";
        //    if (_DC.BType == "KFSOPD")
        //    {
        //        _FunCode = "Ware_Bill_SO_PD";
        //    }
        //    var _VName = ErpUIText.Get(_FunCode);
        //    ComAssignWins.Assign(_ID, _FunCode, _VName);
        //}

        //protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        //{
        //    var _DC = parameter as V_Ware_Bill_SO_Pre_Lens;
        //    var _FCode = "Sale_Order_SD";
        //    if (_DC.BType == "KFSOPD")
        //    {
        //        _FCode = "Sale_Order_PD";
        //    }
        //    var _VName = ErpUIText.Get(_FCode);
        //    var _IDCode = _DC.FBCode;
        //    ComAssignWins.Assign(_IDCode, _FCode, _VName);
        //}


        #region Methods

        private RelayCommand<KeyEventArgs> _CmdBarCodeEnter;

        /// <summary>
        /// Gets the CmdBarCodeEnter.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdBarCodeEnter
        {
            get
            {
                return _CmdBarCodeEnter
                    ?? (_CmdBarCodeEnter = new RelayCommand<KeyEventArgs>(ExecuteCmdBarCodeEnter));
            }
        }

        private void ExecuteCmdBarCodeEnter(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                this.AddBarCodePre();
            }
            catch { }
        }

        private void AddBarCodePre()
        {
            MWare_Bill model = new MWare_Bill()
            {
                BarCodeL = this.BillMain.BarCodeL,
                BarCodeR = this.BillMain.BarCodeR,
                BarCodeSOPre = this.BillMain.BarCodeSOPre,
                BCode = "",
                BDate = DateTime.Now,
                BType = "KFPSOSD",
                CusCode = "",
                F_SD = true,
                FBCode = "",
                F_IO = false,
                ID = "",
                Maker = USysInfo.UserCode,
                MName = USysInfo.UserName,
                MType = "L",
                Remark = "",
                SpCode = "",
                Sub_SD = new List<MWare_Bill_SD>(),
                WhCode = this.BillMain.WhCode,
            };

            MWare_Bill_SD model_R = new MWare_Bill_SD()
            {
                ID = "",
                LensCode = this.BillMain.LensCodeR,
                SPH = this.BillMain.SPHR.Value,
                CYL = this.BillMain.CYLR.Value,
                X_ADD = this.BillMain.X_ADDR.Value,
                F_LR = "R",
                Qty = this.BillMain.QtyR.Value,
                Price = 0,
            };

            model.Sub_SD.Add(model_R);

            MWare_Bill_SD model_L = new MWare_Bill_SD()
            {
                ID = "",
                LensCode = this.BillMain.LensCodeL,
                SPH = this.BillMain.SPHL.Value,
                CYL = this.BillMain.CYLL.Value,
                X_ADD = this.BillMain.X_ADDL.Value,
                F_LR = "L",
                Qty = this.BillMain.QtyL.Value,
                Price = 0,
            };

            model.Sub_SD.Add(model_L);

            model.Sub_Extend = new MWare_Bill_Extend()
            {
                ID = "",
                LensCodeR = this.BillMain.LensCodeR,
                SPHR = this.BillMain.SPHR.Value,
                CYLR = this.BillMain.CYLR.Value,
                X_ADDR = this.BillMain.X_ADDR.Value,
                LensCodeL = this.BillMain.LensCodeL,
                SPHL = this.BillMain.SPHL.Value,
                CYLL = this.BillMain.CYLL.Value,
                X_ADDL = this.BillMain.X_ADDL.Value,
                SCode = "",
                SumQty = this.BillMain.QtyR.Value + this.BillMain.QtyL.Value
            };

            DSWare_Bill _DS = new DSWare_Bill();
            _DS.Add(USysInfo.DBCode, USysInfo.LgIndex, model, geted =>
                {
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }

                    this.ResetBillMain();
                }, null);
        }

        private void ResetBillMain()
        {
            var _whcode = this.BillMain.WhCode;
            this.BillMain = new V_Ware_Bill_SO_Pre_SD() { EditState = 1, QtyR = 1, QtyL = 1, WhCode = _whcode };
            this.IsFocusBillBarCodeR = true;
            this.Search();
        }


        //
        private RelayCommand<KeyEventArgs> _CmdBarCodeREnter;

        /// <summary>
        /// Gets the CmdBarCodeREnter.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdBarCodeREnter
        {
            get
            {
                return _CmdBarCodeREnter
                    ?? (_CmdBarCodeREnter = new RelayCommand<KeyEventArgs>(ExecuteCmdBarCodeREnter));
            }
        }

        private void ExecuteCmdBarCodeREnter(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                var _LensR = ComBarCodeLens.GetLensInfoFromBarCode(this.BillMain.BarCodeR);
                this.BillMain.LensCodeR = _LensR.LensCode;
                this.BillMain.SPHR = _LensR.SPH;
                this.BillMain.CYLR = _LensR.CYL;
                this.BillMain.X_ADDR = _LensR.X_ADD;
                this.IsFocusBillBarCodeL = true;
            }
            catch { }
        }

        //
        private RelayCommand<KeyEventArgs> _CmdBarCodeLEnter;

        /// <summary>
        /// Gets the CmdBarCodeLEnter.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdBarCodeLEnter
        {
            get
            {
                return _CmdBarCodeLEnter
                    ?? (_CmdBarCodeLEnter = new RelayCommand<KeyEventArgs>(ExecuteCmdBarCodeLEnter));
            }
        }

        private void ExecuteCmdBarCodeLEnter(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            try
            {
                var _LensL = ComBarCodeLens.GetLensInfoFromBarCode(this.BillMain.BarCodeL);
                this.BillMain.LensCodeL = _LensL.LensCode;
                this.BillMain.SPHL = _LensL.SPH;
                this.BillMain.CYLL = _LensL.CYL;
                this.BillMain.X_ADDL = _LensL.X_ADD;
                this.IsFocusBillBarCode = true;
            }
            catch { }
        }
        #endregion
    }
}
