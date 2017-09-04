using System.Windows.Input;

namespace ERP.ViewModel
{
    public class VMChildWindow : VMErp
    {
        public VMChildWindow()
        {
            this.IsChildWindow = true;
        }

        #region Methods

        /////////////////////////////////////////////////////////////////////////

        protected override void ViewKeyDown(KeyEventArgs parameter)
        {
            switch (parameter.Key)
            {
                case Key.Enter:
                    this.ExecuteCmdOK();
                    parameter.Handled = true;
                    break;
                case Key.Escape:
                    this.ExecuteCmdCancel();
                    parameter.Handled = true;
                    break;
            }

        }

        #endregion

    }
}
