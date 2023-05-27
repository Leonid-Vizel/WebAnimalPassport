using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace WebAnimalPassport.Models.View.Animal
{
    public sealed class AnimalFoundModel
    {
        public long AnimalId { get; set; }
        [DisplayName("Кличка питомца")]
        [ValidateNever]
        public string AnimalName { get; set; }
    }
}
