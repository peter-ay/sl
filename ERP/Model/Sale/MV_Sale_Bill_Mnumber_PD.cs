using ERP.Common;
using ERP.Utility;
using ERP.ViewModel;
using System;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Sale_Bill_Mnumber_PD
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        public string TypeNameUI
        {
            get
            {
                return this.TypeName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("TypeNameUI");
            }
        }

        public string StateNameUI
        {
            get
            {
                return this.StateName.UIStr();
            }
            set
            {
                this.RaisePropertyChanged("StateNameUI");
            }
        }

        partial void OnTypeNameChanged()
        {
            this.TypeNameUI = "";
        }

        partial void OnStateNameChanged()
        {
            this.StateNameUI = "";
        }

        private string _MyNotes;
        public string MyNotes
        {
            get { return _MyNotes; }
            set
            {
                _MyNotes = value;
                this.RaisePropertyChanged("MyNotes");
            }
        }

        private int _EditState = 0;
        public int EditState
        {
            get { return _EditState; }
            set
            {
                _EditState = value;
                this.RaisePropertyChanged("EditState");
            }
        }

        partial void OnCreated()
        {
            this.EditState = 1;
            this.MyNotes = "";
            ///////////////////////////////
            this.BillCode = "";
            this.BillDate = DateTime.Now;
            this.ConsignDate = DateTime.Now.AddDays(2);
            this.OBillCode = "";
            this.CusCode = "";
            this.SupplierCode = "";
            this.SerialNum = "";
            this.Out_Good = DateTime.Now.AddDays(2).Day.ToString();
            this.BillType = "XSPD";
            this.BillState = "DSH";
            this.Remark = "";
            this.Notes = "";
            this.Maker = USysInfo.UserCode;
            this.Checker = "";
            this.FromBillCode = "";
            this.WhCode = "";
            this.TempAddress = "";
            this.TempDeptCode = "";
            this.Flag_ReOrder = false;
            this.Flag_UnLock = false;
            this.Flag_Cancel = false;
            this.Flag_Close = false;
            this.Flag_Import = false;
            this.Flag_WebOrder = false;
            this.Mnumber = "";
            this.CusName = "";
            this.AreaName = "";
            this.DeliveryAddress = "";
            this.DeptCode = "";
            this.DeptName = "";
            this.PersonCode = "";
            this.ForeignCurrName = "";
            this.PayWayName = "";
            this.TradeWayName = "";
            this.TransferWayName = "";
            this.StateName = ErpUIText.Get("ERP_New");
            this.TypeName = "";
            this.Mname = "";
            this.WhName = "";
            this.SupplierName = "";
            this.DeliveryNum = "";
            this.UpdateMoney = 0;
            this.UpdateMoneyReason = "";
            this.MnumberReplace = "";
            this.MnameReplace = "";
            this.LR_Flag = "";
        }

        partial void OnCusCodeChanged()
        {
            if (EditState != 1)
                return;

            ComHelpV_B_Mnumber.LoadCusMnumberSmart(this.CusCode);

            this.CusName = "";
            this.ForeignCurrName = "";
            this.PayWayName = "";
            this.TradeWayName = "";
            this.TransferWayName = "";
            this.PersonCode = "";
            this.DeliveryAddress = "";
            this.AreaName = "";
            this.DeptName = "";

            var _ds = ComHelpV_B_Customer.UHV_B_User_Customer.Where(item => item.CusCode.ToUpper() == this.CusCode.MyStr()).FirstOrDefault();
            if (_ds == null)
                return;
            this.CusName = _ds.CusName;
            this.ForeignCurrName = _ds.ForeignCurrName;
            this.TradeWayName = _ds.TradeWayName;
            this.TransferWayName = _ds.TransferWayName;
            this.PersonCode = _ds.PersonCode;
            this.DeliveryAddress = _ds.DeliveryAddress;
            this.AreaName = _ds.AreaName;
            this.DeptName = _ds.DeptName;
        }

        partial void OnSupplierCodeChanged()
        {
            if (EditState != 1) return;
            this.SupplierName = "";

            var rs = ComHelpV_B_Supplier.UHV_B_Supplier.Where(it => it.SupplierCode.MyStr() == this.SupplierCode.MyStr()).FirstOrDefault();
            if (rs == null) return;

            this.SupplierName = rs.SupplierNameUI;
        }

        partial void OnWhCodeChanged()
        {
            if (EditState != 1) return;
            this.WhName = "";

            var rs = ComHelpV_B_Warehouse.UHV_B_Warehouse.Where(it => it.WhCode.MyStr() == this.WhCode.MyStr()).FirstOrDefault();
            if (rs == null) return;

            this.WhName = rs.WhNameUI;
        }

        partial void OnMnumberChanged()
        {
            if (EditState != 1) return;
            this.Mname = "";

            var rs = ComHelpV_B_Mnumber.UHV_B_MnumberSmart.Where(it => it.Mnumber.MyStr() == this.Mnumber.MyStr()).FirstOrDefault();
            if (rs == null) return;

            this.Mname = rs.Mname;
        }

        partial void OnMnumberReplaceChanged()
        {
            if (EditState != 1) return;
            this.MnameReplace = "";

            var rs = ComHelpV_B_Mnumber.UHV_B_MnumberSmart.Where(it => it.Mnumber.MyStr() == this.MnumberReplace.MyStr()).FirstOrDefault();
            if (rs == null) return;

            this.MnameReplace = rs.Mname;
        }
    }
}
