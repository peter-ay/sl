
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
    public class VMM_User_List : VMList
    {
        private V_S_UserGroup _selectedItem;
        private List<string> uCodeList = new List<string>();
        private Lazy<DSUser_Group_Assign> DS_Bill = new Lazy<DSUser_Group_Assign>();

        private string _UserCode = "";
        public string UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                _UserCode = value;
                RaisePropertyChanged("UserCode");
            }
        }

        private string _UserName = "";
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public VMM_User_List()
            : base("UserCode", "S_User", "userCode", "userName",isAutoRefresh:true)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
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
            if (!string.IsNullOrEmpty(this.UserCode))
            {
                var item = new V_S_User() { UserCode = this.UserCode, UserName = this.UserName };
                this.GridSelectedItemChanged(item);
            }
        }

        protected override void GridSelectedItemChanged(System.ServiceModel.DomainServices.Client.Entity item)
        {
            if (item == null) return;
            var it = item as V_S_User;
            this.UserCode = it.UserCode;
            this.UserName = it.UserName;
            var ds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_User_GroupIncludeListByUserCode, ReSetSelectCodes);
            ds.QueryParameters.Add(new Parameter() { ParameterName = "userCode", Value = this.UserCode });
            this.IsBusyList2 = true;
            ds.Load();
        }

        protected override string PrepareDDsInfoList2QueryName()
        {
            return UDSMethods.V_S_UserGroupAllList;
        }

        protected override string PrepareDDsInfoList2DefaultKeyCode()
        {
            return "GpCode";
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

            if (DContextList2 == null) return;

            foreach (V_S_UserGroup itenm in DContextList2)
            {
                itenm.IsSelected = false;
            }

            foreach (V_S_User_GroupDataBase y in items2)
            {
                foreach (V_S_UserGroup itenm in DContextList2)
                {
                    if (itenm.GpCode.ToUpper() == y.GpCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_S_UserGroup);
        }

        private void PrepareUpdate(V_S_UserGroup parameter)
        {
            if (string.IsNullOrEmpty(this.UserCode)) return;
            this._selectedItem = parameter;
            uCodeList.Clear();
            uCodeList.Add(_selectedItem.GpCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {

            _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.Update(this.UserCode, uCodeList, flag,
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
            V_S_User _DC = parameter as V_S_User;
            var vmcode = this.VMName.Replace("_List", "");
            var funcode = vmcode.Substring(2);
            ComOpenWins.Open("", funcode);
            Messenger.Default.Send<string>((_DC.UserCode), vmcode + "_ShowFromList");
        }

    }
}
