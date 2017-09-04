
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private Visibility isShowDP = Visibility.Collapsed;
        public Visibility IsShowDP
        {
            get { return isShowDP; }
            set { isShowDP = value; RaisePropertyChanged("IsShowDP"); }
        }
    }
}
