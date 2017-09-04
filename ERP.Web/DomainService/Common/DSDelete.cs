
namespace ERP.Web.DomainService.Common
{
    using ERP.Web.DBUtility;
    using ERP.Web.Model;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Text;
    using System.Reflection;
    using System;
    using ERP.Web.DAL;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class DSDelete : DomainService
    {
        [Invoke]
        public void Delete(string dbCode, int lgIndex, string tableName, List<string> codes, string bCode, string userCode, string userName)
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            var obj = assem.CreateInstance("ERP.Web.DomainService.Bill.DS" + tableName);
            if (obj != null)
            {
                var method = obj.GetType().GetMethod("Delete");
                if (method == null)
                {
                    throw new System.Exception(DALHelper.GetLanguageText("DSDelete_DeleteNone", lgIndex));
                }
                codes.ForEach(item =>
                    {
                        if (string.IsNullOrEmpty(bCode))
                        {
                            method.Invoke(obj, new object[] { dbCode, lgIndex, item, userCode, userName });
                        }
                        else
                        {
                            method.Invoke(obj, new object[] { dbCode, lgIndex, item, userCode, userName, bCode });
                        }
                    });
            }
            else
            {
                throw new System.Exception(DALHelper.GetLanguageText("DSDelete_DeleteNone", lgIndex));
            }
        }

        //old
        //[Invoke]
        //public void Delete(string tableName, string code, List<string> codes, string dbCode, string mainBillCode)
        //{
        //    switch (tableName)
        //    {
        //        case "M_User":
        //            tableName = "S_User";
        //            break;
        //        case "M_Group":
        //            tableName = "S_Group";
        //            break;
        //    }

        //    StringBuilder strSql = new StringBuilder();
        //    codes.ForEach(item =>
        //    {


        //        switch (tableName)
        //        {
        //            case "S_Group":
        //                strSql.Append("update S_User ");
        //                strSql.Append("set UserAuthority=ERP.dbo.SF_GetAuthorityValue(UserAuthority,(select GroupID from S_Group B where B.GroupCode='" + item + "' ),0);");
        //                strSql.Append("update S_Function ");
        //                strSql.Append("set FunAuthority=ERP.dbo.SF_GetAuthorityValue(FunAuthority,(select GroupID from S_Group B where B.GroupCode='" + item + "' ),0);");
        //                strSql.Append("delete S_Group");
        //                strSql.Append("where " + code + "='" + item + "' ;");
        //                break;

        //            //case "Sale_ContractBill_Sub_Process":
        //            //    strSql.Clear();
        //            //    strSql.Append("delete  " + tableName);
        //            //    strSql.Append(" where " + code + "='" + item + "' ");
        //            //    strSql.Append(" and ContractCode='" + mainBillCode + "' ;");
        //            //    break;

        //            default:
        //                strSql.Append("delete  " + tableName);
        //                strSql.Append(" where " + code + "='" + item + "' ;");
        //                break;
        //        }


        //    });

        //    //            if (tableName == "Base_ProcessControl")
        //    //            {
        //    //                strSql.Append(@";update Base_ProcessControl
        //    //                                    set SubID=
        //    //                                    (select  N_ID from 
        //    //	                                    (select  ROW_NUMBER() OVER (ORDER BY Mnumber)  as N_ID,SubID
        //    //		                                    from Base_ProcessControl s 
        //    //	                                    ) as a
        //    //	                                    where a.SubID=Base_ProcessControl.SubID
        //    //                                    ) ");
        //    //            }

        //    //            if (tableName == "Sale_ContractBill_Sub_Process")
        //    //            {
        //    //                strSql.Append(@";update Sale_ContractBill_Sub_Process
        //    //                                    set SubID=
        //    //                                    (select  N_ID from 
        //    //	                                    (select  ROW_NUMBER() OVER (ORDER BY Mnumber)  as N_ID,SubID
        //    //		                                    from Sale_ContractBill_Sub_Process s 
        //    //                                            where  s.ContractCode='" + mainBillCode + @"'
        //    //	                                    ) as a
        //    //	                                    where a.SubID=Sale_ContractBill_Sub_Process.SubID  
        //    //                                    ) 
        //    //                                    where Sale_ContractBill_Sub_Process.ContractCode='" + mainBillCode + @"'
        //    //                                                ");
        //    //            }


