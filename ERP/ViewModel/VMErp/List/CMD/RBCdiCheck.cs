using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<string> _CmdRBCdiCheck;

        /// <summary>
        /// Gets the CmdRBCdiCheck.
        /// </summary>
        public RelayCommand<string> CmdRBCdiCheck
        {
            get
            {
                return _CmdRBCdiCheck
                    ?? (_CmdRBCdiCheck = new RelayCommand<string>(ExecuteCmdRBCdiCheck));
            }
        }

        protected int _ConCheck = -1;
        private void ExecuteCmdRBCdiCheck(string parameter)
        {
            switch (parameter)
            {
                case "0":
                    _ConCheck = 0;
                    break;

                case "1":
                    _ConCheck = 1;
                    break;

                default:
                    _ConCheck = -1;
                    break;
            }
        }
    }
}
