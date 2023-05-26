using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAnimalPassport.Models.Data.Vaccination
{
    public sealed class Vaccination : VaccinationBase
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Animals")]
        public long AnimalId { get; set; }
        public Animal.Animal Animal { get; set; }
        public string? PhotoPath { get; set; }
    }
}
