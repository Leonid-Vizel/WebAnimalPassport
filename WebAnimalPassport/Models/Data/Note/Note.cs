using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Note
{
    public sealed class Note : NoteBase
    {
        [Key]
        public long Id { get; set; }
        public Animal.Animal Animal { get; set; }
        public Note(Note note)
        {
            Animal = note.Animal;
            Text = note.Text;
        }
        public Note() : base() { }
        public Note(NoteBase model) : base(model) { }
    }
}
