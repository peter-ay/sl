

namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                RaisePropertyChanged<bool>(() => this.IsBusy);
            }
        }

        private bool _IsBusy2 = false;
        public bool IsBusy2
        {
            get { return _IsBusy2; }
            set
            {
                _IsBusy2 = value;
                RaisePropertyChanged<bool>(() => this.IsBusy2);
            }
        }

        private bool _IsBusyList2 = false;
        public bool IsBusyList2
        {
            get { return _IsBusyList2; }
            set
            {
                _IsBusyList2 = value;
                RaisePropertyChanged<bool>(() => this.IsBusyList2);
            }
        }

        private bool _IsBusyProgress = false;
        public bool IsBusyProgress
        {
            get { return _IsBusyProgress; }
            set
            {
                _IsBusyProgress = value;
                RaisePropertyChanged<bool>(() => this.IsBusyProgress);
            }
        }

        //BIProgressValue
        private int _BIProgressValue = 0;
        public int BIProgressValue
        {
            get { return _BIProgressValue; }
            set
            {
                _BIProgressValue = value;
                RaisePropertyChanged("BIProgressValue");
            }
        }

        private bool _IsBusyProgressMain = false;
        public bool IsBusyProgressMain
        {
            get { return _IsBusyProgressMain; }
            set
            {
                _IsBusyProgressMain = value;
                RaisePropertyChanged<bool>(() => this.IsBusyProgressMain);
            }
        }

        //BIProgressValueMain
        private int _BIProgressValueMain = 0;
        public int BIProgressValueMain
        {
            get { return _BIProgressValueMain; }
            set
            {
                _BIProgressValueMain = value;
                RaisePropertyChanged("BIProgressValueMain");
            }
        }
        //
        private bool _IsBusyCW = false;
        public bool IsBusyCW
        {
            get { return _IsBusyCW; }
            set
            {
                _IsBusyCW = value;
                RaisePropertyChanged<bool>(() => this.IsBusyCW);
            }
        }
    }
}
