
using System.Windows.Input;
namespace ERP.ViewModel
{
    public abstract class VMListCH : VMList
    {
        public VMListCH(string idCode, string modelName = "", string keyCode = "", string keyName = "")
            : base(idCode, modelName, keyCode, keyName)
        {
            this.IsShowExportBool = false;
            this.IsShowImportBool = false;
        }

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


    }
}
