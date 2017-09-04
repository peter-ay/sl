
namespace ERP.Web.Interface
{
    public interface IDAL
    {
        bool Exists(string dbCode, int lgIndex, string vCode);
        string Add<T>(string dbCode, int lgIndex, T t,bool f_SaveVerify=true);
        void Update<T>(string dbCode, int lgIndex, T t, bool f_SaveVerify=true);
        void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName);
    }
}
