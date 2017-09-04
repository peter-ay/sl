
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using ERP.Web.DomainService.Erp;
using ERP.View;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
namespace ERP.ViewModel
{
    public class VMSale_Delivery_ScanPrint_List : VMList
    {
        #region SearchCondition

        //private string _PrintCode = "";
        //public string PrintCode
        //{
        //    get { return _PrintCode; }
        //    set { _PrintCode = value; RaisePropertyChanged("PrintCode"); }
        //}

        private string _DN = "";
        public string DN
        {
            get { return _DN; }
            set { _DN = value; RaisePropertyChanged("DN"); }
        }

        //IsCheckPPY
        private bool _IsCheckPPY = true;
        public bool IsCheckPPY
        {
            get { return _IsCheckPPY; }
            set { _IsCheckPPY = value; RaisePropertyChanged("IsCheckPPY"); }
        }
        //IsCheckPBFY
        private bool _IsCheckPBFY = true;
        public bool IsCheckPBFY
        {
            get { return _IsCheckPBFY; }
            set { _IsCheckPBFY = value; RaisePropertyChanged("IsCheckPBFY"); }
        }

        //private int _SCDelivery = -1;

        #endregion

        public VMSale_Delivery_ScanPrint_List()
            : base("ID", "Sale_Delivery_ScanPrint", isAutoLoad: false)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            //this.D1 = System.DateTime.Now.AddYears(-2).ToShortDateString();
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            //this.IsCheckDeliveryAll = true;
            //this._SCDelivery = -1;
            //this.BCodeSale = "";
            //this.OBCodeSale = "";
            //this.DN = "";
            //this.CusCode = "";
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            //_SWhere += USptstr.Str1 + "F_SCTime" + USptstr.Str2 + (this.F_SCTime ? "1" : "0");
            //_SWhere += USptstr.Str1 + "D1" + USptstr.Str2 + this.D1;
            //_SWhere += USptstr.Str1 + "D2" + USptstr.Str2 + this.D2;
            //_SWhere += USptstr.Str1 + "BCodeSale" + USptstr.Str2 + this.BCodeSale;
            //_SWhere += USptstr.Str1 + "DN" + USptstr.Str2 + this.DN;
            //_SWhere += USptstr.Str1 + "CusCode" + USptstr.Str2 + this.CusCode;
            //_SWhere += USptstr.Str1 + "SCDelivery" + USptstr.Str2 + this._SCDelivery;
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
                    parameter.Handled = true;
                    break;
            }
        }

        #region Methods

        #region BCodeKeyDown

        private RelayCommand<KeyEventArgs> _OnBCodeKeyDown;

        /// <summary>
        /// Gets the OnBCodeKeyDown.
        /// </summary>
        public RelayCommand<KeyEventArgs> OnBCodeKeyDown
        {
            get
            {
                return _OnBCodeKeyDown
                    ?? (_OnBCodeKeyDown = new RelayCommand<KeyEventArgs>(ExecuteOnBCodeKeyDown));
            }
        }

        private void ExecuteOnBCodeKeyDown(KeyEventArgs parameter)
        {
            if (parameter.Key == Key.Enter)
            {
                this.LoadDeliveryListByBCode();
            }
        }



        private void LoadDeliveryListByBCode()
        {
            if (string.IsNullOrEmpty(this.BCode))
                return;

            try
            {
                var _DC = this.DContextList as IEnumerable<Entity>;
                if (_DC != null)
                {
                    if (_DC.Where(it => ((V_Sale_Delivery_Lens)it).BCodeXSDD.MyStr() == this.BCode.MyStr()).Count() > 0)
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageErp.ErrorMessage(ex.Message);
                return;
            }
            //
            var dds_LoadDeliveryListByBCode = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_Delivery_LensListQuery", dds_LoadDeliveryListByBCode_LoadedData, true);
            dds_LoadDeliveryListByBCode.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = USptstr.Str1 + "BCodeXSDD_Scan" + USptstr.Str2 + this.BCode });
            dds_LoadDeliveryListByBCode.Load();
        }

        private void dds_LoadDeliveryListByBCode_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageErp.ErrorMessage(e.Error.Message.GetErrMsg());
                e.MarkErrorAsHandled();
                return;
            }

            if (e.TotalEntityCount <= 0)
            {
                MessageErp.InfoMessage("[" + this.BCode + "]" + ErpUIText.Get("Sale_Delivery_ScanPrint_List_Err_DeliveryNotExit"));
                return;
            }


            IEnumerable<Entity> _DC = this.DContextList as IEnumerable<Entity>;
            if (_DC != null)
            {
                _DC = _DC.Union(e.Entities);
            }
            else
            {
                _DC = e.Entities;
            }
            this.DContextList = _DC;

        }

        #endregion


        #region DNKeyDown

        private RelayCommand<KeyEventArgs> _OnDNKeyDown;

        public RelayCommand<KeyEventArgs> OnDNKeyDown
        {
            get
            {
                return _OnDNKeyDown
                    ?? (_OnDNKeyDown = new RelayCommand<KeyEventArgs>(ExecuteOnDNKeyDown));
            }
        }

        private void ExecuteOnDNKeyDown(KeyEventArgs parameter)
        {
            if (parameter.Key == Key.Enter)
            {
                this.LoadDeliveryListByDN();
            }
        }

        private void LoadDeliveryListByDN()
        {
            if (string.IsNullOrEmpty(this.DN))
                return;

            try
            {
                var _DC = this.DContextList as IEnumerable<Entity>;
                if (_DC != null)
                {
                    if (_DC.Where(it => ((V_Sale_Delivery_Lens)it).DN.MyStr() == this.DN.MyStr()).Count() > 0)
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageErp.ErrorMessage(ex.Message);
                return;
            }
            //
            var dds_LoadDeliveryListByDN = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_Delivery_LensListQuery", dds_LoadDeliveryListByDN_LoadedData, true);
            dds_LoadDeliveryListByDN.QueryParameters.Add(new Parameter() { ParameterName = "sWhere", Value = USptstr.Str1 + "DN_Scan" + USptstr.Str2 + this.DN });
            dds_LoadDeliveryListByDN.Load();
        }

        private void dds_LoadDeliveryListByDN_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageErp.ErrorMessage(e.Error.Message.GetErrMsg());
                e.MarkErrorAsHandled();
                return;
            }

            if (e.TotalEntityCount <= 0)
            {
                MessageErp.InfoMessage("[" + this.DN + "]" + ErpUIText.Get("Sale_Delivery_ScanPrint_List_Err_DeliveryNotExit"));
                return;
            }


            IEnumerable<Entity> _DC = this.DContextList as IEnumerable<Entity>;
            if (_DC != null)
            {
                _DC = _DC.Union(e.Entities);
            }
            else
            {
                _DC = e.Entities;
            }
            this.DContextList = _DC;

        }

        #endregion

        protected override void Print()
        {
            var _DC = this.DContextList as IEnumerable<Entity>;
            if (_DC == null || _DC.Count() <= 0)
            {
                return;
            }

            List<string> codes = new List<string>();
            //codes.Add(this.CurrentIDCode);
            foreach (V_Sale_Delivery_Lens item in _DC)
            {
                codes.Add(item.BCodeSaleID);
            }

            //var _PCode = this.PrintCode;
            var _F_IsBigFormat = this.IsCheckPBFY != true;
            var _F_IsShowMoney = this.IsCheckPPY == true;
            this.PrintXSSD(codes, _F_IsShowMoney, _F_IsBigFormat);
        }

        #region CmdDeleteAll
        private RelayCommand _CmdDeleteAll;

        /// <summary>
        /// Gets the CmdDeleteAll.
        /// </summary>
        public RelayCommand CmdDeleteAll
        {
            get
            {
                return _CmdDeleteAll
                    ?? (_CmdDeleteAll = new RelayCommand(ExecuteCmdDeleteAll));
            }
        }

        private void ExecuteCmdDeleteAll()
        {
            MessageWindowErp c = new MessageWindowErp(ErpUIText.Get("Sale_Delivery_ScanPrint_List_DeleteAllAsk"), MessageWindowErp.MessageType.Confirm);
            c.Closed += (s1, e1) =>
            {
                if (c.DialogResult == true)
                    this.DContextList = null;
            };
            c.Show();
        }


        #endregion


        #region CmdDeleteSelected

        private RelayCommand _CmdDeleteSelected;

        /// <summary>
        /// Gets the CmdDeleteSelected.
        /// </summary>
        public RelayCommand CmdDeleteSelected
        {
            get
            {
                return _CmdDeleteSelected
                    ?? (_CmdDeleteSelected = new RelayCommand(ExecuteCmdDeleteSelected));
            }
        }

        private void ExecuteCmdDeleteSelected()
        {
            try
            {
                var _DC = this.DContextList as IEnumerable<Entity>;
                if (_DC != null)
                {
                    var _DC2 = _DC.Where(it => ((V_Sale_Delivery_Lens)it).IsSelected != true);
                    this.DContextList = _DC2;
                }
            }
            catch (Exception ex)
            {
                MessageErp.ErrorMessage(ex.Message);
                return;
            }
        }


        #endregion


        #endregion
    }
}
