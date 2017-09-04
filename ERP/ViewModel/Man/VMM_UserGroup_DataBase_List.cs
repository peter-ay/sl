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
    public class VMM_UserGroup_DataBase_List : VMList
    {
        private V_S_UserGroup _selectedItem;
        private List<string> _CodeList = new List<string>();
        private string _dbCode;
        private Lazy<DSUserGroup_DataBase_Assign> _DSBill = new Lazy<DSUserGroup_DataBase_Assign>();

        #region Property


        #endregion

        public VMM_UserGroup_DataBase_List()
            : base("GpCode", "S_UserGroup")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        protected override string PrepareDDsInfoListQueryName()
        {
            return UDSMethods.V_S_UserGroupAllList;
        }

        protected override void PrepareDDsInfoListParameters()
        {

        }

        protected override void OnLoadMainEnd()
        {
            if (this._dbCode == "")
                return;

            this.GetGroupByDBCodeList();
        }

        private void GetGroupByDBCodeList()
        {
            var _DDs = ComDDSFactory.Get(ComDSFactory.Man, UDSMethods.V_S_UserGroupByDBCodeList, ReSetSelectCodes);
            _DDs.QueryParameters.Add(new Parameter() { ParameterName = "dbCode", Value = this._dbCode });
            this.IsBusy = true;
            _DDs.Load();
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

            foreach (V_S_UserGroup itenm in DContextList)
            {
                itenm.IsSelected = false;
            }

            foreach (V_S_UserGroup it2 in items2)
            {
                foreach (V_S_UserGroup itenm in DContextList)
                {
                    if (itenm.GpCode.ToUpper() == it2.GpCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        #region methods

        protected override void ExecuteCmdComBDataBaseChange(System.ServiceModel.DomainServices.Client.Entity paramater)
        {
            if (paramater == null) return;
            var item = paramater as V_S_DataBase;
            this._dbCode = item.DBCode;
            this.GetGroupByDBCodeList();
        }

        protected override void ExecuteAssignItemCheck(System.ServiceModel.DomainServices.Client.Entity parameter)
        {
            this.PrepareUpdate(parameter as V_S_UserGroup);
        }

        private void PrepareUpdate(V_S_UserGroup parameter)
        {
            this._selectedItem = parameter;
            _CodeList.Clear();
            _CodeList.Add(_selectedItem.GpCode);
            this.UpdateCodes(_selectedItem.IsSelected);
        }

        private void UpdateCodes(bool flag, bool isShowBusy = false)
        {
            if (string.IsNullOrEmpty(this._dbCode))
                return;

            if (isShowBusy)
                this.IsBusy = true;
            else
                _selectedItem.Msg = ErpUIText.Get("ERP_Updating");

            _DSBill.Value.Update(this._dbCode, _CodeList, flag,
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
            this._CodeList.Clear();
            foreach (V_S_UserGroup t in this.DContextList)
            {
                t.IsSelected = true;
                _CodeList.Add(t.GpCode);
            }
            this.UpdateCodes(true, true);
        }

        protected override void ExecuteCmdAllUnAssign()
        {
            this.ToUncludeALL();
        }

        private void ToUncludeALL()
        {
            this._CodeList.Clear();
            foreach (V_S_UserGroup t in this.DContextList)
            {
                t.IsSelected = false;
                _CodeList.Add(t.GpCode);
            }
            this.UpdateCodes(false, true);
        }

        #endregion
    }
}
