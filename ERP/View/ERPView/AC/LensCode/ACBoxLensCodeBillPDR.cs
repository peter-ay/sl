
using System.Windows.Data;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
namespace ERP.View
{
    public class ACBoxLensCodeBillPDR : ACBoxLensCodeErp
    {
        protected string _Text = "";

        public ACBoxLensCodeBillPDR()
            : base("DContextMain.LensCodeR")
        {

        }
    }
}
