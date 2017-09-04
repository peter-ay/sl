
namespace ERP.Web.Interface
{
    public interface IDALUpdateEdit
    {
        void UpdateEdit<T>(string dbCode, int lgIndex, T t);
    }
}
