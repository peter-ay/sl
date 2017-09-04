using System;
using System.Collections.Generic;
using ERP.Common;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using ERP.Web.Model;

namespace ERP.ViewModel
{
    public class VMSale_ContractBill_Sub_Mnumber_List : VMList
    {
        public VMSale_ContractBill_Sub_Mnumber_List()
            : base("Mnumber", "Sale_ContractBill_Sub_Mnumber")
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
        private string _tbname = "Sale_ContractBill_Sub_Mnumber";

        protected override void Export()
        {
            ComExport.Export(_tbname, " ContractCode='" + this.CurrentIDCode + "'", " order by Mnumber",
            @" [Mnumber],[SPH1],[SPH2],[CYL1],[CYL2],[ADD1],[ADD2],[Price],[Size],[InvoiceTitle]");
        }

        protected override void Import()
        {
            ComImport.Import(_tbname, this.CurrentIDCode);
        }

        protected override void OnImportCompleted()
        {
            this.ExecuteCmdSearch();
        }

        protected override void Delete()
        {
            Lazy<DSDelete> DS_Bill_Deletes = new Lazy<DSDelete>();
            List<MSale_ContractBill_Sub_Mnumber> _codelist = new List<MSale_ContractBill_Sub_Mnumber>();
            try
            {
                foreach (V_Sale_ContractBill_Sub_Mnumber item in this.DContextMain)
                {
                    if (Convert.ToBoolean(item.GetType().GetProperty("IsSelected").GetValue(item, null)))
                    {
                        _codelist.Add(
                            new MSale_ContractBill_Sub_Mnumber()
                            {
                                Mnumber = item.Mnumber,
                                SPH1 = item.SPH1,
                                SPH2 = item.SPH2,
                                CYL1 = item.CYL1,
                                CYL2 = item.CYL2,
                                ADD1 = item.ADD1,
                                ADD2 = item.ADD2
                            });
                    }
                }
                if (_codelist.Count == 0)
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("ERP_DeleteNone"));
                    return;
                }
                this.IsBusy = true;
                DS_Bill_Deletes.Value.DeleteSale_ContractBill_Sub_Mnumber(this.CurrentIDCode, _codelist, geted =>
                {
                    this.IsBusy = false;
                    if (geted.HasError)
                    {
                        //USysInfo.ErrMsg = ErpUIText.Get("ERP_Err") + geted.Error.Message.Substring(geted.Error.Message.IndexOf('.') + 1);
                        MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                        geted.MarkErrorAsHandled();
                        return;
                    }
                    MessageErp.InfoMessage(ErpUIText.Get("ERP_DeleteSucceed"));
                    this.ExecuteCmdSearch();
                }, null);
            }
            catch
            { MessageErp.ErrorMessage(ErpUIText.Get("ERP_Err")); }
        }
    }
}
