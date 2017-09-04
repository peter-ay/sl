using DevExpress.AgDataGrid;
using System.Collections.ObjectModel;

namespace ERP.Common
{
    public class ComSunGridColumnInfo
    {
        public ObservableCollection<AgDataGridColumn> Columns
        {
            get;
            set;
        }

        public ObservableCollection<AgDataGridSummaryItem> SumColumns
        {
            get;
            set;
        }
    }
}
