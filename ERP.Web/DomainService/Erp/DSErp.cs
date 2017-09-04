
namespace ERP.Web.DomainService.Erp
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


    // Implements application logic using the EntitiesErp context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class DSErp : LinqToEntitiesDomainService<EntitiesErp>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Area' query.
        public IQueryable<V_B_Area> GetV_B_Area()
        {
            return this.ObjectContext.V_B_Area;
        }

        public void InsertV_B_Area(V_B_Area v_B_Area)
        {
            if ((v_B_Area.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Area, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Area.AddObject(v_B_Area);
            }
        }

        public void UpdateV_B_Area(V_B_Area currentV_B_Area)
        {
            this.ObjectContext.V_B_Area.AttachAsModified(currentV_B_Area, this.ChangeSet.GetOriginal(currentV_B_Area));
        }

        public void DeleteV_B_Area(V_B_Area v_B_Area)
        {
            if ((v_B_Area.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Area, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Area.Attach(v_B_Area);
                this.ObjectContext.V_B_Area.DeleteObject(v_B_Area);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Customer' query.
        public IQueryable<V_B_Customer> GetV_B_Customer()
        {
            return this.ObjectContext.V_B_Customer;
        }

        public void InsertV_B_Customer(V_B_Customer v_B_Customer)
        {
            if ((v_B_Customer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Customer.AddObject(v_B_Customer);
            }
        }

        public void UpdateV_B_Customer(V_B_Customer currentV_B_Customer)
        {
            this.ObjectContext.V_B_Customer.AttachAsModified(currentV_B_Customer, this.ChangeSet.GetOriginal(currentV_B_Customer));
        }

        public void DeleteV_B_Customer(V_B_Customer v_B_Customer)
        {
            if ((v_B_Customer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Customer.Attach(v_B_Customer);
                this.ObjectContext.V_B_Customer.DeleteObject(v_B_Customer);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Customer_Acc' query.
        public IQueryable<V_B_Customer_Acc> GetV_B_Customer_Acc()
        {
            return this.ObjectContext.V_B_Customer_Acc;
        }

        public void InsertV_B_Customer_Acc(V_B_Customer_Acc v_B_Customer_Acc)
        {
            if ((v_B_Customer_Acc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Acc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Acc.AddObject(v_B_Customer_Acc);
            }
        }

        public void UpdateV_B_Customer_Acc(V_B_Customer_Acc currentV_B_Customer_Acc)
        {
            this.ObjectContext.V_B_Customer_Acc.AttachAsModified(currentV_B_Customer_Acc, this.ChangeSet.GetOriginal(currentV_B_Customer_Acc));
        }

        public void DeleteV_B_Customer_Acc(V_B_Customer_Acc v_B_Customer_Acc)
        {
            if ((v_B_Customer_Acc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Acc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Acc.Attach(v_B_Customer_Acc);
                this.ObjectContext.V_B_Customer_Acc.DeleteObject(v_B_Customer_Acc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Customer_Browse' query.
        public IQueryable<V_B_Customer_Browse> GetV_B_Customer_Browse()
        {
            return this.ObjectContext.V_B_Customer_Browse;
        }

        public void InsertV_B_Customer_Browse(V_B_Customer_Browse v_B_Customer_Browse)
        {
            if ((v_B_Customer_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Browse, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Browse.AddObject(v_B_Customer_Browse);
            }
        }

        public void UpdateV_B_Customer_Browse(V_B_Customer_Browse currentV_B_Customer_Browse)
        {
            this.ObjectContext.V_B_Customer_Browse.AttachAsModified(currentV_B_Customer_Browse, this.ChangeSet.GetOriginal(currentV_B_Customer_Browse));
        }

        public void DeleteV_B_Customer_Browse(V_B_Customer_Browse v_B_Customer_Browse)
        {
            if ((v_B_Customer_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Browse, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Browse.Attach(v_B_Customer_Browse);
                this.ObjectContext.V_B_Customer_Browse.DeleteObject(v_B_Customer_Browse);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Customer_Main' query.
        public IQueryable<V_B_Customer_Main> GetV_B_Customer_Main()
        {
            return this.ObjectContext.V_B_Customer_Main;
        }

        public void InsertV_B_Customer_Main(V_B_Customer_Main v_B_Customer_Main)
        {
            if ((v_B_Customer_Main.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Main, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Main.AddObject(v_B_Customer_Main);
            }
        }

        public void UpdateV_B_Customer_Main(V_B_Customer_Main currentV_B_Customer_Main)
        {
            this.ObjectContext.V_B_Customer_Main.AttachAsModified(currentV_B_Customer_Main, this.ChangeSet.GetOriginal(currentV_B_Customer_Main));
        }

        public void DeleteV_B_Customer_Main(V_B_Customer_Main v_B_Customer_Main)
        {
            if ((v_B_Customer_Main.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Customer_Main, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Customer_Main.Attach(v_B_Customer_Main);
                this.ObjectContext.V_B_Customer_Main.DeleteObject(v_B_Customer_Main);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Department' query.
        public IQueryable<V_B_Department> GetV_B_Department()
        {
            return this.ObjectContext.V_B_Department;
        }

        public void InsertV_B_Department(V_B_Department v_B_Department)
        {
            if ((v_B_Department.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Department, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Department.AddObject(v_B_Department);
            }
        }

        public void UpdateV_B_Department(V_B_Department currentV_B_Department)
        {
            this.ObjectContext.V_B_Department.AttachAsModified(currentV_B_Department, this.ChangeSet.GetOriginal(currentV_B_Department));
        }

        public void DeleteV_B_Department(V_B_Department v_B_Department)
        {
            if ((v_B_Department.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Department, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Department.Attach(v_B_Department);
                this.ObjectContext.V_B_Department.DeleteObject(v_B_Department);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Department_Browse' query.
        public IQueryable<V_B_Department_Browse> GetV_B_Department_Browse()
        {
            return this.ObjectContext.V_B_Department_Browse;
        }

        public void InsertV_B_Department_Browse(V_B_Department_Browse v_B_Department_Browse)
        {
            if ((v_B_Department_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Department_Browse, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Department_Browse.AddObject(v_B_Department_Browse);
            }
        }

        public void UpdateV_B_Department_Browse(V_B_Department_Browse currentV_B_Department_Browse)
        {
            this.ObjectContext.V_B_Department_Browse.AttachAsModified(currentV_B_Department_Browse, this.ChangeSet.GetOriginal(currentV_B_Department_Browse));
        }

        public void DeleteV_B_Department_Browse(V_B_Department_Browse v_B_Department_Browse)
        {
            if ((v_B_Department_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Department_Browse, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Department_Browse.Attach(v_B_Department_Browse);
                this.ObjectContext.V_B_Department_Browse.DeleteObject(v_B_Department_Browse);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_Frame' query.
        public IQueryable<V_B_Material_Frame> GetV_B_Material_Frame()
        {
            return this.ObjectContext.V_B_Material_Frame;
        }

        public void InsertV_B_Material_Frame(V_B_Material_Frame v_B_Material_Frame)
        {
            if ((v_B_Material_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Frame, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_Frame.AddObject(v_B_Material_Frame);
            }
        }

        public void UpdateV_B_Material_Frame(V_B_Material_Frame currentV_B_Material_Frame)
        {
            this.ObjectContext.V_B_Material_Frame.AttachAsModified(currentV_B_Material_Frame, this.ChangeSet.GetOriginal(currentV_B_Material_Frame));
        }

        public void DeleteV_B_Material_Frame(V_B_Material_Frame v_B_Material_Frame)
        {
            if ((v_B_Material_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Frame, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_Frame.Attach(v_B_Material_Frame);
                this.ObjectContext.V_B_Material_Frame.DeleteObject(v_B_Material_Frame);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_Lens' query.
        public IQueryable<V_B_Material_Lens> GetV_B_Material_Lens()
        {
            return this.ObjectContext.V_B_Material_Lens;
        }

        public void InsertV_B_Material_Lens(V_B_Material_Lens v_B_Material_Lens)
        {
            if ((v_B_Material_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_Lens.AddObject(v_B_Material_Lens);
            }
        }

        public void UpdateV_B_Material_Lens(V_B_Material_Lens currentV_B_Material_Lens)
        {
            this.ObjectContext.V_B_Material_Lens.AttachAsModified(currentV_B_Material_Lens, this.ChangeSet.GetOriginal(currentV_B_Material_Lens));
        }

        public void DeleteV_B_Material_Lens(V_B_Material_Lens v_B_Material_Lens)
        {
            if ((v_B_Material_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_Lens.Attach(v_B_Material_Lens);
                this.ObjectContext.V_B_Material_Lens.DeleteObject(v_B_Material_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Brand' query.
        public IQueryable<V_B_Material_LensClass_Brand> GetV_B_Material_LensClass_Brand()
        {
            return this.ObjectContext.V_B_Material_LensClass_Brand;
        }

        public void InsertV_B_Material_LensClass_Brand(V_B_Material_LensClass_Brand v_B_Material_LensClass_Brand)
        {
            if ((v_B_Material_LensClass_Brand.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Brand, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Brand.AddObject(v_B_Material_LensClass_Brand);
            }
        }

        public void UpdateV_B_Material_LensClass_Brand(V_B_Material_LensClass_Brand currentV_B_Material_LensClass_Brand)
        {
            this.ObjectContext.V_B_Material_LensClass_Brand.AttachAsModified(currentV_B_Material_LensClass_Brand, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Brand));
        }

        public void DeleteV_B_Material_LensClass_Brand(V_B_Material_LensClass_Brand v_B_Material_LensClass_Brand)
        {
            if ((v_B_Material_LensClass_Brand.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Brand, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Brand.Attach(v_B_Material_LensClass_Brand);
                this.ObjectContext.V_B_Material_LensClass_Brand.DeleteObject(v_B_Material_LensClass_Brand);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_DefaultCoating' query.
        public IQueryable<V_B_Material_LensClass_DefaultCoating> GetV_B_Material_LensClass_DefaultCoating()
        {
            return this.ObjectContext.V_B_Material_LensClass_DefaultCoating;
        }

        public void InsertV_B_Material_LensClass_DefaultCoating(V_B_Material_LensClass_DefaultCoating v_B_Material_LensClass_DefaultCoating)
        {
            if ((v_B_Material_LensClass_DefaultCoating.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_DefaultCoating, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_DefaultCoating.AddObject(v_B_Material_LensClass_DefaultCoating);
            }
        }

        public void UpdateV_B_Material_LensClass_DefaultCoating(V_B_Material_LensClass_DefaultCoating currentV_B_Material_LensClass_DefaultCoating)
        {
            this.ObjectContext.V_B_Material_LensClass_DefaultCoating.AttachAsModified(currentV_B_Material_LensClass_DefaultCoating, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_DefaultCoating));
        }

        public void DeleteV_B_Material_LensClass_DefaultCoating(V_B_Material_LensClass_DefaultCoating v_B_Material_LensClass_DefaultCoating)
        {
            if ((v_B_Material_LensClass_DefaultCoating.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_DefaultCoating, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_DefaultCoating.Attach(v_B_Material_LensClass_DefaultCoating);
                this.ObjectContext.V_B_Material_LensClass_DefaultCoating.DeleteObject(v_B_Material_LensClass_DefaultCoating);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Design' query.
        public IQueryable<V_B_Material_LensClass_Design> GetV_B_Material_LensClass_Design()
        {
            return this.ObjectContext.V_B_Material_LensClass_Design;
        }

        public void InsertV_B_Material_LensClass_Design(V_B_Material_LensClass_Design v_B_Material_LensClass_Design)
        {
            if ((v_B_Material_LensClass_Design.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Design, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Design.AddObject(v_B_Material_LensClass_Design);
            }
        }

        public void UpdateV_B_Material_LensClass_Design(V_B_Material_LensClass_Design currentV_B_Material_LensClass_Design)
        {
            this.ObjectContext.V_B_Material_LensClass_Design.AttachAsModified(currentV_B_Material_LensClass_Design, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Design));
        }

        public void DeleteV_B_Material_LensClass_Design(V_B_Material_LensClass_Design v_B_Material_LensClass_Design)
        {
            if ((v_B_Material_LensClass_Design.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Design, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Design.Attach(v_B_Material_LensClass_Design);
                this.ObjectContext.V_B_Material_LensClass_Design.DeleteObject(v_B_Material_LensClass_Design);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Focus' query.
        public IQueryable<V_B_Material_LensClass_Focus> GetV_B_Material_LensClass_Focus()
        {
            return this.ObjectContext.V_B_Material_LensClass_Focus;
        }

        public void InsertV_B_Material_LensClass_Focus(V_B_Material_LensClass_Focus v_B_Material_LensClass_Focus)
        {
            if ((v_B_Material_LensClass_Focus.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Focus, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Focus.AddObject(v_B_Material_LensClass_Focus);
            }
        }

        public void UpdateV_B_Material_LensClass_Focus(V_B_Material_LensClass_Focus currentV_B_Material_LensClass_Focus)
        {
            this.ObjectContext.V_B_Material_LensClass_Focus.AttachAsModified(currentV_B_Material_LensClass_Focus, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Focus));
        }

        public void DeleteV_B_Material_LensClass_Focus(V_B_Material_LensClass_Focus v_B_Material_LensClass_Focus)
        {
            if ((v_B_Material_LensClass_Focus.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Focus, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Focus.Attach(v_B_Material_LensClass_Focus);
                this.ObjectContext.V_B_Material_LensClass_Focus.DeleteObject(v_B_Material_LensClass_Focus);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Index' query.
        public IQueryable<V_B_Material_LensClass_Index> GetV_B_Material_LensClass_Index()
        {
            return this.ObjectContext.V_B_Material_LensClass_Index;
        }

        public void InsertV_B_Material_LensClass_Index(V_B_Material_LensClass_Index v_B_Material_LensClass_Index)
        {
            if ((v_B_Material_LensClass_Index.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Index, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Index.AddObject(v_B_Material_LensClass_Index);
            }
        }

        public void UpdateV_B_Material_LensClass_Index(V_B_Material_LensClass_Index currentV_B_Material_LensClass_Index)
        {
            this.ObjectContext.V_B_Material_LensClass_Index.AttachAsModified(currentV_B_Material_LensClass_Index, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Index));
        }

        public void DeleteV_B_Material_LensClass_Index(V_B_Material_LensClass_Index v_B_Material_LensClass_Index)
        {
            if ((v_B_Material_LensClass_Index.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Index, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Index.Attach(v_B_Material_LensClass_Index);
                this.ObjectContext.V_B_Material_LensClass_Index.DeleteObject(v_B_Material_LensClass_Index);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Materials' query.
        public IQueryable<V_B_Material_LensClass_Materials> GetV_B_Material_LensClass_Materials()
        {
            return this.ObjectContext.V_B_Material_LensClass_Materials;
        }

        public void InsertV_B_Material_LensClass_Materials(V_B_Material_LensClass_Materials v_B_Material_LensClass_Materials)
        {
            if ((v_B_Material_LensClass_Materials.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Materials, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Materials.AddObject(v_B_Material_LensClass_Materials);
            }
        }

        public void UpdateV_B_Material_LensClass_Materials(V_B_Material_LensClass_Materials currentV_B_Material_LensClass_Materials)
        {
            this.ObjectContext.V_B_Material_LensClass_Materials.AttachAsModified(currentV_B_Material_LensClass_Materials, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Materials));
        }

        public void DeleteV_B_Material_LensClass_Materials(V_B_Material_LensClass_Materials v_B_Material_LensClass_Materials)
        {
            if ((v_B_Material_LensClass_Materials.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Materials, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Materials.Attach(v_B_Material_LensClass_Materials);
                this.ObjectContext.V_B_Material_LensClass_Materials.DeleteObject(v_B_Material_LensClass_Materials);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensClass_Usage' query.
        public IQueryable<V_B_Material_LensClass_Usage> GetV_B_Material_LensClass_Usage()
        {
            return this.ObjectContext.V_B_Material_LensClass_Usage;
        }

        public void InsertV_B_Material_LensClass_Usage(V_B_Material_LensClass_Usage v_B_Material_LensClass_Usage)
        {
            if ((v_B_Material_LensClass_Usage.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Usage, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Usage.AddObject(v_B_Material_LensClass_Usage);
            }
        }

        public void UpdateV_B_Material_LensClass_Usage(V_B_Material_LensClass_Usage currentV_B_Material_LensClass_Usage)
        {
            this.ObjectContext.V_B_Material_LensClass_Usage.AttachAsModified(currentV_B_Material_LensClass_Usage, this.ChangeSet.GetOriginal(currentV_B_Material_LensClass_Usage));
        }

        public void DeleteV_B_Material_LensClass_Usage(V_B_Material_LensClass_Usage v_B_Material_LensClass_Usage)
        {
            if ((v_B_Material_LensClass_Usage.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensClass_Usage, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensClass_Usage.Attach(v_B_Material_LensClass_Usage);
                this.ObjectContext.V_B_Material_LensClass_Usage.DeleteObject(v_B_Material_LensClass_Usage);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_LensSmart' query.
        public IQueryable<V_B_Material_LensSmart> GetV_B_Material_LensSmart()
        {
            return this.ObjectContext.V_B_Material_LensSmart;
        }

        public void InsertV_B_Material_LensSmart(V_B_Material_LensSmart v_B_Material_LensSmart)
        {
            if ((v_B_Material_LensSmart.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensSmart, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensSmart.AddObject(v_B_Material_LensSmart);
            }
        }

        public void UpdateV_B_Material_LensSmart(V_B_Material_LensSmart currentV_B_Material_LensSmart)
        {
            this.ObjectContext.V_B_Material_LensSmart.AttachAsModified(currentV_B_Material_LensSmart, this.ChangeSet.GetOriginal(currentV_B_Material_LensSmart));
        }

        public void DeleteV_B_Material_LensSmart(V_B_Material_LensSmart v_B_Material_LensSmart)
        {
            if ((v_B_Material_LensSmart.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_LensSmart, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_LensSmart.Attach(v_B_Material_LensSmart);
                this.ObjectContext.V_B_Material_LensSmart.DeleteObject(v_B_Material_LensSmart);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Material_Process' query.
        public IQueryable<V_B_Material_Process> GetV_B_Material_Process()
        {
            return this.ObjectContext.V_B_Material_Process;
        }

        public void InsertV_B_Material_Process(V_B_Material_Process v_B_Material_Process)
        {
            if ((v_B_Material_Process.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Process, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Material_Process.AddObject(v_B_Material_Process);
            }
        }

        public void UpdateV_B_Material_Process(V_B_Material_Process currentV_B_Material_Process)
        {
            this.ObjectContext.V_B_Material_Process.AttachAsModified(currentV_B_Material_Process, this.ChangeSet.GetOriginal(currentV_B_Material_Process));
        }

        public void DeleteV_B_Material_Process(V_B_Material_Process v_B_Material_Process)
        {
            if ((v_B_Material_Process.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Material_Process, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Material_Process.Attach(v_B_Material_Process);
                this.ObjectContext.V_B_Material_Process.DeleteObject(v_B_Material_Process);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Person' query.
        public IQueryable<V_B_Person> GetV_B_Person()
        {
            return this.ObjectContext.V_B_Person;
        }

        public void InsertV_B_Person(V_B_Person v_B_Person)
        {
            if ((v_B_Person.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Person, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Person.AddObject(v_B_Person);
            }
        }

        public void UpdateV_B_Person(V_B_Person currentV_B_Person)
        {
            this.ObjectContext.V_B_Person.AttachAsModified(currentV_B_Person, this.ChangeSet.GetOriginal(currentV_B_Person));
        }

        public void DeleteV_B_Person(V_B_Person v_B_Person)
        {
            if ((v_B_Person.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Person, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Person.Attach(v_B_Person);
                this.ObjectContext.V_B_Person.DeleteObject(v_B_Person);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier' query.
        public IQueryable<V_B_Supplier> GetV_B_Supplier()
        {
            return this.ObjectContext.V_B_Supplier;
        }

        public void InsertV_B_Supplier(V_B_Supplier v_B_Supplier)
        {
            if ((v_B_Supplier.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier.AddObject(v_B_Supplier);
            }
        }

        public void UpdateV_B_Supplier(V_B_Supplier currentV_B_Supplier)
        {
            this.ObjectContext.V_B_Supplier.AttachAsModified(currentV_B_Supplier, this.ChangeSet.GetOriginal(currentV_B_Supplier));
        }

        public void DeleteV_B_Supplier(V_B_Supplier v_B_Supplier)
        {
            if ((v_B_Supplier.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier.Attach(v_B_Supplier);
                this.ObjectContext.V_B_Supplier.DeleteObject(v_B_Supplier);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier_Browse' query.
        public IQueryable<V_B_Supplier_Browse> GetV_B_Supplier_Browse()
        {
            return this.ObjectContext.V_B_Supplier_Browse;
        }

        public void InsertV_B_Supplier_Browse(V_B_Supplier_Browse v_B_Supplier_Browse)
        {
            if ((v_B_Supplier_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Browse, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Browse.AddObject(v_B_Supplier_Browse);
            }
        }

        public void UpdateV_B_Supplier_Browse(V_B_Supplier_Browse currentV_B_Supplier_Browse)
        {
            this.ObjectContext.V_B_Supplier_Browse.AttachAsModified(currentV_B_Supplier_Browse, this.ChangeSet.GetOriginal(currentV_B_Supplier_Browse));
        }

        public void DeleteV_B_Supplier_Browse(V_B_Supplier_Browse v_B_Supplier_Browse)
        {
            if ((v_B_Supplier_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Browse, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Browse.Attach(v_B_Supplier_Browse);
                this.ObjectContext.V_B_Supplier_Browse.DeleteObject(v_B_Supplier_Browse);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier_Default' query.
        public IQueryable<V_B_Supplier_Default> GetV_B_Supplier_Default()
        {
            return this.ObjectContext.V_B_Supplier_Default;
        }

        public void InsertV_B_Supplier_Default(V_B_Supplier_Default v_B_Supplier_Default)
        {
            if ((v_B_Supplier_Default.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default.AddObject(v_B_Supplier_Default);
            }
        }

        public void UpdateV_B_Supplier_Default(V_B_Supplier_Default currentV_B_Supplier_Default)
        {
            this.ObjectContext.V_B_Supplier_Default.AttachAsModified(currentV_B_Supplier_Default, this.ChangeSet.GetOriginal(currentV_B_Supplier_Default));
        }

        public void DeleteV_B_Supplier_Default(V_B_Supplier_Default v_B_Supplier_Default)
        {
            if ((v_B_Supplier_Default.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default.Attach(v_B_Supplier_Default);
                this.ObjectContext.V_B_Supplier_Default.DeleteObject(v_B_Supplier_Default);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier_Default_CusCode' query.
        public IQueryable<V_B_Supplier_Default_CusCode> GetV_B_Supplier_Default_CusCode()
        {
            return this.ObjectContext.V_B_Supplier_Default_CusCode;
        }

        public void InsertV_B_Supplier_Default_CusCode(V_B_Supplier_Default_CusCode v_B_Supplier_Default_CusCode)
        {
            if ((v_B_Supplier_Default_CusCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_CusCode, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_CusCode.AddObject(v_B_Supplier_Default_CusCode);
            }
        }

        public void UpdateV_B_Supplier_Default_CusCode(V_B_Supplier_Default_CusCode currentV_B_Supplier_Default_CusCode)
        {
            this.ObjectContext.V_B_Supplier_Default_CusCode.AttachAsModified(currentV_B_Supplier_Default_CusCode, this.ChangeSet.GetOriginal(currentV_B_Supplier_Default_CusCode));
        }

        public void DeleteV_B_Supplier_Default_CusCode(V_B_Supplier_Default_CusCode v_B_Supplier_Default_CusCode)
        {
            if ((v_B_Supplier_Default_CusCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_CusCode, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_CusCode.Attach(v_B_Supplier_Default_CusCode);
                this.ObjectContext.V_B_Supplier_Default_CusCode.DeleteObject(v_B_Supplier_Default_CusCode);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier_Default_Lens' query.
        public IQueryable<V_B_Supplier_Default_Lens> GetV_B_Supplier_Default_Lens()
        {
            return this.ObjectContext.V_B_Supplier_Default_Lens;
        }

        public void InsertV_B_Supplier_Default_Lens(V_B_Supplier_Default_Lens v_B_Supplier_Default_Lens)
        {
            if ((v_B_Supplier_Default_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_Lens.AddObject(v_B_Supplier_Default_Lens);
            }
        }

        public void UpdateV_B_Supplier_Default_Lens(V_B_Supplier_Default_Lens currentV_B_Supplier_Default_Lens)
        {
            this.ObjectContext.V_B_Supplier_Default_Lens.AttachAsModified(currentV_B_Supplier_Default_Lens, this.ChangeSet.GetOriginal(currentV_B_Supplier_Default_Lens));
        }

        public void DeleteV_B_Supplier_Default_Lens(V_B_Supplier_Default_Lens v_B_Supplier_Default_Lens)
        {
            if ((v_B_Supplier_Default_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_Lens.Attach(v_B_Supplier_Default_Lens);
                this.ObjectContext.V_B_Supplier_Default_Lens.DeleteObject(v_B_Supplier_Default_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Supplier_Default_ProCode' query.
        public IQueryable<V_B_Supplier_Default_ProCode> GetV_B_Supplier_Default_ProCode()
        {
            return this.ObjectContext.V_B_Supplier_Default_ProCode;
        }

        public void InsertV_B_Supplier_Default_ProCode(V_B_Supplier_Default_ProCode v_B_Supplier_Default_ProCode)
        {
            if ((v_B_Supplier_Default_ProCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_ProCode, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_ProCode.AddObject(v_B_Supplier_Default_ProCode);
            }
        }

        public void UpdateV_B_Supplier_Default_ProCode(V_B_Supplier_Default_ProCode currentV_B_Supplier_Default_ProCode)
        {
            this.ObjectContext.V_B_Supplier_Default_ProCode.AttachAsModified(currentV_B_Supplier_Default_ProCode, this.ChangeSet.GetOriginal(currentV_B_Supplier_Default_ProCode));
        }

        public void DeleteV_B_Supplier_Default_ProCode(V_B_Supplier_Default_ProCode v_B_Supplier_Default_ProCode)
        {
            if ((v_B_Supplier_Default_ProCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Supplier_Default_ProCode, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Supplier_Default_ProCode.Attach(v_B_Supplier_Default_ProCode);
                this.ObjectContext.V_B_Supplier_Default_ProCode.DeleteObject(v_B_Supplier_Default_ProCode);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Warehouse' query.
        public IQueryable<V_B_Warehouse> GetV_B_Warehouse()
        {
            return this.ObjectContext.V_B_Warehouse;
        }

        public void InsertV_B_Warehouse(V_B_Warehouse v_B_Warehouse)
        {
            if ((v_B_Warehouse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse.AddObject(v_B_Warehouse);
            }
        }

        public void UpdateV_B_Warehouse(V_B_Warehouse currentV_B_Warehouse)
        {
            this.ObjectContext.V_B_Warehouse.AttachAsModified(currentV_B_Warehouse, this.ChangeSet.GetOriginal(currentV_B_Warehouse));
        }

        public void DeleteV_B_Warehouse(V_B_Warehouse v_B_Warehouse)
        {
            if ((v_B_Warehouse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse.Attach(v_B_Warehouse);
                this.ObjectContext.V_B_Warehouse.DeleteObject(v_B_Warehouse);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Warehouse_Browse' query.
        public IQueryable<V_B_Warehouse_Browse> GetV_B_Warehouse_Browse()
        {
            return this.ObjectContext.V_B_Warehouse_Browse;
        }

        public void InsertV_B_Warehouse_Browse(V_B_Warehouse_Browse v_B_Warehouse_Browse)
        {
            if ((v_B_Warehouse_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse_Browse, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse_Browse.AddObject(v_B_Warehouse_Browse);
            }
        }

        public void UpdateV_B_Warehouse_Browse(V_B_Warehouse_Browse currentV_B_Warehouse_Browse)
        {
            this.ObjectContext.V_B_Warehouse_Browse.AttachAsModified(currentV_B_Warehouse_Browse, this.ChangeSet.GetOriginal(currentV_B_Warehouse_Browse));
        }

        public void DeleteV_B_Warehouse_Browse(V_B_Warehouse_Browse v_B_Warehouse_Browse)
        {
            if ((v_B_Warehouse_Browse.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse_Browse, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse_Browse.Attach(v_B_Warehouse_Browse);
                this.ObjectContext.V_B_Warehouse_Browse.DeleteObject(v_B_Warehouse_Browse);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_B_Warehouse_Use' query.
        public IQueryable<V_B_Warehouse_Use> GetV_B_Warehouse_Use()
        {
            return this.ObjectContext.V_B_Warehouse_Use;
        }

        public void InsertV_B_Warehouse_Use(V_B_Warehouse_Use v_B_Warehouse_Use)
        {
            if ((v_B_Warehouse_Use.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse_Use, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse_Use.AddObject(v_B_Warehouse_Use);
            }
        }

        public void UpdateV_B_Warehouse_Use(V_B_Warehouse_Use currentV_B_Warehouse_Use)
        {
            this.ObjectContext.V_B_Warehouse_Use.AttachAsModified(currentV_B_Warehouse_Use, this.ChangeSet.GetOriginal(currentV_B_Warehouse_Use));
        }

        public void DeleteV_B_Warehouse_Use(V_B_Warehouse_Use v_B_Warehouse_Use)
        {
            if ((v_B_Warehouse_Use.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_B_Warehouse_Use, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_B_Warehouse_Use.Attach(v_B_Warehouse_Use);
                this.ObjectContext.V_B_Warehouse_Use.DeleteObject(v_B_Warehouse_Use);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_Order_Lens' query.
        public IQueryable<V_Pur_Order_Lens> GetV_Pur_Order_Lens()
        {
            return this.ObjectContext.V_Pur_Order_Lens;
        }

        public void InsertV_Pur_Order_Lens(V_Pur_Order_Lens v_Pur_Order_Lens)
        {
            if ((v_Pur_Order_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_Lens.AddObject(v_Pur_Order_Lens);
            }
        }

        public void UpdateV_Pur_Order_Lens(V_Pur_Order_Lens currentV_Pur_Order_Lens)
        {
            this.ObjectContext.V_Pur_Order_Lens.AttachAsModified(currentV_Pur_Order_Lens, this.ChangeSet.GetOriginal(currentV_Pur_Order_Lens));
        }

        public void DeleteV_Pur_Order_Lens(V_Pur_Order_Lens v_Pur_Order_Lens)
        {
            if ((v_Pur_Order_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_Lens.Attach(v_Pur_Order_Lens);
                this.ObjectContext.V_Pur_Order_Lens.DeleteObject(v_Pur_Order_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_Order_PD' query.
        public IQueryable<V_Pur_Order_PD> GetV_Pur_Order_PD()
        {
            return this.ObjectContext.V_Pur_Order_PD;
        }

        public void InsertV_Pur_Order_PD(V_Pur_Order_PD v_Pur_Order_PD)
        {
            if ((v_Pur_Order_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_PD.AddObject(v_Pur_Order_PD);
            }
        }

        public void UpdateV_Pur_Order_PD(V_Pur_Order_PD currentV_Pur_Order_PD)
        {
            this.ObjectContext.V_Pur_Order_PD.AttachAsModified(currentV_Pur_Order_PD, this.ChangeSet.GetOriginal(currentV_Pur_Order_PD));
        }

        public void DeleteV_Pur_Order_PD(V_Pur_Order_PD v_Pur_Order_PD)
        {
            if ((v_Pur_Order_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_PD.Attach(v_Pur_Order_PD);
                this.ObjectContext.V_Pur_Order_PD.DeleteObject(v_Pur_Order_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_Order_SD' query.
        public IQueryable<V_Pur_Order_SD> GetV_Pur_Order_SD()
        {
            return this.ObjectContext.V_Pur_Order_SD;
        }

        public void InsertV_Pur_Order_SD(V_Pur_Order_SD v_Pur_Order_SD)
        {
            if ((v_Pur_Order_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_SD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_SD.AddObject(v_Pur_Order_SD);
            }
        }

        public void UpdateV_Pur_Order_SD(V_Pur_Order_SD currentV_Pur_Order_SD)
        {
            this.ObjectContext.V_Pur_Order_SD.AttachAsModified(currentV_Pur_Order_SD, this.ChangeSet.GetOriginal(currentV_Pur_Order_SD));
        }

        public void DeleteV_Pur_Order_SD(V_Pur_Order_SD v_Pur_Order_SD)
        {
            if ((v_Pur_Order_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Order_SD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_Order_SD.Attach(v_Pur_Order_SD);
                this.ObjectContext.V_Pur_Order_SD.DeleteObject(v_Pur_Order_SD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract' query.
        public IQueryable<V_Pur_PriceContract> GetV_Pur_PriceContract()
        {
            return this.ObjectContext.V_Pur_PriceContract;
        }

        public void InsertV_Pur_PriceContract(V_Pur_PriceContract v_Pur_PriceContract)
        {
            if ((v_Pur_PriceContract.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract.AddObject(v_Pur_PriceContract);
            }
        }

        public void UpdateV_Pur_PriceContract(V_Pur_PriceContract currentV_Pur_PriceContract)
        {
            this.ObjectContext.V_Pur_PriceContract.AttachAsModified(currentV_Pur_PriceContract, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract));
        }

        public void DeleteV_Pur_PriceContract(V_Pur_PriceContract v_Pur_PriceContract)
        {
            if ((v_Pur_PriceContract.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract.Attach(v_Pur_PriceContract);
                this.ObjectContext.V_Pur_PriceContract.DeleteObject(v_Pur_PriceContract);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_Frame' query.
        public IQueryable<V_Pur_PriceContract_Frame> GetV_Pur_PriceContract_Frame()
        {
            return this.ObjectContext.V_Pur_PriceContract_Frame;
        }

        public void InsertV_Pur_PriceContract_Frame(V_Pur_PriceContract_Frame v_Pur_PriceContract_Frame)
        {
            if ((v_Pur_PriceContract_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Frame, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Frame.AddObject(v_Pur_PriceContract_Frame);
            }
        }

        public void UpdateV_Pur_PriceContract_Frame(V_Pur_PriceContract_Frame currentV_Pur_PriceContract_Frame)
        {
            this.ObjectContext.V_Pur_PriceContract_Frame.AttachAsModified(currentV_Pur_PriceContract_Frame, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_Frame));
        }

        public void DeleteV_Pur_PriceContract_Frame(V_Pur_PriceContract_Frame v_Pur_PriceContract_Frame)
        {
            if ((v_Pur_PriceContract_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Frame, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Frame.Attach(v_Pur_PriceContract_Frame);
                this.ObjectContext.V_Pur_PriceContract_Frame.DeleteObject(v_Pur_PriceContract_Frame);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_FrameSet' query.
        public IQueryable<V_Pur_PriceContract_FrameSet> GetV_Pur_PriceContract_FrameSet()
        {
            return this.ObjectContext.V_Pur_PriceContract_FrameSet;
        }

        public void InsertV_Pur_PriceContract_FrameSet(V_Pur_PriceContract_FrameSet v_Pur_PriceContract_FrameSet)
        {
            if ((v_Pur_PriceContract_FrameSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_FrameSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_FrameSet.AddObject(v_Pur_PriceContract_FrameSet);
            }
        }

        public void UpdateV_Pur_PriceContract_FrameSet(V_Pur_PriceContract_FrameSet currentV_Pur_PriceContract_FrameSet)
        {
            this.ObjectContext.V_Pur_PriceContract_FrameSet.AttachAsModified(currentV_Pur_PriceContract_FrameSet, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_FrameSet));
        }

        public void DeleteV_Pur_PriceContract_FrameSet(V_Pur_PriceContract_FrameSet v_Pur_PriceContract_FrameSet)
        {
            if ((v_Pur_PriceContract_FrameSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_FrameSet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_FrameSet.Attach(v_Pur_PriceContract_FrameSet);
                this.ObjectContext.V_Pur_PriceContract_FrameSet.DeleteObject(v_Pur_PriceContract_FrameSet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_Lens' query.
        public IQueryable<V_Pur_PriceContract_Lens> GetV_Pur_PriceContract_Lens()
        {
            return this.ObjectContext.V_Pur_PriceContract_Lens;
        }

        public void InsertV_Pur_PriceContract_Lens(V_Pur_PriceContract_Lens v_Pur_PriceContract_Lens)
        {
            if ((v_Pur_PriceContract_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Lens.AddObject(v_Pur_PriceContract_Lens);
            }
        }

        public void UpdateV_Pur_PriceContract_Lens(V_Pur_PriceContract_Lens currentV_Pur_PriceContract_Lens)
        {
            this.ObjectContext.V_Pur_PriceContract_Lens.AttachAsModified(currentV_Pur_PriceContract_Lens, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_Lens));
        }

        public void DeleteV_Pur_PriceContract_Lens(V_Pur_PriceContract_Lens v_Pur_PriceContract_Lens)
        {
            if ((v_Pur_PriceContract_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Lens.Attach(v_Pur_PriceContract_Lens);
                this.ObjectContext.V_Pur_PriceContract_Lens.DeleteObject(v_Pur_PriceContract_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_Lens_ProCost' query.
        public IQueryable<V_Pur_PriceContract_Lens_ProCost> GetV_Pur_PriceContract_Lens_ProCost()
        {
            return this.ObjectContext.V_Pur_PriceContract_Lens_ProCost;
        }

        public void InsertV_Pur_PriceContract_Lens_ProCost(V_Pur_PriceContract_Lens_ProCost v_Pur_PriceContract_Lens_ProCost)
        {
            if ((v_Pur_PriceContract_Lens_ProCost.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Lens_ProCost, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Lens_ProCost.AddObject(v_Pur_PriceContract_Lens_ProCost);
            }
        }

        public void UpdateV_Pur_PriceContract_Lens_ProCost(V_Pur_PriceContract_Lens_ProCost currentV_Pur_PriceContract_Lens_ProCost)
        {
            this.ObjectContext.V_Pur_PriceContract_Lens_ProCost.AttachAsModified(currentV_Pur_PriceContract_Lens_ProCost, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_Lens_ProCost));
        }

        public void DeleteV_Pur_PriceContract_Lens_ProCost(V_Pur_PriceContract_Lens_ProCost v_Pur_PriceContract_Lens_ProCost)
        {
            if ((v_Pur_PriceContract_Lens_ProCost.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_Lens_ProCost, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_Lens_ProCost.Attach(v_Pur_PriceContract_Lens_ProCost);
                this.ObjectContext.V_Pur_PriceContract_Lens_ProCost.DeleteObject(v_Pur_PriceContract_Lens_ProCost);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_SpGroup' query.
        public IQueryable<V_Pur_PriceContract_SpGroup> GetV_Pur_PriceContract_SpGroup()
        {
            return this.ObjectContext.V_Pur_PriceContract_SpGroup;
        }

        public void InsertV_Pur_PriceContract_SpGroup(V_Pur_PriceContract_SpGroup v_Pur_PriceContract_SpGroup)
        {
            if ((v_Pur_PriceContract_SpGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_SpGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_SpGroup.AddObject(v_Pur_PriceContract_SpGroup);
            }
        }

        public void UpdateV_Pur_PriceContract_SpGroup(V_Pur_PriceContract_SpGroup currentV_Pur_PriceContract_SpGroup)
        {
            this.ObjectContext.V_Pur_PriceContract_SpGroup.AttachAsModified(currentV_Pur_PriceContract_SpGroup, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_SpGroup));
        }

        public void DeleteV_Pur_PriceContract_SpGroup(V_Pur_PriceContract_SpGroup v_Pur_PriceContract_SpGroup)
        {
            if ((v_Pur_PriceContract_SpGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_SpGroup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_SpGroup.Attach(v_Pur_PriceContract_SpGroup);
                this.ObjectContext.V_Pur_PriceContract_SpGroup.DeleteObject(v_Pur_PriceContract_SpGroup);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_PriceContract_SpGroup_SpCode' query.
        public IQueryable<V_Pur_PriceContract_SpGroup_SpCode> GetV_Pur_PriceContract_SpGroup_SpCode()
        {
            return this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode;
        }

        public void InsertV_Pur_PriceContract_SpGroup_SpCode(V_Pur_PriceContract_SpGroup_SpCode v_Pur_PriceContract_SpGroup_SpCode)
        {
            if ((v_Pur_PriceContract_SpGroup_SpCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_SpGroup_SpCode, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode.AddObject(v_Pur_PriceContract_SpGroup_SpCode);
            }
        }

        public void UpdateV_Pur_PriceContract_SpGroup_SpCode(V_Pur_PriceContract_SpGroup_SpCode currentV_Pur_PriceContract_SpGroup_SpCode)
        {
            this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode.AttachAsModified(currentV_Pur_PriceContract_SpGroup_SpCode, this.ChangeSet.GetOriginal(currentV_Pur_PriceContract_SpGroup_SpCode));
        }

        public void DeleteV_Pur_PriceContract_SpGroup_SpCode(V_Pur_PriceContract_SpGroup_SpCode v_Pur_PriceContract_SpGroup_SpCode)
        {
            if ((v_Pur_PriceContract_SpGroup_SpCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_PriceContract_SpGroup_SpCode, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode.Attach(v_Pur_PriceContract_SpGroup_SpCode);
                this.ObjectContext.V_Pur_PriceContract_SpGroup_SpCode.DeleteObject(v_Pur_PriceContract_SpGroup_SpCode);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Pur_Quote' query.
        public IQueryable<V_Pur_Quote> GetV_Pur_Quote()
        {
            return this.ObjectContext.V_Pur_Quote;
        }

        public void InsertV_Pur_Quote(V_Pur_Quote v_Pur_Quote)
        {
            if ((v_Pur_Quote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Quote, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Pur_Quote.AddObject(v_Pur_Quote);
            }
        }

        public void UpdateV_Pur_Quote(V_Pur_Quote currentV_Pur_Quote)
        {
            this.ObjectContext.V_Pur_Quote.AttachAsModified(currentV_Pur_Quote, this.ChangeSet.GetOriginal(currentV_Pur_Quote));
        }

        public void DeleteV_Pur_Quote(V_Pur_Quote v_Pur_Quote)
        {
            if ((v_Pur_Quote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Pur_Quote, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Pur_Quote.Attach(v_Pur_Quote);
                this.ObjectContext.V_Pur_Quote.DeleteObject(v_Pur_Quote);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Base_Note' query.
        public IQueryable<V_Sale_Base_Note> GetV_Sale_Base_Note()
        {
            return this.ObjectContext.V_Sale_Base_Note;
        }

        public void InsertV_Sale_Base_Note(V_Sale_Base_Note v_Sale_Base_Note)
        {
            if ((v_Sale_Base_Note.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Base_Note, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Base_Note.AddObject(v_Sale_Base_Note);
            }
        }

        public void UpdateV_Sale_Base_Note(V_Sale_Base_Note currentV_Sale_Base_Note)
        {
            this.ObjectContext.V_Sale_Base_Note.AttachAsModified(currentV_Sale_Base_Note, this.ChangeSet.GetOriginal(currentV_Sale_Base_Note));
        }

        public void DeleteV_Sale_Base_Note(V_Sale_Base_Note v_Sale_Base_Note)
        {
            if ((v_Sale_Base_Note.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Base_Note, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Base_Note.Attach(v_Sale_Base_Note);
                this.ObjectContext.V_Sale_Base_Note.DeleteObject(v_Sale_Base_Note);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Base_ReOrderReason' query.
        public IQueryable<V_Sale_Base_ReOrderReason> GetV_Sale_Base_ReOrderReason()
        {
            return this.ObjectContext.V_Sale_Base_ReOrderReason;
        }

        public void InsertV_Sale_Base_ReOrderReason(V_Sale_Base_ReOrderReason v_Sale_Base_ReOrderReason)
        {
            if ((v_Sale_Base_ReOrderReason.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Base_ReOrderReason, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Base_ReOrderReason.AddObject(v_Sale_Base_ReOrderReason);
            }
        }

        public void UpdateV_Sale_Base_ReOrderReason(V_Sale_Base_ReOrderReason currentV_Sale_Base_ReOrderReason)
        {
            this.ObjectContext.V_Sale_Base_ReOrderReason.AttachAsModified(currentV_Sale_Base_ReOrderReason, this.ChangeSet.GetOriginal(currentV_Sale_Base_ReOrderReason));
        }

        public void DeleteV_Sale_Base_ReOrderReason(V_Sale_Base_ReOrderReason v_Sale_Base_ReOrderReason)
        {
            if ((v_Sale_Base_ReOrderReason.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Base_ReOrderReason, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Base_ReOrderReason.Attach(v_Sale_Base_ReOrderReason);
                this.ObjectContext.V_Sale_Base_ReOrderReason.DeleteObject(v_Sale_Base_ReOrderReason);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Delivery_Lens' query.
        public IQueryable<V_Sale_Delivery_Lens> GetV_Sale_Delivery_Lens()
        {
            return this.ObjectContext.V_Sale_Delivery_Lens;
        }

        public void InsertV_Sale_Delivery_Lens(V_Sale_Delivery_Lens v_Sale_Delivery_Lens)
        {
            if ((v_Sale_Delivery_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Delivery_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Delivery_Lens.AddObject(v_Sale_Delivery_Lens);
            }
        }

        public void UpdateV_Sale_Delivery_Lens(V_Sale_Delivery_Lens currentV_Sale_Delivery_Lens)
        {
            this.ObjectContext.V_Sale_Delivery_Lens.AttachAsModified(currentV_Sale_Delivery_Lens, this.ChangeSet.GetOriginal(currentV_Sale_Delivery_Lens));
        }

        public void DeleteV_Sale_Delivery_Lens(V_Sale_Delivery_Lens v_Sale_Delivery_Lens)
        {
            if ((v_Sale_Delivery_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Delivery_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Delivery_Lens.Attach(v_Sale_Delivery_Lens);
                this.ObjectContext.V_Sale_Delivery_Lens.DeleteObject(v_Sale_Delivery_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_FD' query.
        public IQueryable<V_Sale_Order_FD> GetV_Sale_Order_FD()
        {
            return this.ObjectContext.V_Sale_Order_FD;
        }

        public void InsertV_Sale_Order_FD(V_Sale_Order_FD v_Sale_Order_FD)
        {
            if ((v_Sale_Order_FD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_FD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_FD.AddObject(v_Sale_Order_FD);
            }
        }

        public void UpdateV_Sale_Order_FD(V_Sale_Order_FD currentV_Sale_Order_FD)
        {
            this.ObjectContext.V_Sale_Order_FD.AttachAsModified(currentV_Sale_Order_FD, this.ChangeSet.GetOriginal(currentV_Sale_Order_FD));
        }

        public void DeleteV_Sale_Order_FD(V_Sale_Order_FD v_Sale_Order_FD)
        {
            if ((v_Sale_Order_FD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_FD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_FD.Attach(v_Sale_Order_FD);
                this.ObjectContext.V_Sale_Order_FD.DeleteObject(v_Sale_Order_FD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_Frame' query.
        public IQueryable<V_Sale_Order_Frame> GetV_Sale_Order_Frame()
        {
            return this.ObjectContext.V_Sale_Order_Frame;
        }

        public void InsertV_Sale_Order_Frame(V_Sale_Order_Frame v_Sale_Order_Frame)
        {
            if ((v_Sale_Order_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Frame, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Frame.AddObject(v_Sale_Order_Frame);
            }
        }

        public void UpdateV_Sale_Order_Frame(V_Sale_Order_Frame currentV_Sale_Order_Frame)
        {
            this.ObjectContext.V_Sale_Order_Frame.AttachAsModified(currentV_Sale_Order_Frame, this.ChangeSet.GetOriginal(currentV_Sale_Order_Frame));
        }

        public void DeleteV_Sale_Order_Frame(V_Sale_Order_Frame v_Sale_Order_Frame)
        {
            if ((v_Sale_Order_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Frame, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Frame.Attach(v_Sale_Order_Frame);
                this.ObjectContext.V_Sale_Order_Frame.DeleteObject(v_Sale_Order_Frame);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_Lens' query.
        public IQueryable<V_Sale_Order_Lens> GetV_Sale_Order_Lens()
        {
            return this.ObjectContext.V_Sale_Order_Lens;
        }

        public void InsertV_Sale_Order_Lens(V_Sale_Order_Lens v_Sale_Order_Lens)
        {
            if ((v_Sale_Order_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Lens.AddObject(v_Sale_Order_Lens);
            }
        }

        public void UpdateV_Sale_Order_Lens(V_Sale_Order_Lens currentV_Sale_Order_Lens)
        {
            this.ObjectContext.V_Sale_Order_Lens.AttachAsModified(currentV_Sale_Order_Lens, this.ChangeSet.GetOriginal(currentV_Sale_Order_Lens));
        }

        public void DeleteV_Sale_Order_Lens(V_Sale_Order_Lens v_Sale_Order_Lens)
        {
            if ((v_Sale_Order_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Lens.Attach(v_Sale_Order_Lens);
                this.ObjectContext.V_Sale_Order_Lens.DeleteObject(v_Sale_Order_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_PD' query.
        public IQueryable<V_Sale_Order_PD> GetV_Sale_Order_PD()
        {
            return this.ObjectContext.V_Sale_Order_PD;
        }

        public void InsertV_Sale_Order_PD(V_Sale_Order_PD v_Sale_Order_PD)
        {
            if ((v_Sale_Order_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_PD.AddObject(v_Sale_Order_PD);
            }
        }

        public void UpdateV_Sale_Order_PD(V_Sale_Order_PD currentV_Sale_Order_PD)
        {
            this.ObjectContext.V_Sale_Order_PD.AttachAsModified(currentV_Sale_Order_PD, this.ChangeSet.GetOriginal(currentV_Sale_Order_PD));
        }

        public void DeleteV_Sale_Order_PD(V_Sale_Order_PD v_Sale_Order_PD)
        {
            if ((v_Sale_Order_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_PD.Attach(v_Sale_Order_PD);
                this.ObjectContext.V_Sale_Order_PD.DeleteObject(v_Sale_Order_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_PD_Detail' query.
        public IQueryable<V_Sale_Order_PD_Detail> GetV_Sale_Order_PD_Detail()
        {
            return this.ObjectContext.V_Sale_Order_PD_Detail;
        }

        public void InsertV_Sale_Order_PD_Detail(V_Sale_Order_PD_Detail v_Sale_Order_PD_Detail)
        {
            if ((v_Sale_Order_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_PD_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_PD_Detail.AddObject(v_Sale_Order_PD_Detail);
            }
        }

        public void UpdateV_Sale_Order_PD_Detail(V_Sale_Order_PD_Detail currentV_Sale_Order_PD_Detail)
        {
            this.ObjectContext.V_Sale_Order_PD_Detail.AttachAsModified(currentV_Sale_Order_PD_Detail, this.ChangeSet.GetOriginal(currentV_Sale_Order_PD_Detail));
        }

        public void DeleteV_Sale_Order_PD_Detail(V_Sale_Order_PD_Detail v_Sale_Order_PD_Detail)
        {
            if ((v_Sale_Order_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_PD_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_PD_Detail.Attach(v_Sale_Order_PD_Detail);
                this.ObjectContext.V_Sale_Order_PD_Detail.DeleteObject(v_Sale_Order_PD_Detail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_SD' query.
        public IQueryable<V_Sale_Order_SD> GetV_Sale_Order_SD()
        {
            return this.ObjectContext.V_Sale_Order_SD;
        }

        public void InsertV_Sale_Order_SD(V_Sale_Order_SD v_Sale_Order_SD)
        {
            if ((v_Sale_Order_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_SD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_SD.AddObject(v_Sale_Order_SD);
            }
        }

        public void UpdateV_Sale_Order_SD(V_Sale_Order_SD currentV_Sale_Order_SD)
        {
            this.ObjectContext.V_Sale_Order_SD.AttachAsModified(currentV_Sale_Order_SD, this.ChangeSet.GetOriginal(currentV_Sale_Order_SD));
        }

        public void DeleteV_Sale_Order_SD(V_Sale_Order_SD v_Sale_Order_SD)
        {
            if ((v_Sale_Order_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_SD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_SD.Attach(v_Sale_Order_SD);
                this.ObjectContext.V_Sale_Order_SD.DeleteObject(v_Sale_Order_SD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Order_Status' query.
        public IQueryable<V_Sale_Order_Status> GetV_Sale_Order_Status()
        {
            return this.ObjectContext.V_Sale_Order_Status;
        }

        public void InsertV_Sale_Order_Status(V_Sale_Order_Status v_Sale_Order_Status)
        {
            if ((v_Sale_Order_Status.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Status, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Status.AddObject(v_Sale_Order_Status);
            }
        }

        public void UpdateV_Sale_Order_Status(V_Sale_Order_Status currentV_Sale_Order_Status)
        {
            this.ObjectContext.V_Sale_Order_Status.AttachAsModified(currentV_Sale_Order_Status, this.ChangeSet.GetOriginal(currentV_Sale_Order_Status));
        }

        public void DeleteV_Sale_Order_Status(V_Sale_Order_Status v_Sale_Order_Status)
        {
            if ((v_Sale_Order_Status.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Order_Status, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Order_Status.Attach(v_Sale_Order_Status);
                this.ObjectContext.V_Sale_Order_Status.DeleteObject(v_Sale_Order_Status);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract' query.
        public IQueryable<V_Sale_PriceContract> GetV_Sale_PriceContract()
        {
            return this.ObjectContext.V_Sale_PriceContract;
        }

        public void InsertV_Sale_PriceContract(V_Sale_PriceContract v_Sale_PriceContract)
        {
            if ((v_Sale_PriceContract.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract.AddObject(v_Sale_PriceContract);
            }
        }

        public void UpdateV_Sale_PriceContract(V_Sale_PriceContract currentV_Sale_PriceContract)
        {
            this.ObjectContext.V_Sale_PriceContract.AttachAsModified(currentV_Sale_PriceContract, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract));
        }

        public void DeleteV_Sale_PriceContract(V_Sale_PriceContract v_Sale_PriceContract)
        {
            if ((v_Sale_PriceContract.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract.Attach(v_Sale_PriceContract);
                this.ObjectContext.V_Sale_PriceContract.DeleteObject(v_Sale_PriceContract);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_CusGroup' query.
        public IQueryable<V_Sale_PriceContract_CusGroup> GetV_Sale_PriceContract_CusGroup()
        {
            return this.ObjectContext.V_Sale_PriceContract_CusGroup;
        }

        public void InsertV_Sale_PriceContract_CusGroup(V_Sale_PriceContract_CusGroup v_Sale_PriceContract_CusGroup)
        {
            if ((v_Sale_PriceContract_CusGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_CusGroup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_CusGroup.AddObject(v_Sale_PriceContract_CusGroup);
            }
        }

        public void UpdateV_Sale_PriceContract_CusGroup(V_Sale_PriceContract_CusGroup currentV_Sale_PriceContract_CusGroup)
        {
            this.ObjectContext.V_Sale_PriceContract_CusGroup.AttachAsModified(currentV_Sale_PriceContract_CusGroup, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_CusGroup));
        }

        public void DeleteV_Sale_PriceContract_CusGroup(V_Sale_PriceContract_CusGroup v_Sale_PriceContract_CusGroup)
        {
            if ((v_Sale_PriceContract_CusGroup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_CusGroup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_CusGroup.Attach(v_Sale_PriceContract_CusGroup);
                this.ObjectContext.V_Sale_PriceContract_CusGroup.DeleteObject(v_Sale_PriceContract_CusGroup);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_CusGroup_CusCode' query.
        public IQueryable<V_Sale_PriceContract_CusGroup_CusCode> GetV_Sale_PriceContract_CusGroup_CusCode()
        {
            return this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode;
        }

        public void InsertV_Sale_PriceContract_CusGroup_CusCode(V_Sale_PriceContract_CusGroup_CusCode v_Sale_PriceContract_CusGroup_CusCode)
        {
            if ((v_Sale_PriceContract_CusGroup_CusCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_CusGroup_CusCode, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.AddObject(v_Sale_PriceContract_CusGroup_CusCode);
            }
        }

        public void UpdateV_Sale_PriceContract_CusGroup_CusCode(V_Sale_PriceContract_CusGroup_CusCode currentV_Sale_PriceContract_CusGroup_CusCode)
        {
            this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.AttachAsModified(currentV_Sale_PriceContract_CusGroup_CusCode, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_CusGroup_CusCode));
        }

        public void DeleteV_Sale_PriceContract_CusGroup_CusCode(V_Sale_PriceContract_CusGroup_CusCode v_Sale_PriceContract_CusGroup_CusCode)
        {
            if ((v_Sale_PriceContract_CusGroup_CusCode.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_CusGroup_CusCode, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.Attach(v_Sale_PriceContract_CusGroup_CusCode);
                this.ObjectContext.V_Sale_PriceContract_CusGroup_CusCode.DeleteObject(v_Sale_PriceContract_CusGroup_CusCode);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_Frame' query.
        public IQueryable<V_Sale_PriceContract_Frame> GetV_Sale_PriceContract_Frame()
        {
            return this.ObjectContext.V_Sale_PriceContract_Frame;
        }

        public void InsertV_Sale_PriceContract_Frame(V_Sale_PriceContract_Frame v_Sale_PriceContract_Frame)
        {
            if ((v_Sale_PriceContract_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Frame, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Frame.AddObject(v_Sale_PriceContract_Frame);
            }
        }

        public void UpdateV_Sale_PriceContract_Frame(V_Sale_PriceContract_Frame currentV_Sale_PriceContract_Frame)
        {
            this.ObjectContext.V_Sale_PriceContract_Frame.AttachAsModified(currentV_Sale_PriceContract_Frame, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_Frame));
        }

        public void DeleteV_Sale_PriceContract_Frame(V_Sale_PriceContract_Frame v_Sale_PriceContract_Frame)
        {
            if ((v_Sale_PriceContract_Frame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Frame, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Frame.Attach(v_Sale_PriceContract_Frame);
                this.ObjectContext.V_Sale_PriceContract_Frame.DeleteObject(v_Sale_PriceContract_Frame);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_FrameSet' query.
        public IQueryable<V_Sale_PriceContract_FrameSet> GetV_Sale_PriceContract_FrameSet()
        {
            return this.ObjectContext.V_Sale_PriceContract_FrameSet;
        }

        public void InsertV_Sale_PriceContract_FrameSet(V_Sale_PriceContract_FrameSet v_Sale_PriceContract_FrameSet)
        {
            if ((v_Sale_PriceContract_FrameSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_FrameSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_FrameSet.AddObject(v_Sale_PriceContract_FrameSet);
            }
        }

        public void UpdateV_Sale_PriceContract_FrameSet(V_Sale_PriceContract_FrameSet currentV_Sale_PriceContract_FrameSet)
        {
            this.ObjectContext.V_Sale_PriceContract_FrameSet.AttachAsModified(currentV_Sale_PriceContract_FrameSet, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_FrameSet));
        }

        public void DeleteV_Sale_PriceContract_FrameSet(V_Sale_PriceContract_FrameSet v_Sale_PriceContract_FrameSet)
        {
            if ((v_Sale_PriceContract_FrameSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_FrameSet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_FrameSet.Attach(v_Sale_PriceContract_FrameSet);
                this.ObjectContext.V_Sale_PriceContract_FrameSet.DeleteObject(v_Sale_PriceContract_FrameSet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_Lens' query.
        public IQueryable<V_Sale_PriceContract_Lens> GetV_Sale_PriceContract_Lens()
        {
            return this.ObjectContext.V_Sale_PriceContract_Lens;
        }

        public void InsertV_Sale_PriceContract_Lens(V_Sale_PriceContract_Lens v_Sale_PriceContract_Lens)
        {
            if ((v_Sale_PriceContract_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Lens.AddObject(v_Sale_PriceContract_Lens);
            }
        }

        public void UpdateV_Sale_PriceContract_Lens(V_Sale_PriceContract_Lens currentV_Sale_PriceContract_Lens)
        {
            this.ObjectContext.V_Sale_PriceContract_Lens.AttachAsModified(currentV_Sale_PriceContract_Lens, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_Lens));
        }

        public void DeleteV_Sale_PriceContract_Lens(V_Sale_PriceContract_Lens v_Sale_PriceContract_Lens)
        {
            if ((v_Sale_PriceContract_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Lens.Attach(v_Sale_PriceContract_Lens);
                this.ObjectContext.V_Sale_PriceContract_Lens.DeleteObject(v_Sale_PriceContract_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_PriceContract_Lens_ProCost' query.
        public IQueryable<V_Sale_PriceContract_Lens_ProCost> GetV_Sale_PriceContract_Lens_ProCost()
        {
            return this.ObjectContext.V_Sale_PriceContract_Lens_ProCost;
        }

        public void InsertV_Sale_PriceContract_Lens_ProCost(V_Sale_PriceContract_Lens_ProCost v_Sale_PriceContract_Lens_ProCost)
        {
            if ((v_Sale_PriceContract_Lens_ProCost.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Lens_ProCost, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Lens_ProCost.AddObject(v_Sale_PriceContract_Lens_ProCost);
            }
        }

        public void UpdateV_Sale_PriceContract_Lens_ProCost(V_Sale_PriceContract_Lens_ProCost currentV_Sale_PriceContract_Lens_ProCost)
        {
            this.ObjectContext.V_Sale_PriceContract_Lens_ProCost.AttachAsModified(currentV_Sale_PriceContract_Lens_ProCost, this.ChangeSet.GetOriginal(currentV_Sale_PriceContract_Lens_ProCost));
        }

        public void DeleteV_Sale_PriceContract_Lens_ProCost(V_Sale_PriceContract_Lens_ProCost v_Sale_PriceContract_Lens_ProCost)
        {
            if ((v_Sale_PriceContract_Lens_ProCost.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_PriceContract_Lens_ProCost, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_PriceContract_Lens_ProCost.Attach(v_Sale_PriceContract_Lens_ProCost);
                this.ObjectContext.V_Sale_PriceContract_Lens_ProCost.DeleteObject(v_Sale_PriceContract_Lens_ProCost);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Quote' query.
        public IQueryable<V_Sale_Quote> GetV_Sale_Quote()
        {
            return this.ObjectContext.V_Sale_Quote;
        }

        public void InsertV_Sale_Quote(V_Sale_Quote v_Sale_Quote)
        {
            if ((v_Sale_Quote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Quote, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Quote.AddObject(v_Sale_Quote);
            }
        }

        public void UpdateV_Sale_Quote(V_Sale_Quote currentV_Sale_Quote)
        {
            this.ObjectContext.V_Sale_Quote.AttachAsModified(currentV_Sale_Quote, this.ChangeSet.GetOriginal(currentV_Sale_Quote));
        }

        public void DeleteV_Sale_Quote(V_Sale_Quote v_Sale_Quote)
        {
            if ((v_Sale_Quote.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Quote, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Quote.Attach(v_Sale_Quote);
                this.ObjectContext.V_Sale_Quote.DeleteObject(v_Sale_Quote);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Report_CGSD' query.
        public IQueryable<V_Sale_Report_CGSD> GetV_Sale_Report_CGSD()
        {
            return this.ObjectContext.V_Sale_Report_CGSD;
        }

        public void InsertV_Sale_Report_CGSD(V_Sale_Report_CGSD v_Sale_Report_CGSD)
        {
            if ((v_Sale_Report_CGSD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Report_CGSD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Report_CGSD.AddObject(v_Sale_Report_CGSD);
            }
        }

        public void UpdateV_Sale_Report_CGSD(V_Sale_Report_CGSD currentV_Sale_Report_CGSD)
        {
            this.ObjectContext.V_Sale_Report_CGSD.AttachAsModified(currentV_Sale_Report_CGSD, this.ChangeSet.GetOriginal(currentV_Sale_Report_CGSD));
        }

        public void DeleteV_Sale_Report_CGSD(V_Sale_Report_CGSD v_Sale_Report_CGSD)
        {
            if ((v_Sale_Report_CGSD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Report_CGSD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Report_CGSD.Attach(v_Sale_Report_CGSD);
                this.ObjectContext.V_Sale_Report_CGSD.DeleteObject(v_Sale_Report_CGSD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Sale_Report_Lens' query.
        public IQueryable<V_Sale_Report_Lens> GetV_Sale_Report_Lens()
        {
            return this.ObjectContext.V_Sale_Report_Lens;
        }

        public void InsertV_Sale_Report_Lens(V_Sale_Report_Lens v_Sale_Report_Lens)
        {
            if ((v_Sale_Report_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Report_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Sale_Report_Lens.AddObject(v_Sale_Report_Lens);
            }
        }

        public void UpdateV_Sale_Report_Lens(V_Sale_Report_Lens currentV_Sale_Report_Lens)
        {
            this.ObjectContext.V_Sale_Report_Lens.AttachAsModified(currentV_Sale_Report_Lens, this.ChangeSet.GetOriginal(currentV_Sale_Report_Lens));
        }

        public void DeleteV_Sale_Report_Lens(V_Sale_Report_Lens v_Sale_Report_Lens)
        {
            if ((v_Sale_Report_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Sale_Report_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Sale_Report_Lens.Attach(v_Sale_Report_Lens);
                this.ObjectContext.V_Sale_Report_Lens.DeleteObject(v_Sale_Report_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Count_Lens' query.
        public IQueryable<V_Ware_Bill_Count_Lens> GetV_Ware_Bill_Count_Lens()
        {
            return this.ObjectContext.V_Ware_Bill_Count_Lens;
        }

        public void InsertV_Ware_Bill_Count_Lens(V_Ware_Bill_Count_Lens v_Ware_Bill_Count_Lens)
        {
            if ((v_Ware_Bill_Count_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_Lens.AddObject(v_Ware_Bill_Count_Lens);
            }
        }

        public void UpdateV_Ware_Bill_Count_Lens(V_Ware_Bill_Count_Lens currentV_Ware_Bill_Count_Lens)
        {
            this.ObjectContext.V_Ware_Bill_Count_Lens.AttachAsModified(currentV_Ware_Bill_Count_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Count_Lens));
        }

        public void DeleteV_Ware_Bill_Count_Lens(V_Ware_Bill_Count_Lens v_Ware_Bill_Count_Lens)
        {
            if ((v_Ware_Bill_Count_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_Lens.Attach(v_Ware_Bill_Count_Lens);
                this.ObjectContext.V_Ware_Bill_Count_Lens.DeleteObject(v_Ware_Bill_Count_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Count_PD' query.
        public IQueryable<V_Ware_Bill_Count_PD> GetV_Ware_Bill_Count_PD()
        {
            return this.ObjectContext.V_Ware_Bill_Count_PD;
        }

        public void InsertV_Ware_Bill_Count_PD(V_Ware_Bill_Count_PD v_Ware_Bill_Count_PD)
        {
            if ((v_Ware_Bill_Count_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_PD.AddObject(v_Ware_Bill_Count_PD);
            }
        }

        public void UpdateV_Ware_Bill_Count_PD(V_Ware_Bill_Count_PD currentV_Ware_Bill_Count_PD)
        {
            this.ObjectContext.V_Ware_Bill_Count_PD.AttachAsModified(currentV_Ware_Bill_Count_PD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Count_PD));
        }

        public void DeleteV_Ware_Bill_Count_PD(V_Ware_Bill_Count_PD v_Ware_Bill_Count_PD)
        {
            if ((v_Ware_Bill_Count_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_PD.Attach(v_Ware_Bill_Count_PD);
                this.ObjectContext.V_Ware_Bill_Count_PD.DeleteObject(v_Ware_Bill_Count_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Count_PD_Detail' query.
        public IQueryable<V_Ware_Bill_Count_PD_Detail> GetV_Ware_Bill_Count_PD_Detail()
        {
            return this.ObjectContext.V_Ware_Bill_Count_PD_Detail;
        }

        public void InsertV_Ware_Bill_Count_PD_Detail(V_Ware_Bill_Count_PD_Detail v_Ware_Bill_Count_PD_Detail)
        {
            if ((v_Ware_Bill_Count_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_PD_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_PD_Detail.AddObject(v_Ware_Bill_Count_PD_Detail);
            }
        }

        public void UpdateV_Ware_Bill_Count_PD_Detail(V_Ware_Bill_Count_PD_Detail currentV_Ware_Bill_Count_PD_Detail)
        {
            this.ObjectContext.V_Ware_Bill_Count_PD_Detail.AttachAsModified(currentV_Ware_Bill_Count_PD_Detail, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Count_PD_Detail));
        }

        public void DeleteV_Ware_Bill_Count_PD_Detail(V_Ware_Bill_Count_PD_Detail v_Ware_Bill_Count_PD_Detail)
        {
            if ((v_Ware_Bill_Count_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Count_PD_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Count_PD_Detail.Attach(v_Ware_Bill_Count_PD_Detail);
                this.ObjectContext.V_Ware_Bill_Count_PD_Detail.DeleteObject(v_Ware_Bill_Count_PD_Detail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Lens' query.
        public IQueryable<V_Ware_Bill_Lens> GetV_Ware_Bill_Lens()
        {
            return this.ObjectContext.V_Ware_Bill_Lens;
        }

        public void InsertV_Ware_Bill_Lens(V_Ware_Bill_Lens v_Ware_Bill_Lens)
        {
            if ((v_Ware_Bill_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Lens.AddObject(v_Ware_Bill_Lens);
            }
        }

        public void UpdateV_Ware_Bill_Lens(V_Ware_Bill_Lens currentV_Ware_Bill_Lens)
        {
            this.ObjectContext.V_Ware_Bill_Lens.AttachAsModified(currentV_Ware_Bill_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Lens));
        }

        public void DeleteV_Ware_Bill_Lens(V_Ware_Bill_Lens v_Ware_Bill_Lens)
        {
            if ((v_Ware_Bill_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Lens.Attach(v_Ware_Bill_Lens);
                this.ObjectContext.V_Ware_Bill_Lens.DeleteObject(v_Ware_Bill_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_PD' query.
        public IQueryable<V_Ware_Bill_PD> GetV_Ware_Bill_PD()
        {
            return this.ObjectContext.V_Ware_Bill_PD;
        }

        public void InsertV_Ware_Bill_PD(V_Ware_Bill_PD v_Ware_Bill_PD)
        {
            if ((v_Ware_Bill_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_PD.AddObject(v_Ware_Bill_PD);
            }
        }

        public void UpdateV_Ware_Bill_PD(V_Ware_Bill_PD currentV_Ware_Bill_PD)
        {
            this.ObjectContext.V_Ware_Bill_PD.AttachAsModified(currentV_Ware_Bill_PD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_PD));
        }

        public void DeleteV_Ware_Bill_PD(V_Ware_Bill_PD v_Ware_Bill_PD)
        {
            if ((v_Ware_Bill_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_PD.Attach(v_Ware_Bill_PD);
                this.ObjectContext.V_Ware_Bill_PD.DeleteObject(v_Ware_Bill_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_PD_Detail' query.
        public IQueryable<V_Ware_Bill_PD_Detail> GetV_Ware_Bill_PD_Detail()
        {
            return this.ObjectContext.V_Ware_Bill_PD_Detail;
        }

        public void InsertV_Ware_Bill_PD_Detail(V_Ware_Bill_PD_Detail v_Ware_Bill_PD_Detail)
        {
            if ((v_Ware_Bill_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_PD_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_PD_Detail.AddObject(v_Ware_Bill_PD_Detail);
            }
        }

        public void UpdateV_Ware_Bill_PD_Detail(V_Ware_Bill_PD_Detail currentV_Ware_Bill_PD_Detail)
        {
            this.ObjectContext.V_Ware_Bill_PD_Detail.AttachAsModified(currentV_Ware_Bill_PD_Detail, this.ChangeSet.GetOriginal(currentV_Ware_Bill_PD_Detail));
        }

        public void DeleteV_Ware_Bill_PD_Detail(V_Ware_Bill_PD_Detail v_Ware_Bill_PD_Detail)
        {
            if ((v_Ware_Bill_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_PD_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_PD_Detail.Attach(v_Ware_Bill_PD_Detail);
                this.ObjectContext.V_Ware_Bill_PD_Detail.DeleteObject(v_Ware_Bill_PD_Detail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_Lens' query.
        public IQueryable<V_Ware_Bill_SO_Lens> GetV_Ware_Bill_SO_Lens()
        {
            return this.ObjectContext.V_Ware_Bill_SO_Lens;
        }

        public void InsertV_Ware_Bill_SO_Lens(V_Ware_Bill_SO_Lens v_Ware_Bill_SO_Lens)
        {
            if ((v_Ware_Bill_SO_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Lens.AddObject(v_Ware_Bill_SO_Lens);
            }
        }

        public void UpdateV_Ware_Bill_SO_Lens(V_Ware_Bill_SO_Lens currentV_Ware_Bill_SO_Lens)
        {
            this.ObjectContext.V_Ware_Bill_SO_Lens.AttachAsModified(currentV_Ware_Bill_SO_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_Lens));
        }

        public void DeleteV_Ware_Bill_SO_Lens(V_Ware_Bill_SO_Lens v_Ware_Bill_SO_Lens)
        {
            if ((v_Ware_Bill_SO_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Lens.Attach(v_Ware_Bill_SO_Lens);
                this.ObjectContext.V_Ware_Bill_SO_Lens.DeleteObject(v_Ware_Bill_SO_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_PD' query.
        public IQueryable<V_Ware_Bill_SO_PD> GetV_Ware_Bill_SO_PD()
        {
            return this.ObjectContext.V_Ware_Bill_SO_PD;
        }

        public void InsertV_Ware_Bill_SO_PD(V_Ware_Bill_SO_PD v_Ware_Bill_SO_PD)
        {
            if ((v_Ware_Bill_SO_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_PD.AddObject(v_Ware_Bill_SO_PD);
            }
        }

        public void UpdateV_Ware_Bill_SO_PD(V_Ware_Bill_SO_PD currentV_Ware_Bill_SO_PD)
        {
            this.ObjectContext.V_Ware_Bill_SO_PD.AttachAsModified(currentV_Ware_Bill_SO_PD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_PD));
        }

        public void DeleteV_Ware_Bill_SO_PD(V_Ware_Bill_SO_PD v_Ware_Bill_SO_PD)
        {
            if ((v_Ware_Bill_SO_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_PD.Attach(v_Ware_Bill_SO_PD);
                this.ObjectContext.V_Ware_Bill_SO_PD.DeleteObject(v_Ware_Bill_SO_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_PD_Detail' query.
        public IQueryable<V_Ware_Bill_SO_PD_Detail> GetV_Ware_Bill_SO_PD_Detail()
        {
            return this.ObjectContext.V_Ware_Bill_SO_PD_Detail;
        }

        public void InsertV_Ware_Bill_SO_PD_Detail(V_Ware_Bill_SO_PD_Detail v_Ware_Bill_SO_PD_Detail)
        {
            if ((v_Ware_Bill_SO_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_PD_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_PD_Detail.AddObject(v_Ware_Bill_SO_PD_Detail);
            }
        }

        public void UpdateV_Ware_Bill_SO_PD_Detail(V_Ware_Bill_SO_PD_Detail currentV_Ware_Bill_SO_PD_Detail)
        {
            this.ObjectContext.V_Ware_Bill_SO_PD_Detail.AttachAsModified(currentV_Ware_Bill_SO_PD_Detail, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_PD_Detail));
        }

        public void DeleteV_Ware_Bill_SO_PD_Detail(V_Ware_Bill_SO_PD_Detail v_Ware_Bill_SO_PD_Detail)
        {
            if ((v_Ware_Bill_SO_PD_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_PD_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_PD_Detail.Attach(v_Ware_Bill_SO_PD_Detail);
                this.ObjectContext.V_Ware_Bill_SO_PD_Detail.DeleteObject(v_Ware_Bill_SO_PD_Detail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_Pending_PD' query.
        public IQueryable<V_Ware_Bill_SO_Pending_PD> GetV_Ware_Bill_SO_Pending_PD()
        {
            return this.ObjectContext.V_Ware_Bill_SO_Pending_PD;
        }

        public void InsertV_Ware_Bill_SO_Pending_PD(V_Ware_Bill_SO_Pending_PD v_Ware_Bill_SO_Pending_PD)
        {
            if ((v_Ware_Bill_SO_Pending_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pending_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pending_PD.AddObject(v_Ware_Bill_SO_Pending_PD);
            }
        }

        public void UpdateV_Ware_Bill_SO_Pending_PD(V_Ware_Bill_SO_Pending_PD currentV_Ware_Bill_SO_Pending_PD)
        {
            this.ObjectContext.V_Ware_Bill_SO_Pending_PD.AttachAsModified(currentV_Ware_Bill_SO_Pending_PD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_Pending_PD));
        }

        public void DeleteV_Ware_Bill_SO_Pending_PD(V_Ware_Bill_SO_Pending_PD v_Ware_Bill_SO_Pending_PD)
        {
            if ((v_Ware_Bill_SO_Pending_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pending_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pending_PD.Attach(v_Ware_Bill_SO_Pending_PD);
                this.ObjectContext.V_Ware_Bill_SO_Pending_PD.DeleteObject(v_Ware_Bill_SO_Pending_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_Pre_Lens' query.
        public IQueryable<V_Ware_Bill_SO_Pre_Lens> GetV_Ware_Bill_SO_Pre_Lens()
        {
            return this.ObjectContext.V_Ware_Bill_SO_Pre_Lens;
        }

        public void InsertV_Ware_Bill_SO_Pre_Lens(V_Ware_Bill_SO_Pre_Lens v_Ware_Bill_SO_Pre_Lens)
        {
            if ((v_Ware_Bill_SO_Pre_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pre_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pre_Lens.AddObject(v_Ware_Bill_SO_Pre_Lens);
            }
        }

        public void UpdateV_Ware_Bill_SO_Pre_Lens(V_Ware_Bill_SO_Pre_Lens currentV_Ware_Bill_SO_Pre_Lens)
        {
            this.ObjectContext.V_Ware_Bill_SO_Pre_Lens.AttachAsModified(currentV_Ware_Bill_SO_Pre_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_Pre_Lens));
        }

        public void DeleteV_Ware_Bill_SO_Pre_Lens(V_Ware_Bill_SO_Pre_Lens v_Ware_Bill_SO_Pre_Lens)
        {
            if ((v_Ware_Bill_SO_Pre_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pre_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pre_Lens.Attach(v_Ware_Bill_SO_Pre_Lens);
                this.ObjectContext.V_Ware_Bill_SO_Pre_Lens.DeleteObject(v_Ware_Bill_SO_Pre_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_Pre_SD' query.
        public IQueryable<V_Ware_Bill_SO_Pre_SD> GetV_Ware_Bill_SO_Pre_SD()
        {
            return this.ObjectContext.V_Ware_Bill_SO_Pre_SD;
        }

        public void InsertV_Ware_Bill_SO_Pre_SD(V_Ware_Bill_SO_Pre_SD v_Ware_Bill_SO_Pre_SD)
        {
            if ((v_Ware_Bill_SO_Pre_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pre_SD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pre_SD.AddObject(v_Ware_Bill_SO_Pre_SD);
            }
        }

        public void UpdateV_Ware_Bill_SO_Pre_SD(V_Ware_Bill_SO_Pre_SD currentV_Ware_Bill_SO_Pre_SD)
        {
            this.ObjectContext.V_Ware_Bill_SO_Pre_SD.AttachAsModified(currentV_Ware_Bill_SO_Pre_SD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_Pre_SD));
        }

        public void DeleteV_Ware_Bill_SO_Pre_SD(V_Ware_Bill_SO_Pre_SD v_Ware_Bill_SO_Pre_SD)
        {
            if ((v_Ware_Bill_SO_Pre_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_Pre_SD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_Pre_SD.Attach(v_Ware_Bill_SO_Pre_SD);
                this.ObjectContext.V_Ware_Bill_SO_Pre_SD.DeleteObject(v_Ware_Bill_SO_Pre_SD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_SO_SD' query.
        public IQueryable<V_Ware_Bill_SO_SD> GetV_Ware_Bill_SO_SD()
        {
            return this.ObjectContext.V_Ware_Bill_SO_SD;
        }

        public void InsertV_Ware_Bill_SO_SD(V_Ware_Bill_SO_SD v_Ware_Bill_SO_SD)
        {
            if ((v_Ware_Bill_SO_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_SD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_SD.AddObject(v_Ware_Bill_SO_SD);
            }
        }

        public void UpdateV_Ware_Bill_SO_SD(V_Ware_Bill_SO_SD currentV_Ware_Bill_SO_SD)
        {
            this.ObjectContext.V_Ware_Bill_SO_SD.AttachAsModified(currentV_Ware_Bill_SO_SD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_SO_SD));
        }

        public void DeleteV_Ware_Bill_SO_SD(V_Ware_Bill_SO_SD v_Ware_Bill_SO_SD)
        {
            if ((v_Ware_Bill_SO_SD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_SO_SD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_SO_SD.Attach(v_Ware_Bill_SO_SD);
                this.ObjectContext.V_Ware_Bill_SO_SD.DeleteObject(v_Ware_Bill_SO_SD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Transfer_Lens' query.
        public IQueryable<V_Ware_Bill_Transfer_Lens> GetV_Ware_Bill_Transfer_Lens()
        {
            return this.ObjectContext.V_Ware_Bill_Transfer_Lens;
        }

        public void InsertV_Ware_Bill_Transfer_Lens(V_Ware_Bill_Transfer_Lens v_Ware_Bill_Transfer_Lens)
        {
            if ((v_Ware_Bill_Transfer_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Transfer_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Transfer_Lens.AddObject(v_Ware_Bill_Transfer_Lens);
            }
        }

        public void UpdateV_Ware_Bill_Transfer_Lens(V_Ware_Bill_Transfer_Lens currentV_Ware_Bill_Transfer_Lens)
        {
            this.ObjectContext.V_Ware_Bill_Transfer_Lens.AttachAsModified(currentV_Ware_Bill_Transfer_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Transfer_Lens));
        }

        public void DeleteV_Ware_Bill_Transfer_Lens(V_Ware_Bill_Transfer_Lens v_Ware_Bill_Transfer_Lens)
        {
            if ((v_Ware_Bill_Transfer_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Transfer_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Transfer_Lens.Attach(v_Ware_Bill_Transfer_Lens);
                this.ObjectContext.V_Ware_Bill_Transfer_Lens.DeleteObject(v_Ware_Bill_Transfer_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Bill_Transfer_PD' query.
        public IQueryable<V_Ware_Bill_Transfer_PD> GetV_Ware_Bill_Transfer_PD()
        {
            return this.ObjectContext.V_Ware_Bill_Transfer_PD;
        }

        public void InsertV_Ware_Bill_Transfer_PD(V_Ware_Bill_Transfer_PD v_Ware_Bill_Transfer_PD)
        {
            if ((v_Ware_Bill_Transfer_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Transfer_PD, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Transfer_PD.AddObject(v_Ware_Bill_Transfer_PD);
            }
        }

        public void UpdateV_Ware_Bill_Transfer_PD(V_Ware_Bill_Transfer_PD currentV_Ware_Bill_Transfer_PD)
        {
            this.ObjectContext.V_Ware_Bill_Transfer_PD.AttachAsModified(currentV_Ware_Bill_Transfer_PD, this.ChangeSet.GetOriginal(currentV_Ware_Bill_Transfer_PD));
        }

        public void DeleteV_Ware_Bill_Transfer_PD(V_Ware_Bill_Transfer_PD v_Ware_Bill_Transfer_PD)
        {
            if ((v_Ware_Bill_Transfer_PD.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Bill_Transfer_PD, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Bill_Transfer_PD.Attach(v_Ware_Bill_Transfer_PD);
                this.ObjectContext.V_Ware_Bill_Transfer_PD.DeleteObject(v_Ware_Bill_Transfer_PD);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Report_IO_Lens' query.
        public IQueryable<V_Ware_Report_IO_Lens> GetV_Ware_Report_IO_Lens()
        {
            return this.ObjectContext.V_Ware_Report_IO_Lens;
        }

        public void InsertV_Ware_Report_IO_Lens(V_Ware_Report_IO_Lens v_Ware_Report_IO_Lens)
        {
            if ((v_Ware_Report_IO_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_IO_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_IO_Lens.AddObject(v_Ware_Report_IO_Lens);
            }
        }

        public void UpdateV_Ware_Report_IO_Lens(V_Ware_Report_IO_Lens currentV_Ware_Report_IO_Lens)
        {
            this.ObjectContext.V_Ware_Report_IO_Lens.AttachAsModified(currentV_Ware_Report_IO_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Report_IO_Lens));
        }

        public void DeleteV_Ware_Report_IO_Lens(V_Ware_Report_IO_Lens v_Ware_Report_IO_Lens)
        {
            if ((v_Ware_Report_IO_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_IO_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_IO_Lens.Attach(v_Ware_Report_IO_Lens);
                this.ObjectContext.V_Ware_Report_IO_Lens.DeleteObject(v_Ware_Report_IO_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Report_Stocks_Lens_Detail' query.
        public IQueryable<V_Ware_Report_Stocks_Lens_Detail> GetV_Ware_Report_Stocks_Lens_Detail()
        {
            return this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail;
        }

        public void InsertV_Ware_Report_Stocks_Lens_Detail(V_Ware_Report_Stocks_Lens_Detail v_Ware_Report_Stocks_Lens_Detail)
        {
            if ((v_Ware_Report_Stocks_Lens_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_Stocks_Lens_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail.AddObject(v_Ware_Report_Stocks_Lens_Detail);
            }
        }

        public void UpdateV_Ware_Report_Stocks_Lens_Detail(V_Ware_Report_Stocks_Lens_Detail currentV_Ware_Report_Stocks_Lens_Detail)
        {
            this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail.AttachAsModified(currentV_Ware_Report_Stocks_Lens_Detail, this.ChangeSet.GetOriginal(currentV_Ware_Report_Stocks_Lens_Detail));
        }

        public void DeleteV_Ware_Report_Stocks_Lens_Detail(V_Ware_Report_Stocks_Lens_Detail v_Ware_Report_Stocks_Lens_Detail)
        {
            if ((v_Ware_Report_Stocks_Lens_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_Stocks_Lens_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail.Attach(v_Ware_Report_Stocks_Lens_Detail);
                this.ObjectContext.V_Ware_Report_Stocks_Lens_Detail.DeleteObject(v_Ware_Report_Stocks_Lens_Detail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Report_Stocks_Lens_XY' query.
        public IQueryable<V_Ware_Report_Stocks_Lens_XY> GetV_Ware_Report_Stocks_Lens_XY()
        {
            return this.ObjectContext.V_Ware_Report_Stocks_Lens_XY;
        }

        public void InsertV_Ware_Report_Stocks_Lens_XY(V_Ware_Report_Stocks_Lens_XY v_Ware_Report_Stocks_Lens_XY)
        {
            if ((v_Ware_Report_Stocks_Lens_XY.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_Stocks_Lens_XY, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_Stocks_Lens_XY.AddObject(v_Ware_Report_Stocks_Lens_XY);
            }
        }

        public void UpdateV_Ware_Report_Stocks_Lens_XY(V_Ware_Report_Stocks_Lens_XY currentV_Ware_Report_Stocks_Lens_XY)
        {
            this.ObjectContext.V_Ware_Report_Stocks_Lens_XY.AttachAsModified(currentV_Ware_Report_Stocks_Lens_XY, this.ChangeSet.GetOriginal(currentV_Ware_Report_Stocks_Lens_XY));
        }

        public void DeleteV_Ware_Report_Stocks_Lens_XY(V_Ware_Report_Stocks_Lens_XY v_Ware_Report_Stocks_Lens_XY)
        {
            if ((v_Ware_Report_Stocks_Lens_XY.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Report_Stocks_Lens_XY, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Report_Stocks_Lens_XY.Attach(v_Ware_Report_Stocks_Lens_XY);
                this.ObjectContext.V_Ware_Report_Stocks_Lens_XY.DeleteObject(v_Ware_Report_Stocks_Lens_XY);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Stocks_Base_Lens' query.
        public IQueryable<V_Ware_Stocks_Base_Lens> GetV_Ware_Stocks_Base_Lens()
        {
            return this.ObjectContext.V_Ware_Stocks_Base_Lens;
        }

        public void InsertV_Ware_Stocks_Base_Lens(V_Ware_Stocks_Base_Lens v_Ware_Stocks_Base_Lens)
        {
            if ((v_Ware_Stocks_Base_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Stocks_Base_Lens, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Stocks_Base_Lens.AddObject(v_Ware_Stocks_Base_Lens);
            }
        }

        public void UpdateV_Ware_Stocks_Base_Lens(V_Ware_Stocks_Base_Lens currentV_Ware_Stocks_Base_Lens)
        {
            this.ObjectContext.V_Ware_Stocks_Base_Lens.AttachAsModified(currentV_Ware_Stocks_Base_Lens, this.ChangeSet.GetOriginal(currentV_Ware_Stocks_Base_Lens));
        }

        public void DeleteV_Ware_Stocks_Base_Lens(V_Ware_Stocks_Base_Lens v_Ware_Stocks_Base_Lens)
        {
            if ((v_Ware_Stocks_Base_Lens.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Stocks_Base_Lens, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Stocks_Base_Lens.Attach(v_Ware_Stocks_Base_Lens);
                this.ObjectContext.V_Ware_Stocks_Base_Lens.DeleteObject(v_Ware_Stocks_Base_Lens);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'V_Ware_Stocks_Base_Lens_Detail' query.
        public IQueryable<V_Ware_Stocks_Base_Lens_Detail> GetV_Ware_Stocks_Base_Lens_Detail()
        {
            return this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail;
        }

        public void InsertV_Ware_Stocks_Base_Lens_Detail(V_Ware_Stocks_Base_Lens_Detail v_Ware_Stocks_Base_Lens_Detail)
        {
            if ((v_Ware_Stocks_Base_Lens_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Stocks_Base_Lens_Detail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.AddObject(v_Ware_Stocks_Base_Lens_Detail);
            }
        }

        public void UpdateV_Ware_Stocks_Base_Lens_Detail(V_Ware_Stocks_Base_Lens_Detail currentV_Ware_Stocks_Base_Lens_Detail)
        {
            this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.AttachAsModified(currentV_Ware_Stocks_Base_Lens_Detail, this.ChangeSet.GetOriginal(currentV_Ware_Stocks_Base_Lens_Detail));
        }

        public void DeleteV_Ware_Stocks_Base_Lens_Detail(V_Ware_Stocks_Base_Lens_Detail v_Ware_Stocks_Base_Lens_Detail)
        {
            if ((v_Ware_Stocks_Base_Lens_Detail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_Ware_Stocks_Base_Lens_Detail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.Attach(v_Ware_Stocks_Base_Lens_Detail);
                this.ObjectContext.V_Ware_Stocks_Base_Lens_Detail.DeleteObject(v_Ware_Stocks_Base_Lens_Detail);
            }
        }
    }
}


