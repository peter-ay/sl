
namespace ERP.Web.Interface
{
    public interface IDALCheck
    {
        void Check(string dbCode, int lgIndex, string vCode, string userCode, string userName);
        void UnCheck(string dbCode, int lgIndex, string vCode, string userCode, string userName);
    }
}
