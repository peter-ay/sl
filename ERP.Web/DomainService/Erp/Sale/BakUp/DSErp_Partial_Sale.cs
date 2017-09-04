

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSErp
    {
        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="frameCode"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_ContractBill_Sub_FrameSet> GetV_Sale_ContractBill_Sub_FrameSetList
            (string dbCode, string contractCode, string frameCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_Sale_ContractBill_Sub_FrameSet.Where(item => item.ContractCode == contractCode);

            if (!string.IsNullOrEmpty(frameCode))
            {
                frameCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.FrameCode.ToUpper().Contains(it)); });
            }

            return rs;
        }

        /// <summary>
        /// /////////////////
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="frameCode"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_ContractBill_Sub_Frame> GetV_Sale_ContractBill_Sub_FrameList
            (string dbCode, string contractCode, string frameCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_Sale_ContractBill_Sub_Frame.Where(item => item.ContractCode == contractCode);

            if (!string.IsNullOrEmpty(frameCode))
            {
                frameCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.FrameCode.ToUpper().Contains(it)); });
            }

            return rs;
        }

        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="mnumber"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_ContractBill_Sub_Process> GetV_Sale_ContractBill_Sub_ProcessList
            (string dbCode, string contractCode, string mnumber)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_Sale_ContractBill_Sub_Process.Where(item => item.ContractCode == contractCode);

            if (!string.IsNullOrEmpty(mnumber))
            {
                mnumber.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.Mnumber.ToUpper().Contains(it)); });
            }

            return rs;
        }

        /// <summary>
        /// /////////////////////////////////////////
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_ContractBill_Sub_Mnumber> GetV_Sale_ContractBill_Sub_MnumberList
            (string dbCode, string contractCode, string mnumber)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_Sale_ContractBill_Sub_Mnumber.Where(item => item.ContractCode == contractCode);

            if (!string.IsNullOrEmpty(mnumber))
            {
                mnumber.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.Mnumber.ToUpper().Contains(it)); });
            }

            return rs;
        }

        public IQueryable<V_Sale_ContractBill> GetV_Sale_ContractBillBill
            (string dbCode, string contractCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            if (string.IsNullOrEmpty(contractCode))
                return this.ObjectContext.V_Sale_ContractBill;
            return this.ObjectContext.V_Sale_ContractBill.Where(item => item.ContractCode == contractCode);
        }

        /// <summary>
        /// ///////////////
        /// </summary>
        /// <param name="cusType"></param>
        /// <param name="cusCode"></param>
        /// <param name="code1"></param>
        /// <param name="code2"></param>
        /// <param name="ocode"></param>
        /// <param name="maker"></param>
        /// <param name="checker"></param>
        /// <param name="cdicheck"></param>
        /// <param name="conType"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_ContractBill> GetV_Sale_ContractBillList
            (string dbCode,
            DateTime d1, DateTime d2,
            string cusType, string cusCode, string code1, string code2, string ocode,
            string maker, string checker, int cdicheck, string conType)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_Sale_ContractBill.Where(item =>
                item.ContractDate.CompareTo(d1) >= 0 && item.ContractDate.CompareTo(d2) <= 0);
            //
            if (!string.IsNullOrEmpty(cusType))
            {
                cusType.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.CusType.ToUpper().Contains(it)); });
            }
            //
            if (!string.IsNullOrEmpty(code1) || !string.IsNullOrEmpty(code2))
            {
                if (string.IsNullOrEmpty(code1)) code1 = code2;
                if (string.IsNullOrEmpty(code2)) code2 = code1;

                if (code1 == code2)
                {
                    code1.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.ContractCode.ToUpper().Contains(it)); });
                }
                else
                {
                    rs = rs.Where(item => item.ContractCode.ToUpper().CompareTo(code1) >= 0
                        && item.ContractCode.ToUpper().CompareTo(code2) <= 0);
                }
            }
            //
            if (!string.IsNullOrEmpty(ocode))
            {
                ocode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.OContractCode.ToUpper().Contains(it)); });
            }
            //
            if (!string.IsNullOrEmpty(maker))
            {
                maker.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.Maker.ToUpper().Contains(it)); });
            }
            //
            if (!string.IsNullOrEmpty(checker))
            {
                checker.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.Checker.ToUpper().Contains(it)); });
            }
            //
            if (cdicheck != -1)
            {
                if (cdicheck == 0)
                {
                    rs = rs.Where(item => item.Checker == "");
                }
                if (cdicheck == 1)
                {
                    rs = rs.Where(item => item.Checker != "");
                }
            }
            //
            if (!string.IsNullOrEmpty(conType))
            {
                rs = rs.Where(item => item.ContractType == conType);
            }

            if (!string.IsNullOrEmpty(cusCode))
            {
                var rscs = this.ObjectContext.V_Sale_ContractBill_Sub_CusCode.Where(item => item.CusCode.ToUpper().Contains(cusCode)).Select(item2 => item2.ContractCode);
                rs = rs.Where(item => rscs.Contains(item.ContractCode));
            }

            return rs;
        }

        /// <summary>
        /// /////////////////
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="includeState"></param>
        /// <returns></returns>
        public IQueryable<V_B_CustomerSmart> GetV_Sale_ContractBill_Sub_CusCodeList
            (string dbCode, string cusCode, string cusName, string contractCode, int includeState)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            var rs = this.ObjectContext.V_B_CustomerSmart.Where(item => !string.IsNullOrEmpty(item.CusCode));

            if (!string.IsNullOrEmpty(cusCode))
            {
                cusCode.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusCode.ToUpper().Contains(it)); });
            }

            if (!string.IsNullOrEmpty(cusName))
            {
                cusName.Split('%').ToList().ForEach(it => { rs = rs.Where(item => item.CusName.ToUpper().Contains(it)); });
            }

            if (includeState != -1)
            {
                contractCode = contractCode.Trim().ToUpper();
                var cuscodes = from c in this.ObjectContext.V_Sale_ContractBill_Sub_CusCode
                               where c.ContractCode == contractCode
                               select c.CusCode.ToUpper();

                switch (includeState)
                {
                    case 0:
                        rs = rs.Where(item => !cuscodes.Contains(item.CusCode.ToUpper()));
                        break;
                    case 1:
                        rs = rs.Where(item => cuscodes.Contains(item.CusCode.ToUpper()));
                        break;
                }
            }
            return rs;
        }

        /// <summary>
        /// ////
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="code1"></param>
        /// <param name="code2"></param>
        /// <param name="ocode1"></param>
        /// <param name="ocode2"></param>
        /// <param name="deliveryNum1"></param>
        /// <param name="deliveryNum2"></param>
        /// <param name="maker"></param>
        /// <param name="checker"></param>
        /// <param name="mnumber"></param>
        /// <param name="cusCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="supplierCode"></param>
        /// <param name="cdicheck"></param>
        /// <param name="cdiBillType"></param>
        /// <param name="cdiExport"></param>
        /// <param name="cdiDelivery"></param>
        /// <param name="cdiOutGood"></param>
        /// <param name="cdiCX"></param>
        /// <returns></returns>
        //public IQueryable<V_B_Lens> GetV_B_LensList
        //    (string dbCode, string userCode,
        //    DateTime d1, DateTime d2,
        //    string code1, string code2, string ocode, string deliveryNum1, string deliveryNum2,
        //    string serialNum,
        //    string maker, string checker, string mnumber,
        //    string cusCode, string deptCode, string supplierCode, string fromBillCode,
        //    int cdicheck, string cdiBillType, int cdiExport, int cdiDelivery, int cdiOutGood, int cdiCX)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    //var rscus = from c in this.GetV_Common_User_CustomerBrowse()
        //    //            where c.UserCode == userCode
        //    //            select c.CusCode.ToUpper();
        //    //
        //    //var rs = this.ObjectContext.V_B_Lens.Where(item => item.UserCode.Contains(userCode));
        //    ////date
        //    //rs = rs.Where(item => item.BillDate.Value.CompareTo(d1) >= 0 && item.BillDate.Value.CompareTo(d2) <= 0);
        //    ////cuscode
        //    //if (!string.IsNullOrEmpty(cusCode))
        //    //{
        //    //    cusCode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.CusCode.Contains(it)); });
        //    //}
        //    ////code
        //    //if (!string.IsNullOrEmpty(code1) || !string.IsNullOrEmpty(code2))
        //    //{
        //    //    if (string.IsNullOrEmpty(code1)) code1 = code2;
        //    //    if (string.IsNullOrEmpty(code2)) code2 = code1;
        //    //    //
        //    //    if (code1 == code2)
        //    //    {
        //    //        code1.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.BillCode.Contains(it)); });
        //    //    }
        //    //    else
        //    //    {
        //    //        rs = rs.Where(item => item.BillCode.CompareTo(code1) >= 0 && item.BillCode.CompareTo(code2) <= 0);
        //    //    }
        //    //}
        //    ////ocode
        //    //if (!string.IsNullOrEmpty(ocode))
        //    //{
        //    //    ocode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.OBillCode.Contains(it)); });
        //    //}
        //    ////deliveryNum 未完成
        //    //if (!string.IsNullOrEmpty(deliveryNum1) || !string.IsNullOrEmpty(deliveryNum2))
        //    //{
        //    //    if (string.IsNullOrEmpty(deliveryNum1)) deliveryNum1 = deliveryNum2;
        //    //    if (string.IsNullOrEmpty(deliveryNum2)) deliveryNum2 = deliveryNum1;

        //    //    if (deliveryNum1 == deliveryNum2)
        //    //    {
        //    //        deliveryNum1.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.DeliveryNum.Contains(it)); });
        //    //    }
        //    //    else
        //    //    {
        //    //        rs = rs.Where(item => item.DeliveryNum.CompareTo(deliveryNum1) >= 0 && item.DeliveryNum.CompareTo(deliveryNum2) <= 0);
        //    //    }
        //    //}
        //    ////serialNum
        //    //if (!string.IsNullOrEmpty(serialNum))
        //    //{
        //    //    serialNum.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.SerialNum.Contains(it)); });
        //    //}
        //    ////maker
        //    //if (!string.IsNullOrEmpty(maker))
        //    //{
        //    //    maker.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.Maker.Contains(it)); });
        //    //}
        //    ////checker
        //    //if (!string.IsNullOrEmpty(checker))
        //    //{
        //    //    checker.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.Checker.Contains(it)); });
        //    //}
        //    ////mnumber
        //    //if (!string.IsNullOrEmpty(mnumber))
        //    //{
        //    //    mnumber.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.MnumberR.Contains(it) || item.MnumberL.Contains(it)); });
        //    //}
        //    ////deptCode
        //    //if (!string.IsNullOrEmpty(deptCode))
        //    //{
        //    //    deptCode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.DeptCode.Contains(it)); });
        //    //}
        //    ////supplierCode
        //    //if (!string.IsNullOrEmpty(supplierCode))
        //    //{
        //    //    supplierCode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.SupplierCode.Contains(it)); });
        //    //}
        //    ////feomBillCode
        //    //if (!string.IsNullOrEmpty(fromBillCode))
        //    //{
        //    //    fromBillCode.Split('%').ToList().ForEach((it) => { rs = rs.Where(item => item.FromBillCode.Contains(it)); });
        //    //}
        //    ////
        //    //if (cdicheck != -1)
        //    //{
        //    //    if (cdicheck == 1) { rs = rs.Where(item => !string.IsNullOrEmpty(item.Checker)); }
        //    //    else { rs = rs.Where(item => string.IsNullOrEmpty(item.Checker)); }
        //    //}
        //    ////
        //    //if (!string.IsNullOrEmpty(cdiBillType)) { rs = rs.Where(item => item.BillType == cdiBillType); }
        //    ////
        //    //if (cdiExport != -1)
        //    //{
        //    //    if (cdiExport == 1) { rs = rs.Where(item => !string.IsNullOrEmpty(item.SerialNum)); }
        //    //    else { rs = rs.Where(item => string.IsNullOrEmpty(item.SerialNum)); }
        //    //}
        //    ////
        //    //if (cdiDelivery != -1)
        //    //{
        //    //    if (cdiDelivery == 1) { rs = rs.Where(item => !string.IsNullOrEmpty(item.DeliveryNum)); }
        //    //    else { rs = rs.Where(item => string.IsNullOrEmpty(item.DeliveryNum)); }
        //    //}
        //    ////
        //    //if (cdiOutGood != -1)
        //    //{
        //    //    if (cdiOutGood == 1) { rs = rs.Where(item => string.IsNullOrEmpty(item.SupplierCode)); }
        //    //    else { rs = rs.Where(item => !string.IsNullOrEmpty(item.SupplierCode)); }
        //    //}
        //    ////
        //    //if (cdiCX != -1)
        //    //{
        //    //    if (cdiCX == 1) { rs = rs.Where(item => item.Flag_CX == true); }
        //    //    else { rs = rs.Where(item => !item.Flag_CX == true); }
        //    //}

        //    return this.ObjectContext.V_B_Lens;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public IQueryable<V_Sale_Order_SD> GetV_Sale_Order_SDBill
            (string dbCode, string userCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            //var cusList = from c in this.GetV_Common_User_CustomerBrowse()
            //              where c.UserCode == userCode
            //              select c.CusCode.ToUpper();

            //var rs = this.ObjectContext.V_B_Lens_SD.Where(item => cusList.Contains(item.CusCode.ToUpper()));

            //if (string.IsNullOrEmpty(billCode))
            //    return rs;
            var rs = this.ObjectContext.V_Sale_Order_SD;
            return rs.Where(item => item.ID == iD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        //public IQueryable<V_B_Lens_PD> GetV_B_Lens_PDBill
        //    (string dbCode, string userCode, string billCode)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);

        //    var cusList = from c in this.GetV_Common_User_CustomerBrowse()
        //                  where c.UserCode == userCode
        //                  select c.CusCode.ToUpper();

        //    var rs = this.ObjectContext.V_B_Lens_PD.Where(item => cusList.Contains(item.CusCode.ToUpper()));

        //    if (string.IsNullOrEmpty(billCode))
        //        return rs;

        //    return rs.Where(item => item.BillCode == billCode);
        //}

        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        /// <param name="dbCode"></param>
        /// <param name="billCode"></param>
        /// <returns></returns>
        //public IQueryable<V_B_Lens_PDDetail> GetV_B_Lens_PDDetailList
        //    (string dbCode, string billCode)
        //{
        //    this.ObjectContext.ChangeDataBase(dbCode);
        //    return this.ObjectContext.V_B_Lens_PDDetail.Where(item => item.BillCode == billCode);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cusCode"></param>
        /// <returns></returns>
        public IQueryable<V_B_Lens> GetV_B_CusMnumberList(string dbCode, string cusCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            cusCode = cusCode.MyStr();

            var cusList = from c in this.GetV_Sale_ContractBill_Sub_CusCode()
                          where c.CusCode == cusCode
                          select c.ContractCode;

            var billCodeList = from c in this.GetV_Sale_ContractBill()
                               where cusList.Contains(c.ContractCode)
                               && !string.IsNullOrEmpty(c.Checker)
                               && c.BeginDate.CompareTo(DateTime.Now) <= 0
                               && c.EndDate.CompareTo(DateTime.Now) >= 0
                               select c.ContractCode;

            var mnumberList1 = from c in this.GetV_Sale_ContractBill_Sub_Mnumber()
                               where billCodeList.Contains(c.ContractCode)
                               select c.Mnumber.ToUpper();
            var rs = this.ObjectContext.V_B_Lens.Where(item =>
                mnumberList1.Contains(item.LensCode.ToUpper()));

            return rs;
        } 
    }
}