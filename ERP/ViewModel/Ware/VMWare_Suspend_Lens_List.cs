
using ERP.Web.Entity;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ERP.Web.DomainService.Erp;
using ERP.View;
using System;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public class VMWare_Suspend_Lens_List : VMList
    {
        #region SearchCondition

        private string _WhCode = "";
        public string WhCode
        {
            get { return _WhCode; }
            set { _WhCode = value; RaisePropertyChanged("WhCode"); }
        }

        private string _LensCode = "";
        public string LensCode
        {
            get { return _LensCode; }
            set { _LensCode = value; RaisePropertyChanged("LensCode"); }
        }

        private string _SPH = "";
        public string SPH
        {
            get { return _SPH; }
            set { _SPH = value; RaisePropertyChanged("SPH"); }
        }

        private string _CYL = "";
        public string CYL
        {
            get { return _CYL; }
            set { _CYL = value; RaisePropertyChanged("CYL"); }
        }

        private string _X_ADD = "";
        public string X_ADD
        {
            get { return _X_ADD; }
            set { _X_ADD = value; RaisePropertyChanged("X_ADD"); }
        }

        private bool _IsCheckIOTypeALL = true;
        public bool IsCheckIOTypeALL
        {
            get { return _IsCheckIOTypeALL; }
            set { _IsCheckIOTypeALL = value; RaisePropertyChanged("IsCheckIOTypeALL"); }
        }

        #endregion

        public VMWare_Suspend_Lens_List()
            : base("ID", "Ware_Suspend_Lens")
        {
            this.IsShowImportBool = false;
            this.IsShowExportBool = true;
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.WhCode = "";
            this.LensCode = "";
            this.SPH = "";
            this.CYL = "";
            this.X_ADD = "";
            this.IsCheckIOTypeALL = true;
        }

        protected override void PrepareDDsInfoListParametersDetail()
        {
            base.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "WhCode" + USptstr.Str2 + this.WhCode;
            _SWhere += USptstr.Str1 + "LensCode" + USptstr.Str2 + this.LensCode;
            _SWhere += USptstr.Str1 + "SPH" + USptstr.Str2 + this.SPH;
            _SWhere += USptstr.Str1 + "CYL" + USptstr.Str2 + this.CYL;
            _SWhere += USptstr.Str1 + "X_ADD" + USptstr.Str2 + this.X_ADD;
            _SWhere += USptstr.Str1 + "IOType" + USptstr.Str2 + this._IOType;
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts("MDate", true);
        }


        private RelayCommand<string> _myCommand;

        /// <summary>
        /// Gets the CmdRBCdiIOType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiIOType
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new RelayCommand<string>(ExecuteCmdRBCdiIOType));
            }
        }

        private string _IOType = "";
        private void ExecuteCmdRBCdiIOType(string parameter)
        {
            this._IOType = parameter;
        }
    }
}
