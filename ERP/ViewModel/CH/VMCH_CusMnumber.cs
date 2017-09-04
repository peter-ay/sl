

using ERP.Common;
namespace ERP.ViewModel
{
    public class VMCH_CusMnumber : VMListCH
    {
        private string cusCode = "";

        public VMCH_CusMnumber()
            : base("Mnumber", "B_CusMnumber")
        {
        } 

        protected override void PrepareDDsInfoListParameters()
        { 
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cusCode", Value = this.cusCode });
        }

        protected override bool CanExecuteCmdSearch()
        {
            return true;
        }

        protected override void OnCusCodeChange(string msg)
        {
            msg = msg.Trim();
            if (this.cusCode != msg)
            {
                this.cusCode = msg;
                this.InitSearchCondition();
                this.ExecuteCmdSearch();
            }
        } 
    }
}