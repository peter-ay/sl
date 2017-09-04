using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using ERP.View;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private void PrepareDDsInfoMain()
        {
            this.DDsInfoMain = new ComDDsInfo()
            {
                DefaultSortKey = IDCode,
                DefaultIDCode = IDCode,
                PageSize = 1
            };
            this.DDsInfoMain.ClearDefault();
            this.DDsInfoMain.QueryName = this.PrepareDDsInfoMainQueryName();
            this.DDsInfoMain.DefaultKeyCode = this.PrepareDDsInfoMainDefaultKeyCode();
            this.DDsInfoMain.Domaincontext = this.PrepareDDsInfoMainDomaincontext();
            this.PrepareDDsInfoMainFilters();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoMainParameters();
            this.PrepareDDsInfoMainSorts();
        }

        protected virtual string PrepareDDsInfoMainDefaultKeyCode()
        {
            return this.IDCode.Substring(0, 1).ToLower() + this.IDCode.Substring(1);
        }

        protected virtual string PrepareDDsInfoMainQueryName()
        {
            return "GetV_" + this.ModelName + "BillQuery";
        }

        protected virtual DomainContext PrepareDDsInfoMainDomaincontext()
        {
            if (USysInfo.LoginMode == 0)
                return ComDSFactory.Erp;
            else
                return ComDSFactory.Man;
        }

        protected virtual void PrepareDDsInfoMainSorts()
        {

        }

        protected virtual void PrepareDDsInfoMainFilters()
        {

        }

        protected virtual void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        {
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = DDsInfoMain.DefaultKeyCode, Value = ispnIndex ? "" : this.SIDCode });
            if (this._IsAddGpID)
            {
                this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "gpID", Value = (USysInfo.F_Manager || USysInfo.F_CusCodeBrowse ? -99 : USysInfo.GpID) });
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void PrepareLoadMain()
        {
            this.flag_Next = false;
            this.flag_Previous = false;
            this.PrepareDDsInfoMain();
            var dds = ComDDSFactory.Get(this.DDsInfoMain, DDsMain_LoadingData, DDsMain_LoadedData);
            this.OnLoadMainBegin();
            dds.Load();
        }

        protected virtual void OnLoadMainBegin()
        {
            this.ACMinimumPrefixLength = -1;
        }

        private void DDsMain_LoadingData(object sender, LoadingDataEventArgs geted)
        {
            this.IsBusy = true;
            geted.LoadBehavior = LoadBehavior.RefreshCurrent;
        }

        private void DDsMain_LoadedData(object sender, LoadedDataEventArgs geted)
        {
            if (geted.HasError)
            {
                this.IsBusy = false;
                MessageBox.Show(geted.Error.ToString());
                geted.MarkErrorAsHandled();
                this.Drop();
                return;
            }

            var items = geted.Entities;

            if (items.Count() == 0)
            {
                if (!flag_Next && !flag_Previous)
                {
                    USysInfo.ErrMsg = ErpUIText.Get("ERP_NoRecord") + this.SIDCode;
                    MessageErp.ErrorMessage(USysInfo.ErrMsg);
                    this.Drop();
                }
                else if (flag_Next)
                {
                    this.IsEnableNext = false;
                }
                else
                {
                    this.IsEnablePrevious = false;
                }

                this.IsBusy = false;
                return;
            }

            try
            {
                var item = items.FirstOrDefault();
                this.OnLoadMainEndRetSetDContextMain(item);
                this.OnLoadMainEnd();
            }
            catch { }
            finally
            {
                this.IsBusy = false;
            }

        }

        protected virtual void OnLoadMainEndRetSetDContextMain(Entity item)
        {
            this.PrepareDContextMain();
            ComCopyProperties.Copy(this.DContextMain, item);
        }

        protected virtual void OnLoadMainEnd()
        {
            this.ChangeBillSate(UBillState.View);
            this.SIDCode = this.DContextMain.GetType().GetProperty(this.DDsInfoMain.DefaultIDCode).GetValue(this.DContextMain, null).ToString();
            this.PrepareLoadSub();
        }

        protected virtual void PrepareLoadSub()
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoMainNext()
        {
            this.DDsInfoMain.ClearDefault();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoMainParameters(true);
            this.DDsInfoMain.AddDefaultSorts(this.DDsInfoMain.DefaultSortKey);
            this.DDsInfoMain.AddDefaultFiltersNext(this.DDsInfoMain.DefaultIDCode, this.SIDCode);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected virtual void PrepareDDsInfoMainPrevious()
        {
            this.DDsInfoMain.ClearDefault();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoMainParameters(true);
            this.DDsInfoMain.AddDefaultSorts(this.DDsInfoMain.DefaultSortKey, true);
            this.DDsInfoMain.AddDefaultFiltersPrevious(this.DDsInfoMain.DefaultIDCode, this.SIDCode);
        }

    }
}
