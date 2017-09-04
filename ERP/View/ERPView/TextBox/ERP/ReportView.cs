
namespace ERP.View
{
    //ProReport
    public class TBProReport : TextBoxErp
    {
        public TBProReport()
            : base("DContextMain.ProReport")
        {
            this.MaxLength = 200;
            this.ClearValue(TextBoxErp.HeightProperty);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }
    }

    //ProReportRO
    public class TBProReportRO : TextBoxErp
    {
        public TBProReportRO()
            : base("DContextMain.ProReport")
        {
            this.ReSetRO();
            this.ClearValue(TextBoxErp.HeightProperty);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            this.TextAlignment = System.Windows.TextAlignment.Right;
        }
    }

    //ProCostReport
    public class TBProCostReport : TextBoxErp
    {
        public TBProCostReport()
            : base("DContextMain.ProCostReport")
        {
            this.MaxLength = 200;
            this.ClearValue(TextBoxErp.HeightProperty);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }
    }

    //ProCostReportRO
    public class TBProCostReportRO : TextBoxErp
    {
        public TBProCostReportRO()
            : base("DContextMain.ProCostReport")
        {
            this.ReSetRO();
            this.ClearValue(TextBoxErp.HeightProperty);
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            this.TextAlignment = System.Windows.TextAlignment.Right;
        }
    }
}
