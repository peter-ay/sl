
using ERP.ViewModel;
namespace ERP.View
{
    public class ButtonAssign : ButtonFun
    {
        public ButtonAssign()
            : base("IsEnableAssign", "balloons_arrow.png", ErpUIText.Get("ERP_ButtonAssign"), "CmdAssign")
        {
        }
    }

    public class ButtonCheck : ButtonFun
    {
        public ButtonCheck()
            : base("IsEnableCheck", "disks.png", ErpUIText.Get("ERP_ButtonCheck"), "CmdCheck")
        {
        }
    }

    public class ButtonCheckIn : ButtonFun
    {
        public ButtonCheckIn()
            : base("IsEnableCheckIn", "", ErpUIText.Get("ERP_ButtonCheck"), "CmdCheckIn")
        {
        }
    }

    public class ButtonCheckOut : ButtonFun
    {
        public ButtonCheckOut()
            : base("IsEnableCheckOut", "", ErpUIText.Get("ERP_ButtonCheck"), "CmdCheckOut")
        {
        }
    }

    public class ButtonClear : ButtonFun
    {
        public ButtonClear()
            : base("IsEnableClear", "arrow_circle_225.png", ErpUIText.Get("ERP_ButtonClear"), "CmdClear")
        {
        }
    }

    public class ButtonCWCancel : ButtonFun
    {
        public ButtonCWCancel()
            : base("IsEnableCWCancel", "slash.png", ErpUIText.Get("ERP_Btn_Cancel"), "CmdCancel")
        {
        }
    }

    public class ButtonCWOK : ButtonFun
    {
        public ButtonCWOK()
            : base("IsEnableCWOK", "tick_circle_frame.png", ErpUIText.Get("ERP_Btn_OK"), "CmdOK")
        {
        }
    }

    public class ButtonDelete : ButtonFun
    {
        public ButtonDelete()
            : base("IsEnableDelete", "disk__minus.png", ErpUIText.Get("ERP_ButtonDelete"), "CmdDelete")
        {
        }
    }

    public class ButtonDrop : ButtonFun
    {
        public ButtonDrop()
            : base("IsEnableDrop", "slash.png", ErpUIText.Get("ERP_ButtonDrop"), "CmdDrop")
        {
        }
    }

    public class ButtonEdit : ButtonFun
    {
        public ButtonEdit()
            : base("IsEnableEdit", "disk__pencil.png", ErpUIText.Get("ERP_ButtonEdit"), "CmdEdit")
        {
        }
    }

    public class ButtonExit : ButtonFun
    {
        public ButtonExit()
            : base("IsEnableExit", "database_arrow.png", ErpUIText.Get("ERP_ButtonExit"), "CmdExit")
        {
        }
    }

    public class ButtonExport : ButtonFun
    {
        public ButtonExport()
            : base("IsEnableExport", "arrow_skip_090.png", ErpUIText.Get("ERP_ButtonExport"), "CmdExport", "IsShowExport")
        {
        }
    }

    public class ButtonExport2 : ButtonFun
    {
        public ButtonExport2()
            : base("IsEnableExport2", "", ErpUIText.Get("ERP_ButtonExport"), "CmdExport2", "IsShowExport2")
        {
        }
    }

    public class ButtonExportList : ButtonFun
    {
        public ButtonExportList()
            : base("IsEnableExportList", "", ErpUIText.Get("ERP_ButtonExportList"), "CmdExportList", "IsShowExportList")
        {
        }
    }

    public class ButtonImport : ButtonFun
    {
        public ButtonImport()
            : base("IsEnableImport", "arrow_skip_270.png", ErpUIText.Get("ERP_ButtonImport"), "CmdImport", "IsShowImport")
        {
        }
    }

    public class ButtonListDelete : ButtonFun
    {
        public ButtonListDelete()
            : base("IsEnableDelete", "minus_circle.png", ErpUIText.Get("ERP_ButtonListDelete"), "CmdDelete")
        {
        }
    }

    public class ButtonListCheck : ButtonFun
    {
        public ButtonListCheck()
            : base("IsEnableCheck", "disks.png", ErpUIText.Get("ERP_ButtonCheck"), "CmdCheck")
        {
        }
    }

