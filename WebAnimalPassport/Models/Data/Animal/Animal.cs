using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Animal
{
    public sealed class Animal : AnimalBase
    {
        [Key]
        public long Id { get; set; }
        public CustomUser User { get; set; }
        [DisplayName("Дата смерти")]
        public DateTime? DeathDate { get; set; }
        public string? PhotoPath { get; set; }
    }
}
