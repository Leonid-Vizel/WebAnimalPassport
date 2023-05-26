using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Enums
{
    public enum Sex
    {
        [Display(Name = "Мужской")]
        Male,
        [Display(Name = "Женский")]
        Female,
        [Display(Name = "Гермофродит")]
        Hermo
    }
}
