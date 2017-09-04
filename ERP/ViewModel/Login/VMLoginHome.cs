using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using System.Linq;

namespace ERP.ViewModel
{
    public class VMLoginHome : VMErpSimple
    {
        private string fid;
        private string fcode;
        private string fname;
        public VMLoginHome()
        {
        }

        private RelayCommand<string> _CmdOpenWins;

        /// <summary>
        /// Gets the CmdOpenWins.
        /// </summary>
        public RelayCommand<string> CmdOpenWins
        {
            get
            {
                return _CmdOpenWins
                    ?? (_CmdOpenWins = new RelayCommand<string>(
                    p =>
                    {
                        this.OpenWins(p);
                    }));
            }
        }

        private void OpenWins(string obj)
        {
            try
            {
                fcode = obj;
                var rs = URight.Rights.Where(item => item.FunCode == fcode).FirstOrDefault();
                if (rs == null)
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("ERP_AuthorityErr"));
                }
                fid = rs.FunID;
                fname = rs.FunName;
                ComOpenWins.Open(fid, fcode, fname);
            }
            catch { }
        }
    }
}
