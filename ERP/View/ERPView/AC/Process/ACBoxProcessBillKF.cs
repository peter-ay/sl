using ERP.Common;
using System.Windows.Data;
using System.Windows.Controls;

namespace ERP.View
{
    public abstract class ACBoxProcessBillKF : ACBoxProcessErp
    {
        public ACBoxProcessBillKF(string bindDContextName)
            : base(bindDContextName)
        {
            this.ClearValue(ACBoxCusCodeBrowseBill.VisibilityProperty);
            var bd = new Binding("IsShowACProcessKF");
            this.SetBinding(AutoCompleteBox.VisibilityProperty, bd);
        }
    }

    public class ACBoxProcessBillKFMianWan : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFMianWan()
            : base("DContextMain.BASE")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxProcessBillKFMianWanR : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFMianWanR()
            : base("DContextMain.BASER")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxProcessBillKFMianWanL : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFMianWanL()
            : base("DContextMain.BASEL")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxProcessBillKFChaSe : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFChaSe()
            : base("DContextMain.CS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessChaSe_KF;
        }
    }

    public class ACBoxProcessBillKFJuSe : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFJuSe()
            : base("DContextMain.JS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJuSe_KF;
        }
    }

    public class ACBoxProcessBillKFZuanKong : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFZuanKong()
            : base("DContextMain.ZK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessZuanKong_KF;
        }
    }

    public class ACBoxProcessBillKFCheBian : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFCheBian()
            : base("DContextMain.ChB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCheBian_KF;
        }
    }

    public class ACBoxProcessBillKFPiHua : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFPiHua()
            : base("DContextMain.PiH")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPiHua_KF;
        }
    }

    public class ACBoxProcessBillKFKaiKeng : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFKaiKeng()
            : base("DContextMain.KK")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessKaiKeng_KF;
        }
    }

    public class ACBoxProcessBillKFOtherProcess : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFOtherProcess()
            : base("DContextMain.OP")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessOtherProcess_KF;
        }
    }

    public class ACBoxProcessBillKFRanSe : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFRanSe()
            : base("DContextMain.RS")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSe_KF;
        }
    }

    public class ACBoxProcessBillKFRanSe_Name : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFRanSe_Name()
            : base("DContextMain.RSName")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessRanSeName_KF;
        }
    }

    public class ACBoxProcessBillKFShuiYin : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFShuiYin()
            : base("DContextMain.SY")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessShuiYin_KF;
        }
    }

    public class ACBoxProcessBillKFPaoGuang : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFPaoGuang()
            : base("DContextMain.PG")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessPaoGuang_KF;
        }
    }

    public class ACBoxProcessBillKFJingJia : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFJingJia()
            : base("DContextMain.JJ")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessJingJia_KF;
        }
    }

    public class ACBoxProcessBillKFCaiBian : ACBoxProcessBillKF
    {
        public ACBoxProcessBillKFCaiBian()
            : base("DContextMain.CB")
        {
            this.ItemsSource = ComHelpProCode.UV_B_ProcessCaiBian_KF;
        }
    }
}
