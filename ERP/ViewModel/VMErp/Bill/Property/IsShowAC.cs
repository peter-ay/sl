
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private Visibility isShowAC = Visibility.Collapsed;
        public Visibility IsShowAC
        {
            get { return isShowAC; }
            set { isShowAC = value; RaisePropertyChanged("IsShowAC"); }
        }
    }
}
