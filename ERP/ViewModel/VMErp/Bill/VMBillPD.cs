using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using System.Xml;
using System.Xml.Linq;
using DevExpress.AgDataGrid;
using ERP.Common;
using ERP.Utility;
using ERP.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ERP.ViewModel
{
    public abstract partial class VMBillPD : VMBill
    {
        #region perproty

        private bool _IsEnableXYInPut = false;
        public bool IsEnableXYInPut
        {
            get { return _IsEnableXYInPut; }
            set
            {
                _IsEnableXYInPut = value;
                RaisePropertyChanged<bool>(() => this.IsEnableXYInPut);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////
        //private ComDDsInfo _DDsInfoSub;
        //public ComDDsInfo DDsInfoSub
        //{
        //    get { return _DDsInfoSub; }
        //    set { _DDsInfoSub = value; }
        //}
        /////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        public VMBillPD(string idCode, string modelName = "", bool isAddGpID = false)
            : base(idCode, modelName, isAddGpID)
        {

        }

        protected override void ViewOnLoad()
        {
            base.ViewOnLoad();
            this.InitSubGridColumns();
        }

        #region methods
        protected override void New()
        {
            this.CleanGridListSub();
            base.New();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        protected override void Drop()
        {
            this.CleanGridListSub();
            base.Drop();
        }
        ////////////////////////////////////////////////////////////////
        private void CleanGridListSub()
        {
            this.DContextSub = new ObservableCollection<Entity>();
            ComSubGridColumnUpdate t = new ComSubGridColumnUpdate()
            {
                GridName = this.VMNameAuthority,
                Source = this.DContextSub
            };
            Messenger.Default.Send<ComSubGridColumnUpdate>(t, USysMessages.RefreshSubGrid);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        private ObservableCollection<AgDataGridColumn> _Columns;
        protected void InitSubGridColumns()
        {
            ObservableCollection<AgDataGridSummaryItem> sumcolumns = new ObservableCollection<AgDataGridSummaryItem>();

            try
            {
                if (null == _Columns)
                {
                    _Columns = new ObservableCollection<AgDataGridColumn>();

                    var xmlPath = @"/ERP;component/XML/Grid/" + this.XMLPath + @"/" + this.VMNameAuthority + "Sub.xml";

                    using (XmlReader _XReader = XmlReader.Create(xmlPath))
                    {
                        XElement xelement = XElement.Load(_XReader);
                        _Columns.Add(new AgDataGridColumn
                        {
                            FieldName = this.VMName.Substring(2),
                            HeaderContent = "SubGridListName"
                        });
                        var items = xelement.Descendants("Column");
                        foreach (var item in items)
                        {
                            string _FieldName = item.Attribute("FieldName").Value.ToString();
                            string _HeaderContent = item.Attribute("HeaderContent").Value.ToString().UIStr();
                            string _Fsum = "";
                            string _Title = "";
                            try
                            {
                                _Fsum = item.Attribute("Fsum").Value.ToString().UIStr();
                            }
                            catch { }
                            try
                            {
                                _Title = item.Attribute("Title").Value.ToString().UIStr();
                            }
                            catch { }
                            /////////////////////////////
                            _Columns.Add(new AgDataGridColumn
                            {
                                FieldName = _FieldName,
                                HeaderContent = _HeaderContent
                            });

                            if (_Fsum == "1")
                            {
                                sumcolumns.Add(new AgDataGridSummaryItem
                                {
                                    FieldName = _FieldName,
                                    Title = _Title
                                });
                            }
                        }
                    }
                }
                ComSunGridColumnInfo c = new ComSunGridColumnInfo()
                {
                    Columns = _Columns,
                    SumColumns = sumcolumns
                };
                Messenger.Default.Send<ComSunGridColumnInfo>((c), USysMessages.InitSubGridColumns);
            }
            catch { }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void ChangeBillSate(UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);
            this.IsEnableXYInPut = false;
            switch (uBillState)
            {
                case UBillState.View:

                    break;
                case UBillState.New:
                    this.IsEnableXYInPut = true;

                    break;
                case UBillState.Edit:
                    try
                    {
                        if (this.DContextMain.GetType().GetProperty("Checker").GetValue(this.DContextMain, null).ToString() == "")
                        {
                            this.IsEnableXYInPut = true;
                        }
                    }
                    catch { this.IsEnableXYInPut = true; }

                    break;
                case UBillState.Drop:

                    break;
                default: break;
            }
        }
        #endregion

        #region XYTable
        private XYInput _XYInput = UXYTable.XY;
        private RelayCommand _CmdXYInPut;

        /// <summary>
        /// Gets the CmdXYInPut.
        /// </summary>
        public RelayCommand CmdXYInPut
        {
            get
            {
                return _CmdXYInPut
                    ?? (_CmdXYInPut = new RelayCommand(ExecuteCmdXYInPut));
            }
        }

        private void ExecuteCmdXYInPut()
        {
            if (_XYInput == null)
            {
                UXYTable.XY = new XYInput();
                _XYInput = UXYTable.XY;
            }
            _XYInput.Closed -= _XYInput_Closed;
            _XYInput.Closed += new EventHandler(_XYInput_Closed);
            //
            _XYInput.RequestVMName = this.VMName;
            _XYInput.SetIsCusLens();
            //
            if (this.VMName == "VMSale_Order_PD" || this.VMName == "VMSale_Order_JM")
            {
                var _CusCode = this.DContextMain.GetType().GetProperty("CusCode").GetValue(this.DContextMain, null).ToString();
                if (string.IsNullOrEmpty(_CusCode))
                {
                    MessageErp.ErrorMessage(ErpUIText.Get("Err_CusCodeNull"));
                    return;
                }
                var dc = _XYInput.DataContext as VMXYInput;
                dc.DContextMain.CusCode = _CusCode;
                //_XYInput.ACDateSource = 1;
                _XYInput.SetIsCusLens(true);
            }
            //
            try
            {
                _XYInput.ResultDataList = new ObservableCollection<ComXYInputListFormat>();
                _XYInput.ResultDataList.Clear();
                this.FillXYInputResultDataList(_XYInput.ResultDataList);
                var _LensCode = this.DContextMain.GetType().GetProperty("LensCode").GetValue(this.DContextMain, null).ToString();
                var _F_LR = this.DContextMain.GetType().GetProperty("F_LR").GetValue(this.DContextMain, null).ToString();
                var dc = _XYInput.DataContext as VMXYInput;
                dc.DContextMain.LR = _F_LR;
                dc.DContextMain.LensCode = _LensCode;
                if (string.IsNullOrEmpty(_LensCode))
                {
                    dc.DContextMain.LensCodeSelected = "";
                    dc.DContextMain.LensNameSelected = "";
                    dc.DContextMain.LR = "";
                    dc.DContextMain.F_LR = false;
                }
                dc.ExecuteCmdXYLoad();
            }
            catch { }

            _XYInput.Show();

        }

        void _XYInput_Closed(object sender, EventArgs e)
        {
            if (_XYInput.RequestVMName != this.VMName || _XYInput.DialogResult == false)
            {
                this.IsFocusLensCodeReplace = true;
                return;
            }
            var _XYDSource = _XYInput.DataContext as VMXYInput;
            var _LensCodeSelected = _XYDSource.DContextMain.LensCodeSelected.Trim();
            var _F_LR = _XYDSource.DContextMain.LR.Trim();
            if (string.IsNullOrEmpty(_LensCodeSelected))
            {
                this.IsFocusLensCodeReplace = true;
                return;
            }
            try
            {
                this.DContextMain.GetType().GetProperty("LensCode").SetValue(this.DContextMain, _LensCodeSelected, null);
                this.DContextMain.GetType().GetProperty("F_LR").SetValue(this.DContextMain, _F_LR, null);
            }
            catch { }
            try
            {
                if (this.DContextMain.GetType().GetProperty("LensCodeR").GetValue(this.DContextMain, null).ToString().Trim() == "")
                {
                    this.DContextMain.GetType().GetProperty("LensCodeR").SetValue(this.DContextMain, _LensCodeSelected, null);
                }
            }
            catch { }
            ComSubGridColumnUpdate t = this.GetReturnXYData(_XYInput.ResultDataList);
            Messenger.Default.Send<ComSubGridColumnUpdate>(t, USysMessages.RefreshSubGrid);
            this.IsFocusMain = true;
        }

        protected abstract void FillXYInputResultDataList(ObservableCollection<ComXYInputListFormat> observableCollection);

        protected abstract ComSubGridColumnUpdate GetReturnXYData(ObservableCollection<ComXYInputListFormat> comXYInputListFormat);

        #endregion

    }
}
