using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClick2;
        /// <summary>
        /// Gets the CmdGridListClick2.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClick2
        {
            get
            {
                return _CmdGridListClick2
                    ?? (_CmdGridListClick2 = new RelayCommand<Entity>(ExecuteCmdGridListClick2));
            }
        }

        private void ExecuteCmdGridListClick2(Entity parameter)
        {
            this.GridListClick2(parameter);
        }

        protected virtual void GridListClick2(Entity parameter)
        {
            //var vmcode = this.VMName.Replace("_List", "");
            //var funcode = vmcode.Substring(2);
            //ComOpenWins.Open("", funcode);
            //Messenger.Default.Send<string>((parameter), vmcode + "_ShowFromList");
        }
    }
}
