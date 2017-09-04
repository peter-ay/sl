

using ERP.ViewModel;
using System;
using ERP.Common;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using ERP.Utility;
namespace ERP.View
{
    public partial class Ware_Report_Stocks_Lens_XY_List : UserControlErp
    {
        private List<int> cylArray = new List<int>();

        public ObservableCollection<ComXYInputListFormat> ResultDataList
        {
            get;
            set;
        }

        public Ware_Report_Stocks_Lens_XY_List()
        {
            InitializeComponent();
            this.InitDataGrid();
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<ComXYInputMainDataSource>(this, this.GetType().Name + "_XY", (msg) =>
            {
                this.RefreshColumns(msg);
            });
        }

        private void InitDataGrid()
        {
            XY_DataGrid.Columns.Clear();
            DataGridTextColumn dg = null;
            for (int i = 1; i <= 100; i++)
            {
                dg = new DataGridTextColumn()
                {
                    Binding = new System.Windows.Data.Binding("C" + i.ToString())
                    {
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged,
                        FallbackValue = 0,
                    },
                    Visibility = System.Windows.Visibility.Collapsed,
                    FontFamily = new FontFamily("Verdana"),
                    FontWeight = FontWeights.Normal,
                };
                XY_DataGrid.Columns.Add(dg);
            }

            XY_DataGrid.GotFocus += (s, e) =>
            {
                if (!XY_DataGrid.IsReadOnly)
                {
                    if (XY_DataGrid.Columns.Count > 0 && XY_DataGrid.SelectedIndex > -1)
                    {
                        XY_DataGrid.BeginEdit();
                        return;
                    }

                    if (XY_DataGrid.Columns.Count > 0 && XY_DataGrid.SelectedIndex == -1)
                    {
                        XY_DataGrid.SelectedIndex = 0;
                        XY_DataGrid.BeginEdit();
                        return;
                    }

                }
            };

            XY_DataGrid.LoadingRow += (ss, ee) =>
            {
                var dc = ee.Row.DataContext as ComXYInputDataSource;
                ee.Row.Background = new SolidColorBrush(Color.FromArgb(255, 248, 248, 255));
                ee.Row.Header = dc.C0.ToString();
                if (ee.Row.Header.ToString() == "-1")
                {
                    ee.Row.Header = ErpUIText.Get("ERP_Sum");
                    ee.Row.IsEnabled = false;
                }
                else
                {
                    ee.Row.IsEnabled = true;
                }
            };

            XY_DataGrid.BindingValidationError += (e, s) =>
            {
                XY_DataGrid.CancelEdit();
                s.Handled = true;
            };
        }

        int _CCYL1 = -1;
        int _CCYL2 = -1;
        private void RefreshColumns(ComXYInputMainDataSource msg)
        {
            //每次都刷新 
            _CCYL1 = -1; _CCYL2 = -1;
            //////////////////////////////
            if (_CCYL1 != msg.CYL1 || _CCYL2 != msg.CYL2)
            {
                _CCYL1 = msg.CYL1;
                _CCYL2 = msg.CYL2;
                foreach (var c in this.XY_DataGrid.Columns)
                {
                    c.Visibility = Visibility.Collapsed;
                    c.IsReadOnly = false;
                }

                #region CYL排序

                cylArray.Clear();
                var cyl1 = msg.CYL1;
                var cyl2 = msg.CYL2;
                int c_index = 0;
                if (cyl2 <= 0)
                {
                    for (int j = cyl2; j >= cyl1; j -= 25)
                    {
                        XY_DataGrid.Columns[c_index].Visibility = Visibility.Visible;
                        XY_DataGrid.Columns[c_index].Header = j.ToString();
                        cylArray.Add(j);
                        c_index++;
                    }
                }
                else if (cyl1 >= 0)
                {
                    for (int j = cyl1; j <= cyl2; j += 25)
                    {
                        XY_DataGrid.Columns[c_index].Visibility = Visibility.Visible;
                        XY_DataGrid.Columns[c_index].Header = j.ToString();
                        cylArray.Add(j);
                        c_index++;
                    }
                }
                else
                {
                    for (int j = 0; j >= cyl1; j -= 25)
                    {
                        XY_DataGrid.Columns[c_index].Visibility = Visibility.Visible;
                        XY_DataGrid.Columns[c_index].Header = j.ToString();
                        cylArray.Add(j);
                        c_index++;
                    }
                    for (int j = 25; j <= cyl2; j += 25)
                    {
                        XY_DataGrid.Columns[c_index].Visibility = Visibility.Visible;
                        XY_DataGrid.Columns[c_index].Header = j.ToString();
                        cylArray.Add(j);
                        c_index++;
                    }
                }
                XY_DataGrid.Columns[c_index].Visibility = Visibility.Visible;
                XY_DataGrid.Columns[c_index].Header = ErpUIText.Get("ERP_Sum");
                XY_DataGrid.Columns[c_index].IsReadOnly = true;
                #endregion
            }
            this.FillResult();
        }

