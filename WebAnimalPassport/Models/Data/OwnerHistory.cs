using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data
{
    public sealed class OwnerHistory
    {
        [Key]
        public long Id { get; set; }
        public CustomUser User { get; set; }
        public Animal.Animal Animal { get; set; }
        [DisplayName("Дата передачи питомца")]
        [Required(ErrorMessage = "Укажите дату передачи")]
        public DateTime TransmitDate { get; set; }
        [DisplayName("Причина")]
        [Required(ErrorMessage = "Укажите причину передачи!")]
        [MaxLength(10000, ErrorMessage = "Максимальная длина - 10000 символов!")]
        public string Reason { get; set; }
    }
}
