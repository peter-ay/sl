
namespace ERP.Web.DomainService.Common
{
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.DBUtility;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSGetDefaultSpCode : DomainService
    {
        [Invoke]
        public string Get(string dbCode, int lgIndex, string cusCode, string lensCode, string proCode)
        {
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                new SqlParameter("@LgIndex", SqlDbType.Int),
                new SqlParameter("@CusCode", SqlDbType.NVarChar,30),
                new SqlParameter("@LensCode", SqlDbType.NVarChar,50),
                new SqlParameter("@ProCode", SqlDbType.NVarChar,1000),
                new SqlParameter("@SpCode", SqlDbType.NVarChar,30)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = cusCode;
            parameters[2].Value = lensCode;
            parameters[3].Value = proCode;
            parameters[4].Value = "";
            parameters[4].Direction = ParameterDirection.Output;

            DbHelperSQL dbh = new DbHelperSQL(dbCode);

            return dbh.RunProcedureForReturnGenerics<string>("SP_Sale_Order_GetDefaultSpCode", parameters);
        }
    }
}