        private void FillResult()
        {
            var _Source = this.XY_DataGrid.DataContext as VMWare_Report_Stocks_Lens_XY_List; 
            ResultDataList = _Source.ObservableCollectionXY;
            if (ResultDataList == null || ResultDataList.Count == 0) return;
            int? _SPH = 0;
            int? _CYL = 0;
            int? _X_ADD = 0;
            int? _Qty = 0;
            foreach (var item in ResultDataList)
            {
                _SPH = item.SPH;
                _CYL = item.CYL;
                _X_ADD = item.X_ADD;
                _Qty = Convert.ToInt32(item.Qty);
            
                var _CA = _Source.DContextMain.F_CA ? _X_ADD : _CYL;
                _Source.DContextMain.X_ADD = _Source.DContextMain.F_CA ? _CYL.Value : _X_ADD.Value;
                foreach (ComXYInputDataSource it in _Source.XYSource)
                {
                    if (it.C0 == -1)
                    {
                        continue;
                    }
                    if (it.C0 == _SPH)
                    {
                        for (int i = 0; i <= cylArray.Count - 1; i++)
                        {
                            if (cylArray[i] == _CA)
                            {
                                it.GetType().GetProperty("C" + (i + 1).ToString()).SetValue(it, _Qty, null);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            this.UpdateSumRowColumn();
        }

        private void UpdateSumRowColumn()
        {
            #region 行
            int i = 0;
            int j = cylArray.Count;
            int k = 0;
            var _Source = this.XY_DataGrid.DataContext as VMWare_Report_Stocks_Lens_XY_List;
            foreach (ComXYInputDataSource _xyRow in _Source.XYSource)
            {
                i = 0; k = 0;
                if (_xyRow.C0 == -1)
                {
                    continue;
                }
                Type t = _xyRow.GetType();
                foreach (var p in t.GetProperties())
                {
                    if (p.Name == "C0")
                    {
                        continue;
                    }
                    if (k == j)
                    {
                        if (i != 0)
                        {
                            p.SetValue(_xyRow, i, null);
                        }
                        else
                        {
                            p.SetValue(_xyRow, null, null);
                        }
                        break;
                    }
                    i += (p.GetValue(_xyRow, null)) == null ? 0 : Convert.ToInt32(p.GetValue(_xyRow, null));
                    k++;
                }
            }
            #endregion
            #region 列
            int cIndex2 = cylArray.Count + 1;
            int _cResult = 0; int _cResult2 = 0;
            for (int cIndex = 1; cIndex <= cylArray.Count; cIndex++)
            {
                _cResult = 0; _cResult2 = 0;
                foreach (ComXYInputDataSource u in _Source.XYSource)
                {
                    if (u.C0 == -1)
                    {
                        if (_cResult != 0)
                            u.GetType().GetProperty("C" + cIndex.ToString()).SetValue(u, _cResult, null);
                        else
                            u.GetType().GetProperty("C" + cIndex.ToString()).SetValue(u, null, null);
                    }

                    if (u.C0 == -1 && cIndex == 1)
                    {
                        if (_cResult2 != 0)
                            u.GetType().GetProperty("C" + cIndex2.ToString()).SetValue(u, _cResult2, null);
                        else
                            u.GetType().GetProperty("C" + cIndex2.ToString()).SetValue(u, null, null);
                    }

                    var data = u.GetType().GetProperty("C" + cIndex.ToString()).GetValue(u, null);
                    _cResult += data == null ? 0 : Convert.ToInt32(data);

                    if (cIndex == 1)
                    {
                        var data2 = u.GetType().GetProperty("C" + cIndex2.ToString()).GetValue(u, null);
                        _cResult2 += data2 == null ? 0 : Convert.ToInt32(data2);
                    }
                }
            }
            #endregion
        }

    }
}
