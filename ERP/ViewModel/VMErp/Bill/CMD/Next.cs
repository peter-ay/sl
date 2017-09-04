using ERP.Common;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdNext;

        public RelayCommand CmdNext
        {
            get
            {
                return _CmdNext
                    ?? (_CmdNext = new RelayCommand(ExecuteCmdNext));
            }
        }

        private void ExecuteCmdNext()
        {
            this.flag_Next = true;
            this.flag_Previous = false;
            this.LoadNext();
        }

        private void LoadNext()
        {
            this.PrepareDDsInfoMainNext();
            var dds = ComDDSFactory.Get(this.DDsInfoMain, DDsMain_LoadingData, DDsMain_LoadedData);
            dds.Load();
        }
    }
}
