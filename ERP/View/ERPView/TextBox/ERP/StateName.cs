
namespace ERP.View
{
    //StateName
    public class TBStateName : TextBoxErp
    {
        public TBStateName()
            : base("DContextMain.StName")
        {
            this.MaxLength = 30;
        }
    }
    //StateNameRO
    public class TBStateNameRO : TextBoxErp
    {
        public TBStateNameRO()
            : base("DContextMain.StName")
        {
            this.ReSetRO();
        }
    }
    //StateNameUI
    public class TBStateNameUI : TextBoxErp
    {
        public TBStateNameUI()
            : base("DContextMain.StNameUI")
        {
            this.ReSetRO();
        }
    }
    //KFSOStateNameUI
    public class TBKFSOStateNameUI : TextBoxErp
    {
        public TBKFSOStateNameUI()
            : base("DContextMain.SOFKStNameUI")
        {
            this.ReSetRO();
        }
    }
    //CGDDStateNameUI
    public class TBCGDDStateNameUI : TextBoxErp
    {
        public TBCGDDStateNameUI()
            : base("DContextMain.CGDDStNameUI")
        {
            this.ReSetRO();
        }
    }
}
