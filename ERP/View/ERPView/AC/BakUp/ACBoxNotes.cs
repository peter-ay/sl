
using ERP.Common;
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
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;

            this.ItemsSource = ComHelpV_Sale_Base_Note.UHV_Sale_Base_Note;

            this.SetFocus("NotesAC");
            this.SetDropDownClosed("NotesAC");
        }
    }
}
