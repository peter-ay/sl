

namespace ERP.Web.DomainService.Erp
{
    using System;
    using System.Linq;
    using ERP.Web.Entity;
    using System.Collections.Generic;
    using System.Data;
    using ERP.Web.Common;
    using System.ServiceModel.DomainServices.Server;

    public partial class DSErp
    {
        public IQueryable<V_Ware_Report_Stocks_Lens_XY> GetV_Ware_Report_Stocks_Lens_XYList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_Ware_Report_Stocks_Lens_XY> _Rs = this.ObjectContext.V_Ware_Report_Stocks_Lens_XY;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("GpID");
            if (!string.IsNullOrEmpty(_Str))
            {
                if (_Str != "-99")
                {
                    var _GpID = System.Convert.ToInt32(_Str);
                    _Rs = _Rs.Where(item => item.BrowseRight.Substring(_GpID - 1, 1) == "1");
                }
            }

            _Str = _SArray.GetSptstrValue("WhCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.WhCode == it); });
            }

            _Str = _SArray.GetSptstrValue("LensCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.KeyCode.Contains(it) || item.F_Lens == 0); });
            }

            return _Rs;
        }

        [Query(HasSideEffects = true)]
        public IQueryable<V_Ware_Report_Stocks_Lens_XY> GetV_Ware_Report_Stocks_Lens_XYListExport(string dbCode, int lgIndex, string fName, List<string> items)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            if (items[0] != "WhCode")
            {
                items.ForEach(item1 =>
                    {
                        this.PrepareDTable(item1);
                    });
            }
            else
            {
                var _WhCode = items[1];
                var _RsWhCode = this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail.Where(it => it.WhCode == _WhCode);
                _RsWhCode.GroupBy(it => new { it.LensCode, it.F_LR }).ToList().ForEach(it =>
                {
                    this.PrepareDTable(_WhCode + it.Key.LensCode + it.Key.F_LR);
                });
            }

            ComExportToExcel.Export(_DS, fName);
            return null;
        }

        private void PrepareDTable(string KeyCode)
        {
            DataTable _DT = ComExportToExcel.GetXYDetailDataTable(KeyCode);
            IQueryable<V_Ware_Report_Stocks_Lens_Detail> _Rs = this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail;
            _Rs = _Rs.Where(item => item.WhCode + item.LensCode + item.F_LR == KeyCode);

            bool _F_Read = false;
            _Rs.ToList().ForEach(item =>
            {
                if (!@_F_Read)
                {
                    _WhCode = item.WhCode;
                    _LensCode = item.LensCode;
                    _F_LR = item.F_LR;
                    var _RsLes = this.ObjectContext.V_B_Material_Lens.Where(it => it.LensCode == _LensCode).FirstOrDefault();
                    _F_CA = _RsLes == null ? false : _RsLes.F_CA == true;
                    _F_Read = true;
                }
                _DT.Rows.Add(item.SPH, item.CYL, item.X_ADD, item.Stocks);
            });

            var _DT2 = this.InitDataTable(_DT);
            _DS.Tables.Add(_DT2);
        }

        private DataTable InitDataTable(DataTable _DT)
        {
            DataTable _RST = new DataTable(_DT.TableName.GetCorrectXlsName());
            int _SumQty = ComExportToExcel.InitXYTable(_RST, _DT, _F_CA);
            //内容 
            _RST.Rows[0][0] = "******鏡片現存量******";
            _RST.Rows[1][0] = "製作日期:" + ComDateTime.LongDateTime;
            _RST.Rows[2][0] = "倉庫:" + _WhCode;

            if (_F_LR == "")
                _RST.Rows[3][0] = "鏡種:" + _LensCode;
            else
                _RST.Rows[3][0] = "鏡種:" + _LensCode + "[" + _F_LR + "]";

            _RST.Rows[4][0] = "現存量:" + _SumQty.ToString();
            return _RST;
        }
    }
}