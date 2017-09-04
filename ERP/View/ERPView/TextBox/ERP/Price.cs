
namespace ERP.View
{
    public class TBPrice : TextBoxErp
    {
        public TBPrice()
            : base("DContextMain.Price")
        {
            this.MaxLength = 7;
        }
    }
    public class TBPriceRO : TextBoxErp
    {
        public TBPriceRO()
            : base("DContextMain.Price")
        {
            this.ReSetRO();
        }
    }
    public class TBPriceJM : TextBoxErp
    {
        public TBPriceJM()
            : base("DContextMain.PriceJM")
        {
            this.MaxLength = 7;
        }
    }
    public class TBPriceJMRO : TextBoxErp
    {
        public TBPriceJMRO()
            : base("DContextMain.PriceJM")
        {
            this.ReSetRO();
        }
    }
    //
    public class TBPrice_ProCost : TextBoxErp
    {
        public TBPrice_ProCost()
            : base("DContextMain.Price_ProCost")
        {
            this.MaxLength = 7;
        }
    }
    public class TBProCost : TextBoxErp
    {
        public TBProCost()
            : base("DContextMain.ProCost")
        {
            this.MaxLength = 7;
        }
    }
    public class TBPrice_ProCostRO : TextBoxErp
    {
        public TBPrice_ProCostRO()
            : base("DContextMain.Price_ProCost")
        {
            this.ReSetRO();
        }
    }
    public class TBProCostRO : TextBoxErp
    {
        public TBProCostRO()
            : base("DContextMain.ProCost")
        {
            this.ReSetRO();
        }
    }
    public class TBPrice_ProCostJM : TextBoxErp
    {
        public TBPrice_ProCostJM()
            : base("DContextMain.Price_ProCostJM")
        {
            this.MaxLength = 7;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////
    public class TBP1 : TextBoxErp
    {
        public TBP1()
            : base("DContextMain.P1")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP1JM : TextBoxErp
    {
        public TBP1JM()
            : base("DContextMain.P1JM")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP1List : TextBoxErp
    {
        public TBP1List()
            : base("P1")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP1CurDSource : TextBoxErp
    {
        public TBP1CurDSource()
            : base("CurDSource.P1")
        {
            this.MaxLength = 7;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////
    public class TBP2 : TextBoxErp
    {
        public TBP2()
            : base("DContextMain.P2")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP2JM : TextBoxErp
    {
        public TBP2JM()
            : base("DContextMain.P2JM")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP2List : TextBoxErp
    {
        public TBP2List()
            : base("P2")
        {
            this.MaxLength = 7;
        }
    }
    public class TBP2CurDSource : TextBoxErp
    {
        public TBP2CurDSource()
            : base("CurDSource.P2")
        {
            this.MaxLength = 7;
        }
    }
}
