
using System.Windows;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private Visibility isShowTB = Visibility.Visible;
        public Visibility IsShowTB
        {
            get { return isShowTB; }
            set { isShowTB = value; RaisePropertyChanged("IsShowTB"); }
        }
    }
}
