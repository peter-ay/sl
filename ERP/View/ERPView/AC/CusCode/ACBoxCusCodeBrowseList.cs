
namespace ERP.View
{
    public class ACBoxCusCodeBrowseList : ACBoxCusCodeBrowseErp
    {
        public ACBoxCusCodeBrowseList()
            : base("CusCode")
        {
            this.ClearValue(ACBoxErp.VisibilityProperty);
        }
    }
}
