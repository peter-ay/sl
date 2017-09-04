using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public partial class VMBillPD
    {
        #region property


        #endregion

        protected virtual void PrepareDDsInfoSub()
        {
            this.DDsInfoSub = new ComDDsInfo()
                {
                    PageSize = 0,
                };
            this.DDsInfoSub.ClearDefault();
            this.DDsInfoSub.QueryName = this.PrepareDDsInfoSubQueryName();
            this.DDsInfoSub.Domaincontext = this.PrepareDDsInfoSubDomaincontext();
            if (USysInfo.LoginMode == 0)
                this.DDsInfoSub.Parameters.Add(new ComParameters() { ParameterName = "dbCode", Value = USysInfo.DBCode });
            this.PrepareDDsInfoSubParameters();
            this.PrepareDDsInfoSubFilters();
            this.PrepareDDsInfoSubSorts();
        }

        protected virtual DomainContext PrepareDDsInfoSubDomaincontext()
        {
            if (USysInfo.LoginMode == 0)
                return ComDSFactory.Erp;
            else
                return ComDSFactory.Man;
        }

        protected virtual string PrepareDDsInfoSubQueryName()
        {
            return "GetV_" + this.ModelName + "DetailList";
        }

        protected virtual void PrepareDDsInfoSubSorts()
        {
            this.DDsInfoSub.AddDefaultSorts("SubID");
        }

        protected virtual void PrepareDDsInfoSubFilters()
        {

        }

        protected virtual void PrepareDDsInfoSubParameters()
        {
            this.DDsInfoSub.Parameters.Add(new ComParameters() { ParameterName = this.DDsInfoMain.DefaultKeyCode, Value = this.SIDCode });
        }
        //////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrepareLoadSub()
        {
            this.PrepareDDsInfoSub();
            var _DDs = ComDDSFactory.Get(this.DDsInfoSub, null, DDsSub_LoadedData);
            _DDs.Load();
        }

        private void DDsSub_LoadedData(object s, LoadedDataEventArgs geted)
        {
            if (geted.HasError)
            {
                geted.MarkErrorAsHandled();
                return;
            }
            ComSubGridColumnUpdate t = this.GetDContextSubToUpdateSubGrid(geted.Entities);
            Messenger.Default.Send<ComSubGridColumnUpdate>(t, USysMessages.RefreshSubGrid);
        }

        protected abstract ComSubGridColumnUpdate GetDContextSubToUpdateSubGrid(System.Collections.Generic.IEnumerable<Entity> items);

    }
}
