using ERP.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public class VMLoginTab : VMErpSimple
    {
        private const string iSource1 = "/ERP;component/Images/arrow_skip_180.png";
        private const string iSource2 = "/ERP;component/Images/arrow_skip.png";

        public VMLoginTab()
        {

        }

        private string imageSource = iSource1;

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }

        private RelayCommand _TabShowOrHide;

        /// <summary>
        /// Gets the TabShowOrHide.
        /// </summary>
        public RelayCommand TabShowOrHide
        {
            get
            {
                return _TabShowOrHide
                    ?? (_TabShowOrHide = new RelayCommand(
                    () =>
                    {
                        ImageSource = ImageSource == iSource1 ? iSource2 : iSource1;
                        Messenger.Default.Send<string>((""), USysMessages.LoginTab);
                    }));
            }
        }

    }
}
