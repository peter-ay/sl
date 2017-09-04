using ERP.Common;
using System.Windows.Data;
using System.Windows.Controls;

namespace ERP.View
{
    public abstract class ACBoxProcessBillCF : ACBoxProcessErp
    {
        public ACBoxProcessBillCF(string bindDContextName)
            : base(bindDContextName)
        {
            this.ClearValue(ACBoxCusCodeBrowseBill.VisibilityProperty);
            var bd = new Binding("IsShowACProcessCF");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bd);
        }
    }

    public class ACBoxProcessBillCFMianWan : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFMianWan()
            : base("DContextMain.BASE")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxProcessBillCFMianWanR : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFMianWanR()
            : base("DContextMain.BASER")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxProcessBillCFMianWanL : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFMianWanL()
            : base("DContextMain.BASEL")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxProcessBillCFChaSe : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFChaSe()
            : base("DContextMain.CS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessChaSe_CF;
        }
    }

    public class ACBoxProcessBillCFJuSe : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFJuSe()
            : base("DContextMain.JS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJuSe_CF;
        }
    }

    public class ACBoxProcessBillCFZuanKong : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFZuanKong()
            : base("DContextMain.ZK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessZuanKong_CF;
        }
    }

    public class ACBoxProcessBillCFCheBian : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFCheBian()
            : base("DContextMain.ChB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCheBian_CF;
        }
    }

    public class ACBoxProcessBillCFPiHua : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFPiHua()
            : base("DContextMain.PiH")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPiHua_CF;
        }
    }

    public class ACBoxProcessBillCFKaiKeng : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFKaiKeng()
            : base("DContextMain.KK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessKaiKeng_CF;
        }
    }

    public class ACBoxProcessBillCFOtherProcess : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFOtherProcess()
            : base("DContextMain.OP")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessOtherProcess_CF;
        }
    }

    public class ACBoxProcessBillCFRanSe : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFRanSe()
            : base("DContextMain.RS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSe_CF;
        }
    }

    public class ACBoxProcessBillCFRanSe_Name : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFRanSe_Name()
            : base("DContextMain.RSName")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSeName_CF;
        }
    }

    public class ACBoxProcessBillCFShuiYin : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFShuiYin()
            : base("DContextMain.SY")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessShuiYin_CF;
        }
    }

    public class ACBoxProcessBillCFPaoGuang : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFPaoGuang()
            : base("DContextMain.PG")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPaoGuang_CF;
        }
    }

    public class ACBoxProcessBillCFJingJia : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFJingJia()
            : base("DContextMain.JJ")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJingJia_CF;
        }
    }

    public class ACBoxProcessBillCFCaiBian : ACBoxProcessBillCF
    {
        public ACBoxProcessBillCFCaiBian()
            : base("DContextMain.CB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCaiBian_CF;
        }
    }
}
