
namespace ERP.View
{
    #region LensCode

    //LensCode
    public class TBLensCode : TextBoxErp
    {
        public TBLensCode()
            : base("DContextMain.LensCode")
        {
            this.MaxLength = 30;
            this.SetFocus("LensCode");
        }
    }

    //LensCodeList
    public class TBLensCodeList : TextBoxErp
    {
        public TBLensCodeList()
            : base("LensCode")
        {
            this.MaxLength = 30;
            this.SetFocus("LensCode");
        }
    }
    //LensCodeSelectedROList
    public class TBLensCodeSelectedROList : TextBoxErp
    {
        public TBLensCodeSelectedROList()
            : base("LensCodeSelected")
        {
            this.ReSetRO();
        }
    }
    //LensCodeCopy
    public class TBLensCodeCopy : TextBoxErp
    {
        public TBLensCodeCopy()
            : base("LensCodeCopy")
        {
            this.MaxLength = 30;
        }
    }
    //LensCode2
    public class TBLensCode2 : TextBoxErp
    {
        public TBLensCode2()
            : base("LensCode2")
        {
            this.MaxLength = 30;
        }
    }
    //LensCodeReplaceRO
    public class TBLensCodeReplaceRO : TextBoxErp
    {
        public TBLensCodeReplaceRO()
            : base("DContextMain.LensCodeR")
        {
            this.ReSetRO();
        }
    }
    //LensCodeRO
    public class TBLensCodeRO : TextBoxErp
    {
        public TBLensCodeRO()
            : base("DContextMain.LensCode")
        {
            this.ReSetRO();
        }
    }
    //LensCodeROList
    public class TBLensCodeROList : TextBoxErp
    {
        public TBLensCodeROList()
            : base("LensCode")
        {
            this.ReSetRO();
        }
    }
    //LensCodeRRO
    public class TBLensCodeRRO : TextBoxErp
    {
        public TBLensCodeRRO()
            : base("DContextMain.LensCodeR")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //LensCodeRRO1
    public class TBLensCodeRRO1 : TextBoxErp
    {
        public TBLensCodeRRO1()
            : base("DContextMain.LensCodeR")
        {
            this.ReSetRO(); 
        }
    }
    //LensCode_ReplaceR
    public class TBLensCode_ReplaceRRO : TextBoxErp
    {
        public TBLensCode_ReplaceRRO()
            : base("DContextMain.LensCodeRR")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //LensCodeLRO
    public class TBLensCodeLRO : TextBoxErp
    {
        public TBLensCodeLRO()
            : base("DContextMain.LensCodeL")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //LensCodeLRO1
    public class TBLensCodeLRO1 : TextBoxErp
    {
        public TBLensCodeLRO1()
            : base("DContextMain.LensCodeL")
        {
            this.ReSetRO(); 
        }
    }
    //LensCode_ReplaceL
    public class TBLensCode_ReplaceLRO : TextBoxErp
    {
        public TBLensCode_ReplaceLRO()
            : base("DContextMain.LensCodeRL")
        {
            this.ReSetRO();
            this.SetVisible();
        }
    }
    //LensCodeSaleRO
    public class TBLensCodeSaleRO : TextBoxErp
    {
        public TBLensCodeSaleRO()
            : base("DContextMain.LensCodeSale")
        {
            this.ReSetRO();
        }
    }
    //LensCodeRSaleRO
    public class TBLensCodeRSaleRO : TextBoxErp
    {
        public TBLensCodeRSaleRO()
            : base("DContextMain.LensCodeRSale")
        {
            this.ReSetRO();
        }
    }
    //LensCodeLSaleRO
    public class TBLensCodeLSaleRO : TextBoxErp
    {
        public TBLensCodeLSaleRO()
            : base("DContextMain.LensCodeLSale")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region LensName

    //LensName
    public class TBLensName : TextBoxErp
    {
        public TBLensName()
            : base("DContextMain.LensName")
        {
            this.MaxLength = 50;
        }
    }
    //LensNameRO
    public class TBLensNameRO : TextBoxErp
    {
        public TBLensNameRO()
            : base("DContextMain.LensName")
        {
            this.ReSetRO();
        }
    }
    //LensNameList
    public class TBLensNameList : TextBoxErp
    {
        public TBLensNameList()
            : base("LensName")
        {
            this.MaxLength = 50;
        }
    }
    //LensNameROList
    public class TBLensNameROList : TextBoxErp
    {
        public TBLensNameROList()
            : base("LensName")
        {
            this.ReSetRO();
        }
    }
    //LensNameR
    public class TBLensNameRRO : TextBoxErp
    {
        public TBLensNameRRO()
            : base("DContextMain.LensNameR")
        {
            this.ReSetRO();
        }
    }
    //LensNameRSale
    public class TBLensNameRSaleRO : TextBoxErp
    {
        public TBLensNameRSaleRO()
            : base("DContextMain.LensNameRSale")
        {
            this.ReSetRO();
        }
    }
    //LensNameL
    public class TBLensNameLRO : TextBoxErp
    {
        public TBLensNameLRO()
            : base("DContextMain.LensNameL")
        {
            this.ReSetRO();
        }
    }
    //LensNameLSale
    public class TBLensNameLSaleRO : TextBoxErp
    {
        public TBLensNameLSaleRO()
            : base("DContextMain.LensNameLSale")
        {
            this.ReSetRO();
        }
    }
    //LensNameReplace
    public class TBLensNameReplaceRO : TextBoxErp
    {
        public TBLensNameReplaceRO()
            : base("DContextMain.LensNameRR")
        {
            this.ReSetRO();
        }
    }
    //LensNameReplaceR
    public class TBLensNameReplaceRRO : TextBoxErp
    {
        public TBLensNameReplaceRRO()
            : base("DContextMain.LensNameRR")
        {
            this.ReSetRO();
        }
    }
    //LensNameReplaceL
    public class TBLensNameReplaceLRO : TextBoxErp
    {
        public TBLensNameReplaceLRO()
            : base("DContextMain.LensNameRL")
        {
            this.ReSetRO();
        }
    }
    //LensNameSaleRO
    public class TBLensNameSaleRO : TextBoxErp
    {
        public TBLensNameSaleRO()
            : base("DContextMain.LensNameSale")
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region ExLens

