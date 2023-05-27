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
        [MaxLength(100, ErrorMessage = "Максимальный размер - 100")]
        public string? Doze { get; set; }
        [DisplayName("Номер серии")]
        [MaxLength(100, ErrorMessage = "Максимальный размер - 100")]
        public string? BatchNumber { get; set; }
        [DisplayName("ФИО ветеринарного врача")]
        [MaxLength(10000, ErrorMessage = "Максимальная длина - 10000 символов!")]
        public string? DoctorName { get; set; }

        public TreatmentBase() : base() { }
        public TreatmentBase(TreatmentBase model) : this()
        {
            DateTime = model.DateTime;
            BatchNumber = model.BatchNumber;
            TreatmentType = model.TreatmentType;
            Drug = model.Drug;
            Doze = model.Doze;
            DoctorName = model.DoctorName;
        }

        public void Update(TreatmentBase model)
        {
            DateTime = model.DateTime;
            BatchNumber = model.BatchNumber;
            TreatmentType = model.TreatmentType;
            Drug = model.Drug;
            Doze = model.Doze;
            DoctorName = model.DoctorName;
        }
    }
}
