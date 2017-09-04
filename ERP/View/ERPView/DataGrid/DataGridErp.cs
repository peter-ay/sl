using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERP.View
{
    public class DataGridErp : DataGrid
    {
        public DataGridErp()
            : base()
        {
          
        }

        //protected override void OnGotFocus(System.Windows.RoutedEventArgs e)
        //{

        //    base.OnGotFocus(e);
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Messenger.Default.Send<string>((""), USysMessages.GridEnter);
                e.Handled = true;
            }
            ModifierKeys keys = Keyboard.Modifiers;
            if (e.Key == Key.C && keys == ModifierKeys.Control)
            {
                try
                {
                    var _Source = e.OriginalSource as ERP.View.DataGridErp;
                    var _Column = _Source.CurrentColumn;
                    var _Item = _Source.CurrentItem;
                    var _Rs = _Column.GetCellContent(_Item) as System.Windows.Controls.TextBlock;
                    System.Windows.Clipboard.SetText(_Rs.Text);
                }
                catch { }
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
    }
}
