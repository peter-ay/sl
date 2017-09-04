
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private Visibility isShowExport = Visibility.Visible;
        public Visibility IsShowExport
        {
            get { return isShowExport; }
            set
            {
                isShowExport = value;
                RaisePropertyChanged("IsShowExport");
            }
        }

        public bool IsShowExportBool
        {
            set
            {
                if (value)
                    IsShowExport = Visibility.Visible;
                else
                    IsShowExport = Visibility.Collapsed;
            }
        }
    }
}
