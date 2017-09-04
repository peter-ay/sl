
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
using System.Linq;
using ERP.Web.DomainService.Erp;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public class VMSale_Rec_PD : VMBillPD
    {
        #region property

        private string _IDSale;

        private V_Ware_Bill_SO_PD _DC
        {
            get
            {
                return this.DContextMain as V_Ware_Bill_SO_PD;
            }
        }

        #endregion

        public VMSale_Rec_PD()
            : base("ID", "Ware_Bill_SO_PD")
        {
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, this.VMName + "_NewWGSOFromList", (msg) =>
            {
                this._IDSale = msg;
                this.NewSO();
            });
        }

        private void NewSO()
        {
            this.New();
            var _DDsSaleMain = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Ware_Bill_SO_Pending_PDBill", _DDsSaleMain_LoadedData, true);
            _DDsSaleMain.QueryParameters.Add(new System.Windows.Controls.Parameter() { ParameterName = "iD", Value = _IDSale });
            _DDsSaleMain.Load();
        }

        private void _DDsSaleMain_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                USysInfo.ErrMsg = ErpUIText.Get("ERP_NoOrderSO") + this.SIDCode;
                MessageErp.ErrorMessage(USysInfo.ErrMsg);
                this.Drop();
                return;
            }

            if (e.Entities.Count() <= 0)
            {
                USysInfo.ErrMsg = ErpUIText.Get("ERP_NoOrderSOQty") + this.SIDCode;
                MessageErp.ErrorMessage(USysInfo.ErrMsg);
                this.Drop();
                return;
            }

            this.GetSONewSub();
            var item = e.Entities.FirstOrDefault() as V_Ware_Bill_SO_Pending_PD;
            //
            this._DC.BCodeSale = item.BCode;
            this._DC.BDateSale = item.BDate;
            this._DC.CsDateSale = item.CsDate;
            this._DC.CusCode = item.CusCode;
            this._DC.CusName = item.CusName;
            this._DC.FBCode = item.BCode;
            this._DC.ID = "";
            this._DC.LensCode = item.LensCodeR;
            this._DC.LensCodeSale = item.LensCode;
            this._DC.LensName = item.LensNameR;
            this._DC.LensNameSale = item.LensName;
            this._DC.F_LR = item.F_LRSale;
            this._DC.F_LRSale = item.F_LRSale;
            this._DC.NotesSale = item.Notes;
            this._DC.OBCodeSale = item.OBCode;
            this._DC.RemarkSale = item.Remark;
            this._DC.WhCode = "";
            this._DC.WhName = "";
        }

        private void GetSONewSub()
        {
            var _DDsSaleSub = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_Sale_Order_PDDetailList", _DDsSaleSub_LoadedData, true);
            _DDsSaleSub.QueryParameters.Add(new System.Windows.Controls.Parameter() { ParameterName = "iD", Value = _IDSale });
            _DDsSaleSub.Load();
        }

        private void _DDsSaleSub_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Ware_Bill_SO_PD_Detail _Item = null;
            foreach (V_Sale_Order_PD_Detail item in e.Entities)
            {
                _Item = new V_Ware_Bill_SO_PD_Detail()
                {
                    CYL = item.CYL,
                    ID = "",
                    Price = 0,
                    Qty = item.QtyUnSO,
                    QtySale = item.Qty,
                    SPH = item.SPH,
                    SubID = item.SubID,
                    X_ADD = item.X_ADD
                };
                this.DContextSub.Add(_Item);
            }
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };
            Messenger.Default.Send<ComSubGridColumnUpdate>(t, USysMessages.RefreshSubGrid);
            this.IsFocusMain = true;
        }

        protected override void PrepareModel()
        {
            this.CurrentModel = new MWare_Bill();
        }

        protected override void PrepareModelToSave()
        {
            var _CM = this.CurrentModel as MWare_Bill;
            if (null == _DC || null == _CM)
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg); return;
            }
            base.PrepareModelToSave();
            _CM.MType = "L";
            _CM.F_IO = false;
            _CM.F_SD = false;
            _CM.BType = "KFSOPDWG";
            //
            _CM.Sub_PD = new MWare_Bill_PD()
            {
                ID = _DC.ID,
                F_LR = _DC.F_LR,
                LensCode = _DC.LensCode
            };
            //
            MWare_Bill_PD_Detail _Item = null;
            int _SumQty = 0;
            _CM.Sub_PD_Detail = new List<MWare_Bill_PD_Detail>();
            foreach (V_Ware_Bill_SO_PD_Detail item in this.DContextSub)
            {
                _Item = new MWare_Bill_PD_Detail()
                {
                    ID = _DC.ID,
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value,
                    Price = 0
                };
                _CM.Sub_PD_Detail.Add(_Item);
                _SumQty += item.Qty.Value;
            }
        }

        protected override string PrepareDSBill()
        {
            return "Ware_Bill";
        }

        protected override void FillXYInputResultDataList(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> observableCollection)
        {
            ComXYInputListFormat _item = null;
            foreach (V_Ware_Bill_SO_PD_Detail item in this.DContextSub)
            {
                _item = new ComXYInputListFormat()
                {
                    SubID = item.SubID,
                    SPH = item.SPH.Value,
                    CYL = item.CYL.Value,
                    X_ADD = item.X_ADD.Value,
                    Qty = item.Qty.Value,
                };
                observableCollection.Add(_item);
            }
        }

        protected override ComSubGridColumnUpdate GetReturnXYData(System.Collections.ObjectModel.ObservableCollection<ComXYInputListFormat> comXYInputListFormat)
        {
            //
            foreach (V_Ware_Bill_SO_PD_Detail _Item in this.DContextSub)
            {
                _Item.Qty = 0;
            }
            //
            foreach (ComXYInputListFormat _Item1 in comXYInputListFormat)
            {
                foreach (V_Ware_Bill_SO_PD_Detail _Item2 in this.DContextSub)
                {

                    if (_Item2.SPH == _Item1.SPH && _Item2.CYL == _Item1.CYL && _Item2.X_ADD == _Item1.X_ADD)
                    {
                        _Item2.Qty = _Item1.Qty;
                        break;
                    }
                }
            }
            //
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = DContextSub
            };
            return t;
        }

        protected override ComSubGridColumnUpdate GetDContextSubToUpdateSubGrid(IEnumerable<System.ServiceModel.DomainServices.Client.Entity> items)
        {
            this.DContextSub = new System.Collections.ObjectModel.ObservableCollection<System.ServiceModel.DomainServices.Client.Entity>();
            V_Ware_Bill_SO_PD_Detail _item = null;

            foreach (V_Ware_Bill_SO_PD_Detail item in items)
            {
                _item = new V_Ware_Bill_SO_PD_Detail()
                {
                    CYL = item.CYL,
                    ID = item.ID,
                    Price = item.Price,
                    Qty = item.Qty,
                    QtySale = item.QtySale,
                    X_ADD = item.X_ADD,
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
    }
}
