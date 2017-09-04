using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;

namespace ERP.Web.Entity
{
    public static class EntitiesErpChangeDataBase
    {
        public static void ChangeDataBase(this ObjectContext obj, string dbcode)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(((EntityConnection)obj.Connection).StoreConnection.ConnectionString);
            sb.IntegratedSecurity = false;
            sb.InitialCatalog = dbcode;
            ((EntityConnection)obj.Connection).StoreConnection.ConnectionString = sb.ConnectionString;
        }
    }
}