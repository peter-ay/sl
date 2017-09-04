
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private Visibility isShowImport = Visibility.Visible;
        public Visibility IsShowImport
        {
            get { return isShowImport; }
            set
            {
                isShowImport = value;
                RaisePropertyChanged("IsShowImport");
            }
        }

        public bool IsShowImportBool
        {
            set
            {
                if (value)
                    IsShowImport = Visibility.Visible;
                else
                    IsShowImport = Visibility.Collapsed;
            }
        }
    }
}