    public class ButtonListNew : ButtonFun
    {
        public ButtonListNew()
            : base("IsEnableNew", "plus_circle.png", ErpUIText.Get("ERP_ButtonListNew"), "CmdNew")
        {
        }
    }

    public class ButtonNewListSD : ButtonFun
    {
        public ButtonNewListSD()
            : base("IsEnableNewSD", "plus_circle.png", ErpUIText.Get("ERP_ButtonListNewSD"), "CmdNewSD")
        {
        }
    }

    public class ButtonNewListPD : ButtonFun
    {
        public ButtonNewListPD()
            : base("IsEnableNewPD", "plus_circle.png", ErpUIText.Get("ERP_ButtonListNewPD"), "CmdNewPD")
        {
        }
    }

    public class ButtonNewListFD : ButtonFun
    {
        public ButtonNewListFD()
            : base("IsEnableNewFD", "plus_circle.png", ErpUIText.Get("ERP_ButtonListNewFD"), "CmdNewFD")
        {
        }
    }

    public class ButtonNewListFS : ButtonFun
    {
        public ButtonNewListFS()
            : base("IsEnableNewFS", "plus_circle.png", ErpUIText.Get("ERP_ButtonListNewFS"), "CmdNewFS")
        {
        }
    }

    public class ButtonNew : ButtonFun
    {
        public ButtonNew()
            : base("IsEnableNew", "disk__plus.png", ErpUIText.Get("ERP_ButtonNew"), "CmdNew")
        {
        }
    }

    public class ButtonAddNew : ButtonFun
    {
        public ButtonAddNew()
            : base("IsEnableAddNew", "disk__plus.png", ErpUIText.Get("ERP_ButtonAdd"), "CmdAddNew")
        {
        }
    }

    public class ButtonNext : ButtonFun
    {
        public ButtonNext()
            : base("IsEnableNext", "arrow_stop.png", ErpUIText.Get("ERP_ButtonNext"), "CmdNext")
        {
        }
    }

    public class ButtonPrevious : ButtonFun
    {
        public ButtonPrevious()
            : base("IsEnablePrevious", "arrow_stop_180.png", ErpUIText.Get("ERP_ButtonPrevious"), "CmdPrevious")
        {
        }
    }

    public class ButtonPrint : ButtonFun
    {
        public ButtonPrint()
            : base("IsEnablePrint", "printer.png", ErpUIText.Get("ERP_ButtonPrint"), "CmdPrint")
        {
        }
    }

    public class ButtonPrintPreview : ButtonFun
    {
        public ButtonPrintPreview()
            : base("IsEnablePrintPreview", "printer.png", ErpUIText.Get("ERP_ButtonPrintPreview"), "CmdPrintPreview")
        {
        }
    }

    public class ButtonPrintToFactory : ButtonFun
    {
        public ButtonPrintToFactory()
            : base("IsEnablePrintToFactory", "printer__arrow.png", ErpUIText.Get("ERP_ButtonPrintToFactory"), "CmdPrintToFactory")
        {
        }
    }

    public class ButtonReOrder : ButtonFun
    {
        public ButtonReOrder()
            : base("IsEnableReOrder", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonReOrder"), "CmdReOrder")
        {
        }
    }

    public class ButtonCancel : ButtonFun
    {
        public ButtonCancel()
            : base("IsEnableCancel", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonCancel"), "CmdCancel")
        {
        }
    }

    public class ButtonSave : ButtonFun
    {
        public ButtonSave()
            : base("IsEnableSave", "disk.png", ErpUIText.Get("ERP_ButtonSave"), "CmdSave")
        {
        }
    }

    public class ButtonSearch : ButtonFun
    {
        public ButtonSearch()
            : base("IsEnableSearch", "magnifier_left.png", ErpUIText.Get("ERP_ButtonSearch"), "CmdSearch")
        {
        }
    }

    public class ButtonRefresh : ButtonFun
    {
        public ButtonRefresh()
            : base("IsEnableRefresh", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonRefresh"), "CmdSearch")
        {
        }
    }

    public class ButtonRefresh2 : ButtonFun
    {
        public ButtonRefresh2()
            : base("IsEnableRefresh2", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonRefresh"), "CmdRefresh2")
        {
        }
    }

