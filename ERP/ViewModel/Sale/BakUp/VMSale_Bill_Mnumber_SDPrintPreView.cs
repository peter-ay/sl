using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Bill;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
namespace ERP.ViewModel
{
    public class VMSale_Bill_Mnumber_SDPrintPreView : VMBill
    {
        #region property
        private DSSale_Bill _DSMain = new DSSale_Bill();
        private readonly string _BillType = "XSSD";

        private bool _ICPrice = true;
        public bool ICPrice
        {
            get { return _ICPrice; }
            set
            {
                _ICPrice = value;
                RaisePropertyChanged<bool>(() => this.ICPrice);
            }
        }

        private bool _ICNoPrice = false;
        public bool ICNoPrice
        {
            get { return _ICNoPrice; }
            set
            {
                _ICNoPrice = value;
                RaisePropertyChanged<bool>(() => this.ICNoPrice);
            }
        }

        private string _PrintCode = USysInfo.DBPrefix;
        public string PrintCode
        {
            get { return _PrintCode; }
            set
            {
                _PrintCode = value;
                RaisePropertyChanged<string>(() => this.PrintCode);
            }
        }


        #endregion


        public VMSale_Bill_Mnumber_SDPrintPreView()
            : base("BillCode")
        {
            this.IsChildWindow = true;
            this.InitMessage();
        }

        private void InitMessage()
        {
            Messenger.Default.Register<string>(this, USysMessages.RefreshPreViewSDBillCode, (msg) =>
            {
                this.SIDCode = msg;
                this.Search();
            });
        }


        protected override void InitDDsInfoDerive()
        {
            this.DDsInfoMain.Domaincontext = ComDSFactory.Erp;
            this.DDsInfoMain.QueryName = "GetV_Report_SDQuery";
        }

        protected override void PrepareDContextMain()
        {
            this.DContextMain = new V_Report_SD();
        }

        protected override void PrepareModel()
        {

        }

        ///////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdPrintPreview;

        /// <summary>
        /// Gets the CmdPrintPreview.
        /// </summary>
        public RelayCommand CmdPrintPreview
        {
            get
            {
                return _CmdPrintPreview
                    ?? (_CmdPrintPreview = new RelayCommand(ExecuteCmdPrintPreview));
            }
        }

        private void ExecuteCmdPrintPreview()
        {
            var dc = this.DContextMain as V_Report_SD;
            if (!string.IsNullOrEmpty(dc.DeliveryNum))
            {
                this.PrintSD();
                return;
            }
            this.IsBusy = true;
            _DSMain.DeliverySD(this.SIDCode, false, geted =>
                {
                    this.IsBusy = false;
                    if (geted.HasError)
                    {
                        //USysInfo.ErrMsg = geted.Error.Message;
                        //USysInfo.ErrMsg = ErpUIText.ErrMsg + USysInfo.ErrMsg.Substring(USysInfo.ErrMsg.IndexOf('.') + 1);
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    this.PrintSD();
                }, null);
        }

        private void PrintSD()
        {
            ComPrint.Print(this.SIDCode, _BillType, this.ICPrice == true, false, this.PrintCode.MyStr());
            this.Cancel();
        }

        protected override string PrepareDDsInfoMainDefaultKeyCode()
        {
            throw new NotImplementedException();
        }

        protected override string PrepareDDsInfoMainQueryName()
        {
            throw new NotImplementedException();
        }
    }
}
