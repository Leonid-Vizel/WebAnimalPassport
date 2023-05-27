using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.View.Animal
{
    public sealed class AnimalTransmitModel
    {
        public long AnimalId { get; set; }
        [DisplayName("Кличка питомца")]
        [ValidateNever]
        public string AnimalName { get; set; }
        [DisplayName("Идентификатор переноса другого пользователя")]
        [Required(ErrorMessage = "Укажите идентификатор другого пользователя!")]
        public string OtherUserId { get; set; }
        [DisplayName("Причина")]
        [Required(ErrorMessage = "Укажите причину!")]
        public string Reason { get; set; }
    }
}
