using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.DBUtility;

namespace ERP.Web.DomainService.Common
{
    public class ImportB_Material_Lens2 : ImportBase
    {
        protected override void PrepareImport(SqlCommand cmd, DataSet ds)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            //
            strSql.Clear();
            strSql.Append("select top 0 * into #B_Material_Lens2 from B_Material_Lens where LensLevel=2;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
            //
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strSql.Clear();
                strSql.Append("Delete #B_Material_Lens2 where LensCode=@LensCode;");
                //
                strSql.Append("insert into #B_Material_Lens2(");
                strSql.Append("LensCode,LensLevel,LensName,SPH1,SPH2,CYL1,CYL2,X_ADD1,X_ADD2,Focus,RIndex,Design,DefaultCoating,Usage,Materials,Material,Density,Abbe,RIndex_Measured,UVCutOff,PrismAvailability,Colour,Corridor,Fitting,LensType,F_HardCoat,F_Tintage,F_Coating,F_Decenter,F_Prism,F_Base,F_LR,F_CA,F_Pur,F_Stop,Sort1,Sort2,Transmistion1,Transmistion2,Purpose,Criterion1,Criterion2,ReformulatedPower,Ctvalue,Attachment1,PCode,Brand,Modelselect,Bagcode,Guarantee,F_StopSale,Image1,Image2,Image3,Df_SpCode)");
                strSql.Append(" values (");
                strSql.Append("@LensCode,@LensLevel,@LensName,@SPH1,@SPH2,@CYL1,@CYL2,@X_ADD1,@X_ADD2,@Focus,@RIndex,@Design,@DefaultCoating,@Usage,@Materials,@Material,@Density,@Abbe,@RIndex_Measured,@UVCutOff,@PrismAvailability,@Colour,@Corridor,@Fitting,@LensType,@F_HardCoat,@F_Tintage,@F_Coating,@F_Decenter,@F_Prism,@F_Base,@F_LR,@F_CA,@F_Pur,@F_Stop,@Sort1,@Sort2,@Transmistion1,@Transmistion2,@Purpose,@Criterion1,@Criterion2,@ReformulatedPower,@Ctvalue,@Attachment1,@PCode,@Brand,@Modelselect,@Bagcode,@Guarantee,@F_StopSale,@Image1,@Image2,@Image3,@Df_SpCode)");
                parameters = new SqlParameter[]  {
					new SqlParameter("@LensCode", SqlDbType.VarChar,50),
					new SqlParameter("@LensLevel", SqlDbType.TinyInt,1),
					new SqlParameter("@LensName", SqlDbType.NVarChar,100),
					new SqlParameter("@SPH1", SqlDbType.Int,4),
					new SqlParameter("@SPH2", SqlDbType.Int,4),
					new SqlParameter("@CYL1", SqlDbType.Int,4),
					new SqlParameter("@CYL2", SqlDbType.Int,4),
					new SqlParameter("@X_ADD1", SqlDbType.Int,4),
					new SqlParameter("@X_ADD2", SqlDbType.Int,4),
					new SqlParameter("@Focus", SqlDbType.VarChar,10),
					new SqlParameter("@RIndex", SqlDbType.VarChar,10),
					new SqlParameter("@Design", SqlDbType.VarChar,10),
					new SqlParameter("@DefaultCoating", SqlDbType.VarChar,10),
					new SqlParameter("@Usage", SqlDbType.VarChar,10),
					new SqlParameter("@Materials", SqlDbType.VarChar,10),
					new SqlParameter("@Material", SqlDbType.VarChar,30),
					new SqlParameter("@Density", SqlDbType.VarChar,10),
					new SqlParameter("@Abbe", SqlDbType.Decimal,9),
					new SqlParameter("@RIndex_Measured", SqlDbType.VarChar,10),
					new SqlParameter("@UVCutOff", SqlDbType.Int,4),
					new SqlParameter("@PrismAvailability", SqlDbType.VarChar,20),
					new SqlParameter("@Colour", SqlDbType.VarChar,10),
					new SqlParameter("@Corridor", SqlDbType.VarChar,50),
					new SqlParameter("@Fitting", SqlDbType.VarChar,50),
					new SqlParameter("@LensType", SqlDbType.VarChar,10),
					new SqlParameter("@F_HardCoat", SqlDbType.Bit,1),
					new SqlParameter("@F_Tintage", SqlDbType.Bit,1),
					new SqlParameter("@F_Coating", SqlDbType.Bit,1),
					new SqlParameter("@F_Decenter", SqlDbType.Bit,1),
					new SqlParameter("@F_Prism", SqlDbType.Bit,1),
					new SqlParameter("@F_Base", SqlDbType.Bit,1),
					new SqlParameter("@F_LR", SqlDbType.Bit,1),
					new SqlParameter("@F_CA", SqlDbType.Bit,1),
					new SqlParameter("@F_Pur", SqlDbType.Bit,1),
					new SqlParameter("@F_Stop", SqlDbType.Bit,1),
					new SqlParameter("@Sort1", SqlDbType.VarChar,50),
					new SqlParameter("@Sort2", SqlDbType.VarChar,50),
					new SqlParameter("@Transmistion1", SqlDbType.VarChar,30),
					new SqlParameter("@Transmistion2", SqlDbType.VarChar,30),
					new SqlParameter("@Purpose", SqlDbType.VarChar,50),
					new SqlParameter("@Criterion1", SqlDbType.VarChar,200),
					new SqlParameter("@Criterion2", SqlDbType.VarChar,200),
					new SqlParameter("@ReformulatedPower", SqlDbType.Bit,1),
					new SqlParameter("@Ctvalue", SqlDbType.Bit,1),
					new SqlParameter("@Attachment1", SqlDbType.VarChar,100),
					new SqlParameter("@PCode", SqlDbType.VarChar,50),
					new SqlParameter("@Brand", SqlDbType.VarChar,10),
					new SqlParameter("@Modelselect", SqlDbType.VarChar,30),
					new SqlParameter("@Bagcode", SqlDbType.VarChar,20),
					new SqlParameter("@Guarantee", SqlDbType.VarChar,30),
					new SqlParameter("@F_StopSale", SqlDbType.Bit,1),
					new SqlParameter("@Image1", SqlDbType.VarChar,50),
					new SqlParameter("@Image2", SqlDbType.VarChar,50),
					new SqlParameter("@Image3", SqlDbType.VarChar,50),
					new SqlParameter("@Df_SpCode", SqlDbType.VarChar,20)};
                parameters[0].Value = dr["LensCode"].ToString().Trim();
                parameters[1].Value = dr["LensLevel"].ToString().Trim();
                parameters[2].Value = dr["LensName"].ToString().Trim();
                parameters[3].Value = dr["SPH1"].ToString().Trim();
                parameters[4].Value = dr["SPH2"].ToString().Trim();
                parameters[5].Value = dr["CYL1"].ToString().Trim();
                parameters[6].Value = dr["CYL2"].ToString().Trim();
                parameters[7].Value = dr["X_ADD1"].ToString().Trim();
                parameters[8].Value = dr["X_ADD2"].ToString().Trim();
                parameters[9].Value = dr["Focus"].ToString().Trim();
                parameters[10].Value = dr["RIndex"].ToString().Trim();
                parameters[11].Value = dr["Design"].ToString().Trim();
                parameters[12].Value = dr["DefaultCoating"].ToString().Trim();
                parameters[13].Value = dr["Usage"].ToString().Trim();
                parameters[14].Value = dr["Materials"].ToString().Trim();
                parameters[15].Value = dr["Material"].ToString().Trim();
                parameters[16].Value = dr["Density"].ToString().Trim();
                parameters[17].Value = dr["Abbe"].ToString().Trim();
                parameters[18].Value = dr["RIndex_Measured"].ToString().Trim();
                parameters[19].Value = dr["UVCutOff"].ToString().Trim();
                parameters[20].Value = dr["PrismAvailability"].ToString().Trim();
                parameters[21].Value = dr["Colour"].ToString().Trim();
                parameters[22].Value = dr["Corridor"].ToString().Trim();
                parameters[23].Value = dr["Fitting"].ToString().Trim();
                parameters[24].Value = dr["LensType"].ToString().Trim();
                parameters[25].Value = dr["F_HardCoat"].ToString().Trim().GetBoolStr();
                parameters[26].Value = dr["F_Tintage"].ToString().Trim().GetBoolStr();
                parameters[27].Value = dr["F_Coating"].ToString().Trim().GetBoolStr();
                parameters[28].Value = dr["F_Decenter"].ToString().Trim().GetBoolStr();
                parameters[29].Value = dr["F_Prism"].ToString().Trim().GetBoolStr();
                parameters[30].Value = dr["F_Base"].ToString().Trim().GetBoolStr();
                parameters[31].Value = dr["F_LR"].ToString().Trim().GetBoolStr();
                parameters[32].Value = dr["F_CA"].ToString().Trim().GetBoolStr();
                parameters[33].Value = dr["F_Pur"].ToString().Trim().GetBoolStr();
                parameters[34].Value = dr["F_Stop"].ToString().Trim().GetBoolStr();
                parameters[35].Value = dr["Sort1"].ToString().Trim();
                parameters[36].Value = dr["Sort2"].ToString().Trim();
                parameters[37].Value = dr["Transmistion1"].ToString().Trim();
                parameters[38].Value = dr["Transmistion2"].ToString().Trim();
                parameters[39].Value = dr["Purpose"].ToString().Trim();
                parameters[40].Value = dr["Criterion1"].ToString().Trim();
                parameters[41].Value = dr["Criterion2"].ToString().Trim();
                parameters[42].Value = dr["ReformulatedPower"].ToString().Trim().GetBoolStr();
                parameters[43].Value = dr["Ctvalue"].ToString().Trim().GetBoolStr();
                parameters[44].Value = dr["Attachment1"].ToString().Trim();
                parameters[45].Value = dr["PCode"].ToString().Trim();
                parameters[46].Value = dr["Brand"].ToString().Trim();
                parameters[47].Value = dr["Modelselect"].ToString().Trim();
                parameters[48].Value = dr["Bagcode"].ToString().Trim();
                parameters[49].Value = dr["Guarantee"].ToString().Trim();
                parameters[50].Value = dr["F_StopSale"].ToString().Trim().GetBoolStr();
                parameters[51].Value = dr["Image1"].ToString().Trim();
                parameters[52].Value = dr["Image2"].ToString().Trim();
                parameters[53].Value = dr["Image3"].ToString().Trim();
                parameters[54].Value = dr["Df_SpCode"].ToString().Trim();
                cmd.ExecuteMyQuery(strSql.ToString(), parameters);
            }
            //
            strSql.Clear();
            strSql.Append("delete B_Material_Lens where LensLevel=2;");
            strSql.Append("insert into B_Material_Lens select * from #B_Material_Lens2;");
            cmd.CommandText = strSql.ToString();
            cmd.ExecuteNonQuery();
        }
    }
}