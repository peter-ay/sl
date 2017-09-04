using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        #region property

        private string resultInfoCount;
        public string ResultInfoCount
        {
            get { return resultInfoCount; }
            set
            {
                resultInfoCount = value;
                RaisePropertyChanged("ResultInfoCount");
            }
        }

        private string resultInfoTime;
        public string ResultInfoTime
        {
            get { return resultInfoTime; }
            set
            {
                resultInfoTime = value;
                RaisePropertyChanged("ResultInfoTime");
            }
        }

        private DateTime _TimeCount;
        private int _PageSize1 = 100;
        protected string _SWhere = "";

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PrepareDDsInfoList()
        {
            this.DDsInfoList = new ComDDsInfo()
            {
                DefaultSortKey = this.IDCode,
                PageSize = _PageSize1
            };
            this.DDsInfoList.ClearDefault();
            this.DDsInfoList.DefaultKeyCode = this.PrepareDDsInfoListDefaultKeyCode();
            this.DDsInfoList.DefaultKeyName = this.PrepareDDsInfoListDefaultKeyName();
            this.DDsInfoList.QueryName = this.PrepareDDsInfoListQueryName();
            this.DDsInfoList.Domaincontext = this.PrepareDDsInfoListDomaincontext();
            this.PrepareDDsInfoListFilters();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoList.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoListParameters();
            this.PrepareDDsInfoListSorts();
            this.PrepareDDsInfoListGroups();
        }

        protected virtual void PrepareDDsInfoListGroups()
        {

        }

        protected virtual string PrepareDDsInfoListDefaultKeyName()
        {
            return this._keyName;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual string PrepareDDsInfoListDefaultKeyCode()
        {
            return this._keyCode;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual DomainContext PrepareDDsInfoListDomaincontext()
        {
            if (USysInfo.LoginMode == 0)
                return ComDSFactory.Erp;
            else
                return ComDSFactory.Man;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual string PrepareDDsInfoListQueryName()
        {
            return "GetV_" + this.ModelName + "ListQuery";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoListFilters()
        {

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoListParameters()
        {
            //this.DDsInfoList.AddDefaultParameters(this.DDsInfoList.DefaultKeyCode, this.SKeyCode, this.DDsInfoList.DefaultKeyName, this.SKeyName);
            this._SWhere = "";
            this.PrepareDDsInfoListParametersDefault();
            this.PrepareDDsInfoListParametersDetail();
            this.DDsInfoList.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = this._SWhere });
        }

        protected virtual void PrepareDDsInfoListParametersDetail()
        {

        }

        protected string getExportWhereCondition(out string _F_LEID)
        {
            _F_LEID = UReportID.ID;
            this.PrepareDDsInfoListParametersDefault();
            this.PrepareDDsInfoListParametersDetail();
            _SWhere += USptstr.Str1 + "F_LE" + USptstr.Str2 + "1";
            _SWhere += USptstr.Str1 + "F_LEID" + USptstr.Str2 + _F_LEID;
            return this._SWhere;
        }

        protected virtual void PrepareDDsInfoListParametersDefault()
        {
            if (!string.IsNullOrEmpty(this.DDsInfoList.DefaultKeyCode))
                _SWhere += this.DDsInfoList.DefaultKeyCode + USptstr.Str2 + this.SKeyCode;
            if (!string.IsNullOrEmpty(this.DDsInfoList.DefaultKeyName))
                _SWhere += USptstr.Str1 + this.DDsInfoList.DefaultKeyName + USptstr.Str2 + this.SKeyName;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts(this.DDsInfoList.DefaultSortKey);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrepareLoadList()
        {
            this.OnPrepareDDsInfoListBegin();
            this.PrepareDDsInfoList();
            var dds = ComDDSFactory.Get(this.DDsInfoList, DDsList_LoadingData, DDsList_LoadedData);
            this.DContextList = null;
            this.DContextList = dds.Data;
            this.OnLoadMainBegin();
            dds.Load();
        }

        protected virtual void OnPrepareDDsInfoListBegin() { }

        protected virtual void OnLoadMainBegin() { }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadingData(object sender, LoadingDataEventArgs geted)
        {
            this.IsBusy = true;
            this._TimeCount = DateTime.Now;
            geted.LoadBehavior = LoadBehavior.RefreshCurrent;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusy = false;

            if (geted.HasError)
            {
                MessageBox.Show(geted.Error.ToString());
                geted.MarkErrorAsHandled();
                return;
            }
            try
            {
                ResultInfoTime = ErpUIText.Get("ERP_Search1") + DateTime.Now.Subtract(this._TimeCount).TotalSeconds.ToString("N") + ErpUIText.Get("ERP_Search2");
                ResultInfoCount = ErpUIText.Get("ERP_Search3") + (geted.TotalEntityCount).ToString() + ErpUIText.Get("ERP_Search4");
            }
            catch { }

            this.OnLoadMainEnd();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void OnLoadMainEnd()
        {
            this.IsFocusMain = true;
            this.GridListSelectedCodes.Clear();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
