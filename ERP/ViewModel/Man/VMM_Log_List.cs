using ERP.Common;

namespace ERP.ViewModel
{
    public class VMM_Log_List : VMList
    {
        public VMM_Log_List()
            : base("LogTime", "S_Log")
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
            this.D1 = System.DateTime.Now.AddDays(-7).ToShortDateString();
        }

        protected override void PrepareDDsInfoListParameters()
        {
            this.DDsInfoList.Parameters.Add(new ComParameters() { ParameterName = "d1", Value = this.D1 });
            this.DDsInfoList.Parameters.Add(new ComParameters() { ParameterName = "d2", Value = this.D2 });
        }

        protected override void PrepareDDsInfoListSorts()
        {
            this.DDsInfoList.AddDefaultSorts(this.DDsInfoList.DefaultSortKey,true);
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }
    }
}
