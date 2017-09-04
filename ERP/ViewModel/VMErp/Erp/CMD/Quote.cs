using ERP.Utility;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {

        private RelayCommand _CmdQuote;

        /// <summary>
        /// Gets the CmdQuote.
        /// </summary>
        public RelayCommand CmdQuote
        {
            get
            {
                return _CmdQuote ?? (_CmdQuote = new RelayCommand(ExecuteCmdQuote));
            }
        }

        protected void ExecuteCmdQuote()
        {
            if (!CanExecuteCmdQuote())
            {
                return;
            }
            this.Quote();
        }

        protected virtual void Quote() { }

        protected virtual bool CanExecuteCmdQuote()
        {
            return URight.Check(this.VMNameAuthority + "_Quote", false);
        }

    }
}
