
namespace ERP.Web.DomainService.Bill
{
    using ERP.Web.BLL;
    using ERP.Web.Common;
    using ERP.Web.DBUtility;
    using ERP.Web.Model;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.Interface;
    using System.Collections.Generic;
    using System.Text;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSPur_PriceContract : DomainService
    {
        private BLLBase bll = new BPur_PriceContract();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MPur_PriceContract t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MPur_PriceContract t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void UpdateEdit(string dbCode, int lgIndex, MPur_PriceContract t)
        {
            bll.UpdateEdit(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void Check(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Check(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void UnCheck(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.UnCheck(dbCode, lgIndex, vCode, userCode, userName);
        }

        //UpdateSpCodes
        [Invoke]
        public void UpdateSpCodes(string dbCode, int lgIndex, string cusType, List<string> SpCodes, bool add)
        {
            StringBuilder strSql = new StringBuilder();

            SpCodes.ForEach(item =>
            {
                strSql.Append("delete  Pur_PriceContract_SpGroup_SpCode ");
                strSql.Append("where GpCode=@GpCode and SpCode ='" + item + "'; ");
                if (add)
                {
                    strSql.Append("insert into Pur_PriceContract_SpGroup_SpCode ");
                    strSql.Append("values(@GpCode,'" + item + "'); ");
                }
            });

            SqlParameter[] parameters = {
					new SqlParameter("@GpCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = cusType;

            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            dbsql.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}


