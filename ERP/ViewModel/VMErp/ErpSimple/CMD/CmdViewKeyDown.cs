

using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
namespace ERP.ViewModel
{
    public partial class VMErpSimple
    {
        private RelayCommand<KeyEventArgs> _CmdViewKeyDown;

        /// <summary>
        /// Gets the CmdViewKeyDown.
        /// </summary>
        public RelayCommand<KeyEventArgs> CmdViewKeyDown
        {
            get
            {
                return _CmdViewKeyDown ?? (_CmdViewKeyDown = new RelayCommand<KeyEventArgs>(ExecuteCmdViewKeyDown));
            }
        }

        private void ExecuteCmdViewKeyDown(KeyEventArgs parameter)
        {
            if (!CanExecuteCmdViewKeyDown(parameter))
                return;
            this.ViewKeyDown(parameter);
        }

        protected virtual void ViewKeyDown(KeyEventArgs parameter) { }

        protected virtual bool CanExecuteCmdViewKeyDown(KeyEventArgs parameter)
        {
            return true;
        }
    }
}
