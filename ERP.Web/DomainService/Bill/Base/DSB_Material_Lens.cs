
namespace ERP.Web.DomainService.Bill
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.BLL;
    using ERP.Web.Model;
    using ERP.Web.Interface;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    using ERP.Web.DAL;
    using ERP.Web.Common;
    using System.Web;
    using System.IO;
    using System.Collections;
    using ERP.Web.DBUtility;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public partial class DSB_Material_Lens : DomainService
    {
        private BLLBase bll = new BB_Material_Lens();

        [Invoke]
        public string Add(string dbCode, int lgIndex, MB_Material_Lens t)
        {
            return bll.Add(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Update(string dbCode, int lgIndex, MB_Material_Lens t)
        {
            bll.Update(dbCode, lgIndex, t);
        }

        [Invoke]
        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            bll.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        [Invoke]
        public void UploadAttachment(string dbCode, int lgIndex, string fileName, byte[] receipt, string lensCode, bool firstBlock, bool lastBlock)
        {
            var _FileFullName = HttpContext.Current.Server.MapPath("~/Import/Attachment/Base/Lens/" + dbCode + lensCode + "Attachment1.pdf");
            string _TempExt = "_tmp";
            try
            {
                if (firstBlock)
                {
                    File.WriteAllBytes(_FileFullName + _TempExt, receipt);
                    return;
                }
                if (lastBlock)
                {
                    if (File.Exists(_FileFullName))
                        File.Delete(_FileFullName);

                    File.Move(_FileFullName + _TempExt, _FileFullName);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update B_Material_Lens set ");
                    strSql.Append("Attachment1=@Attachment1");
                    strSql.Append(" where LensCode=@LensCode ");
                    SqlParameter[] parameters = {
                    new SqlParameter("@Attachment1", SqlDbType.NVarChar,100), 
                    new SqlParameter("@LensCode", SqlDbType.VarChar,50)};
                    parameters[0].Value = fileName;
                    parameters[1].Value = lensCode;

                    Hashtable ht = new Hashtable();
                    ht.Add(strSql, parameters);
                    DbHelperSQL dbsql = new DbHelperSQL(dbCode);
                    dbsql.ExecuteSqlTran(ht);
                    return;
                }
                using (FileStream fs = File.Open(_FileFullName + _TempExt, FileMode.Append))
                {
                    fs.Write(receipt, 0, receipt.Length);
                    fs.Close();
                }

            }
            catch { throw; }
        }

        [Invoke]
        public void UploadImage(string dbCode, int lgIndex, string fileName, byte[] receipt, string lensCode, int imageID, bool firstBlock, bool lastBlock)
        {
            var _FileFullName = HttpContext.Current.Server.MapPath("~/Import/Images/Base/Lens/" + dbCode + lensCode + "Image" + imageID.ToString() + ".jpg");
            string _TempExt = "_tmp";
            try
            {
                if (firstBlock)
                {
                    File.WriteAllBytes(_FileFullName + _TempExt, receipt);
                    return;
                }
                if (lastBlock)
                {
                    if (File.Exists(_FileFullName))
                        File.Delete(_FileFullName);

                    File.Move(_FileFullName + _TempExt, _FileFullName);
                    return;
                }
                using (FileStream fs = File.Open(_FileFullName + _TempExt, FileMode.Append))
                {
                    fs.Write(receipt, 0, receipt.Length);
                    fs.Close();
                }
            }
            catch { throw; }
        }
    }
}


