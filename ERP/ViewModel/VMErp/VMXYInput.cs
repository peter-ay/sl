using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using ERP.Web.Entity;

namespace ERP.ViewModel
{
    public class VMXYInput : VMErp
    {
        private int _State = 1;
        /// <summary>
        /// //////////0:浏览状态 1修改状态
        /// </summary>
        public int State
        {
            get { return _State; }
            set
            {
                _State = value;
                IsEnableLensCode = true;
                IsEnableSave = true;
                IsReadOnlyXYGrid = false;
                IsEnableXYLoad = true;
                if (_State == 0)
                {
                    IsEnableLensCode = false;
                    IsEnableSave = false;
                    IsReadOnlyXYGrid = true;
                    IsEnableXYLoad = false; ;
                }
            }
        }

        #region ACBox

        private Visibility isShowAC = Visibility.Visible;
        public Visibility IsShowAC
        {
            get { return isShowAC; }
            set { isShowAC = value; RaisePropertyChanged("IsShowAC"); }
        }

        private Visibility _IsShowACCusLensCode = Visibility.Collapsed;
        public Visibility IsShowACCusLensCode
        {
            get { return _IsShowACCusLensCode; }
            set { _IsShowACCusLensCode = value; RaisePropertyChanged("IsShowACCusLensCode"); }
        }

        private int _ACMinimumPrefixLength = 0;
        public int ACMinimumPrefixLength
        {
            get { return _ACMinimumPrefixLength; }
            set { _ACMinimumPrefixLength = value; RaisePropertyChanged("ACMinimumPrefixLength"); }
        }

        private int _MPLPCusLensCode = -1;
        public int MPLPCusLensCode
        {
            get { return _MPLPCusLensCode; }
            set { _MPLPCusLensCode = value; RaisePropertyChanged("MPLPCusLensCode"); }
        }

        #endregion

        #region EnableBtn

        private bool _IsEnableLensCode = true;
        public bool IsEnableLensCode
        {
            get { return _IsEnableLensCode; }
            set
            {
                _IsEnableLensCode = value;
                RaisePropertyChanged<bool>(() => this.IsEnableLensCode);
            }
        }

        private bool _IsEnableSave = true;
        public bool IsEnableSave
        {
            get { return _IsEnableSave; }
            set
            {
                _IsEnableSave = value;
                RaisePropertyChanged<bool>(() => this.IsEnableSave);
            }
        }

        private bool _IsEnableXYLoad = true;
        public bool IsEnableXYLoad
        {
            get { return _IsEnableXYLoad; }
            set
            {
                _IsEnableXYLoad = value;
                RaisePropertyChanged<bool>(() => this.IsEnableXYLoad);
            }
        }

        #endregion

        #region Visibility

        private Visibility _IsShowLR = Visibility.Collapsed;
        public Visibility IsShowLR
        {
            get { return _IsShowLR; }
            set
            {
                _IsShowLR = value;
                RaisePropertyChanged<Visibility>(() => this.IsShowLR);
            }
        }

        private Visibility _IsShowWhCode = Visibility.Collapsed;
        public Visibility IsShowWhCode
        {
            get { return _IsShowWhCode; }
            set
            {
                _IsShowWhCode = value;
                RaisePropertyChanged<Visibility>(() => this.IsShowWhCode);
            }
        }

        #endregion

        private bool _IsReadOnlyLR = false;
        public bool IsReadOnlyLR
        {
            get { return _IsReadOnlyLR; }
            set
            {
                _IsReadOnlyLR = value;
                RaisePropertyChanged<bool>(() => this.IsReadOnlyLR);
            }
        }

        private bool _IsReadOnlyXYGrid = false;
        public bool IsReadOnlyXYGrid
        {
            get { return _IsReadOnlyXYGrid; }
            set
            {
                _IsReadOnlyXYGrid = value;
                RaisePropertyChanged<bool>(() => this.IsReadOnlyXYGrid);
            }
        }

        private ObservableCollection<ComXYInputDataSource> _XYSource = new ObservableCollection<ComXYInputDataSource>();
        public ObservableCollection<ComXYInputDataSource> XYSource
        {
            get { return _XYSource; }
            set
            {
                _XYSource = value;
                RaisePropertyChanged<ObservableCollection<ComXYInputDataSource>>(() => this.XYSource);
            }
        }

