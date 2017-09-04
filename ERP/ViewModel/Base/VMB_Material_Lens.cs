
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

namespace ERP.ViewModel
{
    public class VMB_Material_Lens : VMBill
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

        //IsShowUpload
        private Visibility _IsShowUpload = Visibility.Collapsed;
        public Visibility IsShowUpload
        {
            get { return _IsShowUpload; }
            set
            {
                _IsShowUpload = value;
                RaisePropertyChanged("IsShowUpload");
            }
        }

        #endregion

        public VMB_Material_Lens()
            : base("LensCode", "B_Material_Lens_General")
        {
            this.IsChildWindow = true;
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
            _CM.LensLevel = 1;
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
            this.IsShowUpload = Visibility.Collapsed;
            switch (uBillState)
            {
                case UBillState.View:
                    this.IsShowUpload = Visibility.Visible;
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
        #region CmdUploadAttachment

        private RelayCommand _CmdUploadAttachment;

        /// <summary>
        /// Gets the CmdUploadAttachment.
        /// </summary>
        public RelayCommand CmdUploadAttachment
        {
            get
            {
                return _CmdUploadAttachment
                    ?? (_CmdUploadAttachment = new RelayCommand(ExecuteCmdUploadAttachment));
            }
        }

        private void ExecuteCmdUploadAttachment()
        {
            this.UploadFile();
        }

        DSB_Material_Lens _DS = new DSB_Material_Lens();
        Stream _FileStream; bool _LastBlock = false; string _OpenFileName = string.Empty; long _FileLength; long _FileLengthVs;
        private void UploadFile()
        {
            this.InitUploadPara();
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "PDF Files |*.pdf";
                if ((bool)dialog.ShowDialog())
                {
                    _OpenFileName = dialog.File.Name;
                    _FileStream = dialog.File.OpenRead();
                    _FileLength = dialog.File.Length;
                    _FileLengthVs = _FileLength;

                    if (_FileLength > (20 * 1024 * 1024))
                    {
                        MessageErp.ErrorMessage(ErpUIText.Get("Err_LargeThan20M"));
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

            _DS.UploadAttachment(USysInfo.DBCode, USysInfo.LgIndex, _OpenFileName, _Buffer, this.CurrentIDCode, firstBlock, _LastBlock, OnSendCompleted, null);
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
                this._DC.Attachment1 = _OpenFileName;
            }
            else
            {
                this.SentFileStream(false);
            }
        }

        #endregion

        #region CmdGetAttachment

        private RelayCommand _CmdGetAttachment;

        /// <summary>
        /// Gets the CmdGetAttachment.
        /// </summary>
        public RelayCommand CmdGetAttachment
        {
            get
            {
                return _CmdGetAttachment
                    ?? (_CmdGetAttachment = new RelayCommand(ExecuteCmdGetAttachment));
            }
        }

        private void ExecuteCmdGetAttachment()
        {
            ComOpenURL.Open(USysInfo.DBCode + this.CurrentIDCode + "Attachment1.pdf", "Import/Attachment/Base/Lens");
        }

        #endregion

        #endregion
    }
}
