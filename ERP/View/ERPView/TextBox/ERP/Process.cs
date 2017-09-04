
namespace ERP.View
{

    //ProCode
    public class TBProCode : TextBoxErp
    {
        public TBProCode()
            : base("DContextMain.ProCode")
        {
            this.MaxLength = 20;
        }
    }

    //ProName
    public class TBProName : TextBoxErp
    {
        public TBProName()
            : base("DContextMain.ProName")
        {
            this.MaxLength = 50;
        }
    }

    //ProClass
    public class TBProClassRO : TextBoxErp
    {
        public TBProClassRO()
            : base("DContextMain.ProClass")
        {
            this.ReSetRO();
        }
    }

    //ProClass
    public class TBProClassNameUIRO : TextBoxErp
    {
        public TBProClassNameUIRO()
            : base("DContextMain.ProClassNameUI")
        {
            this.ReSetRO();
        }
    }

    //MianWanR
    public class TBMianWanRRO : TextBoxErp
    {
        public TBMianWanRRO()
            : base("DContextMain.BASER")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //MianWanL
    public class TBMianWanLRO : TextBoxErp
    {
        public TBMianWanLRO()
            : base("DContextMain.BASEL")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Decenter1R
    public class TBDecenter1RRO : TextBoxErp
    {
        public TBDecenter1RRO()
            : base("DContextMain.D1R")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Decenter2
    public class TBDecenter2 : TextBoxErp
    {
        public TBDecenter2()
            : base("DContextMain.D2")
        {
            this.MaxLength = 5;
        }
    }
    //Decenter2R
    public class TBDecenter2R : TextBoxErp
    {
        public TBDecenter2R()
            : base("DContextMain.D2R")
        {
            this.MaxLength = 5;
        }
    }
    //Decenter3R
    public class TBDecenter3RRO : TextBoxErp
    {
        public TBDecenter3RRO()
            : base("DContextMain.D3R")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Decenter4
    public class TBDecenter4 : TextBoxErp
    {
        public TBDecenter4()
            : base("DContextMain.D4")
        {
            this.MaxLength = 5;
        }
    }
    //Decenter4R
    public class TBDecenter4R : TextBoxErp
    {
        public TBDecenter4R()
            : base("DContextMain.D4R")
        {
            this.MaxLength = 5;
        }
    }
    //Decenter1L
    public class TBDecenter1LRO : TextBoxErp
    {
        public TBDecenter1LRO()
            : base("DContextMain.D1L")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Decenter2L
    public class TBDecenter2L : TextBoxErp
    {
        public TBDecenter2L()
            : base("DContextMain.D2L")
        {
            this.MaxLength = 5;
        }
    }
    //Decenter3L
    public class TBDecenter3LRO : TextBoxErp
    {
        public TBDecenter3LRO()
            : base("DContextMain.D3L")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Decenter4L
    public class TBDecenter4L : TextBoxErp
    {
        public TBDecenter4L()
            : base("DContextMain.D4L")
        {
            this.MaxLength = 5;
        }
    }
    //Prism1R 
    public class TBPrism1RRO : TextBoxErp
    {
        public TBPrism1RRO()
            : base("DContextMain.P1R")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Prism2
    public class TBPrism2 : TextBoxErp
    {
        public TBPrism2()
            : base("DContextMain.P2")
        {
            this.MaxLength = 5;
        }
    }
    //Prism2R
    public class TBPrism2R : TextBoxErp
    {
        public TBPrism2R()
            : base("DContextMain.P2R")
        {
            this.MaxLength = 5;
        }
    }
    //Prism3R
    public class TBPrism3RRO : TextBoxErp
    {
        public TBPrism3RRO()
            : base("DContextMain.P3R")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Prism4
    public class TBPrism4 : TextBoxErp
    {
        public TBPrism4()
            : base("DContextMain.P4")
        {
            this.MaxLength = 5;
        }
    }
    //Prism4R
    public class TBPrism4R : TextBoxErp
    {
        public TBPrism4R()
            : base("DContextMain.P4R")
        {
            this.MaxLength = 5;
        }
    }
    //Prism1L
    public class TBPrism1LRO : TextBoxErp
    {
        public TBPrism1LRO()
            : base("DContextMain.P1L")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Prism2L
    public class TBPrism2L : TextBoxErp
    {
        public TBPrism2L()
            : base("DContextMain.P2L")
        {
            this.MaxLength = 5;
        }
    }
    //Prism3L
    public class TBPrism3LRO : TextBoxErp
    {
        public TBPrism3LRO()
            : base("DContextMain.P3L")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //Prism4L
    public class TBPrism4L : TextBoxErp
    {
        public TBPrism4L()
            : base("DContextMain.P4L")
        {
            this.MaxLength = 5;
        }
    }
    //CaiBian
    public class TBCaiBian : TextBoxErp
    {
        public TBCaiBian()
            : base("DContextMain.CB")
        {
            this.MaxLength = 30;
        }
    }
    //CaiBianRO
    public class TBCaiBianRO : TextBoxErp
    {
        public TBCaiBianRO()
            : base("DContextMain.CB")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //ChaSe
    public class TBChaSe : TextBoxErp
    {
        public TBChaSe()
            : base("DContextMain.CS")
        {
            this.MaxLength = 30;
        }
    }
    //ChaSeRO
    public class TBChaSeRO : TextBoxErp
    {
        public TBChaSeRO()
            : base("DContextMain.CS")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //CheBian
    public class TBCheBian : TextBoxErp
    {
        public TBCheBian()
            : base("DContextMain.ChB")
        {
            this.MaxLength = 30;
        }
    }
    //CheBianRO
    public class TBCheBianRO : TextBoxErp
    {
        public TBCheBianRO()
            : base("DContextMain.ChB")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //DaoBian
    public class TBDaoBian : TextBoxErp
    {
        public TBDaoBian()
            : base("DContextMain.DB")
        {
            this.MaxLength = 30;
        }
    }
    //JingJia
    public class TBJingJia : TextBoxErp
    {
        public TBJingJia()
            : base("DContextMain.JJ")
        {
            this.MaxLength = 30;
        }
    }
    //JingJiaRO
    public class TBJingJiaRO : TextBoxErp
    {
        public TBJingJiaRO()
            : base("DContextMain.JJ")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //JuSe
    public class TBJuSe : TextBoxErp
    {
        public TBJuSe()
            : base("DContextMain.JS")
        {
            this.MaxLength = 30;
        }
    }
    //JuSe
    public class TBJuSeRO : TextBoxErp
    {
        public TBJuSeRO()
            : base("DContextMain.JS")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //KaiKeng
    public class TBKaiKeng : TextBoxErp
    {
        public TBKaiKeng()
            : base("DContextMain.KK")
        {
            this.MaxLength = 30;
        }
    }
    //KaiKengRO
    public class TBKaiKengRO : TextBoxErp
    {
        public TBKaiKengRO()
            : base("DContextMain.KK")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //MianWan
    public class TBMianWan : TextBoxErp
    {
        public TBMianWan()
            : base("DContextMain.BASE")
        {
            this.MaxLength = 30;
        }
    }
    //PaoGuang
    public class TBPaoGuang : TextBoxErp
    {
        public TBPaoGuang()
            : base("DContextMain.PG")
        {
            this.MaxLength = 30;
        }
    }
    //PaoGuangRO
    public class TBPaoGuangRO : TextBoxErp
    {
        public TBPaoGuangRO()
            : base("DContextMain.PG")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //RanSe
    public class TBRanSe : TextBoxErp
    {
        public TBRanSe()
            : base("DContextMain.RS")
        {
            this.MaxLength = 30;
        }
    }
    //RanSeRO
    public class TBRanSeRO : TextBoxErp
    {
        public TBRanSeRO()
            : base("DContextMain.RS")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //ShuiYin
    public class TBShuiYin : TextBoxErp
    {
        public TBShuiYin()
            : base("DContextMain.SY")
        {
            this.MaxLength = 30;
        }
    }
    //ShuiYinRO
    public class TBShuiYinRO : TextBoxErp
    {
        public TBShuiYinRO()
            : base("DContextMain.SY")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //ZuanKong
    public class TBZuanKong : TextBoxErp
    {
        public TBZuanKong()
            : base("DContextMain.ZK")
        {
            this.MaxLength = 30;
        }
    }
    //ZuanKongRO
    public class TBZuanKongRO : TextBoxErp
    {
        public TBZuanKongRO()
            : base("DContextMain.ZK")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //PiHua
    public class TBPiHua : TextBoxErp
    {
        public TBPiHua()
            : base("DContextMain.PiH")
        {
            this.MaxLength = 30;
        }
    }
    //PiHuaRO
    public class TBPiHuaRO : TextBoxErp
    {
        public TBPiHuaRO()
            : base("DContextMain.PiH")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //OtherProcess
    public class TBOtherProcess : TextBoxErp
    {
        public TBOtherProcess()
            : base("DContextMain.OP")
        {
            this.MaxLength = 30;
        }
    }
    //OtherProcessRO
    public class TBOtherProcessRO : TextBoxErp
    {
        public TBOtherProcessRO()
            : base("DContextMain.OP")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //RanSeName
    public class TBRanSeName : TextBoxErp
    {
        public TBRanSeName()
            : base("DContextMain.RSName")
        {
            this.MaxLength = 30;
        }
    }
    //RanSeNameRO
    public class TBRanSeNameRO : TextBoxErp
    {
        public TBRanSeNameRO()
            : base("DContextMain.RSName")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //ExtraProcess
    public class TBExtraProcess : TextBoxErp
    {
        public TBExtraProcess()
            : base("DContextMain.ExtraProcess")
        {
            this.MaxLength = 30;
        }
    }
    //ExtraProcessRO
    public class TBExtraProcessRO : TextBoxErp
    {
        public TBExtraProcessRO()
            : base("DContextMain.ExtraProcess")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
}
