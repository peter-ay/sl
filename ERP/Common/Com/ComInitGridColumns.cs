using ERP.Utility;
using ERP.View;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System;
using System.Windows.Data;
using System.Windows;

namespace ERP.Common
{
    public class ComInitGridColumns
    {
        public static void Init(string vMName, string gridName, int gridID = 1)
        {
            try
            {
                var _Columns = new ObservableCollection<DataGridColumn>();

                //var xmlPath = @"/ERP;component/XML/Grid/" + this.Xmlpath + @"/" + gridName.Substring(2) + ".xml";
                var _XMLPath = @"/ERP;component/XML/Grid/" + gridName + ".xml";
                using (XmlReader _XReader = XmlReader.Create(_XMLPath))
                {
                    XElement _XElement = XElement.Load(_XReader);
                    _Columns.Add(new DataGridTextColumn()
                    {
                        Header = gridName,
                        DisplayIndex = 999
                    });

                    var items = _XElement.Descendants("Column");
                    foreach (var item in items)
                    {
                        string _XBinding = item.Attribute("Binding").Value.ToString();
                        string _XHeader = item.Attribute("Header").Value.ToString().UIStr();
                        /////////////////////////////
                        string _F_Header = "";
                        try { _F_Header = item.Attribute("Fheader").Value.ToString(); }
                        catch { }
                        switch (_F_Header)
                        {
                            case "1":
                                _Columns.Add(ComColumnFactory.GetColumnHeader());
                                continue;
                            //case "LP":
                            //case "LPP":
                            //    columns.Add(ComColumnFactory.GetColumnHeader(flag_header));
                            //    continue;
                        }
                        //////////////////////////////
                        string _F_Fun = "";
                        try { _F_Fun = item.Attribute("Ffunction").Value.ToString(); }
                        catch { }
                        if (!string.IsNullOrEmpty(_F_Fun))
                        {
                            _Columns.Add(ComColumnFactory.GetColumnFunction(_XBinding, _XHeader, _F_Fun, vMName.Remove(0, 2), "Locator"));
                            continue;
                        }
                        //////////////////////////////
                        string _F_bool = "";
                        try { _F_bool = item.Attribute("Fbool").Value.ToString(); }
                        catch { }
                        if (_F_bool == "1")
                        {
                            _Columns.Add(ComColumnFactory.GetColumnBool(_XBinding, _XHeader));
                            continue;
                        }
                        /////////////////////
                        string flag_time = "";
                        try { flag_time = item.Attribute("Ftime").Value.ToString(); }
                        catch { }
                        if (!string.IsNullOrEmpty(flag_time))
                        {
                            _Columns.Add(ComColumnFactory.GetColumnTime(_XBinding, _XHeader, flag_time));
                            continue;
                        }
                        /////////////////////
                        string flag_width = "";
                        try { flag_width = item.Attribute("Fwidth").Value.ToString(); }
                        catch { }

                        var _width = DataGridLength.Auto;
                        if (flag_width == "1")
                        {
                            _width = DataGridLength.SizeToHeader;
                        }
                        if (flag_width == "2")
                        {
                            _width = new DataGridLength(200);
                        }
                        if (flag_width == "3")
                        {
                            _width = new DataGridLength(150);
                        }
                        Style _Style = new Style();
                        _Style.TargetType = typeof(TextBlock);
                        //var bd = new Binding("Center");
                        _Style.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, "Left"));
                        _Columns.Add(new DataGridTextColumn
                        {
                            //ClipboardContentBinding = new Binding(_XBinding),
                            Binding = new Binding(_XBinding),
                            Header = _XHeader,
                            FontFamily = new System.Windows.Media.FontFamily("Verdana"),
                            FontSize = 13,
                            FontWeight = System.Windows.FontWeights.Normal,
                            Width = _width,
                            ElementStyle = _Style
                        });
                    }

                    _Columns.Add(new DataGridTextColumn()
                    {
                        Header = _XElement.FirstAttribute.Value,
                        DisplayIndex = 998
                    });
                }
                switch (gridID)
                {
                    case 1:
                        Messenger.Default.Send<ObservableCollection<DataGridColumn>>((_Columns), USysMessages.InitGridColumns);
                        break;
                    case 2:
                        Messenger.Default.Send<ObservableCollection<DataGridColumn>>((_Columns), USysMessages.InitGridColumns2);
                        break;
                    default: break;
                }

            }
            catch { }
        }
    }
}
