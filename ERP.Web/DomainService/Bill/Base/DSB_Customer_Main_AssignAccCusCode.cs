

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
    public class DSB_Customer_Main_AssignAccCusCode : DomainService
    {
        [Invoke]
        public void Update(string dbCode, int lgIndex, string mainCusCode, List<string> codes, bool f_Add = false)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSqlAccCusCode = new StringBuilder();

            codes.ForEach(item =>
            {
                strSqlAccCusCode.Append("'" + item + "',");
            });

            strSqlAccCusCode.Remove(strSqlAccCusCode.Length - 1, 1);

            strSql.Append("update B_Customer_Acc set PCode=@MainCusCode ");
            strSql.Append("where AccCusCode in (" + strSqlAccCusCode + ") ;");

            SqlParameter[] parameters = {
                    new SqlParameter("@MainCusCode", SqlDbType.NVarChar,30)};
            parameters[0].Value = f_Add == true ? mainCusCode : "";
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}