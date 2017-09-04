using System;
using System.Data;
using GemBox.Spreadsheet;
using System.Web;

namespace ERP.Web.Common
{
    public class ComExportToExcel
    {
        public static void Export(DataSet ds, string fName)
        {
            if (ds.Tables[0].Rows.Count >= 0)
            {
                if (fName != "")
                {
                    try
                    {
                        fName = HttpContext.Current.Server.MapPath("~/Export/" + fName);
                        ExcelFile excelFile = new ExcelFile();
                        ExcelWorksheet sheet = null;
                        int columns = 0;
                        int rows = 0;
                        foreach (DataTable dt in ds.Tables)
                        {
                            sheet = excelFile.Worksheets.Add(dt.TableName);
                            columns = dt.Columns.Count;
                            rows = dt.Rows.Count;
                            for (int i = 0; i <= rows - 1; i++)
                            {
                                for (int j = 0; j < columns; j++)
                                {
                                    sheet.Cells[i, j].Style.Font.Name = "Verdana";
                                    sheet.Cells[i, j].Value = dt.Rows[i][j];
                                }
                            }
                        }

                        excelFile.SaveXls(fName);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public static DataTable GetXYDetailDataTable(string tName)
        {
            DataTable _DT = new DataTable(tName);
            _DT.Columns.Add("SPH", typeof(Int32));
            _DT.Columns.Add("CYL", typeof(Int32));
            _DT.Columns.Add("X_ADD", typeof(Int32));
            _DT.Columns.Add("Qty", typeof(Int32));
            return _DT;
        }

        public static int InitXYTable(DataTable _RST, DataTable _DT, bool _F_CA)
        {            //定义列数
            var _SPH1 = Convert.ToInt32(_DT.Select("SPH=Min(SPH)")[0]["SPH"]);
            var _SPH2 = Convert.ToInt32(_DT.Select("SPH=Max(SPH)")[0]["SPH"]);
            var _CYL1 = Convert.ToInt32(_DT.Select("CYL=Min(CYL)")[0]["CYL"]);
            var _CYL2 = Convert.ToInt32(_DT.Select("CYL=Max(CYL)")[0]["CYL"]);
            var _X_ADD1 = Convert.ToInt32(_DT.Select("X_ADD=Min(X_ADD)")[0]["X_ADD"]);
            var _X_ADD2 = Convert.ToInt32(_DT.Select("X_ADD=Max(X_ADD)")[0]["X_ADD"]);

            if (_F_CA)
            {
                _CYL1 = _X_ADD1;
                _CYL2 = _X_ADD2;
            }

            if (_SPH1 > 0)
            { _SPH1 = 0; }
            else if (_SPH2 < 0)
            { _SPH2 = 0; }
            else { }

            if (_CYL1 > 0)
            { _CYL1 = 0; }
            else if (_CYL2 < 0)
            { _CYL2 = 0; }
            else { }

            for (int i = 0; i <= ((_CYL2 - _CYL1) / 25) + 2; i++)
            {
                _RST.Columns.Add();
            }

            //定义行数
            for (int i = 0; i <= ((_SPH2 - _SPH1) / 25) + 11; i++)
            {
                _RST.Rows.Add();
            }
            _RST.Rows[9][_RST.Columns.Count - 1] = "SUM";
            _RST.Rows[_RST.Rows.Count - 1][0] = "SUM";
            if (_F_CA)
                _RST.Rows[9][0] = @"(SPH\ADD)";
            else
                _RST.Rows[9][0] = @"(SPH\CYL)";
            //第开始记录XY信息
            #region 设定CYL
            int c_index = 1;
            if (_CYL2 <= 0)
            {
                for (int j = _CYL2; j >= _CYL1; j -= 25)
                {
                    _RST.Rows[9][c_index] = j.ToString();
                    c_index++;
                }
            }
            else if (_CYL1 >= 0)
            {
                for (int j = _CYL1; j <= _CYL2; j += 25)
                {
                    _RST.Rows[9][c_index] = j.ToString();
                    c_index++;
                }
            }
            else
            {
                for (int j = 0; j >= _CYL1; j -= 25)
                {
                    _RST.Rows[9][c_index] = j.ToString();
                    c_index++;
                }
                for (int j = 25; j <= _CYL2; j += 25)
                {
                    _RST.Rows[9][c_index] = j.ToString();
                    c_index++;
                }
            }
            #endregion
            #region SPH排序
            int s_index = 10;
            if (_SPH2 <= 0)
            {
                for (int i = _SPH2; i >= _SPH1; i -= 25)
                {
                    _RST.Rows[s_index][0] = i.ToString();
                    s_index++;
                }
            }
            else if (_SPH1 >= 0)
            {
                for (int i = _SPH1; i <= _SPH2; i += 25)
                {
                    _RST.Rows[s_index][0] = i.ToString();
                    s_index++;
                }
            }
            else
            {
                for (int i = 0; i >= _SPH1; i -= 25)
                {
                    _RST.Rows[s_index][0] = i.ToString();
                    s_index++;
                }
                for (int i = 25; i <= _SPH2; i += 25)
                {
                    _RST.Rows[s_index][0] = i.ToString();
                    s_index++;
                }
            }
            #endregion
            #region 填数值
            int rr_index = 0; int cr_index = 0;
            foreach (DataRow r in _DT.Rows)
            {
                if (Convert.ToInt32(_SPH2) <= 0)//sph
                {
                    rr_index = 10 + (_SPH2 - Convert.ToInt32(r["SPH"])) / 25;
                }
                else if (_SPH1 >= 0)
                {
                    rr_index = 10 + (Convert.ToInt32(r["SPH"]) - _SPH1) / 25;
                }
                else
                {
                    if (Convert.ToInt32(r["SPH"]) <= 0)
                    {
                        rr_index = 10 + (0 - Convert.ToInt32(r["SPH"])) / 25;
                    }
                    else
                    {
                        rr_index = 10 + (Convert.ToInt32(r["SPH"]) / 25 + (0 - _SPH1) / 25);
                    }
                }

                string _CYL = _F_CA ? "X_ADD" : "CYL";

                if (Convert.ToInt32(_CYL2) <= 0)//cyl
                {
                    cr_index = 1 + (_CYL2 - Convert.ToInt32(r[_CYL])) / 25;
                }
                else if (Convert.ToInt32(_CYL1) >= 0)
                {
                    cr_index = 1 + (Convert.ToInt32(r[_CYL]) - _CYL1) / 25;
                }
                else
                {
                    if (Convert.ToInt32(r[_CYL]) <= 0)
                    {
                        cr_index = 1 + (0 - Convert.ToInt32(r[_CYL])) / 25;
                    }
                    else
                    {
                        cr_index = 1 + (Convert.ToInt32(r[_CYL]) / 25 + (0 - Convert.ToInt32(_CYL1)) / 25);
                    }
                }

                _RST.Rows[rr_index][cr_index] = r["Qty"];
            }

            #endregion
            #region 计算合计
            int sumTemp = 0;
            //行
            for (int r_sumIndex = 10; r_sumIndex <= _RST.Rows.Count - 2; r_sumIndex++)
            {
                sumTemp = 0;
                int c_sumIndex;
                for (c_sumIndex = 1; c_sumIndex <= _RST.Columns.Count - 2; c_sumIndex++)
                {
                    if (_RST.Rows[r_sumIndex][c_sumIndex].ToString() != "")
                    {
                        sumTemp += Convert.ToInt32(_RST.Rows[r_sumIndex][c_sumIndex]);
                    }
                }
                if (sumTemp != 0)
                {
                    _RST.Rows[r_sumIndex][c_sumIndex] = sumTemp;
                }
            }
            //列
            for (int c_sumIndex = 1; c_sumIndex <= _RST.Columns.Count - 1; c_sumIndex++)
            {
                sumTemp = 0;
                int r_sumIndex;
                for (r_sumIndex = 10; r_sumIndex <= _RST.Rows.Count - 2; r_sumIndex++)
                {
                    if (_RST.Rows[r_sumIndex][c_sumIndex].ToString() != "")
                    {
                        sumTemp += Convert.ToInt32(_RST.Rows[r_sumIndex][c_sumIndex]);
                    }
                }
                if (sumTemp != 0)
                {
                    _RST.Rows[r_sumIndex][c_sumIndex] = sumTemp;
                }
            }
            #endregion
            return sumTemp;
        }
    }
}