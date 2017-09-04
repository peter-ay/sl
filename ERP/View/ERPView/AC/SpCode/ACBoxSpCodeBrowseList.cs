
namespace ERP.View
{
    public class ACBoxSpCodeBrowseList : ACBoxSpCodeBrowseErp
    {
        public ACBoxSpCodeBrowseList()
            : base("SpCode")
        {
            this.ClearValue(ACBoxErp.VisibilityProperty);
        }
    }
}
