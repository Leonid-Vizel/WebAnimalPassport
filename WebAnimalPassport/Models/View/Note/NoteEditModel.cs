namespace WebAnimalPassport.Models.View.Note
{
    public sealed class NoteEditModel : NoteCreateModel
    {
        public long Id { get; set; }

        public NoteEditModel() : base() { }

        public NoteEditModel(Data.Note.Note model) : base(model)
        {
            Id = model.Id;
        }
    }
}
