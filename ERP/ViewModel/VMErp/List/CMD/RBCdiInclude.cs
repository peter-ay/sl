using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        protected int _ConInclude = -1;

        private RelayCommand<string> _CmdRBCdiInclude;

        /// <summary>
        /// Gets the CmdRBCdiInclude.
        /// </summary>
        public RelayCommand<string> CmdRBCdiInclude
        {
            get
            {
                return _CmdRBCdiInclude
                    ?? (_CmdRBCdiInclude = new RelayCommand<string>(ExecuteCmdRBCdiInclude));
            }
        }

        private void ExecuteCmdRBCdiInclude(string parameter)
        {
            _ConInclude = System.Convert.ToInt32(parameter);
        }
    }
}
