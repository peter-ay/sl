

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;
    using System.Data;
    using ERP.Web.Common;

    public partial class DSErp
    {
        //
        public IQueryable<V_Ware_Stocks_Base_Lens> GetV_Ware_Stocks_Base_LensBill(string dbCode, string iD, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Stocks_Base_Lens> _Rs = this.ObjectContext.V_Ware_Stocks_Base_Lens;
            if (gpID != -99)
            {
                _Rs = this.ObjectContext.V_Ware_Stocks_Base_Lens.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            if (iD == "") return _Rs;

            return _Rs.Where(item => item.ID == iD);
        }
        //
        public IQueryable<V_Ware_Stocks_Base_Lens_Detail> GetV_Ware_Stocks_Base_LensDetailList(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.Where(item => item.ID == iD);
        }
        //
        public IQueryable<V_Ware_Stocks_Base_Lens_Detail> GetV_Ware_Stocks_Base_LensDetailForCopyList(string dbCode, string iD)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            var _Rs = this.ObjectContext.V_Ware_Stocks_Base_Lens.Where(it => it.WhCode + it.LensCode + it.F_LR == iD).FirstOrDefault();
            var _ID = _Rs == null ? "" : _Rs.ID;
            return this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.Where(item => item.ID == _ID);
        }
        //
        public IQueryable<V_Ware_Stocks_Base_Lens> GetV_Ware_Stocks_Base_LensList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Stocks_Base_Lens> _Rs = this.ObjectContext.V_Ware_Stocks_Base_Lens;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.LensCode.Contains(it)); });
            }

            return _Rs;
        }
        // 
        public IQueryable<V_Ware_Stocks_Base_Lens> GetV_Ware_Stocks_Base_LensForExport(string dbCode, int lgIndex, string fName, List<string> items)
        {
            items.ForEach(item =>
                {
                    var _RS = this.ObjectContext.V_Ware_Stocks_Base_Lens.Where(it => it.ID == item).FirstOrDefault();
                    _WhCode = _RS.WhCode;
                    _LensCode = _RS.LensCode;
                    _F_LR = _RS.F_LR;
                    var _RSLens = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensCode == _LensCode).FirstOrDefault();
                    _F_CA = _RSLens == null ? false : _RSLens.F_CA == true;
                    this.PrepareBSDT(item);
                });
            ComExportToExcel.Export(_DS, fName);
            return null;
        }

        private void PrepareBSDT(string KeyCode)
        {
            DataTable _DT = ComExportToExcel.GetXYDetailDataTable(_WhCode + _LensCode + _F_LR);
            IQueryable<V_Ware_Stocks_Base_Lens_Detail> _Rs = this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail;
            _Rs = _Rs.Where(item => item.ID == KeyCode);
            _Rs.ToList().ForEach(item =>
            {
                _DT.Rows.Add(item.SPH, item.CYL, item.X_ADD, item.Qty);
            });

            var _DT2 = this.InitBSDT(_DT);
            _DS.Tables.Add(_DT2);
        }

        private DataTable InitBSDT(DataTable _DT)
        {
            DataTable _RST = new DataTable(_DT.TableName.GetCorrectXlsName());
            int _SumQty = ComExportToExcel.InitXYTable(_RST, _DT, _F_CA);
            //内容 
            _RST.Rows[0][0] = "******鏡片基本庫存******";
            _RST.Rows[1][0] = "製作日期:" + ComDateTime.LongDateTime;
            _RST.Rows[2][0] = "倉庫:" + _WhCode;

            if (_F_LR == "")
                _RST.Rows[3][0] = "鏡種:" + _LensCode;
            else
                _RST.Rows[3][0] = "鏡種:" + _LensCode + "[" + _F_LR + "]";

            _RST.Rows[4][0] = "總數:" + _SumQty.ToString();
            return _RST;
        }
    }
}