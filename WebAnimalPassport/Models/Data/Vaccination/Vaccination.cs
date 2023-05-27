using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Vaccination
{
    public sealed class Vaccination : VaccinationBase
    {
        [Key]
        public long Id { get; set; }
        public Animal.Animal Animal { get; set; }
        public CustomUser? Doctor { get; set; }
        public string? PhotoPath { get; set; }

        public Vaccination() : base() { }

        public Vaccination(VaccinationBase model) : base(model) { }
    }
}
