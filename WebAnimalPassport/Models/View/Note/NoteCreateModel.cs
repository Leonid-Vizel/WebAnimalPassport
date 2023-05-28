using WebAnimalPassport.Models.Data.Note;

namespace WebAnimalPassport.Models.View.Note
{
    public class NoteCreateModel : NoteBase
    {
        public long AnimalId { get; set; }

        public NoteCreateModel() : base() { }

        public NoteCreateModel(NoteBase model) : base(model) { }
    }
}
