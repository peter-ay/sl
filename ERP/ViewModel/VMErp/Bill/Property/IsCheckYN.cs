using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private bool _IsCheckYNAll = true;
        public bool IsCheckYNAll
        {
            get { return _IsCheckYNAll; }
            set { _IsCheckYNAll = value; RaisePropertyChanged("IsCheckYNAll"); }
        }

        private bool _IsCheckYN = false;
        public bool IsCheckYN
        {
            get { return _IsCheckYN; }
            set { _IsCheckYN = value; RaisePropertyChanged("IsCheckYN"); }
        }

        private bool _IsCheckUnYN = false;
        public bool IsCheckUnYN
        {
            get { return _IsCheckUnYN; }
            set { _IsCheckUnYN = value; RaisePropertyChanged("IsCheckUnYN"); }
        }
    }
}
