using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.View.Animal
{
    public sealed class AnimalDeathModel
    {
        public long AnimalId { get; set; }
        [ValidateNever]
        [DisplayName("Кличка")]
        public string AnimalName { get; set; }
        [DisplayName("Дата смерти")]
        [Required(ErrorMessage = "Укажите дату смерти!")]
        [ValidateNever]
        public DateTime Date { get; set; }
    }
}
