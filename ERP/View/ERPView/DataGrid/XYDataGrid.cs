using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace ERP.View
{
    public class XYDataGrid : DataGrid
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.Key)
            {
                case Key.Enter:
                    this.CommitEdit();
                    Messenger.Default.Send<string>((""), USysMessages.XYGridEnter);
                    e.Handled = true;
                    break;

                case Key.Escape:
                    Messenger.Default.Send<string>((""), USysMessages.XYGridEsc);
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }
    }
}
