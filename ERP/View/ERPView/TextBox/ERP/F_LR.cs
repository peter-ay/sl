
namespace ERP.View
{
    #region F_LR

    //LR_Flag
    public class TBF_LR : TextBoxErp
    {
        public TBF_LR()
            : base("DContextMain.F_LR")
        {
            this.MaxLength = 1;
        }
    }
    //LR_FlagRO
    public class TBF_LRRO : TextBoxErp
    {
        public TBF_LRRO()
            : base("DContextMain.F_LR")
        {
            this.ReSetRO();
            this.TextAlignment = System.Windows.TextAlignment.Center;
            this.Foreground = new System.Windows.Media.SolidColorBrush(ERP.Common.ComColorConstants.DarkBlue);
        }
    }

    //LR_FlagListRO
    public class TBF_LRListRO : TextBoxErp
    {
        public TBF_LRListRO()
            : base("F_LR")
        {
            this.ReSetRO();
        }
    }

    //LR_FlagSaleRO
    public class TBF_LRSaleRO : TextBoxErp
    {
        public TBF_LRSaleRO()
            : base("DContextMain.F_LRSale")
        {
            this.ReSetRO();
            this.TextAlignment = System.Windows.TextAlignment.Center;
            this.Foreground = new System.Windows.Media.SolidColorBrush(ERP.Common.ComColorConstants.DarkBlue);
        }
    }

    #endregion



}
