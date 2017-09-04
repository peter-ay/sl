
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using ERP.Web.DomainService.Common;
using ERP.Web.Entity;
using ERP.Web.Model;
using GalaSoft.MvvmLight.Command;
namespace ERP.ViewModel
{
    public class VMSale_Bill_Mnumber_PD : VMBillPD
    {
        #region property


        #endregion

        public VMSale_Bill_Mnumber_PD()
            : base("BillCode")
        {
        }

        protected override string PrepareDDsInfoMainQueryName()
        {
            return "GetV_Sale_Bill_Mnumber_PDBill";
        }

        protected override string PrepareDDsInfoSubQueryName()
        {
            return "GetV_Sale_Bill_Mnumber_PDDetailList";
        }

        protected override void PrepareDContextMain()
        {
            this.DContextMain = new V_Sale_Bill_Mnumber_PD();
        }

        protected override void PrepareDDsInfoMainParameters(bool ispnIndex = false)
        {
            base.PrepareDDsInfoMainParameters(ispnIndex);
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MSale_Bill();
        }

        protected override ComSubGridColumnUpdate FillDContextSub(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Sale_Bill_Mnumber_PDDetail _item = null;

            foreach (V_Sale_Bill_Mnumber_PDDetail item in items)
            {
                _item = new V_Sale_Bill_Mnumber_PDDetail()
                {
                    CYL = item.CYL,
                    BillCode = item.BillCode,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Quantity_Consign = item.Quantity_Consign,
                    Quantity_Consign_Remain = item.Quantity_Consign_Remain,
                    Quantity_Return = item.Quantity_Return,
                    Quantity_Return_Remain = item.Quantity_Return_Remain,
                    SPH = item.SPH,
                    SubID = item.SubID
                };
                this.DContextSub.Add(_item);
            }
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };

            return t;
        }

        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_PD;
            this.IsEnableXYInPut = false;

            switch (uBillState)
            {
                case UBillState.View:
                case UBillState.Drop:

                    break;

                case UBillState.New:
                case UBillState.Edit:
                    this.IsEnableXYInPut = true;
                    if (!string.IsNullOrEmpty(cDC.CusCode))
                    {
                        ComHelpV_Base_Mnumber.LoadCusMnumberSmart(cDC.CusCode);
                    }
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        private RelayCommand<KeyEventArgs> _CmdKeyDownSupplierCode;

        /// <summary>
        /// Gets the CmdKeyDownSupplierCode.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdKeyDownSupplierCode
        {
            get
            {
                return _CmdKeyDownSupplierCode
                    ?? (_CmdKeyDownSupplierCode = new RelayCommand<KeyEventArgs>(ExecuteCmdKeyDownSupplierCode));
            }
        }

        private void ExecuteCmdKeyDownSupplierCode(KeyEventArgs parameter)
        {
            if (parameter.Key != Key.Enter)
                return;

            var cDX = this.DContextMain as V_Sale_Bill_Mnumber_PD;
            if (cDX == null || cDX.EditState != 1)
                return;

            this.GetDefaultSupplierCode();
        }

        private Lazy<DSGetDefaultSupplierCode> dsgetdefaultsuppliercode = new Lazy<DSGetDefaultSupplierCode>();
        private void GetDefaultSupplierCode()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_PD;
            var cuscode = cDC.CusCode.Trim();
            var mnumber = cDC.Mnumber.Trim();

            string processCodes = "";

            cDC.SupplierName = ErpUIText.Get("ERP_Getting");
            dsgetdefaultsuppliercode.Value.Get(cuscode, mnumber, processCodes, geted =>
            {
                cDC.SupplierCode = "";
                cDC.SupplierName = "";
                if (geted.HasError)
                {
                    //USysInfo.ErrMsg = geted.Error.Message;
                    //USysInfo.ErrMsg = ErpUIText.ErrMsg + USysInfo.ErrMsg.Substring(USysInfo.ErrMsg.IndexOf('.') + 1);
                    MessageErp.ErrorMessage(geted.Error.Message.GetErrMsg());
                    geted.MarkErrorAsHandled();
                    return;
                }
                cDC.SupplierCode = geted.Value;
                this.IsFocusSupplierCode = true;
            }, null);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        protected override ComSubGridColumnUpdate GetReturnXYData(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> items)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Sale_Bill_Mnumber_PDDetail _item = null;

            foreach (ComXYInputListFormat item in items)
            {
                _item = new V_Sale_Bill_Mnumber_PDDetail()
                {
                    CYL = item.CYL,
                    BillCode = "",
                    Price = 0,
                    Quantity = item.Quantity,
                    Quantity_Consign = 0,
                    Quantity_Consign_Remain = 0,
                    Quantity_Return = 0,
                    Quantity_Return_Remain = 0,
                    SPH = item.SPH,
                    SubID = item.SubID
                };
                this.DContextSub.Add(_item);
            }
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };
            return t;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void FillXYInputResultDataList(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> observableCollection)
        {
            ComXYInputListFormat _item = null;
            foreach (V_Sale_Bill_Mnumber_PDDetail item in this.DContextSub)
            {
                _item = new ComXYInputListFormat()
                {
                    SubID = item.SubID,
                    SPH = item.SPH,
                    CYL = item.CYL,
                    Quantity = item.Quantity
                };
                observableCollection.Add(_item);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override string PrepareDSBill()
        {
            return "Sale_Bill";
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void PrepareModelToSave()
        {
            var _DC = this.DContextMain as V_Sale_Bill_Mnumber_PD;
            var _CM = this.CurrentModel as MSale_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();

            if (string.IsNullOrEmpty(_DC.MnumberReplace))
            {
                _DC.MnumberReplace = _DC.Mnumber;
            }

            _CM.SubMnumber = new MSale_Bill_Mnumber()
                {
                    BillCode = _CM.BillCode.Trim(),
                    ContractType = "",
                    DeliveryMname = "",
                    LR_Flag = _DC.LR_Flag.Trim(),
                    Mnumber = _DC.Mnumber.Trim(),
                    MnumberReplace = _DC.MnumberReplace.Trim()
                };

            _CM.SubMnumber_Detail = new List<MSale_Bill_Mnumber_Detail>();
            MSale_Bill_Mnumber_Detail _item = null;
            foreach (V_Sale_Bill_Mnumber_PDDetail item in this.DContextSub)
            {
                _item = new MSale_Bill_Mnumber_Detail()
                {
                    BillCode = _CM.BillCode.Trim(),
                    CYL = item.CYL,
                    Price = 0,
                    Quantity = item.Quantity,
                    Quantity_Consign = 0,
                    Quantity_Return = 0,
                    SPH = item.SPH,
                    SubID = item.SubID
                };
                _CM.SubMnumber_Detail.Add(_item);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override bool VerifySave()
        {
            var cDC = this.DContextMain as V_Sale_Bill_Mnumber_PD;
            //////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.CusCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                return false;
            }
            ///////////////////////////////////////////////////////////////////
            if ((this.DContextSub.Count) <= 0)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_SumQtyLess"));
                return false;
            }

            ///////////////////////////////////////////////////////////////
            if (string.IsNullOrEmpty(cDC.WhCode) && string.IsNullOrEmpty(cDC.SupplierCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_WGorWhCode"));
                return false;
            }

            if (!string.IsNullOrEmpty(cDC.WhCode) && !string.IsNullOrEmpty(cDC.SupplierCode))
            {
                MessageErp.ErrorMessage(ErpUIText.Get("Sale_Bill_Mnumber_SD_Err_WGandWhCode"));
                return false;
            }

            return true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
