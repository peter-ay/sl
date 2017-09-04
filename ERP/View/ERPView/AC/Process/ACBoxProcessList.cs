using ERP.Common;

namespace ERP.View
{
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessList : ACBoxProcessErp
    {
        public ACBoxProcessList(string bindDContextName)
            : base(bindDContextName)
        {
            this.ClearValue(ACBoxCusCodeBrowseBill.VisibilityProperty);
        }
    }

    public class ACBoxProcessListChaSe : ACBoxProcessList
    {
        public ACBoxProcessListChaSe()
            : base("CS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessChaSe;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListJuSe : ACBoxProcessList
    {
        public ACBoxProcessListJuSe()
            : base("JS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJuSe;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListZuanKong : ACBoxProcessList
    {
        public ACBoxProcessListZuanKong()
            : base("ZK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessZuanKong;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessListCheBian : ACBoxProcessList
    {
        public ACBoxProcessListCheBian()
            : base("ChB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCheBian;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessListPiHua : ACBoxProcessList
    {
        public ACBoxProcessListPiHua()
            : base("PiH")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPiHua;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessListKaiKeng : ACBoxProcessList
    {
        public ACBoxProcessListKaiKeng()
            : base("KK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessKaiKeng;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListOtherProcess : ACBoxProcessList
    {
        public ACBoxProcessListOtherProcess()
            : base("OP")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessOtherProcess;
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class ACBoxProcessListRanSe : ACBoxProcessList
    {
        public ACBoxProcessListRanSe()
            : base("RS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSe;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListShuiYin : ACBoxProcessList
    {
        public ACBoxProcessListShuiYin()
            : base("SY")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessShuiYin;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListPaoGuang : ACBoxProcessList
    {
        public ACBoxProcessListPaoGuang()
            : base("PG")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPaoGuang;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListJingJia : ACBoxProcessList
    {
        public ACBoxProcessListJingJia()
            : base("JJ")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJingJia;
        }
    }
    ///////////////////////////////////////////////////////////////////

    public class ACBoxProcessListCaiBian : ACBoxProcessList
    {
        public ACBoxProcessListCaiBian()
            : base("CB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCaiBian;
        }
    }
}
