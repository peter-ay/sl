
namespace ERP.Web.DomainService.Man
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERP.Web.Entity;


    // Implements application logic using the Entities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class DSMan : LinqToEntitiesDomainService<Entities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_DataBase' query.
        public IQueryable<V_S_DataBase> GetV_S_DataBase()
        {
            return this.ObjectContext.V_S_DataBase;
        }

        public void InsertV_S_DataBase(V_S_DataBase v_S_DataBase)
        {
            if ((v_S_DataBase.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_DataBase, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_DataBase.AddObject(v_S_DataBase);
            }
        }

        public void UpdateV_S_DataBase(V_S_DataBase currentV_S_DataBase)
        {
            this.ObjectContext.V_S_DataBase.AttachAsModified(currentV_S_DataBase, this.ChangeSet.GetOriginal(currentV_S_DataBase));
        }

        public void DeleteV_S_DataBase(V_S_DataBase v_S_DataBase)
        {
            if ((v_S_DataBase.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_DataBase, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_DataBase.Attach(v_S_DataBase);
                this.ObjectContext.V_S_DataBase.DeleteObject(v_S_DataBase);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_Function' query.
        public IQueryable<V_S_Function> GetV_S_Function()
        {
            return this.ObjectContext.V_S_Function;
        }

        public void InsertV_S_Function(V_S_Function v_S_Function)
        {
            if ((v_S_Function.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_Function, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_Function.AddObject(v_S_Function);
            }
        }

        public void UpdateV_S_Function(V_S_Function currentV_S_Function)
        {
            this.ObjectContext.V_S_Function.AttachAsModified(currentV_S_Function, this.ChangeSet.GetOriginal(currentV_S_Function));
        }

        public void DeleteV_S_Function(V_S_Function v_S_Function)
        {
            if ((v_S_Function.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_Function, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_Function.Attach(v_S_Function);
                this.ObjectContext.V_S_Function.DeleteObject(v_S_Function);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_Log' query.
        public IQueryable<V_S_Log> GetV_S_Log()
        {
            return this.ObjectContext.V_S_Log;
        }

        public void InsertV_S_Log(V_S_Log v_S_Log)
        {
            if ((v_S_Log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_Log, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_Log.AddObject(v_S_Log);
            }
        }

        public void UpdateV_S_Log(V_S_Log currentV_S_Log)
        {
            this.ObjectContext.V_S_Log.AttachAsModified(currentV_S_Log, this.ChangeSet.GetOriginal(currentV_S_Log));
        }

        public void DeleteV_S_Log(V_S_Log v_S_Log)
        {
            if ((v_S_Log.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_Log, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_Log.Attach(v_S_Log);
                this.ObjectContext.V_S_Log.DeleteObject(v_S_Log);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_User' query.
        public IQueryable<V_S_User> GetV_S_User()
        {
            return this.ObjectContext.V_S_User;
        }

        public void InsertV_S_User(V_S_User v_S_User)
        {
            if ((v_S_User.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_User, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_User.AddObject(v_S_User);
            }
        }

        public void UpdateV_S_User(V_S_User currentV_S_User)
        {
            this.ObjectContext.V_S_User.AttachAsModified(currentV_S_User, this.ChangeSet.GetOriginal(currentV_S_User));
        }

        public void DeleteV_S_User(V_S_User v_S_User)
        {
            if ((v_S_User.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_User, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_User.Attach(v_S_User);
                this.ObjectContext.V_S_User.DeleteObject(v_S_User);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_User_GroupDataBase' query.
        public IQueryable<V_S_User_GroupDataBase> GetV_S_User_GroupDataBase()
        {
            return this.ObjectContext.V_S_User_GroupDataBase;
        }

        public void InsertV_S_User_GroupDataBase(V_S_User_GroupDataBase v_S_User_GroupDataBase)
        {
            if ((v_S_User_GroupDataBase.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_User_GroupDataBase, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_User_GroupDataBase.AddObject(v_S_User_GroupDataBase);
            }
        }

        public void UpdateV_S_User_GroupDataBase(V_S_User_GroupDataBase currentV_S_User_GroupDataBase)
        {
            this.ObjectContext.V_S_User_GroupDataBase.AttachAsModified(currentV_S_User_GroupDataBase, this.ChangeSet.GetOriginal(currentV_S_User_GroupDataBase));
        }

        public void DeleteV_S_User_GroupDataBase(V_S_User_GroupDataBase v_S_User_GroupDataBase)
        {
            if ((v_S_User_GroupDataBase.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_User_GroupDataBase, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_User_GroupDataBase.Attach(v_S_User_GroupDataBase);
                this.ObjectContext.V_S_User_GroupDataBase.DeleteObject(v_S_User_GroupDataBase);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_S_UserGroup' query.
        public IQueryable<V_S_UserGroup> GetV_S_UserGroup()
        {
            return this.ObjectContext.V_S_UserGroup;
        }

        public void InsertV_S_UserGroup(V_S_UserGroup v_S_UserGroup)
        {
            if ((v_S_UserGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_UserGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_S_UserGroup.AddObject(v_S_UserGroup);
            }
        }

        public void UpdateV_S_UserGroup(V_S_UserGroup currentV_S_UserGroup)
        {
            this.ObjectContext.V_S_UserGroup.AttachAsModified(currentV_S_UserGroup, this.ChangeSet.GetOriginal(currentV_S_UserGroup));
        }

        public void DeleteV_S_UserGroup(V_S_UserGroup v_S_UserGroup)
        {
            if ((v_S_UserGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_S_UserGroup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_S_UserGroup.Attach(v_S_UserGroup);
                this.ObjectContext.V_S_UserGroup.DeleteObject(v_S_UserGroup);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_U_ProcessClass' query.
        public IQueryable<V_U_ProcessClass> GetV_U_ProcessClass()
        {
            return this.ObjectContext.V_U_ProcessClass;
        }

        public void InsertV_U_ProcessClass(V_U_ProcessClass v_U_ProcessClass)
        {
            if ((v_U_ProcessClass.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_U_ProcessClass, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_U_ProcessClass.AddObject(v_U_ProcessClass);
            }
        }

        public void UpdateV_U_ProcessClass(V_U_ProcessClass currentV_U_ProcessClass)
        {
            this.ObjectContext.V_U_ProcessClass.AttachAsModified(currentV_U_ProcessClass, this.ChangeSet.GetOriginal(currentV_U_ProcessClass));
        }

        public void DeleteV_U_ProcessClass(V_U_ProcessClass v_U_ProcessClass)
        {
            if ((v_U_ProcessClass.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_U_ProcessClass, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_U_ProcessClass.Attach(v_U_ProcessClass);
                this.ObjectContext.V_U_ProcessClass.DeleteObject(v_U_ProcessClass);
            }
        }
    }
}


