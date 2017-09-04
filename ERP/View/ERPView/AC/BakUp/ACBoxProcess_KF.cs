using ERP.Common;

namespace ERP.View
{
    public class ACBoxMianWan_KF : ACBoxProcess_KF
    {
        public ACBoxMianWan_KF()
            : base("DContextMain.BASE")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxMianWanR_KF : ACBoxProcess_KF
    {
        public ACBoxMianWanR_KF()
            : base("DContextMain.BASER")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxMianWanL_KF : ACBoxProcess_KF
    {
        public ACBoxMianWanL_KF()
            : base("DContextMain.BASEL")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_KF;
        }
    }

    public class ACBoxChaSe_KF : ACBoxProcess_KF
    {
        public ACBoxChaSe_KF()
            : base("DContextMain.CS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessChaSe_KF;
        }
    }

    public class ACBoxJuSe_KF : ACBoxProcess_KF
    {
        public ACBoxJuSe_KF()
            : base("DContextMain.JS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessJuSe_KF;
        }
    }

    public class ACBoxZuanKong_KF : ACBoxProcess_KF
    {
        public ACBoxZuanKong_KF()
            : base("DContextMain.ZK")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessZuanKong_KF;
        }
    }

    public class ACBoxCheBian_KF : ACBoxProcess_KF
    {
        public ACBoxCheBian_KF()
            : base("DContextMain.ChB")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessCheBian_KF;
        }
    }

    public class ACBoxPiHua_KF : ACBoxProcess_KF
    {
        public ACBoxPiHua_KF()
            : base("DContextMain.PiH")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessPiHua_KF;
        }
    }

    public class ACBoxKaiKeng_KF : ACBoxProcess_KF
    {
        public ACBoxKaiKeng_KF()
            : base("DContextMain.KK")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessKaiKeng_KF;
        }
    }

    public class ACBoxOtherProcess_KF : ACBoxProcess_KF
    {
        public ACBoxOtherProcess_KF()
            : base("DContextMain.OP")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessOtherProcess_KF;
        }
    }

    public class ACBoxRanSe_KF : ACBoxProcess_KF
    {
        public ACBoxRanSe_KF()
            : base("DContextMain.RS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessRanSe_KF;
        }
    }

    public class ACBoxRanSe_Name_KF : ACBoxProcess_KF
    {
        public ACBoxRanSe_Name_KF()
            : base("DContextMain.RSName")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessRanSeName_KF;
        }
    }

    public class ACBoxShuiYin_KF : ACBoxProcess_KF
    {
        public ACBoxShuiYin_KF()
            : base("DContextMain.SY")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessShuiYin_KF;
        }
    }

    public class ACBoxPaoGuang_KF : ACBoxProcess_KF
    {
        public ACBoxPaoGuang_KF()
            : base("DContextMain.PG")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessPaoGuang_KF;
        }
    }

    public class ACBoxJingJia_KF : ACBoxProcess_KF
    {
        public ACBoxJingJia_KF()
            : base("DContextMain.JJ")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessJingJia_KF;
        }
    }

    public class ACBoxCaiBian_KF : ACBoxProcess_KF
    {
        public ACBoxCaiBian_KF()
            : base("DContextMain.CB")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessCaiBian_KF;
        }
    }
}