    //Material
    public class TBMaterial : TextBoxErp
    {
        public TBMaterial()
            : base("DContextMain.Material")
        {
            this.MaxLength = 30;
        }
    }

    //Density
    public class TBDensity : TextBoxErp
    {
        public TBDensity()
            : base("DContextMain.Density")
        {
            this.MaxLength = 10;
        }
    }

    //Abbe
    public class TBAbbe : TextBoxErp
    {
        public TBAbbe()
            : base("DContextMain.Abbe")
        {
            this.MaxLength = 10;
        }
    }

    //UVCutOff
    public class TBUVCutOff : TextBoxErp
    {
        public TBUVCutOff()
            : base("DContextMain.UVCutOff")
        {
            this.MaxLength = 10;
        }
    }

    //PrismAvailability
    public class TBPrismAvailability : TextBoxErp
    {
        public TBPrismAvailability()
            : base("DContextMain.PrismAvailability")
        {
            this.MaxLength = 10;
        }
    }

    //Colour
    public class TBColour : TextBoxErp
    {
        public TBColour()
            : base("DContextMain.Colour")
        {
            this.MaxLength = 20;
        }
    }

    //Corridor
    public class TBCorridor : TextBoxErp
    {
        public TBCorridor()
            : base("DContextMain.Corridor")
        {
            this.MaxLength = 30;
        }
    }

    //Fitting
    public class TBFitting : TextBoxErp
    {
        public TBFitting()
            : base("DContextMain.Fitting")
        {
            this.MaxLength = 30;
        }
    }

    //Sort1
    public class TBSort1 : TextBoxErp
    {
        public TBSort1()
            : base("DContextMain.Sort1")
        {
            this.MaxLength = 50;
        }
    }

    //Sort2
    public class TBSort2 : TextBoxErp
    {
        public TBSort2()
            : base("DContextMain.Sort2")
        {
            this.MaxLength = 50;
        }
    }

    //Transmistion1
    public class TBTransmistion1 : TextBoxErp
    {
        public TBTransmistion1()
            : base("DContextMain.Transmistion1")
        {
            this.MaxLength = 100;
        }
    }

    //Transmistion2
    public class TBTransmistion2 : TextBoxErp
    {
        public TBTransmistion2()
            : base("DContextMain.Transmistion2")
        {
            this.MaxLength = 100;
        }
    }

    //Purpose
    public class TBPurpose : TextBoxErp
    {
        public TBPurpose()
            : base("DContextMain.Purpose")
        {
            this.MaxLength = 100;
        }
    }

    //Criterion1
    public class TBCriterion1 : TextBoxErp
    {
        public TBCriterion1()
            : base("DContextMain.Criterion1")
        {
            this.MaxLength = 200;
        }
    }

    //Criterion2
    public class TBCriterion2 : TextBoxErp
    {
        public TBCriterion2()
            : base("DContextMain.Criterion2")
        {
            this.MaxLength = 30;
        }
    }

    //    <ex:TBModelselect Grid.Column="1"/>
    //<TextBlock Text="{Binding UIText[ERP_Bagcode]}" Grid.Column="2"/>
    //<ex:TBBagcode Grid.Column="3"/>
    //<TextBlock Text="{Binding UIText[ERP_Guarantee]}" Grid.Column="4"/>
    //<ex:TBGuarantee Grid.Column="5"/>
    //Criterion2
    public class TBModelselect : TextBoxErp
    {
        public TBModelselect()
            : base("DContextMain.Modelselect")
        {
            this.MaxLength = 30;
        }
    }

    public class TBBagcode : TextBoxErp
    {
        public TBBagcode()
            : base("DContextMain.Bagcode")
        {
            this.MaxLength = 20;
        }
    }

    public class TBGuarantee : TextBoxErp
    {
        public TBGuarantee()
            : base("DContextMain.Guarantee")
        {
            this.MaxLength = 30;
        }
    }

    #endregion


}
