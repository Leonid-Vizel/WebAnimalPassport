using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAnimalPassport.Models.Data.Animal
{
    public sealed class Animal : AnimalBase
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public long UserId { get; set; }
        public User.User User { get; set; }
        [DisplayName("Дата смерти")]
        public DateTime? DeathDate { get; set; }
        public string? PhotoPath { get; set; }
    }
}
