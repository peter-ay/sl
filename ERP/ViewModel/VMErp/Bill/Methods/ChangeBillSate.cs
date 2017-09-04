
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public partial class VMBill
    {
        protected virtual void ChangeBillSate(UBillState uBillState)
        {
            this.EditMode = false;
            ////////////////////////////////////////////////////////////
            this.IsReadOnlyID = true;
            this.IsReadOnlyMain = true;
            this.IsReadOnlyEdit = true;
            //////////////////////////////////////////////////////////
            this.IsEnableCheck = false;
            this.IsEnableDelete = false;
            this.IsEnableDrop = false;
            this.IsEnableEdit = false;
            this.IsEnableExport = false;
            this.IsEnableNew = false;
            this.IsEnableNext = false;
            this.IsEnablePrevious = false;
            this.IsEnablePrint = false;
            this.IsEnablePrintToFactory = false;
            this.IsEnableSave = false;
            this.IsEnableUnCheck = false;
            this.IsEnableUnLock = false;
            this.IsEnableReOrder = false;
            this.IsEnableCheck = false;
            this.IsEnableUnCheck = false;
            this.IsEnableLocate = false;
            //////////////////////////////////////////////////////////////
            this.ResetTBIsVisibility(false);
            this.ResetACIsVisibility(false);
            this.ResetDPIsVisibility(false);
            this.ResetHBIsVisibility(false);

            switch (uBillState)
            {
                case UBillState.View:
                    this.IsEnableNew = true;
                    this.IsEnableNext = true;
                    this.IsEnablePrevious = true;
                    this.IsEnableEdit = true;
                    this.IsEnableLocate = true;
                    try
                    {
                        if (this.DContextMain.GetType().GetProperty("Checker").GetValue(this.DContextMain, null).ToString() == "")
                        {
                            this.IsEnableCheck = true;
                            this.IsEnableDelete = true;
                        }
                        else
                        {
                            this.IsEnableUnCheck = true;
                            this.IsEnableExport = true;
                            this.IsEnablePrint = true;
                            this.IsEnablePrintToFactory = true;
                            this.IsEnableReOrder = true;
                        }
                    }
                    catch
                    {
                        this.IsEnableCheck = true;
                        this.IsEnableDelete = true;
                        this.IsEnableEdit = true;
                    }
                    this.IsFocusMain = true;
                    this.ResetTBIsVisibility(true);
                    break;

                case UBillState.Drop:
                    this.IsEnableNew = true;
                    this.IsEnableLocate = true;
                    this.IsFocusMain = true;
                    this.ResetTBIsVisibility(true);
                    break;

                case UBillState.New:
                    this.IsEnableSave = true;
                    this.IsEnableDrop = true;
                    ////////////////////////////
                    this.IsReadOnlyMain = false;
                    this.IsReadOnlyEdit = false;
                    /////////////////////////////
                    this.ResetDPIsVisibility(true);
                    this.ResetACIsVisibility(true);
                    this.ResetHBIsVisibility(true);

                    try
                    {
                        this.DContextMain.GetType().GetProperty("EditState").SetValue(this.DContextMain, 1, null);
                    }
                    catch { }

                    break;


                case UBillState.Edit:
                    this.FixEditACBug();

                    this.IsEnableSave = true;
                    this.IsEnableDrop = true;

                    this.EditMode = true;
                    //Messenger.Default.Send<string>((""), USysMessages.ACBoxTextUpdate);

                    var _Checker = "";
                    try { _Checker = this.DContextMain.GetType().GetProperty("Checker").GetValue(this.DContextMain, null).ToString(); }
                    catch { }

                    if (string.IsNullOrEmpty(_Checker))
                    {
                        this.IsReadOnlyMain = false;
                        this.IsReadOnlyEdit = false;
                        //////////
                        this.ResetACIsVisibility(true);
                        this.ResetHBIsVisibility(true);
                        this.ResetDPIsVisibility(true);
                    }
                    else
                    {
                        this.IsReadOnlyEdit = false;
                        //////////////////
                        this.ResetTBIsVisibility(true);
                    }
                    ////////////////////////////////////////////////////////////////////////////
                    try
                    {
                        this.DContextMain.GetType().GetProperty("EditState").SetValue(this.DContextMain, 1, null);
                    }
                    catch { }

                    break;
            }
        }
    }
}
