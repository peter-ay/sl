using ERP.Common;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ServiceModel.DomainServices.Client;

namespace ERP.ViewModel
{
    public partial class VMList
    {
        private RelayCommand<Entity> _CmdGridListClickID;
        /// <summary>
        /// Gets the CmdGridListClickID.
        /// </summary>
        public RelayCommand<Entity> CmdGridListClickID
        {
            get
            {
                return _CmdGridListClickID
                    ?? (_CmdGridListClickID = new RelayCommand<Entity>(ExecuteCmdGridListClickID));
            }
        }

        private void ExecuteCmdGridListClickID(Entity parameter)
        {
            this.GridListClickID(parameter);
        }

        protected virtual void GridListClickID(Entity parameter)
        {
            var _vmCode = this.VMName.Replace("_List", "");
            var _funCode = _vmCode.Substring(2);
            ComOpenWins.Open("", _funCode);
            string _ID = "";
            try
            {
                _ID = parameter.GetType().GetProperty("ID").GetValue(parameter, null).ToString();
            }
            catch { _ID = ""; }
            Messenger.Default.Send<string>((_ID), _vmCode + "_ShowFromList");
        }
    }
}
