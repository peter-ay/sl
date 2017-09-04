using ERP.Common;

namespace ERP.View
{
    public class ACBoxMC1 : ACBoxErp
    {
        public ACBoxMC1()
            : base("", "", "DContextMain.D1")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxMC3 : ACBoxErp
    {
        public ACBoxMC3()
            : base("", "", "DContextMain.D3")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1 : ACBoxErp
    {
        public ACBoxP1()
            : base("", "", "DContextMain.P1")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3 : ACBoxErp
    {
        public ACBoxP3()
            : base("", "", "DContextMain.P3")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    ////////////////////////////////////////////////////////////////////////////////


    public class ACBoxMC1L : ACBoxErp
    {
        public ACBoxMC1L()
            : base("", "", "DContextMain.D1L")
        {
            this.ItemsSource = ComMoveCenterSoure.Source1;
        }
    }

    public class ACBoxMC3L : ACBoxErp
    {
        public ACBoxMC3L()
            : base("", "", "DContextMain.D3L")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1L : ACBoxErp
    {
        public ACBoxP1L()
            : base("", "", "DContextMain.P1L")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3L : ACBoxErp
    {
        public ACBoxP3L()
            : base("", "", "DContextMain.P3L")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxMC1R : ACBoxErp
    {
        public ACBoxMC1R()
            : base("", "", "DContextMain.D1R")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxMC3R : ACBoxErp
    {
        public ACBoxMC3R()
            : base("", "", "DContextMain.D3R")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }

    public class ACBoxP1R : ACBoxErp
    {
        public ACBoxP1R()
            : base("", "", "DContextMain.P1R")
        { this.ItemsSource = ComMoveCenterSoure.Source1; }
    }

    public class ACBoxP3R : ACBoxErp
    {
        public ACBoxP3R()
            : base("", "", "DContextMain.P3R")
        { this.ItemsSource = ComMoveCenterSoure.Source2; }
    }
}
