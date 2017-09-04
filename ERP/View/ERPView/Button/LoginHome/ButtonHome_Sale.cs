
using ERP.Utility;
namespace ERP.View
{
    public class ButtonHome_SD : ButtonHome
    {
        public ButtonHome_SD()
            : base("散訂單編制", "Sale_Bill_Mnumber_SD", UImagePaths.bill) { }
    }

    public class ButtonHome_PD : ButtonHome
    {
        public ButtonHome_PD()
            : base("批量訂單編制", "Sale_Bill_Mnumber_PD", UImagePaths.bill) { }
    }

    public class ButtonHome_JM : ButtonHome
    {
        public ButtonHome_JM()
            : base("寄賣訂單編制", "Sale_Bill_Mnumber_JM", UImagePaths.bill) { }
    }

    public class ButtonHome_Frame : ButtonHome
    {
        public ButtonHome_Frame()
            : base("鏡架訂單編制", "Sale_Bill_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_FrameSet : ButtonHome
    {
        public ButtonHome_FrameSet()
            : base("鏡架套餐編制", "Sale_Bill_FrameSet", UImagePaths.bill) { }
    }

    public class ButtonHome_Return_SD : ButtonHome
    {
        public ButtonHome_Return_SD()
            : base("散訂退貨單", "Sale_Bill_Return_Mnumber_SD", UImagePaths.bill, 1) { }
    }

    public class ButtonHome_Return_PD : ButtonHome
    {
        public ButtonHome_Return_PD()
            : base("批量退貨單", "Sale_Bill_Return_Mnumber_PD", UImagePaths.bill, 1) { }
    }

    public class ButtonHome_Return_Frame : ButtonHome
    {
        public ButtonHome_Return_Frame()
            : base("鏡架退貨單", "Sale_Bill_Return_Frame", UImagePaths.bill, 1) { }
    }

    public class ButtonHome_Delivery : ButtonHome
    {
        public ButtonHome_Delivery()
            : base("交收單打印", "Sale_Bill_Delivery", UImagePaths.bill) { }
    }

    public class ButtonHome_SaleBillList : ButtonHome
    {
        public ButtonHome_SaleBillList()
            : base("訂單列表", "Sale_Bill_Mnumber_List", UImagePaths.list) { }
    }

    public class ButtonHome_SaleBillList_JM : ButtonHome
    {
        public ButtonHome_SaleBillList_JM()
            : base("寄賣訂單列表", "Sale_Bill_Mnumber_JM_List", UImagePaths.list) { }
    }

    public class ButtonHome_SaleBillList_Frame : ButtonHome
    {
        public ButtonHome_SaleBillList_Frame()
            : base("鏡架訂單列表", "Sale_Bill_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_SaleBillList_WebOrder : ButtonHome
    {
        public ButtonHome_SaleBillList_WebOrder()
            : base("網上訂單列表", "Sale_Bill_WebOrder_List", UImagePaths.list) { }
    }

    public class ButtonHome_SaleBillList_Return : ButtonHome
    {
        public ButtonHome_SaleBillList_Return()
            : base("退貨單列表", "Sale_Bill_Return_Mnumber_List", UImagePaths.list, 1) { }
    }

    public class ButtonHome_SaleBillList_Return_Frame : ButtonHome
    {
        public ButtonHome_SaleBillList_Return_Frame()
            : base("鏡架退貨單列表", "Sale_Bill_Return_Frame_List", UImagePaths.list, 1) { }
    }

    public class ButtonHome_SaleReportGereral : ButtonHome
    {
        public ButtonHome_SaleReportGereral()
            : base("銷售總賬", "Sale_Report_General_List", UImagePaths.report)
        {
        }
    }



}
