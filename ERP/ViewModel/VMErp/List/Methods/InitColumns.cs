
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;
using ERP.Common;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
namespace ERP.ViewModel
{
    public partial class VMList
    {
        private ObservableCollection<DataGridColumn> columns = null;
        private ObservableCollection<DataGridColumn> columns2 = null;
        private void InitColumns()
        {
            try
            {
                if (null == columns)
                {
                    ComInitGridColumns.Init(this.VMName, this.XMLPath + @"/" + this.VMNameAuthority);
                    //var xmlPath = @"/ERP;component/XML/Grid/" + this.Xmlpath + @"/" + this.VMNameAuthority + ".xml";
                    //columns = new ObservableCollection<DataGridColumn>();
                    //    return;
                    //    columns = new ObservableCollection<DataGridColumn>();
                    //    using (XmlReader xreader = XmlReader.Create(xmlPath))
                    //    {
                    //        XElement xelement = XElement.Load(xreader);
                    //        columns.Add(new DataGridTextColumn()
                    //        {
                    //            Header = this.VMName,
                    //            DisplayIndex = 999
                    //        });

                    //        var items = xelement.Descendants("Column");
                    //        foreach (var item in items)
                    //        {
                    //            string xbinding = item.Attribute("Binding").Value.ToString();
                    //            string xheader = item.Attribute("Header").Value.ToString().UIStr();
                    //            /////////////////////////////
                    //            string flag_header = "";
                    //            try { flag_header = item.Attribute("Fheader").Value.ToString(); }
                    //            catch { }
                    //            if (flag_header == "1")
                    //            {
                    //                columns.Add(ComColumnFactory.GetColumnHeader());
                    //                continue;
                    //            }
                    //            //////////////////////////////
                    //            string flag_funtion = "";
                    //            try { flag_funtion = item.Attribute("Ffunction").Value.ToString(); }
                    //            catch { }
                    //            if (!string.IsNullOrEmpty(flag_funtion))
                    //            {
                    //                columns.Add(ComColumnFactory.GetColumnFunction(xbinding, xheader, flag_funtion, this.VMName.Remove(0, 2), this.LocatorPath));
                    //                continue;
                    //            }
                    //            //////////////////////////////
                    //            string flag_bool = "";
                    //            try { flag_bool = item.Attribute("Fbool").Value.ToString(); }
                    //            catch { }
                    //            if (flag_bool == "1")
                    //            {
                    //                columns.Add(ComColumnFactory.GetColumnBool(xbinding, xheader));
                    //                continue;
                    //            }
                    //            /////////////////////
                    //            string flag_time = "";
                    //            try { flag_time = item.Attribute("Ftime").Value.ToString(); }
                    //            catch { }
                    //            if (!string.IsNullOrEmpty(flag_time))
                    //            {
                    //                columns.Add(ComColumnFactory.GetColumnTime(xbinding, xheader, flag_time));
                    //                continue;
                    //            }
                    //            /////////////////////
                    //            string flag_width = "";
                    //            try { flag_width = item.Attribute("Fwidth").Value.ToString(); }
                    //            catch { }

                    //            var _width = DataGridLength.Auto;
                    //            if (flag_width == "1")
                    //            {
                    //                _width = DataGridLength.SizeToHeader;
                    //            }
                    //            if (flag_width == "2")
                    //            {
                    //                _width = new DataGridLength(200);
                    //            }
                    //            if (flag_width == "3")
                    //            {
                    //                _width = new DataGridLength(150);
                    //            }

                    //            columns.Add(new DataGridTextColumn
                    //            {
                    //                Binding = new Binding(xbinding),
                    //                Header = xheader,
                    //                FontFamily = new System.Windows.Media.FontFamily("Verdana"),
                    //                FontSize = 13,
                    //                FontWeight = System.Windows.FontWeights.Normal,
                    //                Width = _width
                    //            });
                    //        }

                    //        columns.Add(new DataGridTextColumn()
                    //        {
                    //            Header = xelement.FirstAttribute.Value,
                    //            DisplayIndex = 998
                    //        });
                    //    }
                    //}
                    //Messenger.Default.Send<ObservableCollection<DataGridColumn>>((columns), USysMessages.InitGridColumns);
                }
            }
            catch { }
        }

