
using System;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMB_Lens_ProCost_List : VMList
    {
        #region Property

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set
            {
                _LensCode = value;
                RaisePropertyChanged<string>(() => this.LensCode);
            }
        }

        private string _LensName = "";
        public string LensName
        {
            get { return _LensName; }
            set
            {
                _LensName = value;
                RaisePropertyChanged<string>(() => this.LensName);
            }
        }

        private string _LensCodeCopy = "";
        public string LensCodeCopy
        {
            get { return _LensCodeCopy; }
            set
            {
                _LensCodeCopy = value;
                RaisePropertyChanged<string>(() => this.LensCodeCopy);
            }
        }


        #region ProCode
        private bool _F_Set = false;
        public bool F_Set
        {
            get { return _F_Set; }
            set
            {
                _F_Set = value;
                RaisePropertyChanged("F_Set");
            }
        }

        private bool _JY = false;
        public bool JY
        {
            get { return _JY; }
            set
            {
                _JY = value;
                RaisePropertyChanged("JY");
            }
        }

        private bool _UV = false;
        public bool UV
        {
            get { return _UV; }
            set
            {
                _UV = value;
                RaisePropertyChanged("UV");
            }
        }

        private string _CS = "";
        public string CS
        {
            get { return _CS; }
            set
            {
                _CS = value;
                RaisePropertyChanged<string>(() => this.CS);
            }
        }

        private string _ChB = "";
        public string ChB
        {
            get { return _ChB; }
            set
            {
                _ChB = value;
                RaisePropertyChanged<string>(() => this.ChB);
            }
        }

        private string _CB = "";
        public string CB
        {
            get { return _CB; }
            set
            {
                _CB = value;
                RaisePropertyChanged<string>(() => this.CB);
            }
        }

        private string _JJ = "";
        public string JJ
        {
            get { return _JJ; }
            set
            {
                _JJ = value;
                RaisePropertyChanged<string>(() => this.JJ);
            }
        }

        private string _JS = "";
        public string JS
        {
            get { return _JS; }
            set
            {
                _JS = value;
                RaisePropertyChanged<string>(() => this.JS);
            }
        }

        private string _KK = "";
        public string KK
        {
            get { return _KK; }
            set
            {
                _KK = value;
                RaisePropertyChanged<string>(() => this.KK);
            }
        }

        private string _OP = "";
        public string OP
        {
            get { return _OP; }
            set
            {
                _OP = value;
                RaisePropertyChanged<string>(() => this.OP);
            }
        }

        private string _PG = "";
        public string PG
        {
            get { return _PG; }
            set
            {
                _PG = value;
                RaisePropertyChanged<string>(() => this.PG);
            }
        }

        private string _PiH = "";
        public string PiH
        {
            get { return _PiH; }
            set
            {
                _PiH = value;
                RaisePropertyChanged<string>(() => this.PiH);
            }
        }

        private string _RS = "";
        public string RS
        {
            get { return _RS; }
            set
            {
                _RS = value;
                RaisePropertyChanged<string>(() => this.RS);
            }
        }

        private string _SY = "";
        public string SY
        {
            get { return _SY; }
            set
            {
                _SY = value;
                RaisePropertyChanged<string>(() => this.SY);
            }
        }

        private string _ZK = "";
        public string ZK
        {
            get { return _ZK; }
            set
            {
                _ZK = value;
                RaisePropertyChanged<string>(() => this.ZK);
            }
        }

        #endregion

        private string _InvTitle = "";
        public string InvTitle
        {
            get { return _InvTitle; }
            set
            {
                _InvTitle = value;
                RaisePropertyChanged<string>(() => this.InvTitle);
            }
        }

        private Decimal _P1 = 1;
        public Decimal P1
        {
            get { return _P1; }
            set
            {
                _P1 = value;
                RaisePropertyChanged("P1");
            }
        }

        private Decimal _P2 = 1;
        public Decimal P2
        {
            get { return _P2; }
            set
            {
                _P2 = value;
                RaisePropertyChanged("P2");
            }
        }



        #endregion

        public VMB_Lens_ProCost_List()
            : base("LensCode", "B_Lens_ProCost", "lenscode", isAutoLoad: false)
        {
            IsChildWindow = true;
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        #region Methods
        protected override void OnBillCodeChange(string msg)
        {
            base.OnBillCodeChange(msg);
            this.LensCode = USysTemp.KeyCode;
            this.LensName = USysTemp.KeyName;
            this.SKeyCode = msg;
            this.Search();
        }

        private RelayCommand _CmdAddNew;

        /// <summary>
        /// Gets the CmdAddNew.
        /// </summary>
        public RelayCommand CmdAddNew
        {
            get
            {
                return _CmdAddNew
                    ?? (_CmdAddNew = new RelayCommand(ExecuteCmdAddNew));
            }
        }

        private void ExecuteCmdAddNew()
        {
            this.AddPrice();
        }

        private void AddPrice()
        {
            if (this.ViewErrList != null && this.ViewErrList.Value.Count > 0)
                return;
            var model = new MB_Lens();
            model.Sub_ProCost = new MB_Lens_ProCost()
            {
                CB = this.CB,
                ChB = this.ChB,
                CS = this.CS,
                F_Set = this.F_Set,
                InvTitle = this.InvTitle,
                JJ = this.JJ,
                JS = this.JS,
                JY = this.JY,
                KK = this.KK,
                OP = this.OP,
                PG = this.PG,
                PiH = this.PiH,
                RS = this.RS,
                SY = this.SY,
                UV = this.UV,
                ZK = this.ZK,
                ID = "",
                LensCode = this.SKeyCode,
                P1 = this.P1,
                P2 = this.P2
            };
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusy = true;
            _DS.AddProCost(USysInfo.DBCode, USysInfo.LgIndex, model, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.Search();
            }, null);
        }

        protected override void Delete()
        {
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusy = true;
            _DS.DeleteProCost(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodes, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.Search();
            }, null);
        }

        private RelayCommand _CmdEditPrice;

        /// <summary>
        /// Gets the CmdEditPrice.
        /// </summary>
        public RelayCommand CmdEditPrice
        {
            get
            {
                return _CmdEditPrice
                    ?? (_CmdEditPrice = new RelayCommand(ExecuteCmdEditPrice));
            }
        }

        private void ExecuteCmdEditPrice()
        {
            if (this.GridListSelectedCodes.Count == 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_DeleteNone"));
                return;
            }

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_EditPriceConfirm") + "[" + this.GridListSelectedCodes.Count.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.EditPrice();
            };
            u.Show();
        }

        private void EditPrice()
        {
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusy = true;
            _DS.EditProCost(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodes, P1, P2, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.Search();
            }, null);
        }

        //////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdCopy;

        /// <summary>
        /// Gets the CmdCopy.
        /// </summary>
        public RelayCommand CmdCopy
        {
            get
            {
                return _CmdCopy
                    ?? (_CmdCopy = new RelayCommand(ExecuteCmdCopy));
            }
        }

        private void ExecuteCmdCopy()
        {
            if (this.LensCodeCopy.Trim() == "") return;

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_CopyConfirm") + "[" + this.LensCodeCopy.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.CopyPrice();
            };
            u.Show();
        }

        private void CopyPrice()
        {
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusy = true;
            _DS.CopyProCost(USysInfo.DBCode, USysInfo.LgIndex, this.LensCodeCopy, this.SKeyCode, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.Search();
            }, null);
        }
        #endregion
    }
}