    public class ButtonLoad : ButtonFun
    {
        public ButtonLoad()
            : base("IsEnableLoad", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonLoad"), "CmdLoad")
        {
        }
    }

    public class ButtonUnCheck : ButtonFun
    {
        public ButtonUnCheck()
            : base("IsEnableUnCheck", "disks_black.png", ErpUIText.Get("ERP_ButtonUnCheck"), "CmdUnCheck")
        {
        }
    }

    public class ButtonUnCheckIn : ButtonFun
    {
        public ButtonUnCheckIn()
            : base("IsEnableUnCheckIn", "", ErpUIText.Get("ERP_ButtonUnCheck"), "CmdUnCheckIn")
        {
        }
    }

    public class ButtonUnCheckOut : ButtonFun
    {
        public ButtonUnCheckOut()
            : base("IsEnableUnCheckOut", "", ErpUIText.Get("ERP_ButtonUnCheck"), "CmdUnCheckOut")
        {
        }
    }

    public class ButtonUnLock : ButtonFun
    {
        public ButtonUnLock()
            : base("IsEnableUnLock", "chain_unchain.png", ErpUIText.Get("ERP_ButtonUnLock"), "CmdUnLock")
        {
        }
    }

    public class ButtonAllAssign : ButtonFun
    {
        public ButtonAllAssign()
            : base("IsEnableAllAssign", "plus_circle_frame.png", ErpUIText.Get("ERP_ButtonAllAssign"), "CmdAllAssign")
        {

        }
    }

    public class ButtonAllUnAssign : ButtonFun
    {
        public ButtonAllUnAssign()
            : base("IsEnableAlUnlAssign", "minus_circle_frame.png", ErpUIText.Get("ERP_ButtonAllUnAssign"), "CmdAllUnAssign")
        {

        }
    }

    public class ButtonUpdateCache : ButtonFun
    {
        public ButtonUpdateCache()
            : base("IsEnableUpdateCache", "arrow_circle_double.png", ErpUIText.Get("ERP_ButtonUpdateCache"), "CmdUpdateCache")
        {
            this.Width = 85;
        }
    }

    public class ButtonUpdatePassword : ButtonFun
    {
        public ButtonUpdatePassword()
            : base("IsEnableUpdatePassword", "key__exclamation.png", ErpUIText.Get("ERP_ButtonUpdatePassword"), "CmdUpdatePassword")
        {

        }
    }

    public class ButtonInCludeDepartment : ButtonFun
    {
        public ButtonInCludeDepartment()
            : base("IsEnableInCludeDepartment", "gear.png", ErpUIText.Get("ERP_ButtonInCludeDepartment"), "CmdInCludeDepartment")
        {

        }
    }

    public class ButtonInCludeMnumber : ButtonFun
    {
        public ButtonInCludeMnumber()
            : base("IsEnableInCludeMnumber", "gear.png", ErpUIText.Get("ERP_ButtonInCludeMnumber"), "CmdInCludeMnumber")
        {

        }
    }

    public class ButtonExCludeProcess : ButtonFun
    {
        public ButtonExCludeProcess()
            : base("IsEnableExCludeProcess", "gear.png", ErpUIText.Get("ERP_ButtonExCludeProcess"), "CmdExCludeProcess")
        {

        }
    }

    public class ButtonEditPriceContractLens : ButtonFun
    {
        public ButtonEditPriceContractLens()
            : base("IsEnableEditPriceContractLens", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractLens"), "CmdEditPriceContractLens")
        {

        }
    }
    //
    public class ButtonEditPriceContractProCost : ButtonFun
    {
        public ButtonEditPriceContractProCost()
            : base("IsEnableEditPriceContractProCost", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractProCost"), "CmdEditPriceContractProCost")
        {

        }
    }
    //
    public class ButtonEditPriceContractCusCode : ButtonFun
    {
        public ButtonEditPriceContractCusCode()
            : base("IsEnableEditPriceContractCusCode", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractCusCode"), "CmdEditPriceContractCusCode")
        {

        }
    }
    //
    public class ButtonEditPriceContractSpCode : ButtonFun
    {
        public ButtonEditPriceContractSpCode()
            : base("IsEnableEditPriceContractSpCode", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractSpCode"), "CmdEditPriceContractSpCode")
        {

        }
    }
    //
    public class ButtonEditPriceContractFrame : ButtonFun
    {
        public ButtonEditPriceContractFrame()
            : base("IsEnableEditPriceContractFrame", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractFrame"), "CmdEditPriceContractFrame")
        {

        }
    }

