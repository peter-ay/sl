
namespace ERP.View
{
    public abstract class ACBoxProcessErp : ACBoxErp
    {
        public ACBoxProcessErp(string bindDContextName)
            : base("ProCode", "ACDataTemplateProcess", bindDContextName)
        {
        }
    }
}
