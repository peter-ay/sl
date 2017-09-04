using System;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Man;
using ERP.Web.Entity;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace ERP.ViewModel
{
    public class VMM_GroupAuthorityAssign_List : VMList
    {
        #region Property
        DSManGroupAuthorityAssign DS_Bill = new DSManGroupAuthorityAssign();
        private List<string> updateCodes = new List<string>();

        public new V_S_Function SelectedItem
        {
            get;
            set;
        }

        private ObservableCollection<V_S_Function> sourceTree = new ObservableCollection<V_S_Function>();
        public ObservableCollection<V_S_Function> SourceTree
        {
            get
            {
                return sourceTree;
            }
            set
            {
                sourceTree = value;
                RaisePropertyChanged("SourceTree");
            }
        }


        //////////////////////////////////////////////////////////////
        private int _gID = -1;

        #endregion

        public VMM_GroupAuthorityAssign_List()
            : base("")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

        #region Methods

        ///////////////////////////////////////////////////////////////////////////////////////////


        protected override void ExecuteCmdComBGroupChange(System.ServiceModel.DomainServices.Client.Entity paramater)
        {
            var obj = paramater as V_S_Group;
            this._gID = obj.GroupID.Value;
            this.LoadTreeView();
        }

        private void LoadTreeView()
        {
            this.SourceTree.Clear();
            this.SourceTree.Add(new V_S_Function() { FunNameUI = ErpUIText.Get("ERP_Loading") });
            var ddsInfo = new ComDDsInfo() { Domaincontext = ComDSFactory.Man, QueryName = UDSMethods.V_S_FunctionTreeList, PageSize = 0 };
            var dds = ComDDSFactory.Get(ddsInfo, null, ddsTreeView_LoadedData);
            this.IsBusy = true;
            dds.Load();
        }

        private void ddsTreeView_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                return;
            }

            var items = geted.Entities;
            this.SourceTree.Clear();
            V_S_Function it;
            items.ToList().ForEach(item =>
            {
                if (!string.IsNullOrEmpty(((V_S_Function)item).FunParentID)) return;
                it = new V_S_Function();
                ComCopyProperties.Copy(it, item);
                it.I_Explan = true;
                it.Children = GetChild(items, ((V_S_Function)item).FunID);
                this.SourceTree.Add(it);
            });
            //////////////////////////////////////////// 
            var ddsInfo = new ComDDsInfo() { Domaincontext = ComDSFactory.Man, QueryName = UDSMethods.V_S_FunctionAuthorityList, PageSize = 0 };
            ddsInfo.Parameters.Add(new ComParameters() { ParameterName = "groupID", Value = this._gID });
            var dds = ComDDSFactory.Get(ddsInfo, null, ddsAuthorityTree_LoadedData);
            this.IsBusy = true;
            dds.Load();
        }

        private System.Collections.Generic.List<V_S_Function> GetChild(System.Collections.Generic.IEnumerable<System.ServiceModel.DomainServices.Client.Entity> iFunctionTree, string funParentID)
        {
            List<V_S_Function> t = new List<V_S_Function>();
            foreach (V_S_Function item in iFunctionTree)
            {
                if (item.FunParentID == funParentID)
                {
                    item.Children = GetChild(iFunctionTree, item.FunID);
                    t.Add(item);
                }
            }
            return t;
        }

        void ddsAuthorityTree_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;
            if (geted.HasError)
            {
                MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                geted.MarkErrorAsHandled();
                this.SourceTree.Clear();
                return;
            }

            var items2 = geted.Entities;

            foreach (V_S_Function y in items2)
            {
                foreach (V_S_Function itenm in SourceTree.SelectMany(item => GetItems(item)))
                {
                    if (itenm.FunCode.ToUpper() == y.FunCode.ToUpper())
                    {
                        itenm.IsSelected = true;
                        break;
                    }
                }
            }
        }

        private IEnumerable<V_S_Function> GetItems(V_S_Function obj)
        {
            yield return obj;
            foreach (V_S_Function obj2 in obj.Children.SelectMany(item => GetItems(item)))
            {
                yield return obj2;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdAllAdd;

        /// <summary>
        /// Gets the CmdAllAdd.
        /// </summary>
        public RelayCommand CmdAllAdd
        {
            get
            {
                return _CmdAllAdd
                    ?? (_CmdAllAdd = new RelayCommand(ExecuteCmdAllAdd));
            }
        }

        private void ExecuteCmdAllAdd()
        {
            this.UpdateAll(true);
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdAllDelete;

        /// <summary>
        /// Gets the CmdAllDelete.
        /// </summary>
        public RelayCommand CmdAllDelete
        {
            get
            {
                return _CmdAllDelete
                    ?? (_CmdAllDelete = new RelayCommand(ExecuteCmdAllDelete));
            }
        }

        private void ExecuteCmdAllDelete()
        {
            this.UpdateAll(false);
        }


        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        private void UpdateAll(bool isadd)
        {
            if (this._gID == -1) return;
            this.IsBusy = true;
            DS_Bill.UpdateAll(this._gID, isadd, geted =>
            {
                this.IsBusy = false;
                if (geted.HasError)
                {

                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                ResetAllCheck(isadd);
            }, null);
        }

        private void ResetAllCheck(bool isadd)
        {
            foreach (V_S_Function itenm in SourceTree.SelectMany(item => GetItems(item)))
            {
                itenm.IsSelected = isadd;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////
        private RelayCommand _CmdTreeCheckClick;

        /// <summary>
        /// Gets the CmdTreeCheckClick.
        /// </summary>
        public RelayCommand CmdTreeCheckClick
        {
            get
            {
                return _CmdTreeCheckClick
                    ?? (_CmdTreeCheckClick = new RelayCommand(ExecuteCmdTreeCheckClick));
            }
        }

        private void ExecuteCmdTreeCheckClick()
        {
            this.PrepareUpdate();
        }

        private void PrepareUpdate()
        {
            updateCodes.Clear();
            this.SelectedItem.Msg = ErpUIText.Get("ERP_Msg");
            updateCodes.Add(this.SelectedItem.FunCode);
            this.SetChildIsSelect(this.SelectedItem, this.SelectedItem.IsSelected);
            this.UpdateCodes();
        }

        private void SetChildIsSelect(V_S_Function obj, bool isselect)
        {
            obj.Children.ForEach(item =>
            {
                item.Msg = ErpUIText.Get("ERP_Msg");
                item.IsSelected = isselect;
                updateCodes.Add(item.FunCode);
                SetChildIsSelect(item, isselect);
            });
        }

        private void UpdateCodes()
        {
            if (updateCodes.Count == 0 || this._gID == -1) return;

            DS_Bill.Update(this._gID, this.updateCodes, this.SelectedItem.IsSelected, geted =>
            {
                if (geted.HasError)
                {

                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                ResetAllMsg(this.SelectedItem);
            }, null);
        }

        private void ResetAllMsg(V_S_Function obj)
        {
            obj.Msg = "";
            obj.Children.ForEach(item =>
            {
                item.Msg = "";
                ResetAllMsg(item);
            });
        }

        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        private RelayCommand<V_S_Function> _CmdTreeItemClick;

        /// <summary>
        /// Gets the CmdTreeItemClick.
        /// </summary>
        public RelayCommand<V_S_Function> CmdTreeItemClick
        {
            get
            {
                return _CmdTreeItemClick
                    ?? (_CmdTreeItemClick = new RelayCommand<V_S_Function>(
                    p =>
                    {
                        p.I_Explan = !p.I_Explan;
                    }));
            }
        }
        /////////////////////////////////////////////////////////////////////////////
        private RelayCommand<KeyEventArgs> _CmdTreeViewKeyDown;

        /// <summary>
        /// Gets the CmdTreeViewKeyDown.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdTreeViewKeyDown
        {
            get
            {
                return _CmdTreeViewKeyDown
                    ?? (_CmdTreeViewKeyDown = new RelayCommand<KeyEventArgs>(ExecuteCmdTreeViewKeyDown));
            }
        }

        private void ExecuteCmdTreeViewKeyDown(KeyEventArgs parameter)
        {
            switch (parameter.Key)
            {
                case Key.Enter:
                    this.SelectedItem.I_Explan = !this.SelectedItem.I_Explan;
                    parameter.Handled = true;
                    break;
                case Key.Space:
                    this.SelectedItem.IsSelected = !this.SelectedItem.IsSelected;
                    PrepareUpdate();
                    parameter.Handled = true;
                    break;
            }
        }

        protected override bool CanExecuteCmdSearch()
        {
            return false;
        }

        #endregion

    }
}