    public class ButtonEditPriceContractFrameSet : ButtonFun
    {
        public ButtonEditPriceContractFrameSet()
            : base("IsEnableEditPriceContractFrameSet", "gear.png", ErpUIText.Get("ERP_ButtonEditPriceContractFrameSet"), "CmdEditPriceContractFrameSet")
        {

        }
    }

    public class ButtonAllAssignPanel : ButtonFun
    {
        public ButtonAllAssignPanel()
            : base("IsEnableAllAssign", "plus_circle_frame.png", ErpUIText.Get("ERP_ButtonAllAssignPanel"), "CmdAllAssign")
        {

        }
    }

    public class ButtonAllUnAssignPanel : ButtonFun
    {
        public ButtonAllUnAssignPanel()
            : base("IsEnableAllUnAssign", "minus_circle_frame.png", ErpUIText.Get("ERP_ButtonAllUnAssignPanel"), "CmdAllUnAssign")
        {

        }
    }

    public class ButtonXYInPut : ButtonFun
    {
        public ButtonXYInPut()
            : base("IsEnableXYInPut", "table.png", ErpUIText.Get("ERP_XYInPut"), "CmdXYInPut")
        {

        }
    }

    public class ButtonXYLoad : ButtonFun
    {
        public ButtonXYLoad()
            : base("IsEnableXYLoad", "arrow_circle_double_135.png", ErpUIText.Get("ERP_XYLoad"), "CmdXYLoad")
        {

        }
    }

    public class ButtonCopyRights : ButtonFun
    {
        public ButtonCopyRights()
            : base("IsEnableCopyRights", "chain_unchain.png", ErpUIText.Get("ERP_CopyRights"), "CmdCopyRights")
        {

        }
    }

    public class ButtonCopy : ButtonFun
    {
        public ButtonCopy()
            : base("IsEnableCopy", "chain_unchain.png", ErpUIText.Get("ERP_Copy"), "CmdCopy")
        {

        }
    }

    public class ButtonResetPassword : ButtonFun
    {
        public ButtonResetPassword()
            : base("IsEnableResetPassword", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ResetPassword"), "CmdResetPassword")
        {

        }
    }

    public class ButtonRefreshSC : ButtonFun
    {
        public ButtonRefreshSC()
            : base("IsEnableRefreshSC", "arrow_circle_double_135.png", ErpUIText.Get("ERP_ButtonRefreshSC"), "CmdRefreshSC")
        {
        }
    }

    public class ButtonQuote : ButtonFun
    {
        public ButtonQuote()
            : base("IsEnableQuote", "magnifier_left.png", ErpUIText.Get("ERP_ButtonQuote"), "CmdQuote")
        {
        }
    }

    public class ButtonLocate : ButtonFun
    {
        public ButtonLocate()
            : base("IsEnableLocate", "arrow_stop_270.png", ErpUIText.Get("ERP_ButtonLocate"), "CmdLocate")
        {
        }
    }

    public class ButtonLocateSaleOrderCode : ButtonFun
    {
        public ButtonLocateSaleOrderCode()
            : base("IsEnableLocateSaleOrderCode", "arrow_stop_270.png", ErpUIText.Get("ERP_ButtonLocate"), "CmdLocateSaleOrderCode")
        {
        }
    }

    public class ButtonLocateDN : ButtonFun
    {
        public ButtonLocateDN()
            : base("IsEnableLocateDN", "arrow_stop_270.png", ErpUIText.Get("ERP_ButtonLocate"), "CmdLocateDN")
        {
        }
    }

    public class ButtonMinRight : ButtonFun
    {
        public ButtonMinRight()
            : base("", "arrow_stop.png", "", "CmdMinRight")
        {
            this.MinWidth = 0;
            this.Width = 20;
        }
    }

