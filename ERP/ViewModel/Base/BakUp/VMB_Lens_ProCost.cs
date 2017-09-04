
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

        private ComDDsInfo DDsInfoListLensProCost;

        private List<string> _GridListSelectedCodesProCost = new List<string>();

        public List<string> GridListSelectedCodesProCost
        {
            get { return _GridListSelectedCodesProCost; }
            set { _GridListSelectedCodesProCost = value; }
        }

        private string _LensCodeProCostCopy = "";
        public string LensCodeProCostCopy
        {
            get { return _LensCodeProCostCopy; }
            set
            {
                _LensCodeProCostCopy = value;
                RaisePropertyChanged<string>(() => this.LensCodeProCostCopy);
            }
        }

        private bool _IsBusyLens_ProCost = false;
        public bool IsBusyLens_ProCost
        {
            get { return _IsBusyLens_ProCost; }
            set
            {
                _IsBusyLens_ProCost = value;
                RaisePropertyChanged<bool>(() => this.IsBusyLens_ProCost);
            }
        }

        private IEnumerable _DContextListB_Lens_ProCost;
        public IEnumerable DContextListB_Lens_ProCost
        {
            get { return _DContextListB_Lens_ProCost; }
            set
            {
                _DContextListB_Lens_ProCost = value;
                RaisePropertyChanged("DContextListB_Lens_ProCost");
            }
        }

        private string _ResultInfoCountB_Lens_ProCost;
        public string ResultInfoCountB_Lens_ProCost
        {
            get { return _ResultInfoCountB_Lens_ProCost; }
            set
            {
                _ResultInfoCountB_Lens_ProCost = value;
                RaisePropertyChanged("ResultInfoCountB_Lens_ProCost");
            }
        }

        private string _ResultInfoTimeB_Lens_ProCost;
        public string ResultInfoTimeB_Lens_ProCost
        {
            get { return _ResultInfoTimeB_Lens_ProCost; }
            set
            {
                _ResultInfoTimeB_Lens_ProCost = value;
                RaisePropertyChanged("ResultInfoTimeB_Lens_ProCost");
            }
        }

        private DateTime _TimeCountB_Lens_ProCost;

        protected string _SWhereB_Lens_ProCost = "";

        #endregion

        #region Methods

        partial void InitMessagesProCost()
        {
            Messenger.Default.Register<USelectedBillCodes>(this, USysMessages.UpdateSelectedCode, (msg) =>
            {
                this.UpdateSelectedProCostCodes(msg);
            });
        }

        private void UpdateSelectedProCostCodes(USelectedBillCodes msg)
        {
            if (msg.VMName != "B_Lens_ProCost") return;
            if (msg.IsAdd)
            {
                this.GridListSelectedCodesProCost.Add(msg.SelectedBillCode);
            }
            else
            {
                this.GridListSelectedCodesProCost.RemoveAll(s => s == msg.SelectedBillCode);
            }
        }

        private RelayCommand _CmdRefreshLens_ProCost;

        /// <summary>
        /// Gets the CmdRefreshLens_ProCost.
        /// </summary>
        public RelayCommand CmdRefreshLens_ProCost
        {
            get
            {
                return _CmdRefreshLens_ProCost
                    ?? (_CmdRefreshLens_ProCost = new RelayCommand(ExecuteCmdRefreshLens_ProCost));
            }
        }

        private void ExecuteCmdRefreshLens_ProCost()
        {
            this.LoadLensProCost();
        }

        private void LoadLensProCost()
        {
            this.InitDDsProCost();
            var dds = ComDDSFactory.Get(DDsInfoListLensProCost, DDsProCostList_LoadingData, DDsProCostList_LoadedData);
            DContextListB_Lens_ProCost = null;
            DContextListB_Lens_ProCost = dds.Data;
            dds.Load();
        }

        private void InitDDsProCost()
        {
            DDsInfoListLensProCost = new ComDDsInfo()
           {
               DefaultSortKey = "ID",
               PageSize = 50
           };
            DDsInfoListLensProCost.QueryName = UDSMethods.V_B_Lens_ProCostList;
            DDsInfoListLensProCost.Domaincontext = ComDSFactory.Erp;
            DDsInfoListLensProCost.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            var _SWhere = "LensCode" + USptstr.Str2 + this.SIDCode;
            DDsInfoListLensProCost.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = _SWhere });
            DDsInfoListLensProCost.AddDefaultSorts(DDsInfoListLensProCost.DefaultSortKey);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsProCostList_LoadingData(object sender, LoadingDataEventArgs geted)
        {
            this.IsBusyLens_ProCost = true;
            this._TimeCountB_Lens_ProCost = DateTime.Now;
            geted.LoadBehavior = LoadBehavior.RefreshCurrent;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsProCostList_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusyLens_ProCost = false;

            if (geted.HasError)
            {
                MessageBox.Show(geted.Error.ToString());
                geted.MarkErrorAsHandled();
                return;
            }
            try
            {
                ResultInfoTimeB_Lens_ProCost = ErpUIText.Get("ERP_Search1") + DateTime.Now.Subtract(this._TimeCountB_Lens_ProCost).TotalSeconds.ToString("N") + ErpUIText.Get("ERP_Search2");
                ResultInfoCountB_Lens_ProCost = ErpUIText.Get("ERP_Search3") + (geted.TotalEntityCount).ToString() + ErpUIText.Get("ERP_Search4");
            }
            catch { }
            GridListSelectedCodesProCost.Clear();
        }

        private RelayCommand _CmdAddLens_ProCost;

        /// <summary>
        /// Gets the CmdAddLens_ProCost.
        /// </summary>
        public RelayCommand CmdAddLens_ProCost
        {
            get
            {
                return _CmdAddLens_ProCost
                    ?? (_CmdAddLens_ProCost = new RelayCommand(ExecuteCmdAddLens_ProCost));
            }
        }

        private void ExecuteCmdAddLens_ProCost()
        {
            this.AddProCost();
        }

        private void AddProCost()
        {
            //if (this.ViewErrList != null && this.ViewErrList.Value.Count > 0)
            //    return;
            //var s1 = this.SPH1;
            //var s2 = this.SPH2;
            //var c1 = this.CYL1;
            //var c2 = this.CYL2;
            //var a1 = this.ADD1;
            //var a2 = this.ADD2;
            //var dia = this.Dia;
            //var p1 = this.P1;
            //var p2 = this.P2;
            //var model = new MB_Lens();
            //model.Sub_ProCost = new MB_Lens_ProCost()
            //    {
            //        ADD1 = a1,
            //        ADD2 = a2,
            //        CYL1 = c1,
            //        CYL2 = c2,
            //        Dia = dia,
            //        ID = "",
            //        LensCode = this.SIDCode,
            //        P1 = p1,
            //        P2 = p2,
            //        SPH1 = s1,
            //        SPH2 = s2
            //    };
            //DSB_Lens _DS = new DSB_Lens();
            //this.IsBusyLens_ProCost = true;
            //_DS.AddProCost(USysInfo.DBCode, USysInfo.LgIndex, model, geted =>
            //    {
            //        this.IsBusyLens_ProCost = false;
            //        if (geted.HasError)
            //        {
            //            MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
            //            geted.MarkErrorAsHandled();
            //            return;
            //        }
            //        this.LoadLensProCost();
            //    }, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand<bool> _CmdGridLens_ProCostHeadCheck;

        /// <summary>
        /// Gets the CmdGridLens_ProCostHeadCheck.
        /// </summary>
        public RelayCommand<bool> CmdGridLens_ProCostHeadCheck
        {
            get
            {
                return _CmdGridLens_ProCostHeadCheck
                    ?? (_CmdGridLens_ProCostHeadCheck = new RelayCommand<bool>(ExecuteCmdGridLens_ProCostHeadCheck));
            }
        }

        private void ExecuteCmdGridLens_ProCostHeadCheck(bool parameter)
        {
            try
            {
                foreach (var item in this.DContextListB_Lens_ProCost)
                {
                    item.GetType().GetProperty("IsSelected").SetValue(item, parameter, null);
                }
            }
            catch { }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdDeleteLens_ProCost;

        /// <summary>
        /// Gets the CmdDeleteLens_ProCost.
        /// </summary>
        public RelayCommand CmdDeleteLens_ProCost
        {
            get
            {
                return _CmdDeleteLens_ProCost
                    ?? (_CmdDeleteLens_ProCost = new RelayCommand(ExecuteCmdDeleteLens_ProCost));
            }
        }

        private void ExecuteCmdDeleteLens_ProCost()
        {
            if (this.GridListSelectedCodesProCost.Count == 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_DeleteNone"));
                return;
            }

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_DeleteConfirmList") + "[" + this.GridListSelectedCodesProCost.Count.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.DeleteProCost();
            };
            u.Show();
        }

        private void DeleteProCost()
        {
            //DSB_Lens _DS = new DSB_Lens();
            //this.IsBusyLens_ProCost = true;
            //_DS.DeleteProCost(USysInfo.DBCode, USysInfo.LgIndex, this.GridListSelectedCodesProCost, geted =>
            //{
            //    this.IsBusyLens_ProCost = false;
            //    if (geted.HasError)
            //    {
            //        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
            //        geted.MarkErrorAsHandled();
            //        return;
            //    }
            //    this.LoadLensProCost();
            //}, null);
        }
        //////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdCopyLensProCost;

        /// <summary>
        /// Gets the CmdCopyLensProCost.
        /// </summary>
        public RelayCommand CmdCopyLensProCost
        {
            get
            {
                return _CmdCopyLensProCost
                    ?? (_CmdCopyLensProCost = new RelayCommand(ExecuteCmdCopyLensProCost));
            }
        }

        private void ExecuteCmdCopyLensProCost()
        {
            if (this.LensCodeProCostCopy.Trim() == "") return;

            MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_CopyConfirm") + "[" + this.LensCodeProCostCopy.ToString() + "]", MessageWindowErp.MessageType.Confirm);
            u.Closed += (s, e) =>
            {
                if (u.DialogResult == true)
                    this.CopyProCost();
            };
            u.Show();
        }

        private void CopyProCost()
        {
            //DSB_Lens _DS = new DSB_Lens();
            //this.IsBusyLens_ProCost = true;
            //_DS.CopyProCost(USysInfo.DBCode, USysInfo.LgIndex, this.LensCodeProCostCopy, this.SIDCode, geted =>
            //{
            //    this.IsBusyLens_ProCost = false;
            //    if (geted.HasError)
            //    {
            //        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
            //        geted.MarkErrorAsHandled();
            //        return;
            //    }
            //    this.LoadLensProCost();
            //}, null);
        }



        #endregion
    }
}
