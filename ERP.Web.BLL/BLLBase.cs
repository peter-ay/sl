using ERP.Web.DAL;
using ERP.Web.Interface;

namespace ERP.Web.BLL
{
    public abstract class BLLBase : IDAL, IDALCheck, IDALUpdateEdit
    {
        protected DALBase dal;

        private string vCode;

        private BLLBase()
        {
        }

        protected BLLBase(DALBase dal)
            : this()
        {
            this.dal = dal;
        }

        public bool Exists(string dbCode, int lgIndex, string vCode)
        {
            if (string.IsNullOrEmpty(vCode))
                return false;
            return dal.Exists(dbCode, lgIndex, vCode);
        }

        public string Add<T>(string dbCode, int lgIndex, T t, bool f_SaveVerify = true)
        {
            this.VerifyExists(dbCode, lgIndex, t);
            return dal.Add<T>(dbCode, lgIndex, t, f_SaveVerify);
        }

        private void VerifyExists<T>(string dbCode, int lgIndex, T t, bool f_Update = false)
        {
            vCode = this.GetPKCodeValue(t);
            var _exists = this.Exists(dbCode, lgIndex, vCode);
            if (!f_Update)
            {
                if (_exists)
                {
                    throw new System.Exception(DALHelper.GetLanguageText("DALVerify_Exists", lgIndex) + vCode);
                }
            }
            else
            {
                if (!_exists)
                {
                    throw new System.Exception(DALHelper.GetLanguageText("DALVerify_ExistsUpdate", lgIndex) + vCode);
                }
            }
        }

        private void VerifyExistsByID(string dbCode, int lgIndex, string id, bool f_Update = false)
        {
            vCode = id;
            var _exists = this.Exists(dbCode, lgIndex, vCode);
            if (!f_Update)
            {
                if (_exists)
                {
                    throw new System.Exception(DALHelper.GetLanguageText("DALVerify_Exists", lgIndex) + vCode);
                }
            }
            else
            {
                if (!_exists)
                {
                    throw new System.Exception(DALHelper.GetLanguageText("DALVerify_ExistsUpdate", lgIndex) + vCode);
                }
            }
        }

        protected virtual string GetPKCodeValue<T>(T t)
        {
            return t.GetType().GetProperty("ID").GetValue(t, null).ToString();
        }

        public void Update<T>(string dbCode, int lgIndex, T t, bool f_SaveVerify = true)
        {
            this.VerifyExists(dbCode, lgIndex, t, true);
            dal.Update<T>(dbCode, lgIndex, t, f_SaveVerify);
        }

        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            dal.Delete(dbCode, lgIndex, vCode, userCode, userName);
        }

        public void Check(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            this.VerifyExistsByID(dbCode, lgIndex, vCode, true);
            dal.Check(dbCode, lgIndex, vCode, userCode, userName);
        }

        public void UnCheck(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            this.VerifyExistsByID(dbCode, lgIndex, vCode, true);
            dal.UnCheck(dbCode, lgIndex, vCode, userCode, userName);
        }

        public void UpdateEdit<T>(string dbCode, int lgIndex, T t)
        {
            this.VerifyExists(dbCode, lgIndex, t, true);
            dal.UpdateEdit(dbCode, lgIndex, t);
        }
    }
}
