using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.Web.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace ERP.Web.Common
{
    public class ComGernerateDN
    {
        public static void Gernerate(string dbCode, int lgIndex, List<string> codes)
        {
            string totleBillcode = "";
            string totleBillcodeForGenerate = "";
            foreach (var bill in codes)
            {
                totleBillcode += "'" + bill.Trim() + "',";
                totleBillcodeForGenerate += bill.Trim() + ",";
            }
            totleBillcode = totleBillcode.Substring(0, totleBillcode.Length - 1);
            totleBillcodeForGenerate = totleBillcodeForGenerate.Substring(0, totleBillcodeForGenerate.Length - 1);

            DbHelperSQL dbh = new DbHelperSQL(dbCode);
            string spName = "SP_Sale_Order_ExportToFactory";
            SqlParameter[] parameters = null;
            parameters = new SqlParameter[] {
                    new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@BCodes", SqlDbType.NVarChar,4000)
					};
            parameters[0].Value = lgIndex;
            parameters[1].Value = totleBillcode;
            dbh.RunProcedureTran(spName, parameters);
        }
    }
}