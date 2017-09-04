
namespace ERP.Web.DomainService.Common
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Web;
    using ERP.Web.DAL;


    [EnableClientAccess()]
    public class DSImport : DomainService
    {
        [Invoke]
        public string Import(string dbCode, int lgIndex, string id, string user, string tableName, string fileName, string extension, byte[] receipt, bool firstBlock, bool lastBlock)
        {
            //var _FileFullName = HttpContext.Current.Server.MapPath("~/Import/" + user + "[" + fileName + "]" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + extension);

            //var _FileName = dbCode + user + DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length == 2 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString()) + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + fileName;
            var _FileName = dbCode + user + id + fileName;
            var _FileFullName = HttpContext.Current.Server.MapPath("~/Import/" + _FileName);

            string _TempExt = "_tmp";
            try
            {
                if (firstBlock)
                {
                    if (extension == ".xlsx") throw new Exception(DALHelper.GetLanguageText("DSImport_xlsx", lgIndex));
                    File.WriteAllBytes(_FileFullName + _TempExt, receipt);
                    return "";
                }
                if (lastBlock)
                {
                    if (File.Exists(_FileFullName))
                        File.Delete(_FileFullName);

                    File.Move(_FileFullName + _TempExt, _FileFullName);
                    return _FileName;
                }
                using (FileStream fs = File.Open(_FileFullName + _TempExt, FileMode.Append))
                {
                    fs.Write(receipt, 0, receipt.Length);
                    fs.Close();
                }
            }
            catch { throw; }
            return "";
        }

        [Invoke]
        public int ImportCompleted(string dbCode, int lgIndex, string fileName, string tableName, string mainBillCode = "")
        {
            fileName = HttpContext.Current.Server.MapPath("~/Import/" + fileName);
            int rs = ImportFromXls(dbCode, lgIndex, tableName, fileName, mainBillCode);
            //fileName = HttpContext.Current.Server.MapPath("~/Import/" + user + "[" + fileName + "]" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + extension);
            //File.WriteAllBytes(fileName, receipt);
            //switch (extension)
            //{
            //    case ".xls":
            //        rs = ImportFromXls(dbCode, lgIndex, tableName, fileName, mainBillCode);
            //        break;

            //    case ".xlsx":
            //        throw new Exception(DALHelper.GetLanguageText("DSImport_xlsx", lgIndex));

            //}
            return rs;
        }

        [Ignore]
        private int ImportFromXls(string dbCode, int lgIndex, string tableName, string fileName, string BID = "")
        {
            int result = 0;
            try
            {
                Assembly assem = Assembly.GetExecutingAssembly();
                var obj = assem.CreateInstance("ERP.Web.DomainService.Common.Import" + tableName);
                if (obj != null)
                {
                    var method = obj.GetType().GetMethod("Import");

                    int rs = 0;
                    if (string.IsNullOrEmpty(BID))
                    {
                        rs = (int)method.Invoke(obj, new object[] { dbCode, lgIndex, fileName });
                    }
                    else
                    {
                        rs = (int)method.Invoke(obj, new object[] { dbCode, lgIndex, fileName, BID });
                    }

                    result = rs;
                }
                else
                {
                    throw new Exception(DALHelper.GetLanguageText("DSImport_NoMethod", lgIndex));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


