using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Treatment
{
    public abstract class TreatmentBase
    {
        [DisplayName("Дата и время")]
        [Required(ErrorMessage = "Укажите дату и время!")]
        public DateTime DateTime { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название обработки!")]
        public string TreatmentType { get; set;}
        [DisplayName("Препарат (Если применимо)")]
        [MaxLength(10000, ErrorMessage = "Максимальный размер - 10000")]
        public string? Drug { get; set; }
        [DisplayName("Доза (Если применимо)")]
        public double? Doze { get; set; }
    }
}
