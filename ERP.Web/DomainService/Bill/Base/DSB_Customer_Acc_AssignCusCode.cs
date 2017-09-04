

namespace ERP.Web.DomainService.Bill
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using ERP.Web.DBUtility;
    using ERP.Web.Common;

    [EnableClientAccess()]
    public class DSB_Customer_Acc_AssignCusCode : DomainService
    {
        [Invoke]
        public void Update(string dbCode, int lgIndex, string accCusCode, List<string> codes, bool f_Add = false)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSqlCusCode = new StringBuilder();

            codes.ForEach(item =>
            {
                strSqlCusCode.Append("'" + item + "',");
            });

            strSqlCusCode.Remove(strSqlCusCode.Length - 1, 1);

            strSql.Append("update B_Customer set PCode=@AccCusCode ");
            strSql.Append("where CusCode in (" + strSqlCusCode + ") ;");

            SqlParameter[] parameters = {
                    new SqlParameter("@AccCusCode", SqlDbType.NVarChar,30)};
            parameters[0].Value = f_Add == true ? accCusCode : "";
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}