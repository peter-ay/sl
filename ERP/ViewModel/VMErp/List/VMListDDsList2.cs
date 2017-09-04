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

        private string _ResultInfoCount2;
        public string ResultInfoCount2
        {
            get { return _ResultInfoCount2; }
            set
            {
                _ResultInfoCount2 = value;
                RaisePropertyChanged("ResultInfoCount2");
            }
        }

        private string _ResultInfoTime2;
        public string ResultInfoTime2
        {
            get { return _ResultInfoTime2; }
            set
            {
                _ResultInfoTime2 = value;
                RaisePropertyChanged("ResultInfoTime2");
            }
        }

        private DateTime _TimeCount2;
        private int _PageSize2 = 50;
        protected string _SWhere2 = "";

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PrepareDDsInfoList2()
        {
            this.DDsInfoList2 = new ComDDsInfo()
            {
                DefaultSortKey = this.IDCode,
                PageSize = _PageSize2
            };
            this.DDsInfoList2.ClearDefault();
            this.DDsInfoList2.DefaultKeyCode = this.PrepareDDsInfoList2DefaultKeyCode();
            this.DDsInfoList2.DefaultKeyName = this.PrepareDDsInfoList2DefaultKeyName();
            this.DDsInfoList2.QueryName = this.PrepareDDsInfoList2QueryName();
            this.DDsInfoList2.Domaincontext = this.PrepareDDsInfoList2Domaincontext();
            this.PrepareDDsInfoList2Filters();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoList2.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoList2Parameters();
            this.PrepareDDsInfoList2Sorts();
        }

        protected virtual string PrepareDDsInfoList2DefaultKeyName()
        {
            return "";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual string PrepareDDsInfoList2DefaultKeyCode()
        {
            return "";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual DomainContext PrepareDDsInfoList2Domaincontext()
        {
            if (USysInfo.LoginMode == 0)
                return ComDSFactory.Erp;
            else
                return ComDSFactory.Man;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual string PrepareDDsInfoList2QueryName()
        {
            return "";
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoList2Filters()
        {

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoList2Parameters()
        {
            //this.DDsInfoList2.AddDefaultParameters(this.DDsInfoList2.DefaultKeyCode, this.SKeyCode, this.DDsInfoList2.DefaultKeyName, this.SKeyName);
            this._SWhere2 = "";
            if (!string.IsNullOrEmpty(this.DDsInfoList2.DefaultKeyCode))
                _SWhere2 += this.DDsInfoList2.DefaultKeyCode + USptstr.Str2 + this.SKeyCode2;
            if (!string.IsNullOrEmpty(this.DDsInfoList2.DefaultKeyName))
                _SWhere2 += USptstr.Str1 + this.DDsInfoList2.DefaultKeyName + USptstr.Str2 + this.SKeyName2;
            this.DDsInfoList2.Parameters.Add(new ComParameters() { ParameterName = "sWhere", Value = this._SWhere2 });
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoList2Sorts()
        {
            this.DDsInfoList2.Sorts.Add(new ComSorts() { PropertyPath = this.DDsInfoList2.DefaultKeyCode, SortDirection = System.ComponentModel.ListSortDirection.Ascending });
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PrepareLoadList2()
        {
            this.PrepareDDsInfoList2();
            var dds = ComDDSFactory.Get(this.DDsInfoList2, DDsList_LoadingData2, DDsList_LoadedData2);
            this.DContextList2 = null;
            this.DContextList2 = dds.Data;
            this.OnLoadMainBegin2();
            dds.Load();
        }

        protected virtual void OnLoadMainBegin2() { }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadingData2(object sender, LoadingDataEventArgs geted)
        {
            this.IsBusyList2 = true;
            this._TimeCount2 = DateTime.Now;
            geted.LoadBehavior = LoadBehavior.RefreshCurrent;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DDsList_LoadedData2(object sender, LoadedDataEventArgs geted)
        {
            this.IsBusyList2 = false;

            if (geted.HasError)
            {
                MessageBox.Show(geted.Error.ToString());
                geted.MarkErrorAsHandled();
                return;
            }
            try
            {
                ResultInfoTime2 = ErpUIText.Get("ERP_Search1") + DateTime.Now.Subtract(this._TimeCount2).TotalSeconds.ToString("N") + ErpUIText.Get("ERP_Search2");
                ResultInfoCount2 = ErpUIText.Get("ERP_Search3") + (geted.TotalEntityCount).ToString() + ErpUIText.Get("ERP_Search4");
            }
            catch { }

            this.OnLoadMainEnd2();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void OnLoadMainEnd2()
        {
            //this.IsFocusMain = true;
            //this.GridListSelectedCodes.Clear();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
