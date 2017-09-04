
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private Visibility isShowHB = Visibility.Collapsed;
        public Visibility IsShowHB
        {
            get { return isShowHB; }
            set { isShowHB = value; RaisePropertyChanged("IsShowHB"); }
        }
    }
}
