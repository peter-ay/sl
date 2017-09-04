
namespace ERP.Web.DomainService.Erp
{
    using System.Linq;
    using ERP.Web.Entity;
    using System;

    public partial class DSErp
    {
        public IQueryable<V_B_Department> GetV_B_DepartmentBill(string dbCode, string dpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Department> _Rs = this.ObjectContext.V_B_Department;

            if (dpCode == "") return _Rs;
            return _Rs.Where(item => item.DpCode == dpCode);
        }

        public IQueryable<V_B_Department> GetV_B_DepartmentAllList(string dbCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            return this.ObjectContext.V_B_Department;
        }

        public IQueryable<V_B_Department> GetV_B_DepartmentRightBrowseList(string dbCode, int gpID)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Department> _Rs = this.ObjectContext.V_B_Department;

            if (gpID != -99)
            {
                _Rs = _Rs.Where(item => item.BrowseRight.Substring(gpID - 1, 1) == "1");
            }
            return _Rs;
        }

        public IQueryable<V_B_Department_Browse> GetV_B_DepartmentRightBrowseGpCode(string dbCode, string gpCode)
        {
            this.ObjectContext.ChangeDataBase(dbCode);
            IQueryable<V_B_Department_Browse> _Rs = this.ObjectContext.V_B_Department_Browse.Where(it => it.GpCode == gpCode);
            return _Rs;
        }

        public IQueryable<V_B_Department> GetV_B_DepartmentList(string dbCode, string sWhere)
        {
            this.ObjectContext.ChangeDataBase(dbCode);

            IQueryable<V_B_Department> _Rs = this.ObjectContext.V_B_Department;
            var _SArray = sWhere.GetSptstr();
            string _Str = "";

            _Str = _SArray.GetSptstrValue("DpCode");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.DpCode.Contains(it)); });
            }

            _Str = _SArray.GetSptstrValue("DpName");
            if (!string.IsNullOrEmpty(_Str))
            {
                _Str.Split('%').ToList().ForEach(it => { _Rs = _Rs.Where(item => item.DpName.Contains(it)); });
            }
            return _Rs;
        }
    }
}