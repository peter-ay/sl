
namespace ERP.Web.Entity
{
    public partial class Entities
    {
        partial void OnContextCreated()
        {
            this.CommandTimeout = 300;
        }
    }
}