    public class ButtonUpdateFreight : ButtonFun
    {
        public ButtonUpdateFreight()
            : base("IsEnableUpdateFreight", "arrow_circle_double.png", ErpUIText.Get("ERP_ButtonUpdate"), "CmdUpdateFreight")
        {

        }
    }

    public class ButtonUpdateAddress : ButtonFun
    {
        public ButtonUpdateAddress()
            : base("IsEnableUpdateAddress", "arrow_circle_double.png", ErpUIText.Get("ERP_ButtonUpdate"), "CmdUpdateAddress")
        {

        }
    }

    public class ButtonScanBarCode : ButtonFun
    {
        public ButtonScanBarCode()
            : base("IsEnableScanBarCode", "barcode.png", ErpUIText.Get("ERP_ButtonScanBarCode"), "CmdScanBarCode")
        {

        }
    }

    public class ButtonLensLoss : ButtonFun
    {
        public ButtonLensLoss()
            : base("IsEnableLensLoss", "wrench_screwdriver.png", ErpUIText.Get("ERP_ButtonLensLoss"), "CmdLensLoss")
        {

        }
    }

    public class ButtonPDChoose : ButtonFun
    {
        public ButtonPDChoose()
            : base("IsEnablePDChoose", "", ErpUIText.Get("ERP_ButtonPDChoose"), "CmdPDChoose")
        {

        }
    }

    public class ButtonPDStart : ButtonFun
    {
        public ButtonPDStart()
            : base("IsEnablePDStart", "", ErpUIText.Get("ERP_ButtonPDStart"), "CmdPDStart")
        {

        }
    }

    public class ButtonPDEnd : ButtonFun
    {
        public ButtonPDEnd()
            : base("IsEnablePDEnd", "", ErpUIText.Get("ERP_ButtonPDEnd"), "CmdPDEnd")
        {

        }
    }

    public class ButtonRCNew : ButtonFun
    {
        public ButtonRCNew()
            : base("IsEnableRCNew", "", ErpUIText.Get("ERP_ButtonRCNew"), "CmdRCNew")
        {

        }
    }

    public class ButtonRCList : ButtonFun
    {
        public ButtonRCList()
            : base("IsEnableRCList", "", ErpUIText.Get("ERP_ButtonRCList"), "CmdRCList")
        {

        }
    }

    public class ButtonDeleteSelected : ButtonFun
    {
        public ButtonDeleteSelected()
            : base("IsEnableButtonDeleteSelected", "", ErpUIText.Get("ERP_ButtonDeleteSelected"), "CmdDeleteSelected")
        {

        }
    }

    public class ButtonDeleteAll : ButtonFun
    {
        public ButtonDeleteAll()
            : base("IsEnableButtonDeleteAll", "", ErpUIText.Get("ERP_ButtonDeleteAll"), "CmdDeleteAll")
        {

        }
    }



    #region Lens
    //public class ButtonEditLensPrice : ButtonFun
    //{
    //    public ButtonEditLensPrice()
    //        : base("IsEnableEditLensPrice", "gear.png", ErpUIText.Get("ERP_ButtonEditLensPrice"), "CmdEditLensPrice")
    //    {

    //    }
    //}

    //public class ButtonEditLensProCost : ButtonFun
    //{
    //    public ButtonEditLensProCost()
    //        : base("IsEnableEditLensProCost", "gear.png", ErpUIText.Get("ERP_ButtonEditLensProCost"), "CmdEditLensProCost")
    //    {

    //    }
    //}

    //public class ButtonEditLensProControl : ButtonFun
    //{
    //    public ButtonEditLensProControl()
    //        : base("IsEnableEditLensProControl", "gear.png", ErpUIText.Get("ERP_ButtonEditLensProControl"), "CmdEditLensProControl")
    //    {

    //    }
    //}

    //public class ButtonEditPrice : ButtonFun
    //{
    //    public ButtonEditPrice()
    //        : base("IsEnableEditPrice", "disk__pencil.png", ErpUIText.Get("ERP_ButtonEdit"), "CmdEditPrice")
    //    {
    //    }
    //}
    #endregion



}
