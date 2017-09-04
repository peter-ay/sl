using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ERP.Common;
using ERP.View;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using ERP.Utility;
using System.Linq;
using System.Collections.ObjectModel;
using ERP.Web.DomainService.Man;

namespace ERP.ViewModel
{
    public class VMM_GroupUserAssign : VMList
    {
        private V_S_User _selectedItem;
        private List<string> uCodeList = new List<string>();
        private string _groupCode;
        private int _groupID;
        private Lazy<DSManGroupUserAssign> DS_Bill = new Lazy<DSManGroupUserAssign>();

        #region Property


        #endregion

        public VMM_GroupUserAssign()
            : base("UserCode", "S_User", "userCode", "userName")
        {
            IsChildWindow = true;
        }

        protected override void OnLoadMainEnd()
        {
            var ds = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_User_GroupDataBaseBillByGroupCode, ReSetSelectCodes);
            ds.QueryParameters.Add(new Parameter() { ParameterName = "groupCode", Value = this._groupCode });
            this.IsBusy = true;
            ds.Load();
        }

        private void ReSetSelectCodes(object s, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_S_User_GroupDataBase y in items2)
            {
                foreach (V_S_User itenm in DContextList)
                {
                    if (itenm.UserCode.ToUpper() == y.UserCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }

        #region methods

        protected override void ExecuteCmdComBGroupChange(System.ServiceModel.DomainServices.Client.Entity paramater)
        {
            this.ExecuteCmdSearch();
            var item = paramater as V_S_Group;
            this._groupCode = item.GroupCode;
            this._groupID = item.GroupID.Value;
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_S_User);
        }

        private void PrepareUpdate(V_S_User parameter)
        {
            this._selectedItem = parameter;
            uCodeList.Clear();
            uCodeList.Add(_selectedItem.UserCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {
            if (isShowBusy)
                this.IsBusy = true;
            else
                _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            DS_Bill.Value.Update(this._groupID, uCodeList, flag,
                geted =>
                {
                    if (isShowBusy)
                        this.IsBusy = false;
                    else
                        _selectedItem.Msg = "";

                    if (geted.HasError)
                    {
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                }, null);
        }


        protected override void ExecuteCmdAllAssign()
        {
            this.ToIncludeALL();
        }

        private void ToIncludeALL()
        {
            this.uCodeList.Clear();
            foreach (V_S_User t in this.DContextList)
            {
                t.IsSelected = true;
                uCodeList.Add(t.UserCode);
            }
            this.UpdateCodes(true, true);
        }

        protected override void ExecuteCmdAllUnAssign()
        {
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this.uCodeList.Clear();
            foreach (V_S_User t in this.DContextList)
            {
                t.IsSelected = false;
                uCodeList.Add(t.UserCode);
            }
            this.UpdateCodes(false, true);
        }

        #endregion

    }
}
