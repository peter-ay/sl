using System.Data;
using System.Data.SqlClient;
using System.Text;
using ERP.Web.Interface;
using ERP.Web.Model;

namespace ERP.Web.DAL
{
    public partial class DB_Material_Lens : DALBase
    {
        public DB_Material_Lens()
        { }

        public override bool Exists(string dbCode, int lgIndex, string vCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Material_Lens with (nolock)");
            strSql.Append(" where LensCode=@LensCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@LensCode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = vCode;
            DALUtility du = new DALUtility();
            return du.Exists(dbCode, strSql.ToString(), parameters);
        }

        protected override string PrepareKeyCode()
        {
            return "LensCode";
        }

        protected override void PrepareAddMain(int lgIndex, SqlCommand cmd, object t)
        {
            MB_Material_Lens model = t as MB_Material_Lens;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Material_Lens(");
            strSql.Append("LensCode,LensLevel,LensName,SPH1,SPH2,CYL1,CYL2,X_ADD1,X_ADD2,Focus,RIndex,Design,DefaultCoating,Usage,Materials,Material,Density,Abbe,RIndex_Measured,UVCutOff,PrismAvailability,Colour,Corridor,Fitting,LensType,F_HardCoat,F_Tintage,F_Coating,F_Decenter,F_Prism,F_Base,F_LR,F_CA,F_Pur,F_Stop,Sort1,Sort2,Transmistion1,Transmistion2,Purpose,Criterion1,Criterion2,ReformulatedPower,Ctvalue,Attachment1,PCode,Brand,Modelselect,Bagcode,Guarantee,F_StopSale,Image1,Image2,Image3,Df_SpCode)");
            strSql.Append(" values (");
            strSql.Append("@LensCode,@LensLevel,@LensName,@SPH1,@SPH2,@CYL1,@CYL2,@X_ADD1,@X_ADD2,@Focus,@RIndex,@Design,@DefaultCoating,@Usage,@Materials,@Material,@Density,@Abbe,@RIndex_Measured,@UVCutOff,@PrismAvailability,@Colour,@Corridor,@Fitting,@LensType,@F_HardCoat,@F_Tintage,@F_Coating,@F_Decenter,@F_Prism,@F_Base,@F_LR,@F_CA,@F_Pur,@F_Stop,@Sort1,@Sort2,@Transmistion1,@Transmistion2,@Purpose,@Criterion1,@Criterion2,@ReformulatedPower,@Ctvalue,@Attachment1,@PCode,@Brand,@Modelselect,@Bagcode,@Guarantee,@F_StopSale,@Image1,@Image2,@Image3,@Df_SpCode)");
            SqlParameter[] parameters = {
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
            parameters[0].Value = model.LensCode;
            parameters[1].Value = model.LensLevel;
            parameters[2].Value = model.LensName;
            parameters[3].Value = model.SPH1;
            parameters[4].Value = model.SPH2;
            parameters[5].Value = model.CYL1;
            parameters[6].Value = model.CYL2;
            parameters[7].Value = model.X_ADD1;
            parameters[8].Value = model.X_ADD2;
            parameters[9].Value = model.Focus;
            parameters[10].Value = model.RIndex;
            parameters[11].Value = model.Design;
            parameters[12].Value = model.DefaultCoating;
            parameters[13].Value = model.Usage;
            parameters[14].Value = model.Materials;
            parameters[15].Value = model.Material;
            parameters[16].Value = model.Density;
            parameters[17].Value = model.Abbe;
            parameters[18].Value = model.RIndex_Measured;
            parameters[19].Value = model.UVCutOff;
            parameters[20].Value = model.PrismAvailability;
            parameters[21].Value = model.Colour;
            parameters[22].Value = model.Corridor;
            parameters[23].Value = model.Fitting;
            parameters[24].Value = model.LensType;
            parameters[25].Value = model.F_HardCoat;
            parameters[26].Value = model.F_Tintage;
            parameters[27].Value = model.F_Coating;
            parameters[28].Value = model.F_Decenter;
            parameters[29].Value = model.F_Prism;
            parameters[30].Value = model.F_Base;
            parameters[31].Value = model.F_LR;
            parameters[32].Value = model.F_CA;
            parameters[33].Value = model.F_Pur;
            parameters[34].Value = model.F_Stop;
            parameters[35].Value = model.Sort1;
            parameters[36].Value = model.Sort2;
            parameters[37].Value = model.Transmistion1;
            parameters[38].Value = model.Transmistion2;
            parameters[39].Value = model.Purpose;
            parameters[40].Value = model.Criterion1;
            parameters[41].Value = model.Criterion2;
            parameters[42].Value = model.ReformulatedPower;
            parameters[43].Value = model.Ctvalue;
            parameters[44].Value = model.Attachment1;
            parameters[45].Value = model.PCode;
            parameters[46].Value = model.Brand;
            parameters[47].Value = model.Modelselect;
            parameters[48].Value = model.Bagcode;
            parameters[49].Value = model.Guarantee;
            parameters[50].Value = model.F_StopSale;
            parameters[51].Value = model.Image1;
            parameters[52].Value = model.Image2;
            parameters[53].Value = model.Image3;
            parameters[54].Value = model.Df_SpCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t)
        {
            MB_Material_Lens model = t as MB_Material_Lens;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Material_Lens set ");
            strSql.Append("LensLevel=@LensLevel,");
            strSql.Append("LensName=@LensName,");
            strSql.Append("SPH1=@SPH1,");
            strSql.Append("SPH2=@SPH2,");
            strSql.Append("CYL1=@CYL1,");
            strSql.Append("CYL2=@CYL2,");
            strSql.Append("X_ADD1=@X_ADD1,");
            strSql.Append("X_ADD2=@X_ADD2,");
            strSql.Append("Modelselect=@Modelselect,");
            strSql.Append("Bagcode=@Bagcode,");
            strSql.Append("Guarantee=@Guarantee,");
            strSql.Append("Materials=@Materials,");
            strSql.Append("RIndex=@RIndex,");
            strSql.Append("Design=@Design,");
            strSql.Append("Usage=@Usage,");
            strSql.Append("Focus=@Focus,");
            strSql.Append("Material=@Material,");
            strSql.Append("Density=@Density,");
            strSql.Append("Abbe=@Abbe,");
            strSql.Append("UVCutOff=@UVCutOff,");
            strSql.Append("PrismAvailability=@PrismAvailability,");
            strSql.Append("Colour=@Colour,");
            strSql.Append("Corridor=@Corridor,");
            strSql.Append("Fitting=@Fitting,");
            strSql.Append("LensType=@LensType,");
            strSql.Append("F_HardCoat=@F_HardCoat,");
            strSql.Append("F_Tintage=@F_Tintage,");
            strSql.Append("F_Coating=@F_Coating,");
            strSql.Append("F_Decenter=@F_Decenter,");
            strSql.Append("F_Prism=@F_Prism,");
            strSql.Append("F_Base=@F_Base,");
            strSql.Append("F_LR=@F_LR,");
            strSql.Append("F_CA=@F_CA,");
            strSql.Append("F_Pur=@F_Pur,");
            strSql.Append("F_Stop=@F_Stop,");
            strSql.Append("Sort1=@Sort1,");
            strSql.Append("Sort2=@Sort2,");
            strSql.Append("Transmistion1=@Transmistion1,");
            strSql.Append("Transmistion2=@Transmistion2,");
            strSql.Append("Purpose=@Purpose,");
            strSql.Append("Criterion1=@Criterion1,");
            strSql.Append("Criterion2=@Criterion2,");
            strSql.Append("PCode=@PCode,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("ReformulatedPower=@ReformulatedPower,");
            strSql.Append("Ctvalue=@Ctvalue,");
            strSql.Append("Df_SpCode=@Df_SpCode,");
            strSql.Append("F_StopSale=@F_StopSale");
            strSql.Append(" where LensCode=@LensCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@LensLevel", SqlDbType.TinyInt,1),
					new SqlParameter("@LensName", SqlDbType.NVarChar,100),
					new SqlParameter("@SPH1", SqlDbType.Int,4),
					new SqlParameter("@SPH2", SqlDbType.Int,4),
					new SqlParameter("@CYL1", SqlDbType.Int,4),
					new SqlParameter("@CYL2", SqlDbType.Int,4),
					new SqlParameter("@X_ADD1", SqlDbType.Int,4),
					new SqlParameter("@X_ADD2", SqlDbType.Int,4),
					new SqlParameter("@Modelselect", SqlDbType.VarChar,30),
					new SqlParameter("@Bagcode", SqlDbType.VarChar,20),
					new SqlParameter("@Guarantee", SqlDbType.VarChar,30),
					new SqlParameter("@Materials", SqlDbType.VarChar,10),
					new SqlParameter("@RIndex", SqlDbType.VarChar,10),
					new SqlParameter("@Design", SqlDbType.VarChar,10),
					new SqlParameter("@Usage", SqlDbType.VarChar,10),
					new SqlParameter("@Focus", SqlDbType.VarChar,10),
					new SqlParameter("@Material", SqlDbType.VarChar,30),
					new SqlParameter("@Density", SqlDbType.VarChar,10),
					new SqlParameter("@Abbe", SqlDbType.Decimal,9),
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
					new SqlParameter("@PCode", SqlDbType.VarChar,50),
					new SqlParameter("@Brand", SqlDbType.VarChar,10),
					new SqlParameter("@ReformulatedPower", SqlDbType.Bit,1),
					new SqlParameter("@Ctvalue", SqlDbType.Bit,1),
                    new SqlParameter("@Df_SpCode", SqlDbType.VarChar,20),
					new SqlParameter("@F_StopSale", SqlDbType.Bit,1),
					new SqlParameter("@LensCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.LensLevel;
            parameters[1].Value = model.LensName;
            parameters[2].Value = model.SPH1;
            parameters[3].Value = model.SPH2;
            parameters[4].Value = model.CYL1;
            parameters[5].Value = model.CYL2;
            parameters[6].Value = model.X_ADD1;
            parameters[7].Value = model.X_ADD2;
            parameters[8].Value = model.Modelselect;
            parameters[9].Value = model.Bagcode;
            parameters[10].Value = model.Guarantee;
            parameters[11].Value = model.Materials;
            parameters[12].Value = model.RIndex;
            parameters[13].Value = model.Design;
            parameters[14].Value = model.Usage;
            parameters[15].Value = model.Focus;
            parameters[16].Value = model.Material;
            parameters[17].Value = model.Density;
            parameters[18].Value = model.Abbe;
            parameters[19].Value = model.UVCutOff;
            parameters[20].Value = model.PrismAvailability;
            parameters[21].Value = model.Colour;
            parameters[22].Value = model.Corridor;
            parameters[23].Value = model.Fitting;
            parameters[24].Value = model.LensType;
            parameters[25].Value = model.F_HardCoat;
            parameters[26].Value = model.F_Tintage;
            parameters[27].Value = model.F_Coating;
            parameters[28].Value = model.F_Decenter;
            parameters[29].Value = model.F_Prism;
            parameters[30].Value = model.F_Base;
            parameters[31].Value = model.F_LR;
            parameters[32].Value = model.F_CA;
            parameters[33].Value = model.F_Pur;
            parameters[34].Value = model.F_Stop;
            parameters[35].Value = model.Sort1;
            parameters[36].Value = model.Sort2;
            parameters[37].Value = model.Transmistion1;
            parameters[38].Value = model.Transmistion2;
            parameters[39].Value = model.Purpose;
            parameters[40].Value = model.Criterion1;
            parameters[41].Value = model.Criterion2;
            parameters[42].Value = model.PCode;
            parameters[43].Value = model.Brand;
            parameters[44].Value = model.ReformulatedPower;
            parameters[45].Value = model.Ctvalue;
            parameters[46].Value = model.Df_SpCode;
            parameters[47].Value = model.F_StopSale;
            parameters[48].Value = model.LensCode;
            cmd.ExecuteMyQuery(strSql.ToString(), parameters);
        }

        protected override void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t)
        {

        }
    }
}
