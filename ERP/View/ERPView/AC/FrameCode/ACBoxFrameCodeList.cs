
namespace ERP.View
{
    public abstract class ACBoxFrameCodeList : ACBoxFrameCodeErp
    {
        public ACBoxFrameCodeList()
            : base("FrameCode")
        {
            this.ClearValue(ACBoxErp.VisibilityProperty);
        }
    }
}
