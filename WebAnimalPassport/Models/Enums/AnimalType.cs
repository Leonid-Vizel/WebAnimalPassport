using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Enums
{
    public enum AnimalType
    {
        [Display(Name = "Кот/Кошка")]
        Cat,
        [Display(Name = "Собака")]
        Dog
    }
}
