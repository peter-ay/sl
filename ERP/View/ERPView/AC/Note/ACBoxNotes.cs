
using ERP.Common;
using System.Windows.Data;
using System.Windows.Controls;
namespace ERP.View
{
    public class ACBoxNotes : ACBoxErp
    {
        public ACBoxNotes()
            : base("KeyName", "ACDataTemplateNotes", "DContextMain.MyNotes")
        {
            this.Width = 0;
            this.Height = 0;
            this.MinWidth = 0;
            this.ItemsSource = ComHelpSale_Base_Note.UHV_Sale_Base_Note;
            this.SetFocus("NotesAC");
            this.SetDropDownClosed("NotesAC");
        }
    }
}