        //    DbHelperSQL dbsql = (string.IsNullOrEmpty(dbCode)) ? new DbHelperSQL() : new DbHelperSQL(dbCode);
        //    dbsql.ExecuteSql(strSql.ToString());
        //}

        //[Invoke]
        //public void DeleteSale_ContractBill_Sub_Mnumber(string billCode, List<MSale_ContractBill_Sub_Mnumber> models)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    SqlParameter[] parameters = null;
        //    DbHelperSQL dbsql = new DbHelperSQL();
        //    models.ForEach(item =>
        //        {
        //            strSql.Clear();
        //            strSql.Append("delete from Sale_ContractBill_Sub_Mnumber ");
        //            strSql.Append(" where ContractCode=@ContractCode and Mnumber=@Mnumber and SPH1=@SPH1 and SPH2=@SPH2 and CYL1=@CYL1 and CYL2=@CYL2 and ADD1=@ADD1 and ADD2=@ADD2 ;");
        //            parameters = new SqlParameter[]  {
        //            new SqlParameter("@ContractCode", SqlDbType.NVarChar,50),
        //            new SqlParameter("@Mnumber", SqlDbType.NVarChar,50),
        //            new SqlParameter("@SPH1", SqlDbType.Int,4),
        //            new SqlParameter("@SPH2", SqlDbType.Int,4),
        //            new SqlParameter("@CYL1", SqlDbType.Int,4),
        //            new SqlParameter("@CYL2", SqlDbType.Int,4),
        //            new SqlParameter("@ADD1", SqlDbType.Int,4),
        //            new SqlParameter("@ADD2", SqlDbType.Int,4)};
        //            parameters[0].Value = billCode;
        //            parameters[1].Value = item.Mnumber;
        //            parameters[2].Value = item.SPH1;
        //            parameters[3].Value = item.SPH2;
        //            parameters[4].Value = item.CYL1;
        //            parameters[5].Value = item.CYL2;
        //            parameters[6].Value = item.ADD1;
        //            parameters[7].Value = item.ADD2;
        //            try
        //            {
        //                dbsql.ExecuteSql(strSql.ToString(), parameters);
        //            }
        //            catch { }
        //        });
        //}

        //[Invoke]
        //public void DeleteSale_ContractBill_Sub_FrameSet(string billCode, List<MSale_ContractBill_Sub_FrameSet> models)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    SqlParameter[] parameters = null;
        //    DbHelperSQL dbsql = new DbHelperSQL();
        //    models.ForEach(item =>
        //    {
        //        strSql.Clear();
        //        strSql.Append("delete from Sale_ContractBill_Sub_FrameSet ");
        //        strSql.Append(" where ContractCode=@ContractCode and FrameCode=@FrameCode and FQuantity=@FQuantity and Mnumber=@Mnumber and MQuantity=@MQuantity ;");
        //        parameters = new SqlParameter[] {
        //            new SqlParameter("@ContractCode", SqlDbType.NVarChar,30),
        //            new SqlParameter("@FrameCode", SqlDbType.VarChar,30),
        //            new SqlParameter("@FQuantity", SqlDbType.Int,4),
        //            new SqlParameter("@Mnumber", SqlDbType.VarChar,30),
        //            new SqlParameter("@MQuantity", SqlDbType.Int,4)			};
        //        parameters[0].Value = billCode;
        //        parameters[1].Value = item.FrameCode;
        //        parameters[2].Value = item.FQuantity;
        //        parameters[3].Value = item.Mnumber;
        //        parameters[4].Value = item.MQuantity;
        //        try
        //        {
        //            dbsql.ExecuteSql(strSql.ToString(), parameters);
        //        }
        //        catch { }
        //    });
        //}

    }
}


