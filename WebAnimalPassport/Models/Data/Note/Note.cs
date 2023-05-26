using System.ComponentModel.DataAnnotations;
using WebAnimalPassport.Models.Data.Animal;

namespace WebAnimalPassport.Models.Data.Note
{
    public sealed class Note : NoteBase
    {
        [Key]
        public long Id { get; set; }
        public Animal.Animal Animal { get; set; }
    }
}
