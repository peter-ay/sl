
namespace ERP.View
{
    public abstract class ACBoxLensCodeList : ACBoxLensCodeErp
    {
        public ACBoxLensCodeList()
            : base("LensCode")
        {
            this.ClearValue(ACBoxErp.VisibilityProperty);
        }
    }
}
