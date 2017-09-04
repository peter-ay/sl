using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    public partial class VMLocator
    {
        partial void RegisterViewModelMan()
        {
            SimpleIoc.Default.Register<VMM_User_List>();
            SimpleIoc.Default.Register<VMM_User>();
            SimpleIoc.Default.Register<VMM_UserGroup>();
            SimpleIoc.Default.Register<VMM_UserGroup_List>();
            SimpleIoc.Default.Register<VMM_UserGroup_DataBase_List>();
            SimpleIoc.Default.Register<VMM_UserGroup_User_List>();
            SimpleIoc.Default.Register<VMM_UserGroup_Rights_List>();
            SimpleIoc.Default.Register<VMM_Log_List>();
            //SimpleIoc.Default.Register<VMM_GroupDataBaseAssign>();
            //SimpleIoc.Default.Register<VMM_GroupUserAssign>();
            //SimpleIoc.Default.Register<VMM_GroupAssign>();
            //SimpleIoc.Default.Register<VMM_UserAssign>();
        }

        public VMM_User_List M_User_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_User_List>();
            }
        }

        public VMM_User M_User
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_User>();
            }
        }

        public VMM_UserGroup M_UserGroup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_UserGroup>();
            }
        }

        public VMM_UserGroup_List M_UserGroup_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_UserGroup_List>();
            }
        }
        //VMMan_User_DataBase_List
        public VMM_UserGroup_DataBase_List M_UserGroup_DataBase_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_UserGroup_DataBase_List>();
            }
        }
        //VMMan_User_Group_List
        public VMM_UserGroup_User_List M_UserGroup_User_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_UserGroup_User_List>();
            }
        }
        //Man_GroupAuthorityAssign_List
        public VMM_UserGroup_Rights_List M_UserGroup_Rights_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_UserGroup_Rights_List>();
            }
        }
        //VMMan_Log_List
        public VMM_Log_List M_Log_List
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMM_Log_List>();
            }
        }
        //VMM_GroupDataBaseAssign
        //public VMM_GroupDataBaseAssign M_GroupDataBaseAssign
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMM_GroupDataBaseAssign>();
        //    }
        //}
        //VMM_GroupUserssign
        //public VMM_GroupUserAssign M_GroupUserAssign
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMM_GroupUserAssign>();
        //    }
        //}
        //VMMan_GroupAssign
        //public VMM_GroupAssign M_GroupAssign
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMM_GroupAssign>();
        //    }
        //}
        //VMMan_User
        //public VMM_UserAssign M_UserAssign
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<VMM_UserAssign>();
        //    }
        //}
    }
}
