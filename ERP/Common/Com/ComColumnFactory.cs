using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using ERP.Converters;

namespace ERP.Common
{
    public class ComColumnFactory
    {
        public static DataGridColumn GetColumnHeader()
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.HeaderStyle = (Style)App.Current.Resources["styleDataGridColumnHeaderStyle"];
            dg.CellEditingTemplate = (DataTemplate)App.Current.Resources["styleDataGridCheck"];
            return dg;
        }

        //public static DataGridColumn GetColumnHeader(string hCode)
        //{
        //    DataGridTemplateColumn dg = new DataGridTemplateColumn();
        //    switch (hCode)
        //    {
        //        case "LP":
        //            dg.HeaderStyle = (Style)App.Current.Resources["styleDataGridColumnHeaderStyleLens_Price"];
        //            break;
        //        case "LPP":
        //            dg.HeaderStyle = (Style)App.Current.Resources["styleDataGridColumnHeaderStyleLens_ProCost"];
        //            break;
        //        default:
        //            break;
        //    }
        //    dg.CellEditingTemplate = (DataTemplate)App.Current.Resources["styleDataGridCheck"];
        //    return dg;
        //}

        public static DataGridColumn GetColumnFunction(string xbinding, string xheader, string funtiontype, string viewName, string Locator)
        {
            DataGridColumn dg = null; ;
            switch (funtiontype)
            {
                case "Edit":
                    return GetColumnFunctionEdit(xbinding, xheader, viewName, Locator);
                case "ID":
                    return GetColumnFunctionID(xbinding, xheader, viewName, Locator);
                case "Key":
                    return GetColumnFunctionKey(xbinding, xheader, viewName, Locator);
                case "1":
                    return GetColumnFunction1(xbinding, xheader, viewName, Locator);
                case "2":
                    return GetColumnFunction2(xbinding, xheader, viewName, Locator);
                case "3":
                    return GetColumnFunction3(xbinding, xheader, viewName, Locator);
                case "4":
                    return GetColumnFunction4(xbinding, xheader, viewName, Locator);
                case "5":
                    return GetColumnFunction5(xbinding, xheader, viewName, Locator);
                default:
                    return dg;
            }
        }

        private static DataGridColumn GetColumnFunctionEdit(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}"" 
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClickEdit, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        private static DataGridColumn GetColumnFunctionID(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}""  
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClickID, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        private static DataGridColumn GetColumnFunctionKey(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton Name='hbtn'
                            Content=""{Binding " + xbinding + @"}""   
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClickKey, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding Content, ElementName=hbtn}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnFunction1(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton
                            Content=""{Binding " + xbinding + @"}"" 
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClick1, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnFunction2(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}"" 
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClick2, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnFunction3(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}""  
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClick3, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnFunction4(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}"" 
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClick4, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnFunction5(string xbinding, string xheader, string viewName, string Locator)
        {
            DataGridTemplateColumn dg = new DataGridTemplateColumn();
            dg.Header = xheader;
            dg.CanUserSort = true;
            dg.SortMemberPath = xbinding;
            dg.ClipboardContentBinding = new Binding(xbinding);
            dg.CellTemplate = (System.Windows.DataTemplate)
            XamlReader.Load(@"<DataTemplate 
                            xmlns='http://schemas.microsoft.com/client/2007'  
                            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                            xmlns:Command='clr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras' 
                            xmlns:i='http://schemas.microsoft.com/expression/2010/interactivity'>
                            <HyperlinkButton 
                            Content=""{Binding " + xbinding + @"}"" 
                            VerticalContentAlignment=""Center"" HorizontalContentAlignment=""Left"">
                                    <i:Interaction.Triggers>
                                    		<i:EventTrigger EventName=""Click"">
                                    			<Command:EventToCommand Command=""{Binding " + viewName + @".CmdGridListClick5, Mode=OneWay, Source={StaticResource " + Locator + @"}}"" CommandParameter=""{Binding}""/>
                                    		</i:EventTrigger>
                                    	</i:Interaction.Triggers>
                                    </HyperlinkButton>
                            </DataTemplate>");
            return dg;
        }

        public static DataGridColumn GetColumnBool(string xbinding, string xheader)
        {
            DataGridColumn dg = new DataGridCheckBoxColumn
            {
                Binding = new Binding(xbinding),
                Header = xheader
            };
            return dg;
        }

        public static DataGridColumn GetColumnTime(string xbinding, string xheader, string timeType)
        {
            DataGridTextColumn dg;
            var t = new Binding(xbinding);
            switch (timeType)
            {
                case "1":
                    t.StringFormat = "yyyy-MM-dd";
                    break;
                case "2":
                    t.StringFormat = "u";
                    t.Converter = new DateStringU();
                    break;
                default:
                    break;
            }
            dg = new DataGridTextColumn
            {
                Binding = t,
                Header = xheader,
                FontFamily = new System.Windows.Media.FontFamily("Verdana"),
                FontSize = 13,
                FontWeight = System.Windows.FontWeights.Normal
            };
            return dg;
        }
    }
}
