
using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.Entity;
using ERP.Web.Model;
using System.Windows;
namespace ERP.ViewModel
{
    public class VMWare_Bill_SO_SD : VMBill
    {
        #region property

        private V_Ware_Bill_SO_SD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_SO_SD;
            }
        }

        #region ImageSource

        private string _ImageSourceR1 = "";
        public string ImageSourceR1
        {
            get { return _ImageSourceR1; }
            set
            {
                _ImageSourceR1 = value;
                RaisePropertyChanged("ImageSourceR1");
            }
        }

        private string _ImageSourceR2 = "";
        public string ImageSourceR2
        {
            get { return _ImageSourceR2; }
            set
            {
                _ImageSourceR2 = value;
                RaisePropertyChanged("ImageSourceR2");
            }
        }

        private string _ImageSourceR3 = "";
        public string ImageSourceR3
        {
            get { return _ImageSourceR3; }
            set
            {
                _ImageSourceR3 = value;
                RaisePropertyChanged("ImageSourceR3");
            }
        }

        private string _ImageSourceL1 = "";
        public string ImageSourceL1
        {
            get { return _ImageSourceL1; }
            set
            {
                _ImageSourceL1 = value;
                RaisePropertyChanged("ImageSourceL1");
            }
        }

        private string _ImageSourceL2 = "";
        public string ImageSourceL2
        {
            get { return _ImageSourceL2; }
            set
            {
                _ImageSourceL2 = value;
                RaisePropertyChanged("ImageSourceL2");
            }
        }

        private string _ImageSourceL3 = "";
        public string ImageSourceL3
        {
            get { return _ImageSourceL3; }
            set
            {
                _ImageSourceL3 = value;
                RaisePropertyChanged("ImageSourceL3");
            }
        }

        private static string _ImageUrl = ComOpenURL.GetRootURL() + @"Import/Images/Base/Lens/" + USysInfo.DBCode;

        #endregion

        //IsShowUploadImage
        private Visibility _IsShowUploadImage = Visibility.Collapsed;
        public Visibility IsShowUploadImage
        {
            get { return _IsShowUploadImage; }
            set
            {
                _IsShowUploadImage = value;
                RaisePropertyChanged("IsShowUploadImage");
            }
        }

        #endregion

        public VMWare_Bill_SO_SD()
            : base("ID", "Ware_Bill_SO_SD")
        {
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            this.IsShowUploadImage = Visibility.Collapsed;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsShowUploadImage = Visibility.Visible;
                    break;
                case UBillState.Drop:

                    break;

                case UBillState.New:

                    break;

                case UBillState.Edit:

                    //if (string.IsNullOrEmpty(_DC.Checker))
                    //{
                    //    this.FixEditACBug();
                    //}

                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.LensCodeR = " " + this._DC.LensCodeR;
            this._DC.LensCodeR = this._DC.LensCodeR.Trim();
            this._DC.LensCodeL = " " + this._DC.LensCodeL;
            this._DC.LensCodeL = this._DC.LensCodeL.Trim();
            ///////////////////////////////////////////////
            this._DC.WhCode = " " + this._DC.WhCode;
            this._DC.WhCode = this._DC.WhCode.Trim();
            /////////////////////////////////////////////// 
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            _CM.MType = "L";
            _CM.F_IO = false;
            _CM.F_SD = true;
            //
            _CM.Sub_SD = new List<MWare_Bill_SD>();
            MWare_Bill_SD sub_SD = null;
            for (int i = 0; i <= 1; i++)
            {
                sub_SD = new MWare_Bill_SD()
                {
                    ID = _CM.ID,
                    CYL = i == 0 ? _DC.CYLR.Value : _DC.CYLL.Value,
                    Qty = i == 0 ? _DC.QtyR.Value : _DC.QtyL.Value,
                    SPH = i == 0 ? _DC.SPHR.Value : _DC.SPHL.Value,
                    LensCode = i == 0 ? _DC.LensCodeR.Trim() : _DC.LensCodeL.Trim(),
                    X_ADD = i == 0 ? _DC.X_ADDR.Value : _DC.X_ADDL.Value,
                    Price = 0,
                    F_LR = i == 0 ? "R" : "L",
                };
                _CM.Sub_SD.Add(sub_SD);
            }
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill";
        }

        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();

            this.ResetImageSource();
        }

        private void ResetImageSource()
        {
            Random random = new Random();
            int randomValue = random.Next(1000000);

            this.ImageSourceR1 = _ImageUrl + this._DC.LensCodeRSale + "Image1.jpg" + "?id=" + randomValue;
            this.ImageSourceR2 = _ImageUrl + this._DC.LensCodeRSale + "Image2.jpg" + "?id=" + randomValue;
            this.ImageSourceR3 = _ImageUrl + this._DC.LensCodeRSale + "Image3.jpg" + "?id=" + randomValue;
            this.ImageSourceL1 = _ImageUrl + this._DC.LensCodeLSale + "Image1.jpg" + "?id=" + randomValue;
            this.ImageSourceL2 = _ImageUrl + this._DC.LensCodeLSale + "Image2.jpg" + "?id=" + randomValue;
            this.ImageSourceL3 = _ImageUrl + this._DC.LensCodeLSale + "Image3.jpg" + "?id=" + randomValue;
        }

        #region CmdGetImage

        private RelayCommand<string> _CmdGetImage;

        /// <summary>
        /// Gets the CmdGetImage.
        /// </summary>
        public RelayCommand<string> CmdGetImage
        {
            get
            {
                return _CmdGetImage
                    ?? (_CmdGetImage = new RelayCommand<string>(ExecuteCmdGetImage));
            }
        }

        private void ExecuteCmdGetImage(string parameter)
        {
            switch (parameter)
            {
                case "R1":
                    ComOpenURL.OpenByFullURL(this.ImageSourceR1);
                    break;
                case "R2":
                    ComOpenURL.OpenByFullURL(this.ImageSourceR2);
                    break;
                case "R3":
                    ComOpenURL.OpenByFullURL(this.ImageSourceR3);
                    break;
                case "L1":
                    ComOpenURL.OpenByFullURL(this.ImageSourceL1);
                    break;
                case "L2":
                    ComOpenURL.OpenByFullURL(this.ImageSourceL2);
                    break;
                case "L3":
                    ComOpenURL.OpenByFullURL(this.ImageSourceL3);
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
