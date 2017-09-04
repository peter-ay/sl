
using ERP.Common;
using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ERP.View
{
    public partial class XYInput : ChildWindowErp
    {
        private List<int> cylArray = new List<int>();

        //private int _ACDateSource = 0;
        /// <summary>
        /// ////////////// 0:普通镜种;1:客户镜种;
        /// </summary>
        //public int ACDateSource
        //{
        //    get { return _ACDateSource; }
        //    set
        //    {
        //        _ACDateSource = value;
        //        this.ACXYLensCode.ItemsSource = ComHelpV_B_LensCode.UHV_B_CusLensCodeSmartQuote;
        //        this.BtnCusLensCode.Visibility = Visibility.Collapsed;
        //        this.BtnCusLensCodeReplace.Visibility = Visibility.Visible;
        //        if (_ACDateSource == 1)
        //        {
        //            this.ACXYLensCode.ItemsSource = ComHelpV_B_LensCode.UHV_B_LensCodeSmart;
        //            this.BtnCusLensCode.Visibility = Visibility.Visible;
        //            this.BtnCusLensCodeReplace.Visibility = Visibility.Collapsed;
        //        }
        //    }
        //}

        public ObservableCollection<ComXYInputListFormat> ResultDataList
        {
            get;
            set;
        }

        public string RequestVMName
        {
            get;
            set;
        }

        public XYInput()
        {
            InitializeComponent();
            this.InitDataGrid();
            this.InitMessage();
        }

        private void InitMessage()
        {
            Messenger.Default.Register<ComXYInputMainDataSource>(this, USysMessages.XYColumnShow, (msg) =>
            {
                this.RefreshColumns(msg);
            });

            Messenger.Default.Register<bool>(this, USysMessages.XYInputResult, (msg) =>
            {
                this.ReturnResult(msg);
            });
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
                var _Source = this.XY_DataGrid.DataContext as VMXYInput;
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
            var _Source = this.XY_DataGrid.DataContext as VMXYInput;
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

        private void ReturnResult(bool msg)
        {
            if (!msg)
            {
                this.DialogResult = false;
                return;
            }
            this.ConvertToResultList();
            this.DialogResult = true;
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

            XY_DataGrid.CurrentCellChanged += (s1, e1) =>
            {
                XY_DataGrid.BeginEdit();
            };

            XY_DataGrid.CellEditEnded += new EventHandler<DataGridCellEditEndedEventArgs>(XY_DataGrid_CellEditEnded);

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

        void XY_DataGrid_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            #region 行
            ComXYInputDataSource _xyRow = e.Row.DataContext as ComXYInputDataSource;
            if (_xyRow.C0 == -1)
            {
                return;
            }
            int i = 0;
            int j = cylArray.Count;
            int k = 0;
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
            #endregion
            #region 列
            int cIndex = e.Column.DisplayIndex + 1;
            int cIndex2 = cylArray.Count + 1;
            int cResult = 0; int cResult2 = 0;
            var _Source = this.XY_DataGrid.DataContext as VMXYInput;
            foreach (ComXYInputDataSource u in _Source.XYSource)
            {
                if (u.C0 == -1)
                {
                    if (cResult != 0)
                    {
                        u.GetType().GetProperty("C" + cIndex.ToString()).SetValue(u, cResult, null);
                    }
                    else
                    {
                        u.GetType().GetProperty("C" + cIndex.ToString()).SetValue(u, null, null);
                    }
                    if (cResult2 != 0)
                    {
                        u.GetType().GetProperty("C" + cIndex2.ToString()).SetValue(u, cResult2, null);
                    }
                    else
                    {
                        u.GetType().GetProperty("C" + cIndex2.ToString()).SetValue(u, null, null);
                    }
                }

                var data = u.GetType().GetProperty("C" + cIndex.ToString()).GetValue(u, null);
                cResult += data == null ? 0 : Convert.ToInt32(data);
                var data2 = u.GetType().GetProperty("C" + cIndex2.ToString()).GetValue(u, null);
                cResult2 += data2 == null ? 0 : Convert.ToInt32(data2);
            }
            #endregion
        }

        private void ConvertToResultList()
        {
            ResultDataList = new ObservableCollection<ComXYInputListFormat>();
            if (cylArray.Count == 0) return;

            int _SubID = 1;
            int _SPH = 0;
            int _CYL = 0;
            int _Qty = 0;
            ComXYInputListFormat item = null;
            try
            {
                #region Convert
                var _Source = this.XY_DataGrid.DataContext as VMXYInput;
                foreach (ComXYInputDataSource t in _Source.XYSource)
                {
                    if (t.C0 == -1)
                    {
                        continue;
                    }
                    for (int y = 0; y <= cylArray.Count - 1; y++)
                    {
                        var _Rs = t.GetType().GetProperty("C" + (y + 1).ToString()).GetValue(t, null);
                        if (_Rs == null) continue;
                        else _Qty = Convert.ToInt32(_Rs);
                        if (_Qty == 0) continue;
                        _SPH = t.C0.Value;
                        _CYL = cylArray[y];
                        item = new ComXYInputListFormat();

                        item.SubID = _SubID++;
                        item.SPH = _SPH;

                        if (_Source.DContextMain.F_CA)
                        {
                            item.X_ADD = _CYL;
                            item.CYL = _Source.DContextMain.X_ADD;
                        }
                        else
                        {
                            item.CYL = _CYL;
                            item.X_ADD = _Source.DContextMain.X_ADD;
                        }

                        item.Qty = Convert.ToInt32(_Qty);
                        if (item.Qty < 0) item.Qty = 0;
                        ResultDataList.Add(item);
                    }
                }
                #endregion
            }
            catch { }
        }

        private void XY_DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //SPHShow.Text = e.Row.Header.ToString();
            //CYLShow.Text = e.Column.Header.ToString();
        }

        public void SetIsCusLens(bool flag = false)
        {
            ACXYCusLensCode.Visibility = Visibility.Collapsed;
            ACXYLensCode.Visibility = Visibility.Collapsed;
            var _VM = this.DataContext as VMXYInput;
            _VM.ACMinimumPrefixLength = -1;
            _VM.MPLPCusLensCode = -1;
            if (flag)
            {
                ACXYCusLensCode.Visibility = Visibility.Visible;
                _VM.MPLPCusLensCode = 0;
            }
            else
            {
                ACXYLensCode.Visibility = Visibility.Visible;
                _VM.ACMinimumPrefixLength = 0;
            }
        }

    }
}

