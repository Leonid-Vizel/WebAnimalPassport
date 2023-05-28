using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Animal
{
    public sealed class Animal : AnimalBase
    {
        [Key]
        public long Id { get; set; }
        public CustomUser InitialUser { get; set; }
        public CustomUser User { get; set; }
        [DisplayName("Дата смерти")]
        public DateTime? DeathDate { get; set; }
        public string? PhotoPath { get; set; }
        public List<OwnerHistory> Owners { get; set; }
        public List<Note.Note> Notes { get; set; }
        public List<Vaccination.Vaccination> Vaccinations { get; set; }
        public List<Treatment.Treatment> Treatments { get; set; }
        public List<Examination.Examination> Examinations { get; set; }

        public Animal() : base() { }
        public Animal(AnimalBase model) : base(model) { }
    }
}
