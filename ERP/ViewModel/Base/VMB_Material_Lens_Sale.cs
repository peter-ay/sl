
using GalaSoft.MvvmLight.Command;
using ERP.Common;
using ERP.Utility;
using ERP.Web.Entity;
using System.Windows;
using ERP.Web.DomainService.Bill;
using System.Windows.Controls;
using System.IO;
using ERP.View;
using System;
using ERP.Web.Model;
using System.ServiceModel.DomainServices.Client;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public class VMB_Material_Lens_Sale : VMBill
    {
        #region Property

        private V_B_Material_Lens _DC
        {
            get
            {
                return this.DContextMain as V_B_Material_Lens;
            }
        }

        //IsEnableLensType
        private bool _IsEnableLensType = false;
        public bool IsEnableLensType
        {
            get { return _IsEnableLensType; }
            set
            {
                _IsEnableLensType = value;
                RaisePropertyChanged("IsEnableLensType");
            }
        }


        #region IsCheckLensType
        private bool _IsCheckLensTypeST = true;
        public bool IsCheckLensTypeST
        {
            get { return _IsCheckLensTypeST; }
            set
            {
                _IsCheckLensTypeST = value;
                RaisePropertyChanged("IsCheckLensTypeST");
            }
        }

        private bool _IsCheckLensTypeRX = false;
        public bool IsCheckLensTypeRX
        {
            get { return _IsCheckLensTypeRX; }
            set
            {
                _IsCheckLensTypeRX = value;
                RaisePropertyChanged("IsCheckLensTypeRX");
            }
        }

        private bool _IsCheckLensTypeOT = false;
        public bool IsCheckLensTypeOT
        {
            get { return _IsCheckLensTypeOT; }
            set
            {
                _IsCheckLensTypeOT = value;
                RaisePropertyChanged("IsCheckLensTypeOT");
            }
        }
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

        //IsShowLoadingPCode
        //private Visibility _IsShowLoadingPCode = Visibility.Collapsed;
        //public Visibility IsShowLoadingPCode
        //{
        //    get { return _IsShowLoadingPCode; }
        //    set
        //    {
        //        _IsShowLoadingPCode = value;
        //        RaisePropertyChanged("IsShowLoadingPCode");
        //    }
        //}

        #region ImageSource

        private string _ImageSource1 = "";
        public string ImageSource1
        {
            get { return _ImageSource1; }
            set
            {
                _ImageSource1 = value;
                RaisePropertyChanged("ImageSource1");
            }
        }

        private string _ImageSource2 = "";
        public string ImageSource2
        {
            get { return _ImageSource2; }
            set
            {
                _ImageSource2 = value;
                RaisePropertyChanged("ImageSource2");
            }
        }

        private string _ImageSource3 = "";
        public string ImageSource3
        {
            get { return _ImageSource3; }
            set
            {
                _ImageSource3 = value;
                RaisePropertyChanged("ImageSource3");
            }
        }

        private static string _ImageUrl = ComOpenURL.GetRootURL() + @"Import/Images/Base/Lens/" + USysInfo.DBCode;

        #endregion

        #endregion

        public VMB_Material_Lens_Sale()
            : base("LensCode", "B_Material_Lens_Sale")
        {
            this.IsChildWindow = true;
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<V_B_Material_Lens>(this, this.VMName + "_FillFromPCode", (msg) =>
            {
                this.ReFillFromPCode(msg);
            });
        } 

        private void ReFillFromPCode(V_B_Material_Lens msg)
        {
            //ComCopyProperties.Copy(this._DC.DContextMain, msg);
            this._DC.LensLevel = 2;
            this._DC.PCode = msg.LensCode;
            this._DC.SPH1 = msg.SPH1;
            this._DC.SPH2 = msg.SPH2;
            this._DC.CYL1 = msg.CYL1;
            this._DC.CYL2 = msg.CYL2;
            this._DC.X_ADD1 = msg.X_ADD1;
            this._DC.X_ADD2 = msg.X_ADD2;
            this._DC.Materials = msg.Materials;
            this._DC.RIndex = msg.RIndex;
            this._DC.Design = msg.Design;
            this._DC.Usage = msg.Usage;
            this._DC.Focus = msg.Focus;
            this._DC.Material = msg.Material;
            this._DC.Density = msg.Density;
            this._DC.Abbe = msg.Abbe;
            this._DC.UVCutOff = msg.UVCutOff;
            this._DC.PrismAvailability = msg.PrismAvailability;
            this._DC.Colour = msg.Colour;
            this._DC.Corridor = msg.Corridor;
            this._DC.Fitting = msg.Fitting;
            this._DC.LensType = msg.LensType;
            this._DC.F_HardCoat = msg.F_HardCoat;
            this._DC.F_Tintage = msg.F_Tintage;
            this._DC.F_Coating = msg.F_Coating;
            this._DC.F_Decenter = msg.F_Decenter;
            this._DC.F_Prism = msg.F_Prism;
            this._DC.F_Base = msg.F_Base;
            this._DC.F_LR = msg.F_LR;
            this._DC.F_CA = msg.F_CA;
            this._DC.F_Pur = msg.F_Pur;
            this._DC.Sort1 = msg.Sort1;
            this._DC.Sort2 = msg.Sort2;
            this._DC.Transmistion1 = msg.Transmistion1;
            this._DC.Transmistion2 = msg.Transmistion2;
            this._DC.Purpose = msg.Purpose;
            this._DC.Criterion1 = msg.Criterion1;
            this._DC.Criterion2 = msg.Criterion2;
            this._DC.ReformulatedPower = msg.ReformulatedPower;
            this._DC.Ctvalue = msg.Ctvalue;
        }

        #region Methods

        protected override void PrepareDContextMain()
        {
            this.DContextMain = new V_B_Material_Lens();
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MB_Material_Lens();
        }

        protected override void New()
        {
            base.New();
            this._DC.LensLevel = 2;
        }

        protected override bool VerifySave()
        {

            if (string.IsNullOrEmpty(_DC.LensCode.Trim()))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_LensCodeNull"));
                return false;
            }

            return true;
        }

        protected override void PrepareModelToSave()
        {
            base.PrepareModelToSave();
            var _CM = this.CurrentModel as MB_Material_Lens;
            _CM.LensLevel = 2;
        }

        protected override string PrepareDSBill()
        {
            return "B_Material_Lens";
        }

        ///////////////////////////////////////////////////////////////////////
        private RelayCommand<string> _CmdRBCdiLensType;

        /// <summary>
        /// Gets the CmdRBCdiLensType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiLensType
        {
            get
            {
                return _CmdRBCdiLensType
                    ?? (_CmdRBCdiLensType = new RelayCommand<string>(ExecuteCmdRBCdiLensType));
            }
        }

        private void ExecuteCmdRBCdiLensType(string parameter)
        {
            try
            {
                var _DC = this.DContextMain as V_B_Material_Lens;
                _DC.LensType = parameter;
            }
            catch { }
        }

        /////////////////////////////////////////////////////////////////////////////
        protected override void OnLoadMainEnd()
        {
            base.OnLoadMainEnd();

            Random random = new Random();
            int randomValue = random.Next(1000000);

            this.ImageSource1 = _ImageUrl + this.CurrentIDCode + "Image1.jpg" + "?id=" + randomValue;
            this.ImageSource2 = _ImageUrl + this.CurrentIDCode + "Image2.jpg" + "?id=" + randomValue;
            this.ImageSource3 = _ImageUrl + this.CurrentIDCode + "Image3.jpg" + "?id=" + randomValue;

            try
            {
                var _DC = this.DContextMain as V_B_Material_Lens;
                switch (_DC.LensType)
                {
                    case "ST":
                        this.IsCheckLensTypeST = true;
                        break;
                    case "RX":
                        this.IsCheckLensTypeRX = true;
                        break;
                    default:
                        this.IsCheckLensTypeOT = true;
                        break;
                }
            }
            catch { }
        }
        ////////////////////////////////////////////////////////////////////////////
        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnableLensType = false;
            this.IsShowUploadImage = Visibility.Collapsed;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsShowUploadImage = Visibility.Visible;
                    break;
                case UBillState.Edit:
                    this.IsEnableLensType = true;
                    break;
                case UBillState.Drop:
                    break;
                case UBillState.New:
                    this.IsEnableLensType = true;
                    this.IsCheckLensTypeST = true;
                    break;
            }
        }

        protected override void FixEditACBug()
        {
            this._DC.Focus = " " + this._DC.Focus;
            this._DC.Focus = this._DC.Focus.Trim();

            this._DC.RIndex = " " + this._DC.RIndex;
            this._DC.RIndex = this._DC.RIndex.Trim();

            this._DC.Design = " " + this._DC.Design;
            this._DC.Design = this._DC.Design.Trim();

            this._DC.Materials = " " + this._DC.Materials;
            this._DC.Materials = this._DC.Materials.Trim();

            this._DC.Usage = " " + this._DC.Usage;
            this._DC.Usage = this._DC.Usage.Trim();
        }

        //////////////////////////////////////////////////////////////////////

        #region CmdUploadImage

        private RelayCommand<string> _CmdUploadImage;

        /// <summary>
        /// Gets the CmdUploadImage.
        /// </summary>
        public RelayCommand<string> CmdUploadImage
        {
            get
            {
                return _CmdUploadImage
                    ?? (_CmdUploadImage = new RelayCommand<string>(ExecuteCmdUploadImage));
            }
        }

        private void ExecuteCmdUploadImage(string parameter)
        {
            this._ImageID = Convert.ToInt32(parameter);
            this.UploadFile();
        }

        DSB_Material_Lens _DS = new DSB_Material_Lens();
        Stream _FileStream; bool _LastBlock = false; string _OpenFileName = string.Empty; long _FileLength; long _FileLengthVs; int _ImageID;
        private void UploadFile()
        {
            this.InitUploadPara();
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "JPEG files|*.jpg";
                if ((bool)dialog.ShowDialog())
                {
                    _OpenFileName = dialog.File.Name;
                    _FileStream = dialog.File.OpenRead();
                    _FileLength = dialog.File.Length;
                    _FileLengthVs = _FileLength;

                    if (_FileLength > (1 * 1024 * 1024))
                    {
                        MessageErp.ErrorMessage(ErpUIText.Get("Err_ImageLargeThan1M"));
                        try { _FileStream.Close(); }
                        catch { }
                        return;
                    }
                    this.SentFileStream(true);
                }
            }

            catch (IOException)
            {
                try { _FileStream.Close(); }
                catch { }
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_FileInUse"));
            }
        }

        private void InitUploadPara()
        {
            _LastBlock = false;
            this.BIProgressValue = 0;
            this.IsBusyProgress = false;
            try { _FileStream.Close(); }
            catch { }
        }

        private void SentFileStream(bool firstBlock)
        {
            byte[] _Buffer = new byte[4 * 4 * 1024];
            int _BytesRead = _FileStream.Read(_Buffer, 0, _Buffer.Length);
            _FileLengthVs = _FileLengthVs - _BytesRead;
            if (_FileLengthVs <= 0) _FileLengthVs = 0;
            double V1 = Convert.ToDouble(_FileLength - _FileLengthVs);
            double V2 = Convert.ToDouble(_FileLength);
            this.BIProgressValue = Convert.ToInt32((V1 / V2) * 100);
            this.IsBusyProgress = true;

            if (_BytesRead <= 0)
            {
                _LastBlock = true;
            }

            _DS.UploadImage(USysInfo.DBCode, USysInfo.LgIndex, _OpenFileName, _Buffer, this.CurrentIDCode, _ImageID, firstBlock, _LastBlock, OnSendCompleted, null);
        }

        private void OnSendCompleted(InvokeOperation geted)
        {
            if (geted.HasError)
            {
                this.IsBusyProgress = false;
                this.BIProgressValue = 0;
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                try { _FileStream.Close(); }
                catch { }
                return;
            }

            if (_LastBlock)
            {
                this.InitUploadPara();
                this.ResetImageSource();
            }
            else
            {
                this.SentFileStream(false);
            }
        }

        private void ResetImageSource()
        {
            Random random = new Random();
            int randomValue = random.Next(1000000);

            switch (_ImageID)
            {
                case 1:
                    this.ImageSource1 = _ImageUrl + this.CurrentIDCode + "Image1.jpg" + "?id=" + randomValue;
                    break;
                case 2:
                    this.ImageSource2 = _ImageUrl + this.CurrentIDCode + "Image2.jpg" + "?id=" + randomValue;
                    break;
                case 3:
                    this.ImageSource3 = _ImageUrl + this.CurrentIDCode + "Image3.jpg" + "?id=" + randomValue;
                    break;
                default:
                    break;
            }
        }

        #endregion

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
                case "1":
                    ComOpenURL.OpenByFullURL(this.ImageSource1);
                    break;
                case "2":
                    ComOpenURL.OpenByFullURL(this.ImageSource2);
                    break;
                case "3":
                    ComOpenURL.OpenByFullURL(this.ImageSource3);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion
    }
}
