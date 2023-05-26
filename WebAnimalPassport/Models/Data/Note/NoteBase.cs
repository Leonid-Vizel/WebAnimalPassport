using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Note
{
    public class NoteBase
    {
        [DisplayName("Текст заметки")]
        [MaxLength(30000, ErrorMessage = "Максимальный размер - 30000 символов!")]
        public string Text { get; set; }
    }
}
