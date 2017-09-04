
using System;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMB_Lens_Price_List : VMList
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


        #region SCA-Dia-P1P2

        private int _SPH1 = 0;
        public int SPH1
        {
            get { return _SPH1; }
            set
            {
                _SPH1 = value;
                RaisePropertyChanged("SPH1");
            }
        }

        private int _SPH2 = 0;
        public int SPH2
        {
            get { return _SPH2; }
            set
            {
                _SPH2 = value;
                RaisePropertyChanged("SPH2");
            }
        }

        private int _CYL1 = 0;
        public int CYL1
        {
            get { return _CYL1; }
            set
            {
                _CYL1 = value;
                RaisePropertyChanged("CYL1");
            }
        }

        private int _CYL2 = 0;
        public int CYL2
        {
            get { return _CYL2; }
            set
            {
                _CYL2 = value;
                RaisePropertyChanged("CYL2");
            }
        }

        private int _ADD1 = 0;
        public int ADD1
        {
            get { return _ADD1; }
            set
            {
                _ADD1 = value;
                RaisePropertyChanged("ADD1");
            }
        }

        private int _ADD2 = 0;
        public int ADD2
        {
            get { return _ADD2; }
            set
            {
                _ADD2 = value;
                RaisePropertyChanged("ADD2");
            }
        }

        private int _Dia = 65;
        public int Dia
        {
            get { return _Dia; }
            set
            {
                _Dia = value;
                RaisePropertyChanged("Dia");
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

        #endregion

        public VMB_Lens_Price_List()
            : base("LensCode", "B_Lens_Price", "lenscode", isAutoLoad: false)
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
            var s1 = this.SPH1;
            var s2 = this.SPH2;
            var c1 = this.CYL1;
            var c2 = this.CYL2;
            var a1 = this.ADD1;
            var a2 = this.ADD2;
            var dia = this.Dia;
            var p1 = this.P1;
            var p2 = this.P2;
            var model = new MB_Lens();
            model.Sub_Price = new MB_Lens_Price()
            {
                ADD1 = a1,
                ADD2 = a2,
                CYL1 = c1,
                CYL2 = c2,
                Dia = dia,
                ID = "",
                LensCode = this.SKeyCode,
                P1 = p1,
                P2 = p2,
                SPH1 = s1,
                SPH2 = s2
            };
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusy = true;
            _DS.AddPrice(USysInfo.DBCode, USysInfo.LgIndex, model, geted =>
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
            _DS.DeletePrice(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodes, geted =>
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
            _DS.EditPrice(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodes, P1, P2, geted =>
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
            _DS.CopyPrice(USysInfo.DBCode, USysInfo.LgIndex, this.LensCodeCopy, this.SKeyCode, geted =>
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
