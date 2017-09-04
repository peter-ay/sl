using System.Collections.Generic;
using System.Data.SqlClient;
using ERP.Web.DBUtility;
using System.Collections;
using System.Text;
using System.Data;
using ERP.Web.Interface;
namespace ERP.Web.DAL
{
    public abstract class DALBase : IDAL, IDALCheck, IDALUpdateEdit
    {

        #region Exists

        public abstract bool Exists(string dbCode, int lgIndex, string vCode);

        #endregion

        #region Add

        public string Add<T>(string dbCode, int lgIndex, T t, bool f_SaveVerify = true)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            var _KeyCode = this.PrepareKeyCode();
            string _KeyValue = "";
            using (SqlConnection conn = new SqlConnection(dbsql.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = 200;
                    try
                    {
                        //var _ID = this.PrepareID(cmd);
                        var _ID = this.PrepareID();
                        try { t.GetType().GetProperty("ID").SetValue(t, _ID, null); }
                        catch { }
                        var _BType = "";
                        try { _BType = t.GetType().GetProperty("BType").GetValue(t, null).ToString(); }
                        catch { _BType = ""; }
                        var modelName = t.GetType().Name;
                        var modelNameSpace = modelName.Substring(0, modelName.IndexOf('_')).Substring(1);
                        //CD
                        if (_BType != "XSCD")
                        {
                            if (t.GetType().GetProperty("BCode") != null)
                            {
                                //
                                var _BCode = this.PrepareBCode(cmd, lgIndex, modelNameSpace, _BType);
                                try { t.GetType().GetProperty("BCode").SetValue(t, _BCode, null); }
                                catch { }
                            }
                        }
                        this.PrepareAddMain(lgIndex, cmd, t);
                        this.PrepareAddSub(lgIndex, cmd, t);
                        _KeyValue = t.GetType().GetProperty(_KeyCode).GetValue(t, null).ToString();
                        if (f_SaveVerify)
                        {
                            this.PrepareSaveVerify(lgIndex, cmd, _KeyValue);
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return _KeyValue;
        }

        private void PrepareSaveVerify(int lgIndex, SqlCommand cmd, string keyCode)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            string _SPSaveVerify = this.PrepareSaveVerifySPName();
            strSql.Append(_SPSaveVerify);
            parameters = new SqlParameter[] {
					new SqlParameter("@LgIndex", SqlDbType.Int),
                    new SqlParameter("@PKCode", SqlDbType.VarChar,50)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = keyCode;
            cmd.ExecuteMySPQuery(strSql.ToString(), parameters);
        }

        protected virtual string PrepareSaveVerifySPName()
        {
            return "SP_" + this.GetType().Name.Substring(1) + "_SaveVerify";
        }

        protected virtual string PrepareKeyCode()
        {
            return "ID";
        }

        protected virtual void PrepareAddSub(int lgIndex, SqlCommand cmd, object t)
        {

        }

        protected abstract void PrepareAddMain(int lgIndex, SqlCommand cmd, object t);

        private string PrepareBCode(SqlCommand cmd, int lgIndex, string modelNameSpace, string typeCode)
        {
            var spName = this.PrepareBCodeSPName(modelNameSpace);
            if (string.IsNullOrEmpty(typeCode))
                typeCode = this.PrepareBillTypeCode();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(spName);
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@LgIndex", SqlDbType.Int),
					new SqlParameter("@TypeCode", SqlDbType.VarChar,10),
					new SqlParameter("@BCode", SqlDbType.VarChar,30)};
            parameters[0].Value = lgIndex;
            parameters[1].Value = typeCode;
            parameters[2].Value = "";
            parameters[2].Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql.ToString();
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
            return cmd.Parameters[2].Value.ToString().Trim();
        }

        protected virtual string PrepareBillTypeCode()
        {
            return "";
        }

        protected virtual string PrepareBCodeSPName(string modelNameSpace)
        {
            return "SP_" + modelNameSpace + "_GenerateBCode";
        }

        private string PrepareID(SqlCommand cmd)
        {
            string cmdText = "select HKOERP.dbo.SF_GetID()";
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteScalar().ToString();
        }

        private string PrepareID()
        {
            return Common.ComID.GetInstance().ID25;
        }

        #endregion

        #region Update

        public void Update<T>(string dbCode, int lgIndex, T t, bool f_SaveVerify = true)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            var _KeyCode = this.PrepareKeyCode();
            string _KeyValue = t.GetType().GetProperty(_KeyCode).GetValue(t, null).ToString();
            using (SqlConnection conn = new SqlConnection(dbsql.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = 200;
                    try
                    {
                        this.PrepareUpdateMain(lgIndex, cmd, t);
                        this.PrepareUpdateSub(lgIndex, cmd, t);
                        if (f_SaveVerify)
                            this.PrepareSaveVerify(lgIndex, cmd, _KeyValue);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        protected virtual void PrepareUpdateSub(int lgIndex, SqlCommand cmd, object t)
        {

        }

        protected abstract void PrepareUpdateMain(int lgIndex, SqlCommand cmd, object t);

        #endregion

        #region UpdateEdit

        public void UpdateEdit<T>(string dbCode, int lgIndex, T t)
        {
            DbHelperSQL dbsql = new DbHelperSQL(dbCode);
            using (SqlConnection conn = new SqlConnection(dbsql.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = 200;
                    try
                    {
                        this.PrepareUpdateEditMain(lgIndex, cmd, t);
                        this.PrepareUpdateEditSub(lgIndex, cmd, t);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        protected virtual void PrepareUpdateEditSub(int lgIndex, SqlCommand cmd, object t)
        {

        }

        protected abstract void PrepareUpdateEditMain(int lgIndex, SqlCommand cmd, object t);

        #endregion

        #region Check

        public void Check(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            string _SPCheck = this.PrepareSPCheck();
            DALUtility du = new DALUtility(dbCode, lgIndex, _SPCheck, vCode, userCode, userName);
            du.Check();
        }

        protected virtual string PrepareSPCheck()
        {
            return "SP_" + this.GetType().Name.Substring(1) + "_Check1";
        }

        #endregion

        #region UnCheck

        public void UnCheck(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            string _SPUnCheck = this.PrepareSPUnCheck();
            DALUtility du = new DALUtility(dbCode, lgIndex, _SPUnCheck, vCode, userCode, userName);
            du.UnCheck();
        }

        protected virtual string PrepareSPUnCheck()
        {
            return "SP_" + this.GetType().Name.Substring(1) + "_Check2";
        }

        #endregion

        #region Delete

        public void Delete(string dbCode, int lgIndex, string vCode, string userCode, string userName)
        {
            string _SPDel = this.PrepareSPDel();
            DALUtility du = new DALUtility(dbCode, lgIndex, _SPDel, vCode, userCode, userName);
            du.Delete();
        }

        protected virtual string PrepareSPDel()
        {
            return "SP_" + this.GetType().Name.Substring(1) + "_Delete";
        }

        #endregion

    }
}
