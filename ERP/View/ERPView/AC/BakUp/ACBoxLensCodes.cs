
namespace ERP.View
{
    public class ACBoxLensCode : ACBoxLensCodeErp
    {
        public ACBoxLensCode()
            : base("DContextMain.LensCode", 1)
        {
            this.Name = "LensCode";
            this.SetFocus("LensCode");
        }
    }

    public class ACBoxCusLensCode : ACBoxLensCodeErp
    {
        public ACBoxCusLensCode()
            : base("DContextMain.LensCode")
        {
            this.Name = "LensCode";
            this.SetFocus("CusLensCode");
        }
    }

    public class ACBoxLensCodeReplace : ACBoxLensCodeErp
    {
        public ACBoxLensCodeReplace()
            : base("DContextMain.LensCodeR", 1)
        {
            this.Name = "LensCodeReplace";
            this.SetFocus("LensCodeReplace");
        }
    }

    public class ACBoxLensCodeL : ACBoxLensCodeErp
    {
        public ACBoxLensCodeL()
            : base("DContextMain.LensCodeL")
        {
            this.Name = "LensCodeL";
            base.SetGotFocus(this.Name);
            this.SetFocus(this.Name);
        }
    }

    public class ACBoxLensCodeR : ACBoxLensCodeErp
    {
        public ACBoxLensCodeR()
            : base("DContextMain.LensCodeR")
        {
            this.Name = "LensCodeR";
            this.SetFocus("LensCodeR");
        }
    }

    public class ACBoxLensCodeReplaceL : ACBoxLensCodeErp
    {
        public ACBoxLensCodeReplaceL()
            : base("DContextMain.LensCodeRL", 1)
        {
            this.Name = "LensCode_ReplaceL";
            this.SetFocus("LensCode_ReplaceL");
        }
    }

    public class ACBoxLensCodeReplaceR : ACBoxLensCodeErp
    {
        public ACBoxLensCodeReplaceR()
            : base("DContextMain.LensCodeRR", 1)
        {
            this.Name = "LensCode_ReplaceR";
            this.SetFocus("LensCode_ReplaceR");
        }
    }
}
