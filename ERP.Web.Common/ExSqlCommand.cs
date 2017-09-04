
namespace System.Data.SqlClient
{
    using System.Data;
    using System.Text;

    public static class ExSqlCommand
    {
        public static int ExecuteMyQuery(this SqlCommand cmd, string strSql, SqlParameter[] parameters)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteMySPQuery(this SqlCommand cmd, string strSql, SqlParameter[] parameters)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
    }
}
