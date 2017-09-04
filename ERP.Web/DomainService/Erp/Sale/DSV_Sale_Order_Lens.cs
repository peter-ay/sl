

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using ERP.Web.Common;
    using System.Collections.Generic;
    using System.Data;
    using ERP.Web.DBUtility;
    using System.Data.SqlClient;

    public partial class DSErp
    {
        //SD
        public IQueryable<V_Sale_Order_SD> GetV_Sale_Order_SDBill(string dbCode, string iD, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_Order_SD> _Rs = this.ObjectContext.V_Sale_Order_SD;
            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            if (iD == "") return _Rs;

            return _Rs.Where(item => item.ID == iD);
        }
        //PD
        public IQueryable<V_Sale_Order_PD> GetV_Sale_Order_PDBill(string dbCode, string iD, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_Order_PD> _Rs = this.ObjectContext.V_Sale_Order_PD;
            if (gpID != -99)
            {
                _Rs = this.ObjectContext.V_Sale_Order_PD.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            if (iD == "") return _Rs;

            return _Rs.Where(item => item.ID == iD);
        }
        //PDDetail
        public IQueryable<V_Sale_Order_PD_Detail> GetV_Sale_Order_PDDetailList(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Sale_Order_PD_Detail.Where(item => item.ID == iD);
        }
        //PDExport
        public IQueryable<V_Sale_Order_PD> GetV_Sale_Order_PDBillForExport(string dbCode, int lgIndex, string fName, string iD)
        {
            this.CreateSerialNum(dbCode, lgIndex, iD);
            var _RS = this.ObjectContext.V_Sale_Order_PD.Where(it => it.ID == iD).FirstOrDefault();
            _WhCode = _RS.WhCode;
            _LensCode = _RS.LensCode;
            _F_LR = _RS.F_LR;
            var _RSLens = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensCode == _LensCode).FirstOrDefault();
            _F_CA = _RSLens == null ? false : _RSLens.F_CA == true;
            this.PrepareXSPDDT(_RS);
            ComExportToExcel.Export(_DS, fName);
            return null;
        }
        //
        private void CreateSerialNum(string dbCode, int lgIndex, string totleBillcode)
        {
            DbHelperSQL dbh = new DbHelperSQL(dbCode);
            string spName = "SP_Sale_Order_ExportToFactory";
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@BCodes", SqlDbType.NVarChar,4000)
					};
            parameters[0].Value = lgIndex;
            parameters[1].Value = totleBillcode;
            dbh.RunProcedureTran(spName, parameters);
        }
        //
        private void PrepareXSPDDT(V_Sale_Order_PD model)
        {
            DataTable _DT = ComExportToExcel.GetXYDetailDataTable(model.BCode);
            IQueryable<V_Sale_Order_PD_Detail> _Rs = this.ObjectContext.V_Sale_Order_PD_Detail;
            _Rs = _Rs.Where(item => item.ID == model.ID);
            _Rs.ToList().ForEach(item =>
            {
                _DT.Rows.Add(item.SPH, item.CYL, item.X_ADD, item.Qty);
            });

            var _DT2 = this.InitXSPDDT(_DT, model);
            _DS.Tables.Add(_DT2);
        }
        //
        private DataTable InitXSPDDT(DataTable _DT, V_Sale_Order_PD model)
        {
            DataTable _RST = new DataTable(model.BCode);
            int _SumQty = ComExportToExcel.InitXYTable(_RST, _DT, _F_CA);
            //内容 
            _RST.Rows[0][0] = "V2******批量/寄賣訂單******";
            _RST.Rows[1][0] = "訂單日期:" + model.BDate.Value.GetMyShortDateStr();
            _RST.Rows[2][0] = "訂單號:" + model.BCode + ";客戶訂單號:" + model.OBCode + ";制單:" + model.Maker;
            _RST.Rows[3][0] = "客戶代碼:" + model.CusCode + "(" + model.CusName + ")";
            _RST.Rows[4][0] = "訂單鏡種:" + model.LensCode + "(" + model.LensName + ")" + (model.F_LR == "" ? "" : ";鏡片:" + model.F_LR);
            _RST.Rows[5][0] = "流水號:" + model.SN;
            _RST.Rows[6][0] = "特別說明:" + model.Notes;
            _RST.Rows[7][0] = "備註:" + model.Remark;
            return _RST;
        }
        //List
        public IQueryable<V_Sale_Order_Lens> GetV_Sale_Order_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Sale_Order_Lens> _Rs = this.ObjectContext.V_Sale_Order_Lens;
            string _Str = "";
            var _SArray = sWhere.GetSptstr();

            _Str = _SArray.GetSptstrValue("F_LE");
            if (!string.IsNullOrEmpty(_Str))
            {
                _F_LE = true;
            }

            _Str = _SArray.GetSptstrValue("F_LEID");
            if (!string.IsNullOrEmpty(_Str))
            {
                _F_LEID = _Str;
            }

            _Str = _SArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(_Str);
                    _Rs = _Rs.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

            _Str = _SArray.GetSptstrValue("BCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("F_SCTime");
            if (!string.IsNullOrEmpty(_Str) && _Str == "1")
            {
                _Str = _SArray.GetSptstrValue("D1");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d1vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDate.Value >= d1vs);
                }

                _Str = _SArray.GetSptstrValue("D2");
                if (!string.IsNullOrEmpty(_Str))
                {
                    var d2vs = System.Convert.ToDateTime(_Str);
                    _Rs = _Rs.Where(item => item.BDate.Value <= d2vs);
                }
            }

            _Str = _SArray.GetSptstrValue("OBCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.OBCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("CusCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.CusCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("Maker");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.Maker.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("SCUD");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _UD = System.Convert.ToInt16(_Str);
                _Rs = _Rs.Where(item => item.UD == _UD);
            }

            _Str = _SArray.GetSptstrValue("SCOG");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _OG = System.Convert.ToInt16(_Str);
                _Rs = _Rs.Where(item => item.OGType == _OG);
            }

            _Str = _SArray.GetSptstrValue("SCCheck");
            if (!string.IsNullOrEmpty(_Str) && _Str != "-1")
            {
                var _SCC = System.Convert.ToInt16(_Str);
                if (_SCC == 1)
                {
                    _Rs = _Rs.Where(item => !string.IsNullOrEmpty(item.Checker));
                }
                else
                {
                    _Rs = _Rs.Where(item => string.IsNullOrEmpty(item.Checker));
                }
            }

            _Str = _SArray.GetSptstrValue("LensType");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensType == it); });
            }

            _Str = _SArray.GetSptstrValue("BType");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.BType == it); });
            }

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCodeR.Contains(it) || item.LensCodeL.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("SpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.SpCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("F_JM");
            if (!string.IsNullOrEmpty(_Str))
            {
                var _F_JM = System.Convert.ToInt16(_Str);
                if (_F_JM == 1)
                    _Rs = _Rs.Where(item => item.BType == "XSJM");
                else
                    _Rs = _Rs.Where(item => item.BType != "XSJM");
            }

            if (!_F_LE)
                return _Rs;
            else
            {
                this.PrepareExportListLens(_Rs, _F_LEID);
                //ERP.Web.DomainService.Common.DSExport.ExportListLens(_Rs.Select(it => it.BCode).ToList());
                return null;
            }
        }

        private void PrepareExportListLens(IQueryable<V_Sale_Order_Lens> _Rs, string _F_LEID)
        {
            _DT = new DataTable();
            var _RSLE = _Rs.ToList();
            _DT.Columns.Add("ID");
            _DT.Columns.Add("OBCode");
            _DT.Columns.Add("BDate");
            _DT.Columns.Add("CusCode");
            _DT.Columns.Add("CusName");
            _DT.Columns.Add("LensCodeR");
            _DT.Columns.Add("SPHR");
            _DT.Columns.Add("CYLR");
            _DT.Columns.Add("X_ADDR");
            _DT.Columns.Add("LensCodeL");
            _DT.Columns.Add("SPHL");
            _DT.Columns.Add("CYLL");
            _DT.Columns.Add("X_ADDL");
            _DT.Columns.Add("SumQty");
            _DT.Columns.Add("AMOUNT SERVICES");
            _DT.Columns.Add("AMOUNT SERVICES DETAIL");
            _DT.Columns.Add("AMOUNT LENS");
            _DT.Columns.Add("Remark");

            foreach (var item in _RSLE)
            {
                var _dr = _DT.Rows.Add();
                _dr["ID"] = item.BCode;
                _dr["OBCode"] = item.OBCode;
                _dr["BDate"] = item.BDate.Value.ToShortDateString();
                _dr["CusCode"] = item.CusCode;
                _dr["CusName"] = item.CusName;
                _dr["LensCodeR"] = item.LensCodeR;
                _dr["SPHR"] = item.SPHR;
                _dr["CYLR"] = item.CYLR;
                _dr["X_ADDR"] = item.X_ADDR;
                _dr["LensCodeL"] = item.LensCodeL;
                _dr["SPHL"] = item.SPHL;
                _dr["CYLL"] = item.CYLL;
                _dr["X_ADDL"] = item.X_ADDL;
                _dr["SumQty"] = item.SumQty;
                _dr["AMOUNT SERVICES"] = item.ProCostR + item.ProCostL;
                _dr["AMOUNT SERVICES DETAIL"] = item.Rt5;
                _dr["AMOUNT LENS"] = item.SumMoney;
                _dr["Remark"] = item.Remark;
            }

            ERP.Web.DomainService.Common.DSExport.ExportListLens(_DT, _F_LEID);
        }

    }
}