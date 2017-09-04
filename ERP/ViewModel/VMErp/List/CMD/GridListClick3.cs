using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClick3;
        /// <summary>
        /// Gets the CmdGridListClick3.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClick3
        {
            get
            {
                return _CmdGridListClick3
                    ?? (_CmdGridListClick3 = new RelayCommand<Entity>(ExecuteCmdGridListClick3));
            }
        }

        private void ExecuteCmdGridListClick3(Entity parameter)
        {
            this.GridListClick3(parameter);
        }

        protected virtual void GridListClick3(Entity parameter)
        {
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
