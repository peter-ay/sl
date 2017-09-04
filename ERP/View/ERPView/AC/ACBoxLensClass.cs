using ERP.Common;

namespace ERP.View
{
    public class ACBoxBrandCode : ACBoxErp
    {
        public ACBoxBrandCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.Brand")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Brand;
        }
    }

    public class ACBoxFocusCode : ACBoxErp
    {
        public ACBoxFocusCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.Focus")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Focus;
        }
    }

    public class ACBoxDesignCode : ACBoxErp
    {
        public ACBoxDesignCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.Design")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Design;
        }
    }

    public class ACBoxRIndexCode : ACBoxErp
    {
        public ACBoxRIndexCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.RIndex")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Index;
        }
    }

    public class ACBoxMaterialsCode : ACBoxErp
    {
        public ACBoxMaterialsCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.Materials")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Materials;
        }
    }

    public class ACBoxUsageCode : ACBoxErp
    {
        public ACBoxUsageCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.Usage")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_Usage;
        }
    }

    public class ACBoxDefaultCoatingCode : ACBoxErp
    {
        public ACBoxDefaultCoatingCode()
            : base("KeyCode", "ACDataTemplateLensClass", "DContextMain.DefaultCoating")
        {
            this.ItemsSource = ComHelpLensClass.UHV_B_Material_LensClass_DefaultCoating;
        }
    }
}
