using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Note
{
    public sealed class Note : NoteBase
    {
        [Key]
        public long Id { get; set; }
    }
}
