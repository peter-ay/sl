using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Controls;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using ERP.Web.Entity;

namespace ERP.ViewModel
{
    public class VMSale_Bill_Mnumber_List : VMList
    {

        #region Property

        private string deptCode;
        public string DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; RaisePropertyChanged("DeptCode"); }
        }

        private string cusCode;
        public string CusCode
        {
            get { return cusCode; }
            set { cusCode = value; RaisePropertyChanged("CusCode"); }
        }

        private string supplierCode;
        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; RaisePropertyChanged("SupplierCode"); }
        }

        private string billCode1;
        public string BillCode1
        {
            get { return billCode1; }
            set { billCode1 = value; RaisePropertyChanged("BillCode1"); }
        }

        private string billCode2;
        public string BillCode2
        {
            get { return billCode2; }
            set { billCode2 = value; RaisePropertyChanged("BillCode2"); }
        }

        private string oBillCode;
        public string OBillCode
        {
            get { return oBillCode; }
            set { oBillCode = value; RaisePropertyChanged("OBillCode"); }
        }

        private string serialNum;
        public string SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; RaisePropertyChanged("SerialNum"); }
        }

        private string _FromBillCode;
        public string FromBillCode
        {
            get { return _FromBillCode; }
            set { _FromBillCode = value; RaisePropertyChanged("FromBillCode"); }
        }

        private string deliveryNum1;
        public string DeliveryNum1
        {
            get { return deliveryNum1; }
            set { deliveryNum1 = value; RaisePropertyChanged("DeliveryNum1"); }
        }

        private string deliveryNum2;
        public string DeliveryNum2
        {
            get { return deliveryNum2; }
            set { deliveryNum2 = value; RaisePropertyChanged("DeliveryNum2"); }
        }

        private string mnumber;
        public string Mnumber
        {
            get { return mnumber; }
            set { mnumber = value; RaisePropertyChanged("Mnumber"); }
        }

        private string cdiBillType = "";
        private int cdiExport = -1;
        private int cdiDelivery = -1;
        private int cdiOutGood = -1;
        private int cdiCX = -1;


        private bool isDeliveryAll = true;
        public bool IsDeliveryAll
        {
            get { return isDeliveryAll; }
            set { isDeliveryAll = value; RaisePropertyChanged("IsDeliveryAll"); }
        }

        private bool isExportAll = true;
        public bool IsExportAll
        {
            get { return isExportAll; }
            set { isExportAll = value; RaisePropertyChanged("IsExportAll"); }
        }

        private bool isCXAll = true;
        public bool IsCXAll
        {
            get { return isCXAll; }
            set { isCXAll = value; RaisePropertyChanged("IsCXAll"); }
        }

        private bool isOutGoodAll = true;
        public bool IsOutGoodAll
        {
            get { return isOutGoodAll; }
            set { isOutGoodAll = value; RaisePropertyChanged("IsOutGoodAll"); }
        }

        #endregion


        public VMSale_Bill_Mnumber_List()
            : base("BillCode", "Sale_Bill_Mnumber")
        {
        }

        protected override void InitSearchCondition()
        {
            base.InitSearchCondition();
            this.SupplierCode = "";
            this.DeptCode = "";
            this.Checker = "";
            this.Maker = "";
            this.CusCode = "";
            this.BillCode1 = "";
            this.BillCode2 = "";
            this.OBillCode = "";
            this.SerialNum = "";
            this.Mnumber = "";
            this.DeliveryNum1 = "";
            this.DeliveryNum2 = "";
            this.cdiBillType = "";
            this.FromBillCode = "";
            this.cdiCX = -1;
            this.cdiDelivery = -1;
            this.cdiExport = -1;
            this.cdiOutGood = -1;
            this.IsCheckAll = true;
            this.IsTypeAll = true;
            this.IsCXAll = true;
            this.IsDeliveryAll = true;
            this.IsExportAll = true;
            this.IsOutGoodAll = true;
        }

        protected override void PrepareDDsInfoMainParameters()
        {
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "userCode", Value = USysInfo.UserCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "d1", Value = this.D1 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "d2", Value = this.D2 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "code1", Value = this.BillCode1 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "code2", Value = this.BillCode2 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "ocode", Value = this.OBillCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "deliveryNum1", Value = this.DeliveryNum1 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "deliveryNum2", Value = this.DeliveryNum2 });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "serialNum", Value = this.SerialNum });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "maker", Value = this.Maker });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "checker", Value = this.Checker });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "mnumber", Value = Mnumber });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cusCode", Value = this.CusCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "deptCode", Value = this.DeptCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "supplierCode", Value = this.SupplierCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "fromBillCode", Value = this.FromBillCode });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdicheck", Value = _cdiCheck });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdiBillType", Value = cdiBillType });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdiExport", Value = cdiExport });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdiDelivery", Value = cdiDelivery });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdiOutGood", Value = cdiOutGood });
            this.DDsInfoMain.Parameters.Add(new ComParameters() { ParameterName = "cdiCX", Value = cdiCX });
        }

        #region Cdi

        private RelayCommand<string> _CmdRBCdiCX;

        /// <summary>
        /// Gets the CmdRBCdiCX.
        /// </summary>
        public RelayCommand<string> CmdRBCdiCX
        {
            get
            {
                return _CmdRBCdiCX
                    ?? (_CmdRBCdiCX = new RelayCommand<string>(
                    p =>
                    {
                        this.cdiCX = Convert.ToInt32(p);
                    }));
            }
        }
        /////////////////////////////
        private RelayCommand<string> _CmdRBCdiDelivery;

        /// <summary>
        /// Gets the CmdRBCdiDelivery.
        /// </summary>
        public RelayCommand<string> CmdRBCdiDelivery
        {
            get
            {
                return _CmdRBCdiDelivery
                    ?? (_CmdRBCdiDelivery = new RelayCommand<string>(
                    p =>
                    {
                        this.cdiDelivery = Convert.ToInt32(p);
                    }));
            }
        }
        //////////////////////////////////////////

        private RelayCommand<string> _CmdRBCdiBillType;

        /// <summary>
        /// Gets the CmdRBCdiBillType.
        /// </summary>
        public RelayCommand<string> CmdRBCdiBillType
        {
            get
            {
                return _CmdRBCdiBillType
                    ?? (_CmdRBCdiBillType = new RelayCommand<string>(
                    p =>
                    {
                        cdiBillType = p;
                    }));
            }
        }
        ////////////////////////////////////////
        private RelayCommand<string> _CmdRBCdiExport;

        /// <summary>
        /// Gets the CmdRBCdiExport.
        /// </summary>
        public RelayCommand<string> CmdRBCdiExport
        {
            get
            {
                return _CmdRBCdiExport
                    ?? (_CmdRBCdiExport = new RelayCommand<string>(
                    p =>
                    {
                        this.cdiExport = Convert.ToInt32(p);
                    }));
            }
        }
        //////////////////////////////////////////////////
        private RelayCommand<string> _CmdRBCdiOutGood;

        /// <summary>
        /// Gets the CmdRBCdiOutGood.
        /// </summary>
        public RelayCommand<string> CmdRBCdiOutGood
        {
            get
            {
                return _CmdRBCdiOutGood
                    ?? (_CmdRBCdiOutGood = new RelayCommand<string>(
                    p =>
                    {
                        this.cdiOutGood = Convert.ToInt32(p);
                    }));
            }
        }

        #endregion

        protected override void GridListClick1(string parameter)
        {
            string _funCode = "";
            string billType = "";

            if (parameter.Contains("XSSD"))
                billType = "XSSD";
            else if (parameter.Contains("XSPD"))
                billType = "XSPD";
            else
                billType = "";

            switch (billType)
            {
                case "XSSD":
                    _funCode = "Sale_Bill_Mnumber_SD";
                    break;
                case "XSPD":
                    _funCode = "Sale_Bill_Mnumber_PD";
                    break;
                default:
                    break;
            }

            ComOpenWins.Open("", _funCode);
            Messenger.Default.Send<string>((parameter), "VM" + _funCode + "_ShowFromList");
        }

        //////////////////////////////////////////////////////////////////////////////////
        protected override void Export()
        {
            if (this.GridListSelectedCodes.Count == 0) return;
            bool _cx = false;
            foreach (V_Sale_Bill_Mnumber it in this.DContextMain)
            {
                if (it.IsSelected)
                {
                    _cx = it.Flag_CX;
                    break;
                }
            }
            ComExportToFactory.Export(this.GridListSelectedCodes, _cx);
        }

    }
}
