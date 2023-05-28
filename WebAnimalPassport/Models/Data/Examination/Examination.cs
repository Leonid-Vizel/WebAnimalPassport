using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Examination
{
    public sealed class Examination : ExaminationBase
    {
        [Key]
        public long Id { get; set; }
        public Animal.Animal Animal { get; set; }
        public CustomUser? Doctor { get; set; }
        public string? PhotoPath { get; set; }

        public Examination() : base() { }
        public Examination(ExaminationBase model) : base(model) { }
    }
}
