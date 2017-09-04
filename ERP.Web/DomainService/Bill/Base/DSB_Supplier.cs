
namespace ERP.Web.DomainService.Bill
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using ERP.Web.Interface;
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using ERP.Web.DBUtility;
    using System.Data;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSB_Supplier : DomainService
    {
        private BLLBase bll = new BB_Supplier();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MB_Supplier t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MB_Supplier t)
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
                    strSql.Append("update B_Supplier  ");
                    strSql.Append("set BrowseRight=HKOERP.dbo.SF_GetRightValue(isnull(BrowseRight,HKOERP.dbo.SF_GetRightDefaultValue()),(select GpID from HKOERP.dbo.S_UserGroup A1 with (nolock) where GpCode=@GpCode),@f_ADD)");
                    strSql.Append(" where SpCode=@SpCode ;");
                    parameters = new SqlParameter[] {
                    new SqlParameter("@GpCode", SqlDbType.NVarChar,30),
                    new SqlParameter("@SpCode", SqlDbType.NVarChar,30),
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

        //UpdateCusCodes
        [Invoke]
        public void UpdateCusCodes(string dbCode, int lgIndex, string spCode, List<string> cusCodes, bool add)
        {
            StringBuilder strSql = new StringBuilder();

            cusCodes.ForEach(item =>
            {
                strSql.Append("delete  B_Supplier_Default_CusCode ");
                strSql.Append("where SpCode=@SpCode and CusCode ='" + item + "'; ");
                if (add)
                {
                    strSql.Append("insert into B_Supplier_Default_CusCode ");
                    strSql.Append("values(@SpCode,'" + item + "'); ");
                }
            });

            SqlParameter[] parameters = {
					new SqlParameter("@SpCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = spCode;

            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }

        //UpdateLens
        [Invoke]
        public void UpdateLensCodes(string dbCode, int lgIndex, string spCode, List<string> lensCode, bool add)
        {
            StringBuilder strSql = new StringBuilder();

            lensCode.ForEach(item =>
            {
                strSql.Append("delete  B_Supplier_Default_Lens ");
                strSql.Append("where SpCode=@SpCode and LensCode ='" + item + "'; ");
                if (add)
                {
                    strSql.Append("insert into B_Supplier_Default_Lens ");
                    strSql.Append("values(@SpCode,'" + item + "'); ");
                }
            });

            SqlParameter[] parameters = {
					new SqlParameter("@SpCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = spCode;

            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
        //UpdateProCode
        [Invoke]
        public void UpdateProCodes(string dbCode, int lgIndex, string spCode, List<string> ProCode, bool add)
        {
            StringBuilder strSql = new StringBuilder();

            ProCode.ForEach(item =>
            {
                strSql.Append("delete  B_Supplier_Default_ProCode ");
                strSql.Append("where SpCode=@SpCode and ProCode ='" + item + "'; ");
                if (add)
                {
                    strSql.Append("insert into B_Supplier_Default_ProCode ");
                    strSql.Append("values(@SpCode,'" + item + "'); ");
                }
            });

            SqlParameter[] parameters = {
					new SqlParameter("@SpCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = spCode;

            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }



    }
}


