using ERP.Common;
using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ERP.View
{
    /// <summary>
    /// Description for LoginTab.
    /// </summary>
    public partial class LoginTab : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the LoginTab class.
        /// </summary>
        public LoginTab()
        {
            InitializeComponent();
            this.InitMessages();
        }

        private void InitMessages()
        {
            Messenger.Default.Register<string>(this, USysMessages.AddTab, (msg) =>
            {
                this.AddTab();
            });

            Messenger.Default.Register<string>(this, USysMessages.RemoveTab, (msg) =>
            {
                this.RemoveTab();
            });
        }

        private void RemoveTab()
        {
            this.MainUserTab.Items.Remove(this.MainUserTab.SelectedItem);
        }

        private void AddTab()
        {
            if (this.MainUserTab.Items.Count >= 20)
            {
                MessageErp.ErrorMessage(ErpUIText.Get("ERP_TabToMany"));
                return;
            }

            if (ComWinsInfo.F_CheckRight == true)
            {
                if (!URight.Check(ComWinsInfo.FunCode + ComWinsInfo.Extend))
                {
                    return;
                }
            }

            //判断是否已经加载
            if (this.MainUserTab.Items.Count > 0)
            {
                foreach (TabItem item in this.MainUserTab.Items)
                {
                    TabItem uItem = item as TabItem;
                    if (null == uItem)
                    {
                        continue;
                    }
                    if (uItem.Name == ComWinsInfo.FunCode + "_TabItem")
                    {
                        uItem.IsSelected = true;
                        try
                        {
                            var Obj = uItem.Content as ScrollViewer;
                            if (null != Obj)
                                return;
                            else
                                return;
                        }
                        catch { return; }
                    }
                }
            }

            Control myControl = ComWinFactory.GetInstance(ComWinsInfo.FunCode);

            ChildWindow ccw = myControl as ChildWindow;
            if (ccw != null)
            {
                ccw.Show();
                return;
            }

            Control cw = myControl as UserControl;
            TabItem newTab = null;

            if (cw != null)
            {
                var sitem = USysTabs.Items.Where(item => item.Name == cw.Name + "_TabItem").FirstOrDefault() as TabItem;
                if (sitem != null)
                {
                    this.MainUserTab.Items.Add(sitem);
                    sitem.IsSelected = true;
                    return;
                }
                newTab = new TabItem() { Name = cw.Name + "_TabItem" };
                newTab.Style = App.Current.Resources["MyTabItemStyle"] as Style;
                newTab.Padding = new Thickness(5, 3, 5, 0);
                if (ComWinsInfo.FunCode.Substring(ComWinsInfo.FunCode.Length - 4).ToUpper() != "LIST")
                {
                    ScrollViewer sv = new ScrollViewer();
                    sv.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    sv.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    sv.Padding = new Thickness(0);
                    sv.Content = cw;
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromArgb(255, 240, 248, 255);
                    sv.Background = mySolidColorBrush;
                    newTab.Header = ComWinsInfo.FunName;
                    newTab.Content = sv;
                }
                else
                {
                    newTab.Header = ComWinsInfo.FunName;
                    newTab.Content = cw;
                }
                #region 创建模板
                Grid g = new Grid();
                ColumnDefinition cd = new ColumnDefinition();
                ColumnDefinition cd1 = new ColumnDefinition();
                g.ColumnDefinitions.Add(cd);
                g.ColumnDefinitions.Add(cd1);
                //
                TextBlock tb = new TextBlock();
                tb.Text = ComWinsInfo.FunName;
                tb.FontSize = Convert.ToDouble(ErpUIText.ErpFontSize);
                tb.Foreground = new SolidColorBrush(ComColorConstants.DimGray);
                tb.Padding = new Thickness(0);
                tb.Margin = new Thickness(-2, 0, 0, -2);
                tb.HorizontalAlignment = HorizontalAlignment.Left;
                tb.VerticalAlignment = VerticalAlignment.Center;
                g.Children.Add(tb);
                //
                ButtonErp t = new ButtonErp();
                t.MinWidth = 0;
                t.Padding = new Thickness(0);
                t.Margin = new Thickness(1, -3, -7, -2);
                t.Width = 12; t.Height = 12;
                t.HorizontalAlignment = HorizontalAlignment.Left;
                t.VerticalAlignment = VerticalAlignment.Center;
                t.FontFamily = new FontFamily("Verdana");
                t.FontWeight = System.Windows.FontWeights.Normal;
                t.FontSize = 10;
                t.Content = "X";
                t.SetValue(Grid.RowProperty, 0);
                t.SetValue(Grid.ColumnProperty, 1);
                t.Click += (ss1, ee1) =>
                {
                    this.MainUserTab.Items.Remove(newTab);
                };
                t.HorizontalAlignment = HorizontalAlignment.Center;
                t.VerticalAlignment = VerticalAlignment.Center;
                g.Children.Add(t);
                #endregion
                newTab.Header = g;
                this.MainUserTab.Items.Add(newTab);
                USysTabs.Items.Add(newTab);
                newTab.IsSelected = true;
            }
            else
            {
                MessageErp.ErrorMessage(ErpUIText.ErrMsg);
                return;
            }
        }
    }
}