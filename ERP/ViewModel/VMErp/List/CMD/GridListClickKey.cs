using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<string> _CmdGridListClickKey;
        /// <summary>
        /// Gets the CmdGridListClickKey.
        /// </summary>
        public RelayCommand<string> CmdGridListClickKey
        {
            get
            {
                return _CmdGridListClickKey
                    ?? (_CmdGridListClickKey = new RelayCommand<string>(ExecuteCmdGridListClickKey));
            }
        }

        private void ExecuteCmdGridListClickKey(string parameter)
        {
            this.GridListClickKey(parameter);
        }

        protected virtual void GridListClickKey(string parameter)
        {
            var vmcode = this.VMName.Replace("_List", "");
            var funcode = vmcode.Substring(2);
            ComOpenWins.Open("", funcode);
            Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
