using ERP.Common;

namespace ERP.View
{
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillChaSe : ACBoxProcessErp
    {
        public ACBoxProcessBillChaSe()
            : base("DContextMain.CS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessChaSe;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillJuSe : ACBoxProcessErp
    {
        public ACBoxProcessBillJuSe()
            : base("DContextMain.JS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJuSe;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillZuanKong : ACBoxProcessErp
    {
        public ACBoxProcessBillZuanKong()
            : base("DContextMain.ZK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessZuanKong;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillCheBian : ACBoxProcessErp
    {
        public ACBoxProcessBillCheBian()
            : base("DContextMain.ChB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCheBian;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillPiHua : ACBoxProcessErp
    {
        public ACBoxProcessBillPiHua()
            : base("DContextMain.PiH")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPiHua;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillKaiKeng : ACBoxProcessErp
    {
        public ACBoxProcessBillKaiKeng()
            : base("DContextMain.KK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessKaiKeng;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillOtherProcess : ACBoxProcessErp
    {
        public ACBoxProcessBillOtherProcess()
            : base("DContextMain.OP")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessOtherProcess;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillRanSe : ACBoxProcessErp
    {
        public ACBoxProcessBillRanSe()
            : base("DContextMain.RS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSe;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillRanSe_Name : ACBoxProcessErp
    {
        public ACBoxProcessBillRanSe_Name()
            : base("DContextMain.RSName")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSeName;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillShuiYin : ACBoxProcessErp
    {
        public ACBoxProcessBillShuiYin()
            : base("DContextMain.SY")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessShuiYin;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillPaoGuang : ACBoxProcessErp
    {
        public ACBoxProcessBillPaoGuang()
            : base("DContextMain.PG")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPaoGuang;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillJingJia : ACBoxProcessErp
    {
        public ACBoxProcessBillJingJia()
            : base("DContextMain.JJ")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJingJia;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessBillCaiBian : ACBoxProcessErp
    {
        public ACBoxProcessBillCaiBian()
            : base("DContextMain.CB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCaiBian;
        }
    }
}