        private ComXYInputMainDataSource _DContextMain = new ComXYInputMainDataSource();
        public new ComXYInputMainDataSource DContextMain
        {
            get { return _DContextMain; }
            set
            {
                _DContextMain = value;
                RaisePropertyChanged<ComXYInputMainDataSource>(() => this.DContextMain);
            }
        }

        #region Cyl
        private string _CYL = "CYL";
        public string CYL
        {
            get { return _CYL; }
            set
            {
                _CYL = value;
                RaisePropertyChanged<string>(() => this.CYL);
            }
        }

        private string _CYLSelectedShow = "CYL:";
        public string CYLSelectedShow
        {
            get { return _CYLSelectedShow; }
            set
            {
                _CYLSelectedShow = value;
                RaisePropertyChanged<string>(() => this.CYLSelectedShow);
            }
        }

        private string _ADDInput = "ADD:";
        public string ADDInput
        {
            get { return _ADDInput; }
            set
            {
                _ADDInput = value;
                RaisePropertyChanged<string>(() => this.ADDInput);
            }
        }
        #endregion

        //private int _Stocks = 0;
        //public int Stocks
        //{
        //    get { return _Stocks; }
        //    set
        //    {
        //        _Stocks = value;
        //        RaisePropertyChanged("Stocks");
        //    }
        //}

        public VMXYInput()
        {
            this.InitMessage();
        }

        private void InitMessage()
        {
            Messenger.Default.Register<string>(this, USysMessages.XYGridEnter, (msg) =>
            {
                this.ExecuteCmdSave();
            });

            Messenger.Default.Register<string>(this, USysMessages.XYGridEsc, (msg) =>
            {
                this.ExecuteCmdExit();
            });

            Messenger.Default.Register<string>(this, USysMessages.KeyCodeEnter, (msg) =>
            {
                if (msg != "ACXYLensCode") return;
                this.CallHelpWinDowCusLensCode();
            });
        }

        private RelayCommand _CmdXYLoad;

        /// <summary>
        /// Gets the CmdXYLoad.
        /// </summary>
        public RelayCommand CmdXYLoad
        {
            get
            {
                return _CmdXYLoad
                    ?? (_CmdXYLoad = new RelayCommand(ExecuteCmdXYLoad));
            }
        }

        public void ExecuteCmdXYLoad()
        {
            XYLoad();
        }

        int _CSPH1 = -1;
        int _CSPH2 = -1;
        private void XYLoad()
        {
            var _LensCodeInput = this.DContextMain.LensCode.MyStr();
            if (string.IsNullOrEmpty(_LensCodeInput)) return;
            //this.IsShowWhCode = Visibility.Collapsed;
            //this.IsShowLR = Visibility.Collapsed;
            this.CYL = "CYL";
            //var _Rs = ComHelpLensCode.UHV_B_Material_LensSmart.Where(item => item.LensCode.ToUpper().Trim() == _LensCodeInput).FirstOrDefault();
            //if (_Rs == null)
            //{
            //    XYSource.Clear();
            //    return;
            //}

            var dds = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_LensSmartXYTableQuery", dds_LoadedData, true);
            dds.QueryParameters.Add(new Parameter() { ParameterName = "lensCode", Value = _LensCodeInput });
            this.IsBusyCW = true;
            dds.Load();
            //
        }

        private void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            this.IsBusyCW = false;
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }

            if (e.TotalEntityCount <= 0)
            {
                XYSource.Clear();
                return;
            }

            V_B_Material_LensSmart _Rs = e.Entities.FirstOrDefault() as V_B_Material_LensSmart;

            this.DContextMain.LensCodeSelected = _Rs.LensCode;
            this.DContextMain.LensNameSelected = _Rs.LensName;
            this.DContextMain.F_LR = _Rs.F_LR ?? false;
            this.DContextMain.F_CA = _Rs.F_CA ?? false;

            if (this.DContextMain.F_LR)
            {
                this.IsReadOnlyLR = false;
            }
            else
            {
                this.IsReadOnlyLR = true;
                this.DContextMain.LR = "";
            }

            if (this.DContextMain.F_CA)
            {
                this.CYL = "ADD";
                this.ADDInput = "CYL:";
            }
            else
            {
                this.CYL = "CYL";
                this.ADDInput = "ADD:";
            }

            if (this.DContextMain.F_LR && string.IsNullOrEmpty(this.DContextMain.LR))
            {
                this.DContextMain.LR = "R";
            }