        protected void InitColumns2()
        {
            try
            {
                if (null == columns2)
                {
                    ComInitGridColumns.Init(this.VMName, this.XMLPath + @"/" + this.VMNameAuthority + "2", 2);
                    //columns2 = new ObservableCollection<DataGridColumn>();

                    //var xmlPath = @"/ERP;component/XML/Grid/" + this.XMLPath + @"/" + this.VMName.Substring(2) + "2.xml";

                    //using (XmlReader xreader = XmlReader.Create(xmlPath))
                    //{
                    //    XElement xelement = XElement.Load(xreader);
                    //    columns2.Add(new DataGridTextColumn()
                    //    {
                    //        Header = this.VMName,
                    //        DisplayIndex = 999
                    //    });

                    //    var items = xelement.Descendants("Column");
                    //    foreach (var item in items)
                    //    {
                    //        string xbinding = item.Attribute("Binding").Value.ToString();
                    //        string xheader = item.Attribute("Header").Value.ToString().UIStr();
                    //        /////////////////////////////
                    //        string flag_header = "";
                    //        try { flag_header = item.Attribute("Fheader").Value.ToString(); }
                    //        catch { }
                    //        if (flag_header == "1")
                    //        {
                    //            columns2.Add(ComColumnFactory.GetColumnHeader());
                    //            continue;
                    //        }
                    //        //////////////////////////////
                    //        string flag_funtion = "";
                    //        try { flag_funtion = item.Attribute("Ffunction").Value.ToString(); }
                    //        catch { }
                    //        if (!string.IsNullOrEmpty(flag_funtion))
                    //        {
                    //            columns2.Add(ComColumnFactory.GetColumnFunction(xbinding, xheader, flag_funtion, this.VMName.Remove(0, 2), this.LocatorPath));
                    //            continue;
                    //        }
                    //        //////////////////////////////
                    //        string flag_bool = "";
                    //        try { flag_bool = item.Attribute("Fbool").Value.ToString(); }
                    //        catch { }
                    //        if (flag_bool == "1")
                    //        {
                    //            columns2.Add(ComColumnFactory.GetColumnBool(xbinding, xheader));
                    //            continue;
                    //        }
                    //        /////////////////////
                    //        string flag_time = "";
                    //        try { flag_time = item.Attribute("Ftime").Value.ToString(); }
                    //        catch { }
                    //        if (!string.IsNullOrEmpty(flag_time))
                    //        {
                    //            columns2.Add(ComColumnFactory.GetColumnTime(xbinding, xheader, flag_time));
                    //            continue;
                    //        }
                    //        /////////////////////
                    //        string flag_width = "";
                    //        try { flag_width = item.Attribute("Fwidth").Value.ToString(); }
                    //        catch { }

                    //        var _width = DataGridLength.Auto;
                    //        if (flag_width == "1")
                    //        {
                    //            _width = DataGridLength.SizeToHeader;
                    //        }
                    //        if (flag_width == "2")
                    //        {
                    //            _width = new DataGridLength(200);
                    //        }
                    //        if (flag_width == "3")
                    //        {
                    //            _width = new DataGridLength(150);
                    //        }

                    //        columns2.Add(new DataGridTextColumn
                    //        {
                    //            Binding = new Binding(xbinding),
                    //            Header = xheader,
                    //            FontFamily = new System.Windows.Media.FontFamily("Verdana"),
                    //            FontSize = 13,
                    //            FontWeight = System.Windows.FontWeights.Normal,
                    //            Width = _width
                    //        });
                    //    }

                    //    columns2.Add(new DataGridTextColumn()
                    //    {
                    //        Header = xelement.FirstAttribute.Value,
                    //        DisplayIndex = 998
                    //    });
                    //}
                }
                //Messenger.Default.Send<ObservableCollection<DataGridColumn>>((columns2), USysMessages.InitGridColumns2);
            }
            catch { }
        }
    }
}
