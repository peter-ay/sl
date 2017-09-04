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
    public class VMSale_Order_SD_PrintPreView : VMBill
    {
        private string _YN = "2";

        public string YN
        {
            get { return _YN; }
            set { _YN = value; }
        }

        private bool _IsCheckY = false;
        public bool IsCheckY
        {
            get { return _IsCheckY; }
            set { _IsCheckY = value; RaisePropertyChanged("IsCheckY"); }
        }

        private bool _IsCheckN = true;
        public bool IsCheckN
        {
            get { return _IsCheckN; }
            set { _IsCheckN = value; RaisePropertyChanged("IsCheckN"); }
        }

        public VMSale_Order_SD_PrintPreView()
            : base("")
        {
            this.IsChildWindow = true;
            //this.InitMessage();
        }

        private void InitMessage()
        {
            //Messenger.Default.Register<string>(this, USysMessages.RefreshPreViewSDBillCode, (msg) =>
            //{
            //    this.SIDCode = msg;
            //    this.Search();
            //});
        }

        #region CmdRBCdiYN

        private RelayCommand<string> _CmdRBCdiYN;

        /// <summary>
        /// Gets the CmdRBCdiYN.
        /// </summary>
        public RelayCommand<string> CmdRBCdiYN
        {
            get
            {
                return _CmdRBCdiYN
                    ?? (_CmdRBCdiYN = new RelayCommand<string>(ExecuteCmdRBCdiYN));
            }
        }

        private void ExecuteCmdRBCdiYN(string parameter)
        {
            _YN = parameter;
        }

        #endregion
    }
}