            var _SPH1 = _Rs.SPH1;
            var _SPH2 = _Rs.SPH2;
            var _CYL1 = _Rs.CYL1;
            var _CYL2 = _Rs.CYL2;
            if (this.DContextMain.F_LR)
            {
                _CYL1 = _Rs.X_ADD1;
                _CYL2 = _Rs.X_ADD2;
            }

            this.LoadXY(_SPH1.Value, _SPH2.Value, _CYL1.Value, _CYL2.Value);
        }

        private void LoadXY(int sPH1, int sPH2, int cYL1, int cYL2)
        {
            //每次都刷新 
            _CSPH1 = -1; _CSPH2 = -1;
            /////////////////////////////////////
            if (_CSPH1 != sPH1 || _CSPH2 != sPH2)
            {
                _CSPH1 = sPH1;
                _CSPH2 = sPH2;
                XYSource.Clear();
                #region SPH排序
                if (sPH2 <= 0)
                {
                    for (int i = sPH2; i >= sPH1; i -= 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                else if (sPH1 >= 0)
                {
                    for (int i = sPH1; i <= sPH2; i += 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                else
                {
                    for (int i = 0; i >= sPH1; i -= 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                    for (int i = 25; i <= sPH2; i += 25)
                    {
                        XYSource.Add(new ComXYInputDataSource() { C0 = i });
                    }
                }
                XYSource.Add(new ComXYInputDataSource() { C0 = -1 });
                #endregion
            }
            DContextMain.CYL1 = cYL1;
            DContextMain.CYL2 = cYL2;
            Messenger.Default.Send<ComXYInputMainDataSource>((DContextMain), USysMessages.XYColumnShow);
        }

        private RelayCommand _CmdSave;

        /// <summary>
        /// Gets the CmdSave.
        /// </summary>
        public RelayCommand CmdSave
        {
            get
            {
                return _CmdSave
                    ?? (_CmdSave = new RelayCommand(ExecuteCmdSave));
            }
        }

        private void ExecuteCmdSave()
        {
            if (this.State == 0) return;

            if (DContextMain.F_LR)
            {
                if (string.IsNullOrEmpty(DContextMain.LR))
                    DContextMain.LR = "R";

                DContextMain.LR = DContextMain.LR.Trim().ToUpper();

                if (DContextMain.LR != "R" && DContextMain.LR != "L")
                {
                    DContextMain.LR = "R";
                }
            }
            else
            {
                DContextMain.LR = "";
            }

            Messenger.Default.Send<bool>((true), USysMessages.XYInputResult);
        }

        ///////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////

        private RelayCommand _CmdExit;

        /// <summary>
        /// Gets the CmdExit.
        /// </summary>
        public new RelayCommand CmdExit
        {
            get
            {
                return _CmdExit
                    ?? (_CmdExit = new RelayCommand(ExecuteCmdExit));
            }
        }

        private new void ExecuteCmdExit()
        {
            if (State == 1)
            {
                MessageWindowErp u = new MessageWindowErp(ErpUIText.Get("ERP_XYInputWithOutSave"), MessageWindowErp.MessageType.Confirm);
                u.Closed += (s, e) =>
                    {
                        if (u.DialogResult == false) return;
                        Messenger.Default.Send<bool>((false), USysMessages.XYInputResult);
                    };
                u.Show();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void ViewKeyDown(System.Windows.Input.KeyEventArgs parameter)
        {
            switch (parameter.Key)
            {
                case Key.Escape:
                    this.ExecuteCmdExit();
                    parameter.Handled = true;
                    break;
                case Key.Enter:
                    this.ExecuteCmdSave();
                    parameter.Handled = true;
                    break;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// ///////////////////////////////////////////////////////
        /// </summary>
        private RelayCommand _CmdLensCode;

        /// <summary>
        /// Gets the CmdLensCode.
        /// </summary>
        public RelayCommand CmdLensCode
        {
            get
            {
                return _CmdLensCode
                    ?? (_CmdLensCode = new RelayCommand(
                    () =>
                    {
                        this.CallHelpWinDowCusLensCode();
                    }));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override string GetDContextMainCusCode()
        {
            return this.DContextMain.CusCode.Trim();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void HandleReturnMsg(string msg)
        {
            DContextMain.LensCode = msg.Trim();
            this.IsFocusLensCode = true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
