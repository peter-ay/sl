using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERP.View
{
    public partial class DataGridListErp2 : UserControl
    {
        private string MyListName;

        public DataGridListErp2()
        {
            InitializeComponent();
            MyListName = !string.IsNullOrEmpty(this.Name) ? this.Name.Substring(1, 999) : "";
            this.MainDataGrid.LoadingRow += new System.EventHandler<DataGridRowEventArgs>(MainDataGrid_LoadingRow);
            this.MainDataGrid.ColumnHeaderDragCompleted += new System.EventHandler<System.Windows.Controls.Primitives.DragCompletedEventArgs>(MainDataGrid_ColumnHeaderDragCompleted);
            Messenger.Default.Register<ObservableCollection<DataGridColumn>>(this, USysMessages.InitGridColumns2, (columns) =>
            {
                this.InitColumns(columns);
            });

        }

        void MainDataGrid_ColumnHeaderDragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            ComDataGridColumnSet.WriteDataGridColumnInfo(this.MyListName, this.MainDataGrid);
        }

        void MainDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                int _pageIndex = this.MainDataPager.PageIndex;
                int _pageSize = this.MainDataPager.PageSize;
                e.Row.Header = ((e.Row.GetIndex() + 1) + _pageIndex * _pageSize).ToString();
            }
            catch { }
        }

        private void InitColumns(ObservableCollection<DataGridColumn> columns)
        {
            if (null == columns) return;
            if (this.MainDataGrid.Columns.Count > 0) return;

            foreach (var item in columns)
            {
                switch (item.DisplayIndex)
                {
                    case 999:
                        this.MyListName = item.Header.ToString();
                        continue;
                    case 998:
                        this.MainDataGrid.FrozenColumnCount = System.Convert.ToInt32(item.Header);
                        continue;
                    default:
                        this.MainDataGrid.Columns.Add(item);
                        break;
                }
            }
            this.MainDataGrid.UpdateLayout();
            string previewType = "";
            ComDataGridColumnSet.ReadDataGridColumnInfo(this.MyListName, this.MainDataGrid, out previewType);
        }
    }
}
