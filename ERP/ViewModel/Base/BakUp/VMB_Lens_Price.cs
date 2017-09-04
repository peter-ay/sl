
using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public partial class VMB_Lens
    {
        #region Property

        private ComDDsInfo DDsInfoListLensPrice;

        private List<string> _GridListSelectedCodesPrice = new List<string>();

        public List<string> GridListSelectedCodesPrice
        {
            get { return _GridListSelectedCodesPrice; }
            set { _GridListSelectedCodesPrice = value; }
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

        private bool _IsBusyLens_Price = false;
        public bool IsBusyLens_Price
        {
            get { return _IsBusyLens_Price; }
            set
            {
                _IsBusyLens_Price = value;
                RaisePropertyChanged<bool>(() => this.IsBusyLens_Price);
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

        private IEnumerable _DContextListB_Lens_Price;
        public IEnumerable DContextListB_Lens_Price
        {
            get { return _DContextListB_Lens_Price; }
            set
            {
                _DContextListB_Lens_Price = value;
                RaisePropertyChanged("DContextListB_Lens_Price");
            }
        }

        private string _ResultInfoCountB_Lens_Price;
        public string ResultInfoCountB_Lens_Price
        {
            get { return _ResultInfoCountB_Lens_Price; }
            set
            {
                _ResultInfoCountB_Lens_Price = value;
                RaisePropertyChanged("ResultInfoCountB_Lens_Price");
            }
        }

        private string _ResultInfoTimeB_Lens_Price;
        public string ResultInfoTimeB_Lens_Price
        {
            get { return _ResultInfoTimeB_Lens_Price; }
            set
            {
                _ResultInfoTimeB_Lens_Price = value;
                RaisePropertyChanged("ResultInfoTimeB_Lens_Price");
            }
        }

        private DateTime _TimeCountB_Lens_Price;

        protected string _SWhereB_Lens_Price = "";

        #endregion

        #region Methods

        partial void InitMessagesPrice()
        {
            Messenger.Default.Register<USelectedBillCodes>(this, USysMessages.UpdateSelectedCode, (msg) =>
            {
                this.UpdateSelectedCodes(msg);
            });
        }

        private void UpdateSelectedCodes(USelectedBillCodes msg)
        {
            if (msg.VMName != "B_Lens_Price") return;
            if (msg.IsAdd)
            {
                this.GridListSelectedCodesPrice.Add(msg.SelectedBillCode);
            }
            else
            {
                this.GridListSelectedCodesPrice.RemoveAll(s => s == msg.SelectedBillCode);
            }
        }

        private RelayCommand _CmdRefreshLens_Price;

        /// <summary>
        /// Gets the CmdRefreshLens_Price.
        /// </summary>
        public RelayCommand CmdRefreshLens_Price
        {
            get
            {
                return _CmdRefreshLens_Price
                    ?? (_CmdRefreshLens_Price = new RelayCommand(ExecuteCmdRefreshLens_Price));
            }
        }

        private void ExecuteCmdRefreshLens_Price()
        {
            this.LoadLensPrice();
        }

        private void LoadLensPrice()
        {
            this.InitDDs();
            var dds = ComDDSFactory.Get(DDsInfoListLensPrice, DDsList_LoadingData, DDsList_LoadedData);
            DContextListB_Lens_Price = null;
            DContextListB_Lens_Price = dds.Data;
            dds.Load();
        }

        private void InitDDs()
        {
            DDsInfoListLensPrice = new ComDDsInfo()
           {
               DefaultSortKey = "SPH1",
               PageSize = 50
           };
            DDsInfoListLensPrice.QueryName = UDSMethods.V_B_Lens_PriceList;
            DDsInfoListLensPrice.Domaincontext = ComDSFactory.Erp;
            DDsInfoListLensPrice.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            var _SWhere = "LensCode" + USptstr.Str2 + this.SIDCode;
            DDsInfoListLensPrice.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = _SWhere });
            DDsInfoListLensPrice.AddDefaultSorts(DDsInfoListLensPrice.DefaultSortKey);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadingData(object sender, LoadingDataEventArgs geted)
        {
            this.IsBusyLens_Price = true;
            this._TimeCountB_Lens_Price = DateTime.Now;
            geted.LoadBehavior = LoadBehavior.RefreshCurrent;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusyLens_Price = false;

            if (geted.HasError)
            {
                MessageBox.Show(geted.Error.ToString());
                geted.MarkErrorAsHandled();
                return;
            }
            try
            {
                ResultInfoTimeB_Lens_Price = ErpUIText.Get("ERP_Search1") + DateTime.Now.Subtract(this._TimeCountB_Lens_Price).TotalSeconds.ToString("N") + ErpUIText.Get("ERP_Search2");
                ResultInfoCountB_Lens_Price = ErpUIText.Get("ERP_Search3") + (geted.TotalEntityCount).ToString() + ErpUIText.Get("ERP_Search4");
            }
            catch { }
            GridListSelectedCodesPrice.Clear();
        }

        private RelayCommand _CmdAddLens_Price;

        /// <summary>
        /// Gets the CmdAddLens_Price.
        /// </summary>
        public RelayCommand CmdAddLens_Price
        {
            get
            {
                return _CmdAddLens_Price
                    ?? (_CmdAddLens_Price = new RelayCommand(ExecuteCmdAddLens_Price));
            }
        }

        private void ExecuteCmdAddLens_Price()
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
                    LensCode = this.SIDCode,
                    P1 = p1,
                    P2 = p2,
                    SPH1 = s1,
                    SPH2 = s2
                };
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusyLens_Price = true;
            _DS.AddPrice(USysInfo.DBCode, USysInfo.LgIndex, model, geted =>
                {
                    this.IsBusyLens_Price = false;
                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    this.LoadLensPrice();
                }, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand<bool> _CmdGridLens_PriceHeadCheck;

        /// <summary>
        /// Gets the CmdGridLens_PriceHeadCheck.
        /// </summary>
        public RelayCommand<bool> CmdGridLens_PriceHeadCheck
        {
            get
            {
                return _CmdGridLens_PriceHeadCheck
                    ?? (_CmdGridLens_PriceHeadCheck = new RelayCommand<bool>(ExecuteCmdGridLens_PriceHeadCheck));
            }
        }

        private void ExecuteCmdGridLens_PriceHeadCheck(bool parameter)
        {
            try
            {
                foreach (var item in this.DContextListB_Lens_Price)
                {
                    item.GetType().GetProperty("IsSelected").SetValue(item, parameter, null);
                }
            }
            catch { }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdDeleteLens_Price;

        /// <summary>
        /// Gets the CmdDeleteLens_Price.
        /// </summary>
        public RelayCommand CmdDeleteLens_Price
        {
            get
            {
                return _CmdDeleteLens_Price
                    ?? (_CmdDeleteLens_Price = new RelayCommand(ExecuteCmdDeleteLens_Price));
            }
        }

        private void ExecuteCmdDeleteLens_Price()
        {
            if (this.GridListSelectedCodesPrice.Count == 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_DeleteNone"));
                return;
            }

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_DeleteConfirmList") + "[" + this.GridListSelectedCodesPrice.Count.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.DeletePrice();
            };
            u.Show();
        }

        private void DeletePrice()
        {
            DSB_Lens _DS = new DSB_Lens();
            this.IsBusyLens_Price = true;
            _DS.DeletePrice(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodesPrice, geted =>
            {
                this.IsBusyLens_Price = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.LoadLensPrice();
            }, null);
        }
        //////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdCopyLensPrice;

        /// <summary>
        /// Gets the CmdCopyLensPrice.
        /// </summary>
        public RelayCommand CmdCopyLensPrice
        {
            get
            {
                return _CmdCopyLensPrice
                    ?? (_CmdCopyLensPrice = new RelayCommand(ExecuteCmdCopyLensPrice));
            }
        }

        private void ExecuteCmdCopyLensPrice()
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
            this.IsBusyLens_Price = true;
            _DS.CopyPrice(USysInfo.DBCode, USysInfo.LgIndex, this.LensCodeCopy, this.SIDCode, geted =>
            {
                this.IsBusyLens_Price = false;
                if (geted.HasError)
                {
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                this.LoadLensPrice();
            }, null);
        }



        #endregion
    }
}
