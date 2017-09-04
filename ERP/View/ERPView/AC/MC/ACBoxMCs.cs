using ERP.Common;
using System.Windows.Data;
using System.Windows.Controls;

namespace ERP.View
{
    public class ACBoxMCErp : ACBoxErp
    {
        public ACBoxMCErp(string bindDContextName)
            : base("", "", bindDContextName)
        {
  
        } 
    }

    public class ACBoxMC1 : ACBoxMCErp
    {
        public ACBoxMC1()
            : base("DContextMain.D1")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxMC3 : ACBoxMCErp
    {
        public ACBoxMC3()
            : base("DContextMain.D3")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1 : ACBoxMCErp
    {
        public ACBoxP1()
            : base("DContextMain.P1")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3 : ACBoxMCErp
    {
        public ACBoxP3()
            : base("DContextMain.P3")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    ////////////////////////////////////////////////////////////////////////////////


    public class ACBoxMC1L : ACBoxMCErp
    {
        public ACBoxMC1L()
            : base("DContextMain.D1L")
        {
            this.ItemsSource = ComMoveCenterSoure.Source1;
        }
    }

    public class ACBoxMC3L : ACBoxMCErp
    {
        public ACBoxMC3L()
            : base("DContextMain.D3L")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1L : ACBoxMCErp
    {
        public ACBoxP1L()
            : base("DContextMain.P1L")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3L : ACBoxMCErp
    {
        public ACBoxP3L()
            : base("DContextMain.P3L")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxMC1R : ACBoxMCErp
    {
        public ACBoxMC1R()
            : base("DContextMain.D1R")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxMC3R : ACBoxMCErp
    {
        public ACBoxMC3R()
            : base("DContextMain.D3R")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1R : ACBoxMCErp
    {
        public ACBoxP1R()
            : base("DContextMain.P1R")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3R : ACBoxMCErp
    {
        public ACBoxP3R()
            : base("DContextMain.P3R")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }
}
