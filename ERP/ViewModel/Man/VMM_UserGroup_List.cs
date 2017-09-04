using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Man;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMM_UserGroup_List : VMList
    {
        private V_S_User _selectedItem;
        private List<string> uCodeList = new List<string>();
        private Lazy<DSUserGroup_User_Assign> DS_Bill = new Lazy<DSUserGroup_User_Assign>();

        private string _GpCode = "";
        public string GpCode
        {
            get
            {
                return _GpCode;
            }
            set
            {
                _GpCode = value;
                RaisePropertyChanged("GpCode");
            }
        }

        private string _GpName = "";
        public string GpName
        {
            get
            {
                return _GpName;
            }
            set
            {
                _GpName = value;
                RaisePropertyChanged("GpName");
            }
        }

        private int _GpID = -1;
        public int GpID
        {
            get
            {
                return _GpID;
            }
            set
            {
                _GpID = value;
                RaisePropertyChanged("GpID");
            }
        }

        public VMM_UserGroup_List()
            : base("GpCode", "S_UserGroup", "gpCode", "gpName", isAutoRefresh: true)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }


        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.LoadList2();
        }

        protected override void Refresh2()
        {
            this.LoadList2();
        }

        protected override void OnLoadMainEnd2()
        {
            if (!string.IsNullOrEmpty(this.GpCode))
            {
                var item = new V_S_UserGroup() { GpCode = this.GpCode, GpName = this.GpName, GpID = this.GpID };
                this.GridSelectedItemChanged(item);
            }
        }

        protected override void GridSelectedItemChanged(System.ServiceModel.DomainServices.Client.Entity item)
        {
            if (item == null) return;
            var it = item as V_S_UserGroup;
            this.GpID = it.GpID;
            this.GpCode = it.GpCode;
            this.GpName = it.GpName;
            var ds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_User_GroupIncludeListByGpCode, ReSetSelectCodes);
            ds.QueryParameters.Add(new Parameter() { ParameterName = "gpCode", Value = this.GpCode });
            this.IsBusyList2 = true;
            ds.Load();
        }

        protected override string PrepareDDsInfoList2QueryName()
        {
            return UDSMethods.V_S_UserAllList;
        }

        protected override string PrepareDDsInfoList2DefaultKeyCode()
        {
            return "UserCode";
        }

        protected override void PrepareDDsInfoList2Parameters()
        {

        }

        private void ReSetSelectCodes(object s, LoadedDataEventArgs geted)
        {
            this.IsBusyList2 = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_S_User itenm in DContextList2)
            {
                itenm.IsSelected = false;
            }

            foreach (V_S_User_GroupDataBase y in items2)
            {
                foreach (V_S_User itenm in DContextList2)
                {
                    if (itenm.UserCode.ToUpper() == y.UserCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_S_User);
        }

        private void PrepareUpdate(V_S_User parameter)
        {
            if (string.IsNullOrEmpty(this.GpCode)) return;
            this._selectedItem = parameter;
            uCodeList.Clear();
            uCodeList.Add(_selectedItem.UserCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {

            _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.Update(this.GpID, uCodeList, flag,
                geted =>
                {
                    _selectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }

        protected override void GridListClick1(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            V_S_UserGroup _DC = parameter as V_S_UserGroup;
            var vmcode = this.VMName.Replace("_List", "");
            var funcode = vmcode.Substring(2);
            ComOpenWins.Open("", funcode);
            Messenger.Default.Send<string>((_DC.GpCode), vmcode + "_ShowFromList");
        }

    }
}
