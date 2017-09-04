
namespace ERP.View
{
    //Notes
    public class TBNotes : TextBoxErp
    {
        public TBNotes()
            : base("DContextMain.Notes", bdIsReadOnly: "TB_Falg_ROEdit")
        {
            this.MaxLength = 100;
            base.SetFocus("Notes");
            base.SetKeyDown("Notes");
        }
    }
    //NotesSale
    public class TBNotesSaleRO : TextBoxErp
    {
        public TBNotesSaleRO()
            : base("DContextMain.NotesSale")
        {
            this.ReSetRO(); 
        }
    }
}
