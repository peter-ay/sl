
using ERP.Utility;
namespace ERP.View
{
    public class ButtonHome_List_SellOut : ButtonHome
    {
        public ButtonHome_List_SellOut()
            : base("銷售出庫單列表", "WareHouse_Bill_Mnumber_SellOut", UImagePaths.list) { }
    }

    public class ButtonHome_BarCodeIn : ButtonHome
    {
        public ButtonHome_BarCodeIn()
            : base("條碼入庫單", "WareHouse_Bill_BarCodeIn", UImagePaths.bill) { }
    }

    public class ButtonHome_BarCodeOut : ButtonHome
    {
        public ButtonHome_BarCodeOut()
            : base("條碼出庫單", "WareHouse_Bill_BarCodeOut", UImagePaths.bill) { }
    }

    public class ButtonHome_List_BarCode : ButtonHome
    {
        public ButtonHome_List_BarCode()
            : base("條碼出入庫列表", "WareHouse_Bill_BarCode_Mnumber_List", UImagePaths.list) { }
    }

    public class ButtonHome_OtherIn : ButtonHome
    {
        public ButtonHome_OtherIn()
            : base("其他入庫單", "WareHouse_Bill_OtherIn", UImagePaths.bill) { }
    }

    public class ButtonHome_OtherOut : ButtonHome
    {
        public ButtonHome_OtherOut()
            : base("其他出庫單", "WareHouse_Bill_OtherOut", UImagePaths.bill) { }
    }

    public class ButtonHome_OtherOut_Frame : ButtonHome
    {
        public ButtonHome_OtherOut_Frame()
            : base("鏡架其他出庫", "WareHouse_Bill_OtherOut_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_OtherIn_Frame : ButtonHome
    {
        public ButtonHome_OtherIn_Frame()
            : base("鏡架其他入庫", "WareHouse_Bill_OtherIN_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_Inventory : ButtonHome
    {
        public ButtonHome_Inventory()
            : base("盤點單編制", "WareHouse_Bill_Inventory", UImagePaths.bill) { }
    }

    public class ButtonHome_Inventory_Frame : ButtonHome
    {
        public ButtonHome_Inventory_Frame()
            : base("鏡架盤點單", "WareHouse_Bill_Inventory_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_Transferring : ButtonHome
    {
        public ButtonHome_Transferring()
            : base("調撥單編制", "WareHouse_Bill_Transferring", UImagePaths.bill) { }
    }

    public class ButtonHome_Transferring_Frame : ButtonHome
    {
        public ButtonHome_Transferring_Frame()
            : base("鏡架調撥單", "WareHouse_Bill_Transferring_Frame", UImagePaths.bill) { }
    }

    public class ButtonHome_Stocks : ButtonHome
    {
        public ButtonHome_Stocks()
            : base("現存量表", "WareHouse_Stocks", UImagePaths.report) { }
    }

    public class ButtonHome_Day : ButtonHome
    {
        public ButtonHome_Day()
            : base("日報表", "WareHouse_Day_List", UImagePaths.report) { }
    }

    public class ButtonHome_Ledger : ButtonHome
    {
        public ButtonHome_Ledger()
            : base("流水帳", "WareHouse_Ledger_List", UImagePaths.report) { }
    }

    public class ButtonHome_List_InOut : ButtonHome
    {
        public ButtonHome_List_InOut()
            : base("其他出入庫列表", "WareHouse_InOutBill_List", UImagePaths.list) { }
    }

    public class ButtonHome_List_InOut_Frame : ButtonHome
    {
        public ButtonHome_List_InOut_Frame()
            : base("鏡架其他列表", "WareHouse_InOutBill_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_List_Transferring : ButtonHome
    {
        public ButtonHome_List_Transferring()
            : base("調撥單列表", "WareHouse_Transferring_List", UImagePaths.list) { }
    }

    public class ButtonHome_List_Inventory : ButtonHome
    {
        public ButtonHome_List_Inventory()
            : base("盤點單列表", "WareHouse_Inventory_List", UImagePaths.list) { }
    }

    public class ButtonHome_List_Transferring_Frame : ButtonHome
    {
        public ButtonHome_List_Transferring_Frame()
            : base("鏡架調撥列表", "WareHouse_Transferring_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_List_Inventory_Frame : ButtonHome
    {
        public ButtonHome_List_Inventory_Frame()
            : base("盤點單列表", "WareHouse_Inventory_Frame_List", UImagePaths.list) { }
    }

    public class ButtonHome_Stocks_Frame : ButtonHome
    {
        public ButtonHome_Stocks_Frame()
            : base("現存量表", "WareHouse_Stocks_Frame", UImagePaths.report) { }
    }

    public class ButtonHome_Day_Frame : ButtonHome
    {
        public ButtonHome_Day_Frame()
            : base("日報表", "WareHouse_Day_Frame_List", UImagePaths.report) { }
    }

    public class ButtonHome_Ledger_Frame : ButtonHome
    {
        public ButtonHome_Ledger_Frame()
            : base("流水帳", "WareHouse_Ledger_Frame_List", UImagePaths.report) { }
    }

}
