using Org.BouncyCastle.Asn1.BC;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Note
{
    public class NoteBase
    {
        [DisplayName("Текст заметки")]
        [MaxLength(30000, ErrorMessage = "Максимальный размер - 30000 символов!")]
        public string Text { get; set; }

        public NoteBase() : base() { }
        public NoteBase(NoteBase model) : this()
        {
            Text = model.Text;
        }

        public void Update(NoteBase model)
        {
            Text = model.Text;
        }
    }
}
