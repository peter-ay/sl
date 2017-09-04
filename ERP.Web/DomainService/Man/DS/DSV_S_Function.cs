
namespace ERP.Web.DomainService.Man
{
    using System.Linq;
    using ERP.Web.Entity;

    public partial class DSMan
    {
        //Function

        public IQueryable<V_S_Function> GetV_S_FunctionRightList(int gpID)
        {
            if (gpID == -99)
            {
                return this.ObjectContext.V_S_Function.Where(item => !item.FunID.StartsWith("99"));
            }
            else
            {
                return this.ObjectContext.V_S_Function.Where(item => !item.FunID.StartsWith("99")
                    && item.FunRight.Substring(gpID - 1, 1) == "1");
            }
        }

        public IQueryable<V_S_Function> GetV_S_FunctionTreeList()
        {
            return this.ObjectContext.V_S_Function.Where(item => !item.FunID.StartsWith("99")).OrderBy(it => it.FunID);
        }

        public IQueryable<V_S_Function> GetV_S_FunctionTreeManList()
        {
            return this.ObjectContext.V_S_Function.Where
                (item => item.FunID.StartsWith("99") && item.F_ShowInMenu == true).OrderBy(it => it.FunID);
        }

        public IQueryable<V_S_Function> GetV_S_FunctionTreeErpList(int gpID)
        {
            if (gpID == -99)
            {
                return this.ObjectContext.V_S_Function.Where
                    (item => !item.FunID.StartsWith("99") && item.F_ShowInMenu == true).OrderBy(it => it.FunID);
            }
            else
            {
                return this.ObjectContext.V_S_Function.Where
                    (item => !item.FunID.StartsWith("99") && item.F_ShowInMenu == true
                        && item.FunRight.Substring(gpID - 1, 1) == "1").OrderBy(it => it.FunID);
            }
        }
    }
}


