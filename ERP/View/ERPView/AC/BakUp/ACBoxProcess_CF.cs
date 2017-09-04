using ERP.Common;

namespace ERP.View
{
    public class ACBoxMianWan_CF : ACBoxProcess_CF
    {
        public ACBoxMianWan_CF()
            : base("DContextMain.BASE")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxMianWanR_CF : ACBoxProcess_CF
    {
        public ACBoxMianWanR_CF()
            : base("DContextMain.BASER")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxMianWanL_CF : ACBoxProcess_CF
    {
        public ACBoxMianWanL_CF()
            : base("DContextMain.BASEL")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessMianWan_CF;
        }
    }

    public class ACBoxChaSe_CF : ACBoxProcess_CF
    {
        public ACBoxChaSe_CF()
            : base("DContextMain.CS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessChaSe_CF;
        }
    }

    public class ACBoxJuSe_CF : ACBoxProcess_CF
    {
        public ACBoxJuSe_CF()
            : base("DContextMain.JS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessJuSe_CF;
        }
    }

    public class ACBoxZuanKong_CF : ACBoxProcess_CF
    {
        public ACBoxZuanKong_CF()
            : base("DContextMain.ZK")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessZuanKong_CF;
        }
    }

    public class ACBoxCheBian_CF : ACBoxProcess_CF
    {
        public ACBoxCheBian_CF()
            : base("DContextMain.ChB")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessCheBian_CF;
        }
    }

    public class ACBoxPiHua_CF : ACBoxProcess_CF
    {
        public ACBoxPiHua_CF()
            : base("DContextMain.PiH")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessPiHua_CF;
        }
    }

    public class ACBoxKaiKeng_CF : ACBoxProcess_CF
    {
        public ACBoxKaiKeng_CF()
            : base("DContextMain.KK")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessKaiKeng_CF;
        }
    }

    public class ACBoxOtherProcess_CF : ACBoxProcess_CF
    {
        public ACBoxOtherProcess_CF()
            : base("DContextMain.OP")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessOtherProcess_CF;
        }
    }

    public class ACBoxRanSe_CF : ACBoxProcess_CF
    {
        public ACBoxRanSe_CF()
            : base("DContextMain.RS")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessRanSe_CF;
        }
    }

    public class ACBoxRanSe_Name_CF : ACBoxProcess_CF
    {
        public ACBoxRanSe_Name_CF()
            : base("DContextMain.RSName")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessRanSeName_CF;
        }
    }

    public class ACBoxShuiYin_CF : ACBoxProcess_CF
    {
        public ACBoxShuiYin_CF()
            : base("DContextMain.SY")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessShuiYin_CF;
        }
    }

    public class ACBoxPaoGuang_CF : ACBoxProcess_CF
    {
        public ACBoxPaoGuang_CF()
            : base("DContextMain.PG")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessPaoGuang_CF;
        }
    }

    public class ACBoxJingJia_CF : ACBoxProcess_CF
    {
        public ACBoxJingJia_CF()
            : base("DContextMain.JJ")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessJingJia_CF;
        }
    }

    public class ACBoxCaiBian_CF : ACBoxProcess_CF
    {
        public ACBoxCaiBian_CF()
            : base("DContextMain.CB")
        {
            this.ItemsSource = ComHelpV_B_Process.UV_B_ProcessCaiBian_CF;
        }
    }
}
