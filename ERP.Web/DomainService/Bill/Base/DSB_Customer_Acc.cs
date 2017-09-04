
namespace ERP.Web.DomainService.Bill
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using ERP.Web.Interface;
    using System.Text;
    using System.Collections.Generic;
    using ERP.Web.DBUtility;
    using System.Data.SqlClient;
    using System.Data;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSB_Customer_Acc : DomainService
    {
        private BLLBase bll = new BB_Customer_Acc();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MB_Customer_Acc t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MB_Customer_Acc t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void AssignRightBrowse(string dbCode, int lgIndex, string gpCode, List<string> codes, bool f_ADD = false)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            try
            {
                codes.ForEach(item =>
                {
                    strSql.Clear();
                    strSql.Append("update B_Customer_Acc  ");
                    strSql.Append("set BrowseRight=HKOERP.dbo.SF_GetRightValue(isnull(BrowseRight,HKOERP.dbo.SF_GetRightDefaultValue()),(select GpID from HKOERP.dbo.S_UserGroup A1 with (nolock) where GpCode=@GpCode),@f_ADD)");
                    strSql.Append(" where CusCode=@CusCode ;");
                    parameters = new SqlParameter[] {
                    new SqlParameter("@GpCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@CusCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@f_ADD", SqlDbType.Bit)};
                    parameters[0].Value = gpCode;
                    parameters[1].Value = item;
                    parameters[2].Value = f_ADD;
                    dbsql.ExecuteSql(strSql.ToString(), parameters);
                });
            }
            catch
            {
                throw;
            }
        }
    }
}


