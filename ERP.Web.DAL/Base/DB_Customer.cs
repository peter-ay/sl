using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Customer : DALBase
    {
        public DB_Customer()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Customer with (nolock)");
            strSql.Append(" where CusCode=@CusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@CusCode", SqlDbType.NVarChar,50)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "CusCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select @BrowseRight;");
            /////////////////////////////////////////////////
            strSql.Append("insert into B_Customer(");
            strSql.Append("CusCode,CusName,PCode,CusAddress,AreaCode,DpCode,DpCodeCX,PersonCode,Fax,Email,ContactPerson,Tel,DAddress,BarCode,F_Stop,F_NoticeRepeatOBill,PrintShowPriceType,PrintCode,Remark,BrowseRight)");
            strSql.Append(" values (");
            strSql.Append("@CusCode,@CusName,@PCode,@CusAddress,@AreaCode,@DpCode,@DpCodeCX,@PersonCode,@Fax,@Email,@ContactPerson,@Tel,@DAddress,@BarCode,@F_Stop,@F_NoticeRepeatOBill,@PrintShowPriceType,@PrintCode,@Remark,@BrowseRight)");
            SqlParameter[] parameters = {
					new SqlParameter("@CusCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCodeCX", SqlDbType.VarChar,10),
					new SqlParameter("@PersonCode", SqlDbType.VarChar,10),
					new SqlParameter("@Fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@DAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@BarCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@F_NoticeRepeatOBill", SqlDbType.Bit,1),
					new SqlParameter("@PrintShowPriceType", SqlDbType.TinyInt,1),
					new SqlParameter("@PrintCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.CusCode;
            parameters[1].Value = model.CusName;
            parameters[2].Value = model.PCode;
            parameters[3].Value = model.CusAddress;
            parameters[4].Value = model.AreaCode;
            parameters[5].Value = model.DpCode;
            parameters[6].Value = model.DpCodeCX;
            parameters[7].Value = model.PersonCode;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.ContactPerson;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.DAddress;
            parameters[13].Value = model.BarCode;
            parameters[14].Value = model.F_Stop;
            parameters[15].Value = model.F_NoticeRepeatOBill;
            parameters[16].Value = model.PrintShowPriceType;
            parameters[17].Value = model.PrintCode;
            parameters[18].Value = model.Remark;
            parameters[19].Value = model.BrowseRight;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            var model = t as MB_Customer;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Customer set ");
            strSql.Append("CusName=@CusName,");
            strSql.Append("PCode=@PCode,");
            strSql.Append("CusAddress=@CusAddress,");
            strSql.Append("AreaCode=@AreaCode,");
            strSql.Append("DpCode=@DpCode,");
            strSql.Append("DpCodeCX=@DpCodeCX,");
            strSql.Append("PersonCode=@PersonCode,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Email=@Email,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("DAddress=@DAddress,");
            strSql.Append("BarCode=@BarCode,");
            strSql.Append("F_Stop=@F_Stop,");
            strSql.Append("F_NoticeRepeatOBill=@F_NoticeRepeatOBill,");
            strSql.Append("PrintShowPriceType=@PrintShowPriceType,");
            strSql.Append("PrintCode=@PrintCode,");
            strSql.Append("Remark=@Remark");
            //strSql.Append("BrowseRight=@BrowseRight");
            strSql.Append(" where CusCode=@CusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@CusName", SqlDbType.NVarChar,50),
					new SqlParameter("@PCode", SqlDbType.VarChar,10),
					new SqlParameter("@CusAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@AreaCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCode", SqlDbType.VarChar,10),
					new SqlParameter("@DpCodeCX", SqlDbType.VarChar,10),
					new SqlParameter("@PersonCode", SqlDbType.VarChar,10),
					new SqlParameter("@Fax", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,20),
					new SqlParameter("@Tel", SqlDbType.NVarChar,30),
					new SqlParameter("@DAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@BarCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@F_NoticeRepeatOBill", SqlDbType.Bit,1),
					new SqlParameter("@PrintShowPriceType", SqlDbType.TinyInt,1),
					new SqlParameter("@PrintCode", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
                    //new SqlParameter("@BrowseRight", SqlDbType.VarChar,1000),
					new SqlParameter("@CusCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.CusName;
            parameters[1].Value = model.PCode;
            parameters[2].Value = model.CusAddress;
            parameters[3].Value = model.AreaCode;
            parameters[4].Value = model.DpCode;
            parameters[5].Value = model.DpCodeCX;
            parameters[6].Value = model.PersonCode;
            parameters[7].Value = model.Fax;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.ContactPerson;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.DAddress;
            parameters[12].Value = model.BarCode;
            parameters[13].Value = model.F_Stop;
            parameters[14].Value = model.F_NoticeRepeatOBill;
            parameters[15].Value = model.PrintShowPriceType;
            parameters[16].Value = model.PrintCode;
            parameters[17].Value = model.Remark;
            //parameters[18].Value = model.BrowseRight;
            parameters[18].Value = model.CusCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
