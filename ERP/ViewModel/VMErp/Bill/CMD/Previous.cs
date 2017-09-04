using ERP.Common;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMBill
    {
        private RelayCommand _CmdPrevious;

        public RelayCommand CmdPrevious
        {
            get
            {
                return _CmdPrevious
                    ?? (_CmdPrevious = new RelayCommand(ExecuteCmdPrevious));
            }
        }

        private void ExecuteCmdPrevious()
        {
            this.flag_Next = false;
            this.flag_Previous = true;
            this.LoadPrevious();
        }

        private void LoadPrevious()
        {
            this.PrepareDDsInfoMainPrevious();
            var dds = ComDDSFactory.Get(this.DDsInfoMain, DDsMain_LoadingData, DDsMain_LoadedData);
            dds.Load();
        }
    }
}
