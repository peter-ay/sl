using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public abstract partial class VMList : VMErp
    {
        #region Property
        private string _keyCode = "", _keyName = "";
        private bool _IsAutoLoad = false;
        private bool _IsAutoRefresh = false;

        //private IEnumerable _DContextMain;
        //public new IEnumerable DContextMain
        //{
        //    get { return _DContextMain; }
        //    set { _DContextMain = value; RaisePropertyChanged("DContextMain"); }
        //}

        #endregion

        public VMList(string idCode, string modelName = "", string keyCode = "", string keyName = "", bool isAutoLoad = true, bool isAutoRefresh = false, int pageSize1 = 100, int pageSize2 = 50)
            : base()
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            this.IDCode = idCode;
            this.ModelName = modelName;
            this._keyCode = keyCode;
            this._keyName = keyName;
            this._IsAutoLoad = isAutoLoad;
            this._IsAutoRefresh = isAutoRefresh;
            this._PageSize1 = pageSize1;
            this._PageSize2 = pageSize2;
            this.InitSearchCondition();
            this.InitMessages();
        }

        #region Methods

        protected virtual void InitSearchCondition()
        {
            this.SKeyCode = "";
            this.SKeyName = "";
            this.D1 = DateTime.Now.ToShortDateString();
            this.D2 = DateTime.Now.ToShortDateString();
            this._ConCheck = -1;
            this._ConInclude = -1;
            this.F_SCTime = true;
            this.BCode = "";
            this.OBCode = "";
        }

        protected override void ViewOnLoad()
        {
            this.InitColumns();
            this.IsFocusMain = true;
            if (_IsAutoLoad)
            {
                this.Search();
            }
        }

        protected override void OnImportCompleted()
        {
            this.Search();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, this.VMName + "_Refresh", (msg) =>
            {
                this.RefreshList();
            });

            Messenger.Default.Register<USelectedBillCodes>(this, USysMessages.UpdateSelectedCode, (msg) =>
            {
                this.UpdateSelectedCodes(msg);
            });

            if (this._IsAutoRefresh)
            {
                Messenger.Default.Register<bool>(this, this.VMNameAuthority.Replace("_List", "") + "_Result", (msg) =>
                {
                    this.Search();
                });
            }
        }

        private void UpdateSelectedCodes(USelectedBillCodes msg)
        {
            if (msg.VMName.Replace("S_", "M_") + "_List" != this.VMNameAuthority) return;
            if (msg.IsAdd)
            {
                this.GridListSelectedCodes.Add(msg.SelectedBillCode);
            }
            else
            {
                this.GridListSelectedCodes.RemoveAll(s => s == msg.SelectedBillCode);
            }
        }

        private void RefreshList()
        {
            if (this.DContextList != null)
                this.Search();
        }

        protected override void ViewKeyDown(KeyEventArgs parameter)
        {
            switch (parameter.Key)
            {
                case Key.Enter:
                    this.ExecuteCmdSearch();
                    parameter.Handled = true;
                    break;
                case Key.Escape:
                    this.ExecuteCmdExit();
                    parameter.Handled = true;
                    break;
            }
        }

        ////////////////////////////////////////////////////////////

        #endregion

    }
}
