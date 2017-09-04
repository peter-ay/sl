
namespace ERP.Web.Entity
{
    public partial class EntitiesErp
    {
        partial void OnContextCreated()
        {
            this.CommandTimeout = 300;
        }
    }
}