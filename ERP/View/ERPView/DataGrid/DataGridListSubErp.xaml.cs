using DevExpress.AgDataGrid;
using DevExpress.AgDataGrid.Data;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;

namespace ERP.View
{
    public partial class DataGridListSubErp : UserControl
    {
        private string MyListName = "";

        public DataGridListSubErp()
        {
            InitializeComponent();
            Messenger.Default.Register<ComSunGridColumnInfo>(this, USysMessages.InitSubGridColumns, (columns) =>
            {
                this.InitColumns(columns);
            });
            Messenger.Default.Register<ComSubGridColumnUpdate>(this, USysMessages.RefreshSubGrid, (msg) =>
            {
                if (msg.GridName == MyListName)
                    this.RefreshGrid(msg.Source);
            });
        }

        private void RefreshGrid(ObservableCollection<Entity> source)
        {
            this.SubGrid.DataSource = null;
            this.SubGrid.DataSource = source;
        }

        private void InitColumns(ComSunGridColumnInfo columns)
        {
            if (null == columns) return;
            if (this.SubGrid.Columns.Count > 0) return;

            foreach (var item in columns.Columns)
            {
                if (item.HeaderContent.ToString() == "SubGridListName")
                {
                    this.MyListName = item.FieldName;
                    continue;
                }

                this.SubGrid.Columns.Add(item);
            }

            this.SubGrid.UpdateLayout();

            ///////////////////////////////////////////////////////
            this.SubGrid.ShowTotals = System.Windows.Visibility.Visible;
            this.SubGrid.BeginUpdate();
            try
            {
                this.SubGrid.Totals.Clear();
                foreach (var item in columns.SumColumns)
                {
                    this.SubGrid.Totals.Add(new AgDataGridSummaryItem()
                    {
                        FieldName = item.FieldName,
                        Title = item.Title,
                        SummaryType = SummaryItemType.Sum
                    });
                }
                this.SubGrid.Totals[0].SummaryType = SummaryItemType.Count;
            }
            finally
            {
                this.SubGrid.EndUpdate();
            }
        }
    }
}
