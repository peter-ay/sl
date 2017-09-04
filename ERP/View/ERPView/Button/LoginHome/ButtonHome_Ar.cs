
using ERP.Utility;
namespace ERP.View
{
    public class ButtonHome_Ar_List : ButtonHome
    {
        public ButtonHome_Ar_List()
            : base("應收對帳單", "AR_CusAcc_List", UImagePaths.list) { }
    }

    public class ButtonHome_Ar_List_Frame : ButtonHome
    {
        public ButtonHome_Ar_List_Frame()
            : base("鏡架應收對帳單", "AR_CusAcc_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_Ar_List_AccNum : ButtonHome
    {
        public ButtonHome_Ar_List_AccNum()
            : base("帳單管理", "AR_AccNum_List", UImagePaths.list) { }
    }

    //   <Button   x:Name="btn_AR_CusAcc" Content="應收對帳單"  Margin="0,0,4,0"/>
    //<Button   x:Name="btn_AR_CusAccNum_Frame" Content="鏡架應收對帳單"  Margin="0,4,4,0"/>
    //<Button   x:Name="btn_AR_CusAccNum" Content="帳單管理"  Margin="0,4,4,0"/>


}
