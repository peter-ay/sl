
using ERP.Utility;
namespace ERP.View
{
    public class ButtonHome_Pur_Bill : ButtonHome
    {
        public ButtonHome_Pur_Bill()
            : base("採購訂單編制", "Purchase_Bill_Mnumber", UImagePaths.bill) { }
    }

    public class ButtonHome_Pur_Bill_Frame : ButtonHome
    {
        public ButtonHome_Pur_Bill_Frame()
            : base("鏡架採購訂單", "Purchase_Bill_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_Pur_Bill_Return : ButtonHome
    {
        public ButtonHome_Pur_Bill_Return()
            : base("採購退廠單", "Purchase_Bill_Return", UImagePaths.bill) { }
    }

    public class ButtonHome_Pur_Bill_Return_Frame : ButtonHome
    {
        public ButtonHome_Pur_Bill_Return_Frame()
            : base("鏡架採購退廠單", "Purchase_Bill_Return_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_Pur_List : ButtonHome
    {
        public ButtonHome_Pur_List()
            : base("採購訂單列表", "Purchase_OrderBill_List", UImagePaths.list) { }
    }

    public class ButtonHome_Pur_List_Frame : ButtonHome
    {
        public ButtonHome_Pur_List_Frame()
            : base("鏡架採購列表", "Purchase_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_Pur_List_Return : ButtonHome
    {
        public ButtonHome_Pur_List_Return()
            : base("退廠單列表", "Purchase_Return_List", UImagePaths.list) { }
    }

    public class ButtonHome_Pur_List_Return_Frame : ButtonHome
    {
        public ButtonHome_Pur_List_Return_Frame()
            : base("鏡架退廠單列表", "Purchase_Return_Frame_List", UImagePaths.list) { }
    }

}
