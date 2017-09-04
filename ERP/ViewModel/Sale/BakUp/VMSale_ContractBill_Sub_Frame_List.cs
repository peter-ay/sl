using System;
using ERP.Common;

namespace ERP.ViewModel
{
    public class VMSale_ContractBill_Sub_Frame_List : VMList
    {
        public VMSale_ContractBill_Sub_Frame_List()
            : base("FrameCode", "Sale_ContractBill_Sub_Frame")
        {
            IsChildWindow = true;
        }

        protected override void PrepareDDsInfoMainParameters()
        {
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "contractCode", Value = this.CurrentIDCode.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "framecode", Value = this.SKeyCode.MyStr() });
        }

        protected override void OnBillCodeChange(string msg)
        {
            if (this.CurrentIDCode != msg)
            {
                this.CurrentIDCode = msg;
                this.Title = ErpUIText.Get(this.VMNameAuthority + "_Title") + " || " + msg;
                this.InitSearchCondition();
                this.ExecuteCmdSearch();
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        private string _tbname = "Sale_ContractBill_Sub_Frame";

        protected override void Export()
        {
            ComExport.Export(_tbname, " ContractCode='" + this.CurrentIDCode + "'", " order by FrameCode",
            @" [FrameCode],[Price],[InvoiceTitle]");
        }

        protected override void Import()
        {
            ComImport.Import(_tbname, this.CurrentIDCode);
        }

        protected override void OnImportCompleted()
        {
            this.ExecuteCmdSearch();
        }
    }
}
