using ERP.Common;
using System;

namespace ERP.ViewModel
{
    public class VMSale_ContractBill_Sub_Process_List : VMList
    {
        public VMSale_ContractBill_Sub_Process_List()
            : base("SubID", "Sale_ContractBill_Sub_Process")
        {
            IsChildWindow = true;
        } 

        protected override void PrepareDDsInfoMainParameters()
        {
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "contractCode", Value = this.CurrentIDCode.MyStr() });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "mnumber", Value = this.SKeyCode.MyStr() });
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
        private string _tbname = "Sale_ContractBill_Sub_Process";

        protected override void Export()
        {
            ComExport.Export(_tbname, " ContractCode='" + this.CurrentIDCode + "'", " order by SubID",
            @"SubID,Mnumber,ProcessSet,Price,InvoiceTitle,
                ChaSe,JuSe,ShuiYin,RanSe,
                UV,JingJia,JiaYing,PaoGuang,CaiBian,CheBian,KaiKeng,PiHua,DaoBian,
                MianWan,ZuanKong,OtherProcess,ExtraProcess,Remark ");
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
